namespace CurseSharp.CurseClient.WebSocketModels
{
    /// <summary>
    /// 
    /// </summary>
    public class AttachmentModel
    {
        public string ID { get; set; }
        public string ConversationID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public long Size { get; set; }
        public string FileType { get; set; }
        public string Url { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public bool IsAnimated { get; set; }
        public bool IsEmbed { get; set; }
        public int AuthorID { get; set; }
        public string AuthorName { get; set; }
        public long Timestamp { get; set; }
        public int RegionID { get; set; }
    }
}
