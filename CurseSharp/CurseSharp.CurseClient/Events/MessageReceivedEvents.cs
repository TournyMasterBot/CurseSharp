using CurseSharp.CurseClient.Models.BotModels;
using System;
using static CurseSharp.CurseClient.Models.Enums;

namespace CurseSharp.CurseClient.Events
{
    /// <summary>
    /// Todo: Finish -- WORK IN PROGRESS
    /// This model, along with 'EditMessageReceivedEventArgs' (Does not currently exist)
    /// and 'DeleteMessageReceivedEventArgs' (Does not currently exist)
    /// will allow granular handling of messages at the top level application.
    /// 
    /// The end user will still be able to use the raw socket 'MessageReceivedEventArgs',
    /// but will not need to if they don't care about edited/deleted messages.
    /// </summary>
    public class CreateMessageReceivedEventArgs : EventArgs
    {
        public string SocketID { get; set; }
        public string ServerID { get; set; }
        public string ChannelID { get; set; }
        public ConversationNotificationType ConversationNotificationType { get; set; }
        public AuthorModel Author { get; set; }
        public int RecipientID { get; set; }
        public long MessageTimestamp { get; set; }
        public string MessageBody { get; set; }
        public int[] Mentions { get; set; }
    }
}
