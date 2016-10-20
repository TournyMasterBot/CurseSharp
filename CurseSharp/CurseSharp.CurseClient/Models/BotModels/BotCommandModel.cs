using System;
using System.Threading;
using System.Threading.Tasks;

namespace CurseSharp.CurseClient.Models.BotModels
{
    public class BotCommandModel
    {
        public string CommandTrigger { get; set; }
        public string CommandCall { get; set; }
        public int[] AllowedGroupRoles { get; set; }
        public string HelpText { get; set; }
        public TaskCreationOptions TaskCreationOptions { get; set; }
        public TaskScheduler TaskScheduler { get; set; }
        public CancellationTokenSource CancellationToken { get; set; }
        public Action<CommandTriggerModel> ExecuteAction { get; set; }
    }
}
