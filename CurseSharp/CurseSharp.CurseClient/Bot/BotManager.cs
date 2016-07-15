using CurseSharp.CurseClient.BotModels;
using CurseSharp.CurseClient.Endpoints;
using CurseSharp.CurseClient.WebSocketModels;
using CurseSharp.Logging;
using CuseSharp.Sockets;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;
using static CurseSharp.CurseClient.Models.Enums;
using static CuseSharp.Sockets.WebSocketWrapper;
using CurseSharp.CurseClient.Events;
using CurseSharp.CurseClient.Models.BotModels;

namespace CurseSharp.CurseClient.Bot
{
    /// <summary>
    /// Main Bot class, primary interactions should route through this class.
    /// </summary>
    public class BotManager : IDisposable
    {
        /// <summary>
        /// Account used for all interactions with the web api and websocket
        /// </summary>
        public AccountModel Account { get; set; }

        /// <summary>
        /// Event handler for 'Create' messages. This type is a subset of the MessageReceived event.
        /// </summary>
        public event EventHandler<CreateMessageReceivedEventArgs> CreateMessageReceived;

        public BotCommandManager CommandManager = new BotCommandManager();

        /// <summary>
        /// Web Socket that is connected to Curse servers.
        /// </summary>
        private WebSocketWrapper socket { get; set; }


        /// <summary>
        /// Constructor for BotManager, default initialization
        /// </summary>
        public BotManager()
        {
            Account = new AccountModel();
        }

