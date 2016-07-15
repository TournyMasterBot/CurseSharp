namespace CurseSharp.CurseClient.Models.BotModels
{
    public class SendChatMessageModel
    {
        public string ConversationID { get; set; }
        public string AttachmentID { get; set; }
        public string ClientID { get; set; }
        public string Message { get; set; }
    }
}
