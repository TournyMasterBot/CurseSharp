namespace CurseSharp.CurseClient.Models.BotModels
{
    public class BanPhraseModel
    {
        /* Disabled for V1
        public bool IsHomoglyphParent { get; set; }
        public int BadPhraseID { get; set; }
        /// <summary>
        /// If 'IsHomoglyphParent' is true, this should match 'BadWordID'
        /// </summary>
        public int BadPhraseHomoglyphID { get; set; }
        */
        public string BadPhrase { get; set; }
        public string BadPhraseOriginal { get; set; }
        public BanPhraseResponse Response { get; set; }
        public BanPhraseCheckType CheckType { get; set; }
        public BanPhraseOptions BanPhraseOptions { get; set; }
        public int ResponseDuration { get; set; }
        public bool LogAction { get; set; }
    }
}
