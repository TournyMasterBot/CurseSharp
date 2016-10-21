using CurseSharp.CurseClient.BotModels;
using CurseSharp.CurseClient.Models;
using CurseSharp.CurseClient.Models.CurseClientModels.MessageModels;
using CuseSharp;
using Newtonsoft.Json;
using System;
using System.Diagnostics;

namespace CurseSharp.CurseClient.Endpoints
{
    public static class MessageEndpoint
    {
        private static string MessageUrl = $"https://conversations-v1.curseapp.net/conversations/";

        public static void SendChatMessage(AccountModel account, string conversationID, string message)
        {
            if(account == null)
            {
                throw new ArgumentNullException("account");
            }

            if(string.IsNullOrWhiteSpace(conversationID))
            {
                throw new ArgumentNullException("conversationID");
            }

            if(string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentNullException("message");
            }

            var messageData = new SendChatMessageModel();
            messageData.MachineKey = account.UserData.MachineKey;
            messageData.AttachmentID = "00000000-0000-0000-0000-000000000000";
            messageData.ClientID = account.UserData.SessionID;
            messageData.Body = message;
            messageData.AttachmentID = "";

            WebWrapper.Post($"{MessageUrl}{conversationID}", account, JsonConvert.SerializeObject(messageData));
        }

        public static void BanUser(AccountModel account, string conversationID, int userID, string reason, bool banIP, Enums.BanUserMessageDeleteMode messageDeleteMode)
        {
            if(account == null)
            {
                throw new ArgumentNullException("account");
            }

            if(string.IsNullOrWhiteSpace(conversationID))
            {
                throw new ArgumentNullException("conversationID");
            }

            if(string.IsNullOrWhiteSpace(reason))
            {
                throw new ArgumentNullException("reason");
            }

            var messageData = new BanUserMessageModel();
            messageData.UserID = userID;
            messageData.Reason = reason;
            messageData.BanIP = banIP;
            messageData.MessageDeleteMode = messageDeleteMode;
            WebWrapper.Post($"https://groups-v1.curseapp.net/servers/{conversationID}/bans", account, JsonConvert.SerializeObject(messageData));
        }

        public static void UnbanUser(AccountModel account, string serverID, int userID, string reason, bool banIP, Enums.BanUserMessageDeleteMode messageDeleteMode)
        {
            if(account == null)
            {
                throw new ArgumentNullException("account");
            }

            if(string.IsNullOrWhiteSpace(serverID))
            {
                throw new ArgumentNullException("conversationID");
            }

            if(string.IsNullOrWhiteSpace(reason))
            {
                throw new ArgumentNullException("reason");
            }

            var messageData = new BanUserMessageModel();
            messageData.UserID = userID;
            messageData.Reason = reason;
            messageData.BanIP = banIP;
            messageData.MessageDeleteMode = messageDeleteMode;
            WebWrapper.Delete($"https://groups-v1.curseapp.net/servers/{serverID}/bans/{userID}", account.SessionData.Session.Token);
        }

        public static void DeleteMessage(AccountModel account, string conversationID, string messageID, string timestamp)
        {
            if(string.IsNullOrWhiteSpace(conversationID))
            {
                throw new ArgumentNullException("conversationID");
            }
            if(string.IsNullOrWhiteSpace(messageID))
            {
                throw new ArgumentNullException("messageid");
            }
            if(string.IsNullOrWhiteSpace(timestamp))
            {
                throw new ArgumentNullException("timestamp");
            }

            var deleteData = new DeleteChatMessageModel();
            deleteData.MessageID = messageID;
            deleteData.MessageTimestamp = timestamp;

            WebWrapper.Delete($"{MessageUrl}{conversationID}/{messageID}-{timestamp}", account.SessionData.Session.Token);
        }

        public static void EditMessage(AccountModel account, string conversationID, string messageID, string timestamp, string message, int[] mentions = null)
        {
            if(string.IsNullOrWhiteSpace(conversationID))
            {
                throw new ArgumentNullException("conversationID");
            }
            if(string.IsNullOrWhiteSpace(messageID))
            {
                throw new ArgumentNullException("messageid");
            }
            if(string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentNullException("message");
            }
            if(mentions == null)
            {
                mentions = new int[0];
            }

            var editData = new EditChatMessageModel();
            editData.Body = message;
            editData.Mentions = mentions;

            WebWrapper.Post($"{MessageUrl}{conversationID}/{messageID}-{timestamp}", account, JsonConvert.SerializeObject(editData));
        }
    }
}
