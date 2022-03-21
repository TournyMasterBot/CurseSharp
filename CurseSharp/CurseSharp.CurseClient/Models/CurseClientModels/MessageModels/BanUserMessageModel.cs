namespace CurseSharp.CurseClient.Models.CurseClientModels.MessageModels
{
    public class BanUserMessageModel
    {
        public int UserID { get; set; }
        public string Reason { get; set; }
        public bool BanIP { get; set; }
        public Enums.BanUserMessageDeleteMode MessageDeleteMode { get; set; }
    }
}