        /// <summary>
        /// Starts the bot, uses the provided Username and Password to connect to the login server, and connects to the Curse websocket.
        /// By default, the build property 'VERBOSE_LOGGING' is set, this causes many informational logs to be triggered. You can disable this by
        /// removing the build property, or changing the minimum log level in 'CurseSharp.Logging' to 'Debug' or greater.
        /// </summary>
        /// <param name="username">Curse Username</param>
        /// <param name="password">Curse Password</param>
        public void Run(string username, string password)
        {
#if VERBOSE_LOGGING
            Log.Verbose("Bot Started");
#endif

            var loginRequest = new LoginEndpoint();
            Account = loginRequest.Login(new AccountModel { Username = username, Password = password });
            socket = new WebSocketWrapper("wss://notifications-v1.curseapp.net/");
            socket.MessageReceived += Socket_MessageReceived;
            socket.Connect();
            var isAlive = Task.Factory.StartNew(async delegate
            {
                await Task.Delay(1000);
                return socket.IsAlive;
            }).Unwrap().Result;
            if(isAlive)
            {
                var sessionResponse = SessionEndpoint.GetSessionData(Account);
                Account.UserData = sessionResponse;
                var notifier = new SendDataModel();
                notifier.PopulateDefaults(Account.UserData.MachineKey, Account.UserData.User.UserID, Account.UserData.SessionID);

                // Begins the heartbeat task, which sends a ping message every (x) seonds.
                var cancellationToken = new CancellationTokenSource();
                Task.Factory.StartNew(() =>
                {
                    Heartbeat();
                }, cancellationToken.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default);

                var joinEnvelope = new MessageEnvelopeModel();
                joinEnvelope.TypeID = NotificationType.JoinRequest;
                joinEnvelope.Body = notifier;
                socket.Send(JsonConvert.SerializeObject(joinEnvelope));

                var channelMessageListenEnvelope = new MessageEnvelopeModel();
                joinEnvelope.TypeID = NotificationType.ConversationMessageNotification;
                joinEnvelope.Body = notifier;
                socket.Send(JsonConvert.SerializeObject(joinEnvelope));

            }
            else
            {
                Log.Error("Socket does not appear to be connected.");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conversationID">Channel or users ID. This can be retrieved from the contacts endpoint, or received when reading a users message.</param>
        /// <param name="message"></param>
        public void SendChatMessage(string conversationID, string message)
        {
            int maxWait = 3;
            int currentWait = 0;
            while(!socket.IsAlive || Account.UserData == null || Account.UserData.SessionID == null)
            {
#if VERBOSE_LOGGING
                Log.Verbose($@"Socket isn't ready. Waiting... Socket: {socket.SocketID}");
#endif
                Thread.Sleep(1000);
                currentWait++;
                if(currentWait > maxWait)
                {
                    Log.Error($"Unable to send message to Socket: {socket.SocketID} - max timeout exceeded. Failed to send message to ConversationID: {conversationID}, Message: {message}");
                    return;
                }
            }
            var messageData = new SendChatMessageModel();
            messageData.ConversationID = conversationID;
            messageData.AttachmentID = "00000000-0000-0000-0000-000000000000";
            messageData.ClientID = Account.UserData.SessionID;
            messageData.Message = message;

            var messageEnvelope = new MessageEnvelopeModel();
            messageEnvelope.TypeID = NotificationType.ConversationMessageRequest;
            messageEnvelope.Body = messageData;
            socket.Send(JsonConvert.SerializeObject(messageEnvelope));
        }

        /// <summary>
        /// Issues a ping to the Curse servers to keep the connection alive
        /// </summary>
        private void Heartbeat()
        {
            var sleepSeconds = 15; // Set default ping sleep for 15 seconds
            var sleepTime = sleepSeconds * 1000; // Multiply sleep seconds by 1000 to get milliseconds.

            // The ping model never changes, so let's only create it once and reuse it.
            var handshakeBody = new HandshakeModel();
            var handshakeEnvelope = new MessageEnvelopeModel();
            handshakeEnvelope.TypeID = NotificationType.Handshake;
            handshakeEnvelope.Body = handshakeBody;

            // Checks if the socket is still connected before trying to send the ping.
            while(socket.IsAlive)
            {
                socket.Send(JsonConvert.SerializeObject(handshakeEnvelope));
                Thread.Sleep(sleepTime);
            }
        }

        /// <summary>
        /// Action to take when a socket message is received
        /// </summary>
        private void Socket_MessageReceived(object sender, SocketMessageReceivedEventArgs e)
        {
            switch(e.MessageType)
            {
                case NotificationType.ConversationMessageNotification:
                {
                    ProcessConversationMessageNotification(e);
                    break;
                }
                default:
                {
                    Log.Error($"NotificationType {Enum.GetName(typeof(NotificationType), e.MessageType)} ({e.MessageType}) has no defined message handling.");
                    break;
                }
            }
        }

        /// <summary>
        /// Determines what type of processing to do for a message
        /// </summary>
        private void ProcessConversationMessageNotification(SocketMessageReceivedEventArgs e)
        {
            // Determine what type of message was received
            switch(e.Body.NotificationType)
            {
                // Normal chat message is received
                case ConversationNotificationType.Normal:
                {
                    // Nobody is listening
                    if(CreateMessageReceived == null)
                    {
                        return;
                    }

                    var args = new CreateMessageReceivedEventArgs()
                    {
                        SocketID = e.SocketID,
                        ServerID = e.Body.ServerID,
                        ChannelID = e.Body.RootConversationID,
                        MessageTimestamp = e.Body.Timestamp,
                        Mentions = e.Body.Mentions,
                        ConversationNotificationType = e.Body.NotificationType,
                        RecipientID = e.Body.RecipientID,
                        Author = new AuthorModel() { UserID = e.Body.SenderID, Username = e.Body.SenderName},
                        MessageBody = e.Body.Content
                    };
                    CreateMessageReceived?.Invoke(this, args);
                    // Make sure there is a message, that the author is populated, and that the author is not the current bot user
                    if(!string.IsNullOrWhiteSpace(args.MessageBody) && args.Author.UserID != 0
                        && args.Author.UserID != Account.UserData.User.UserID
                    )
                    {
                        ProcessMessageReceivedForCommands(args);
                    }
                    break;
                }
                // A user edited a previously received message
                case ConversationNotificationType.Edited:
                {
                    break;
                }
                // A user clicked 'GG' next to a previously received message
                case ConversationNotificationType.Liked:
                {
                    break;
                }
                // A user deleted a previously received message
                case ConversationNotificationType.Deleted:
                {
                    break;
                }
            }
        }

        private void ProcessMessageReceivedForCommands(CreateMessageReceivedEventArgs message)
        {
            try
            {
                int length = message.MessageBody.IndexOf(' ');
                // If no space is in the message, use the whole message to check for command.
                if(length == -1)
                {
                    length = message.MessageBody.Length;
                }
                var checkcommand = message.MessageBody.Substring(0, length);

                if(!CommandManager.Commands.ContainsKey(checkcommand))
                {
                    return;
                }

#if VERBOSE_LOGGING
                Logging.Log.Verbose($"Command Trigger Detected: {checkcommand}");
#endif
                Task.Factory.StartNew(() =>
                {
                    CommandManager.Commands[checkcommand].ExecuteAction(new CommandTriggerModel() {Command = CommandManager.Commands[checkcommand], Message = message });
                }, 
                CommandManager.Commands[checkcommand].CancellationToken.Token, 
                CommandManager.Commands[checkcommand].TaskCreationOptions, 
                CommandManager.Commands[checkcommand].TaskScheduler
                );
            }
            catch(Exception ex)
            {
                Logging.Log.Error(ex.ToString());
            }
        }

        /// <summary>
        /// Cleanup after the bot
        /// </summary>
        public void Dispose()
        {
            socket.Dispose();
#if VERBOSE_LOGGING
            Log.Verbose("Bot Disposed");
#endif
        }
    }
}
