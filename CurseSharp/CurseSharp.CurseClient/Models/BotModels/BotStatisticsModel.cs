namespace CurseSharp.CurseClient.Models.BotModels
{
    public class BotStatisticsModel
    {
        public long MessagesEdited { get; set; }
        public long MessagesDeleted { get; set; }
        public long UsersBanned { get; set; }

        public BotStatisticsModel()
        {
            MessagesEdited = 0;
            MessagesDeleted = 0;
            UsersBanned = 0;
        }
    }
}
