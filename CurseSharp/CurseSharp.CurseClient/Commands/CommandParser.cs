using CurseSharp.CurseClient.Bot;
using CurseSharp.CurseClient.Commands.BanPhrases;
using CurseSharp.CurseClient.Extensions;
using CurseSharp.CurseClient.Models;

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
            string[] splitParts; // Normalized parts for comparison
            string[] editParts; // Original message that will possibly get edited

            // Spaces found in message
            if(e.MessageBody.IndexOf(' ') > -1)
            {
                editParts = e.MessageBody.Split(' ');

                var messageBody = e.MessageBody.NormalizeForComparison();
                splitParts = messageBody.Split(' ');
            }
            // No spaces found in message
            else
            {
                splitParts = new string[1];
                editParts = new string[1];
                editParts[0] = e.MessageBody;
                var messageBody = e.MessageBody.NormalizeForComparison();
                splitParts[0] = messageBody;
            }

            // Time to process the message
            bool skipProcessing = false;
            bool editMessage = false;
            bool deleteMessage = false;
            bool timeoutUser = false;
            bool banUser = false;

            int i = 0;
            foreach(var part in splitParts)
            {
                if(skipProcessing)
                {
                    break;
                }
                var isBanWord = part.CompareToBanWords();
                if(isBanWord == null)
                {
                    i++;
                    continue;
                }
                switch(isBanWord.ActionRequired)
                {
                    // These items require checking all words, because issues might be found later
                    case BanPhraseResponse.DoNothing:
                    {
                        continue;
                    }
                    case BanPhraseResponse.Edit:
                    {
                        editMessage = true;
                        editParts[i] = "***";
                        break;
                    }
                    // These items are destructive, no point in checking the rest of the message
                    case BanPhraseResponse.Delete:
                    {
                        deleteMessage = true;
                        skipProcessing = true;                        
                        break;
                    }
                    case BanPhraseResponse.Timeout:
                    {
                        timeoutUser = true;
                        deleteMessage = true;
                        skipProcessing = true;
                        break;
                    }
                    case BanPhraseResponse.Ban:
                    {
                        banUser = true;
                        deleteMessage = true;
                        skipProcessing = true;
                        break;
                    }
                }
                i++;
            }

            // Message appears to be safe
            if(!editMessage && !deleteMessage && !timeoutUser && !banUser)
            {
                return;
            }

            // Delete message is more destructive than edit message, apply it first
            if(deleteMessage)
            {
                MessageEndpoint.DeleteMessage(Bot.Client.Account, e.ConversationID, e.ServerID, e.MessageTimestamp.ToString());
            }
            else if(editMessage)
            {
                MessageEndpoint.EditMessage(Bot.Client.Account, e.ConversationID, e.ServerID, e.MessageTimestamp.ToString(), string.Join(" ", editParts), e.Mentions);
            }

            // Ban user is more destructive than timeout, apply it fir
            if(banUser)
            {
                Bot.Client.BanUser(e.Author.UserID.ToString());
            }
            else if(timeoutUser)
            {
                Bot.Client.TimeoutUser(e.Author.UserID.ToString());
            }
        }
    }
}
