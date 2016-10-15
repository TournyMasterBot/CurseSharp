namespace CurseSharp.CurseClient.Models.CurseClientModels.MessageModels
{
    public class SendChatMessageModel
    {
        public string MachineKey { get; set; }
        public string AttachmentID { get; set; }
        public string ClientID { get; set; }
        public string Body { get; set; }
        public string AttachmentRegionID { get; set; }
    }
}
