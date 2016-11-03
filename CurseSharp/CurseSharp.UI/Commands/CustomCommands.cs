using CurseSharp.CurseClient.Endpoints;
using CurseSharp.CurseClient.Models.BotModels;
using CurseSharp.Logging;
using CurseSharp.UI.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CurseSharp.UI.Commands
{
    public static class CustomCommands
    {
        public static void AddDemoCommands()
        {
            Commands();
            CountToInfinity();
        }

        private static void Commands()
        {
            // Example echoing available bot commands
            var botShowCommands = new BotCommandModel()
            {
                CommandTrigger = "!",
                CommandCall = "commands",
                HelpText = @"Sends a list of all available commands to the channel",
                TaskCreationOptions = TaskCreationOptions.LongRunning,
                TaskScheduler = TaskScheduler.Default,
                CancellationToken = new CancellationTokenSource(),
                ExecuteAction = new Action<CommandTriggerModel>((CommandTriggerModel message) =>
                {
                    if(Bot.Client != null && Bot.Client.CommandManager.Commands.Count > 0) // Should always be true, because this is a command, but you get the idea.
                    {
                        var commandlist = new StringBuilder();
                        foreach(var commanditem in Bot.Client.CommandManager.Commands.OrderBy(x => x.Key))
                        {
                            commandlist.AppendLine($"{commanditem.Key}: {commanditem.Value.HelpText}");
                        }
                        if(!string.IsNullOrWhiteSpace(commandlist.ToString()))
                        {
                            MessageEndpoint.SendChatMessage(Bot.Client.Account, Bot.Channels.First().Value.First().GroupID, commandlist.ToString());
                        }
                    }
                })
            };
            Bot.Client.CommandManager.AddCommand(botShowCommands);
        }

        private static void CountToInfinity()
        {
            var botCommandCountToInfinity = new BotCommandModel()
            {
                CommandTrigger = "!",
                CommandCall = "CountToInfinity",
                HelpText = @"Makes the bot count to infinity.",
                TaskCreationOptions = TaskCreationOptions.LongRunning,
                TaskScheduler = TaskScheduler.Default,
                CancellationToken = new CancellationTokenSource(),
                ExecuteAction = new Action<CommandTriggerModel>((CommandTriggerModel message) =>
                {
                    int i = 0;
                    try
                    {
                        MessageEndpoint.SendChatMessage(Bot.Client.Account, Bot.Channels.First().Value.First().GroupID, $"Let's count to infinity!");
                        Thread.Sleep(1000);
                        while(!message.Command.CancellationToken.IsCancellationRequested)
                        {
                            CancellationToken token = message.Command.CancellationToken.Token;
                            i++;
                            MessageEndpoint.SendChatMessage(Bot.Client.Account, Bot.Channels.First().Value.First().GroupID, $"{i}");
                            Thread.Sleep(1000);
                        }

                        MessageEndpoint.SendChatMessage(Bot.Client.Account, Bot.Channels.First().Value.First().GroupID, $"Aw, ok. I'll stop counting to infinity.");
                        message.Command.CancellationToken = new CancellationTokenSource();
                    }
                    catch(Exception ex)
                    {
                        MessageEndpoint.SendChatMessage(Bot.Client.Account, Bot.Channels.First().Value.First().GroupID, $"Something broke. I'll stop counting to infinity.");
                        Log.Error(ex.ToString());
                    }
                })
            };
            Bot.Client.CommandManager.AddCommand(botCommandCountToInfinity);
        }
    }
}
