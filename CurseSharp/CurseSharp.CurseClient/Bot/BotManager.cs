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

namespace CurseSharp.CurseClient.Bot
{
    /// <summary>
    /// Main Bot class, primary interactions should route through this class.
    /// </summary>
    public partial class BotManager : IDisposable
    {
        /// <summary>
        /// Account used for all interactions with the web api and websocket
        /// </summary>
        public AccountModel Account { get; set; }


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
            if(string.IsNullOrWhiteSpace(username))
            {
                throw new FormatException("Username must be populated.");
            }

            if(string.IsNullOrWhiteSpace(password))
            {
                throw new FormatException("Password must be populated");
            }

#if VERBOSE_LOGGING
            Log.Verbose("Bot Started");
#endif

            var loginRequest = new LoginEndpoint();
            Account = loginRequest.Login(new AccountModel { Username = username, Password = password });
            socket = new WebSocketWrapper("wss://notifications-v1.curseapp.net/");
            socket.MessageReceived += Socket_WireMessageReceived; // Required so that the websocket can send events to the bot.
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
        /// Issues a ping to the Curse servers to keep the connection alive
        /// </summary>
        private void Heartbeat()
        {
            var sleepSeconds = 60; // Set default ping sleep for 15 seconds
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
