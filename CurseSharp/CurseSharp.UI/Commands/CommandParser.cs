using CurseSharp.CurseClient.Bot;
using CurseSharp.CurseClient.Endpoints;
using CurseSharp.CurseClient.Extensions;
using CurseSharp.CurseClient.Models;
using CurseSharp.CurseClient.Models.BotModels;
using CurseSharp.CurseClient.Sessions;
using CurseSharp.UI.Commands.BanPhrases;
using CurseSharp.UI.Service;
using System;
using System.Threading.Tasks;

namespace CurseSharp.UI.Commands
{
    public static class CommandParser
    {
        /// <summary>
        /// Process New Messages
        /// </summary>
        public static void ProcessNewMessage(object sender, BotManager.NewMessageReceivedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(e.MessageBody))
            {
                return;
            }

            // Apply message filtering and censoring for users who do not have the 'All' permission
            if(e.SenderPermissions != Enums.GroupPermissions.All)
            {
                MessageFilters(e);
            }
            
        }

        private static void MessageFilters(BotManager.NewMessageReceivedEventArgs e)
        {
            // Time to process the message
            bool editMessage = false;
            bool deleteMessage = false;
            bool timeoutUser = false;
            bool banUser = false;

            BanWordHandlerModel result = null;
            var checkAgainst = string.Empty;
            do
            {
                try
                {
                    result = BanPhraseManager.CompareToBanWords(e.MessageBody);
                    if(result == null)
                    {
                        break;
                    }
                    if(checkAgainst == result.EditMessage)
                    {
                        break;
                    }
                    checkAgainst = result.EditMessage;
                }
                catch(Exception ex)
                {
                    result = null;
                    Logging.Log.Error(ex.ToString());
                }
                if(result.ActionRequired.HasFlag(BanPhraseResponse.Ban))
                {
                    banUser = true;
                    deleteMessage = true;
                    break;
                }
                else if(result.ActionRequired.HasFlag(BanPhraseResponse.Timeout))
                {
                    timeoutUser = true;
                    deleteMessage = true;
                    break;
                }
                else if(result.ActionRequired.HasFlag(BanPhraseResponse.Delete))
                {
                    deleteMessage = true;
                    break;
                }
                else if(result.ActionRequired.HasFlag(BanPhraseResponse.Edit))
                {
                    editMessage = true;
                    e.MessageBody = result.EditMessage;
                }
            } while(result != null);

            // Message appears to be safe
            if(!editMessage && !deleteMessage && !timeoutUser && !banUser)
            {
                return;
            }
            // No message was left after editing, just delete the message
            if(string.IsNullOrWhiteSpace(e.MessageBody) && editMessage && !deleteMessage)
            {
                deleteMessage = true;
            }
            // Delete message is more destructive than edit message, apply it first
            if(banUser)
            {
                MessageEndpoint.DeleteMessage(Bot.Client.Account, e.ConversationID, e.ServerID, e.MessageTimestamp.ToString());
                MessageEndpoint.BanUser(Bot.Client.Account, e.RootConversationID, e.Author.UserID, "Banned Phrase Usage", false, Enums.BanUserMessageDeleteMode.None);

                lock(SessionState.BotStats)
                {
                    SessionState.BotStats.UsersBanned++;
                    SessionState.SaveBotStats();
                }
            }
            else if(deleteMessage)
            {
                MessageEndpoint.DeleteMessage(Bot.Client.Account, e.ConversationID, e.ServerID, e.MessageTimestamp.ToString());
                lock(SessionState.BotStats)
                {
                    SessionState.BotStats.MessagesDeleted++;
                    SessionState.SaveBotStats();
                }
            }
            else if(editMessage)
            {
                MessageEndpoint.EditMessage(Bot.Client.Account, e.ConversationID, e.ServerID, e.MessageTimestamp.ToString(), e.MessageBody, e.Mentions);

                lock(SessionState.BotStats)
                {
                    SessionState.BotStats.MessagesEdited++;
                    SessionState.SaveBotStats();
                }
            }
        }
    }
}
