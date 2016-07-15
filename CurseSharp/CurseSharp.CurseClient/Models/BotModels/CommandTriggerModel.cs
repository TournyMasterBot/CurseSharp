using CurseSharp.CurseClient.Events;

namespace CurseSharp.CurseClient.Models.BotModels
{
    public class CommandTriggerModel
    {
        public CreateMessageReceivedEventArgs Message;
        public BotCommandModel Command;
    }
}
