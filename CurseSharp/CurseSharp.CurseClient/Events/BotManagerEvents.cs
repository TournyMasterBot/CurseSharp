using CurseSharp.CurseClient.Models.BotModels;
using System;
using System.Threading.Tasks;
using static CurseSharp.CurseClient.Models.Enums;
using static CuseSharp.Sockets.WebSocketWrapper;
using CurseSharp.CurseClient.WebSocketModels;
using Newtonsoft.Json;
using CurseSharp.CurseClient.Sessions;

namespace CurseSharp.CurseClient.Bot
{
    public partial class BotManager
    {
        #region Event Models
        public class ChatMessageReceivedEventArgs : EventArgs
        {
            public string SocketID { get; set; }
            public string ClientID { get; set; }
            public string ServerID { get; set; }
            public string ConversationID { get; set; }
            public string ContactID { get; set; }
            public int ConversationType { get; set; }
            public string RootConversationID { get; set; }
            public long Timestamp { get; set; }
            public int SenderID { get; set; }
            public string SenderName { get; set; }
            public GroupPermissions SenderPermissions { get; set; }
            public int[] SenderRoles { get; set; }
            public int SenderVanityRole { get; set; }
            public int[] Mentions { get; set; }
            public int RecipientID { get; set; }
            public string Content { get; set; }
            public bool IsDeleted { get; set; }
            public long DeletedTimestamp { get; set; }
            public int DeletedUserID { get; set; }
            public string DeletedUsername { get; set; }
            public long EditedTimestamp { get; set; }
            public int EditedUserID { get; set; }
            public string EditedUsername { get; set; }
            public int LikeCount { get; set; }
            public int[] LikeUserIDs { get; set; }
            public string[] LikeUsernames { get; set; }
            public int[] ContentTags { get; set; }
            public AttachmentModel[] Attachments { get; set; }
            public ConversationNotificationType NotificationType { get; set; }
        }

        public class NewMessageReceivedEventArgs : EventArgs
        {
            public string SocketID { get; set; }
            public string ServerID { get; set; }
            public string RootConversationID { get; set; }
            public string ConversationID { get; set; }
            public string ContactID { get; set; }
            public string ClientID { get; set; }
            public ConversationNotificationType ConversationNotificationType { get; set; }
            public AuthorModel Author { get; set; }
            public int RecipientID { get; set; }
            public long MessageTimestamp { get; set; }
            public string MessageBody { get; set; }
            public int[] Mentions { get; set; }
            public GroupPermissions SenderPermissions { get; set; }
            public int[] SenderRoles { get; set; }
        }

        public class ConnectionOpenedEventArgs : EventArgs
        {
            public string SocketID { get; set; }
        }

        public class ConnectionClosedEventArgs : EventArgs
        {
            public string SocketID { get; set; }
        }

        public class EditMessageReceivedEventArgs : EventArgs
        {
            public string SocketID { get; set; }
            public string ServerID { get; set; }
            public string RootConversationID { get; set; }
            public string ConversationID { get; set; }
            public string ContactID { get; set; }
            public DateTime EditedTimestamp { get; set; }
            public int EditedUserID { get; set; }
            public string EditedUsername { get; set; }
            public string MessageBody { get; set; }
        }

        public class DeleteMessageReceivedEventArgs : EventArgs
        {
            public string SocketID { get; set; }
            public string ServerID { get; set; }
            public string RootConversationID { get; set; }
            public string ConversationID { get; set; }
            public string ContactID { get; set; }
            public DateTime DeletedTimestamp { get; set; }
            public int DeletedUserID { get; set; }
            public string DeletedUsername { get; set; }
            public string MessageBody { get; set; }
        }

        public class FriendRequestReceivedEventArgs : EventArgs
        {

        }
        #endregion

        #region Event Definition
        /// <summary>
        /// Event handler for any received chat message, this can fire for new/edited/deleted events
        /// </summary>
        public event EventHandler<SocketMessageReceivedEventArgs> WireMessageReceived;

        /// <summary>
        /// Event handler for any received chat message, this can fire for new/edited/deleted events
        /// </summary>
        public event EventHandler<ChatMessageReceivedEventArgs> RawChatMessageReceived;

        /// <summary>
        /// Event handler for new messages. This type is a subset of the MessageReceived event and will only fire when the user first sends a message.
        /// </summary>
        public event EventHandler<NewMessageReceivedEventArgs> NewMessageReceived;

        /// <summary>
        /// Event handler for edited messages. This type is a subset of the MessageReceived event and will only fire when the user edits a message.
        /// </summary>
        public event EventHandler<EditMessageReceivedEventArgs> EditMessageReceived;

        /// <summary>
        /// Event handler for deleted messages. This type is a subset of the MessageReceived event and will only fire when the user deletes a message.
        /// </summary>
        public event EventHandler<DeleteMessageReceivedEventArgs> DeleteMessageReceived;

