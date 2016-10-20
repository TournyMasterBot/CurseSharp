namespace CurseSharp.CurseClient.Models.BotModels
{
    public class BanWordHandlerModel
    {
        public bool IsBadWord { get; set; }
        public BanPhraseResponse ActionRequired { get; set; }
        public int? ActionDuration { get; set; }
        public string EditMessage { get; set; }
    }
}
