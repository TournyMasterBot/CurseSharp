using static CurseSharp.CurseClient.Bot.BotManager;

namespace CurseSharp.CurseClient.Models.BotModels
{
    public class CommandTriggerModel
    {
        public NewMessageReceivedEventArgs Message;
        public BotCommandModel Command;
    }
}