        /// <summary>
        /// Event handler for ffriendship requests. This message will only fire when the bot receives a friend invite from a user. 
        /// This message is not resent by the server, so the friend endpoint needs to be used to capture anything that happened while
        /// the bot was offline.
        /// </summary>
        public event EventHandler<FriendRequestReceivedEventArgs> FriendMessageReceived;
        #endregion

        #region Event Handler
        /// <summary>
        /// Action to take when a socket message is received
        /// </summary>
        public void Socket_WireMessageReceived(object sender, SocketMessageReceivedEventArgs e)
        {
            var args = JsonConvert.DeserializeObject<ChatMessageReceived>(e.Body);
            ProcessConversationMessageNotification(args);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        public void Socket_NewMessageReceived(object sender, NewMessageReceivedEventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        public void Socket_EditMessageReceived(object sender, EditMessageReceivedEventArgs e)
        {
            Console.WriteLine($"Edit test");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        public void Socket_DeleteMessageReceived(object sender, DeleteMessageReceivedEventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public void Socket_FriendshipRequestReceived(object sender, FriendRequestReceivedEventArgs e)
        {

        }
        #endregion

        #region Event Processing
        /// <summary>
        /// Determines what type of processing to do for a message
        /// </summary>
        private void ProcessConversationMessageNotification(ChatMessageReceived e)
        {
            // Determine what type of message was received
            switch(e.NotificationType)
            {
                // Normal chat message is received
                case ConversationNotificationType.Normal:
                {
                    if(WireMessageReceived != null)
                    {
                        var args = new ChatMessageReceivedEventArgs()
                        {
                            SocketID = e.SocketID,
                            ClientID = e.ClientID,
                            ServerID = e.ServerID,
                            ConversationID = e.ConversationID,
                            ContactID = e.ContactID,
                            ConversationType = e.ConversationType,
                            RootConversationID = e.RootConversationID,
                            Timestamp = e.Timestamp,
                            SenderID = e.SenderID,
                            SenderName = e.SenderName,
                            SenderPermissions = e.SenderPermissions,
                            SenderRoles = e.SenderRoles.ToArray(),
                            SenderVanityRole = e.SenderVanityRole,
                            Mentions = e.Mentions,
                            RecipientID = e.RecipientID,
                            Content = e.Content,
                            IsDeleted = e.IsDeleted,
                            DeletedTimestamp = e.DeletedTimestamp,
                            DeletedUserID = e.DeletedUserID,
                            DeletedUsername = e.DeletedUsername,
                            EditedTimestamp = e.EditedTimestamp,
                            EditedUserID = e.EditedUserID,
                            EditedUsername = e.EditedUsername,
                            LikeCount = e.LikeCount,
                            LikeUserIDs = e.LikeUserIDs,
                            LikeUsernames = e.LikeUsernames,
                            ContentTags = e.ContentTags,
                            Attachments = e.Attachments,
                            NotificationType = e.NotificationType
                        };
                        RawChatMessageReceived?.Invoke(this, args);
                    }
                    if(NewMessageReceived != null)
                    {
                        var args = new NewMessageReceivedEventArgs()
                        {
                            SocketID = socket.SocketID,
                            ServerID = e.ServerID,
                            RootConversationID = e.RootConversationID,
                            ConversationID = e.ConversationID,
                            ContactID = e.ContactID,
                            ClientID = e.ClientID,
                            MessageTimestamp = e.Timestamp,
                            Mentions = e.Mentions,
                            ConversationNotificationType = e.NotificationType,
                            RecipientID = e.RecipientID,
                            Author = new AuthorModel() { UserID = e.SenderID, Username = e.SenderName },
                            MessageBody = e.Content,
                            SenderPermissions = e.SenderPermissions,
                            SenderRoles = e.SenderRoles.ToArray()
                        };
                        NewMessageReceived?.Invoke(this, args);

                        // Since this is a new message, check if it's a bot command. We ignore edited messages for bot commands.
                        // Make sure there is a message, that the author is populated, and that the author is not the current bot user
                        if(
                            !string.IsNullOrWhiteSpace(args.MessageBody) &&
                            args.Author.UserID != 0 &&
                            args.Author.UserID != Account.UserData.User.UserID
                        )
                        {
                            ProcessMessageReceivedForCommands(args);
                        }

                    }

                    // Todo: Does this go here?
                    if(FriendMessageReceived != null)
                    {
                        FriendMessageReceived?.Invoke(this, null);
                        // Todo: Invoke friend request
                    }

                    break;
                }
                // A user edited a previously received message
                case ConversationNotificationType.Edited:
                {
                    if(EditMessageReceived != null)
                    {
                        EditMessageReceived?.Invoke(this, null);
                        // Todo: Invoke edit message
                    }

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
                    if(DeleteMessageReceived != null)
                    {
                        DeleteMessageReceived?.Invoke(this, null);
                        // Todo: Invoke edit message
                    }

                    break;
                }
            }
        }

        private void ProcessMessageReceivedForCommands(NewMessageReceivedEventArgs message)
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
                    CommandManager.Commands[checkcommand].ExecuteAction(new CommandTriggerModel() { Command = CommandManager.Commands[checkcommand], Message = message });
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


        #endregion

    }


}
