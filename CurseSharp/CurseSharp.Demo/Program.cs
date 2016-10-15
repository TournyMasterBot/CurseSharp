using CurseSharp.Logging;
using System;
using System.Runtime.InteropServices;
using CurseSharp.CurseClient.Endpoints;
using System.Linq;
using CurseSharp.CurseClient.Models.BotModels;
using System.Threading.Tasks;
using System.Threading;
using System.Text;
using static CurseSharp.CurseClient.Bot.BotManager;

namespace CurseSharp.Demo
{
    class Program
    {
        #region Application Exit / Fatal Error handling
        [DllImport("Kernel32")]
        public static extern bool SetConsoleCtrlHandler(HandlerRoutine Handler, bool Add);

        //delegate type to be used of the handler routine
        public delegate bool HandlerRoutine(CtrlTypes CtrlType);

        // control messages
        public enum CtrlTypes
        {
            CTRL_C_EVENT = 0,
            CTRL_BREAK_EVENT,
            CTRL_CLOSE_EVENT,
            CTRL_LOGOFF_EVENT = 5,
            CTRL_SHUTDOWN_EVENT
        }

        /// <summary>
        /// This method will be called if the user closes the console window or presses CTRL+C
        /// </summary>
        /// <param name="ctrlType"></param>
        /// <returns>always true</returns>
        private static bool ConsoleCtrlCheck(CtrlTypes ctrlType)
        {
            Cleanup();
            return true;
        }

        private static void Cleanup(bool deleteServer = false)
        {
            Log.Flush();
        }

        private static void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            Log.Fatal(e.ExceptionObject.ToString());
        }
        #endregion

        private static bool appRunning = true;
        private static CurseClient.Bot.BotManager bot = null;

        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionHandler; // Ensures fatal application crashes are logged

            Console.WriteLine("CurseSharp Demo.");
            Console.WriteLine("Your test account should be joined to the channel(s) you wish to join.");
            Console.WriteLine("A later version will allow you to modify which channels you which to be in.");
            Console.WriteLine("To begin, type 'Connect' and enter your username/password when prompted.");
            Console.WriteLine(@"Type 'help' for a list of commands.");

            do
            {
                Console.WriteLine(@"Command?");
                var command = Console.ReadLine();
                if(!string.IsNullOrWhiteSpace(command))
                {
                    var parts = command.Split('|');
                    switch(parts[0].ToLower())
                    {
                        case "connect":
                        {
                            Console.WriteLine(@"Enter your username.");
                            var username = Console.ReadLine();

                            if(string.IsNullOrWhiteSpace(username))
                            {
                                Console.WriteLine(@"Username cannot be empty.");
                                continue;
                            }

                            Console.WriteLine(@"Enter your password.");
                            var password = Console.ReadLine();

                            if(string.IsNullOrWhiteSpace(password))
                            {
                                Console.WriteLine(@"Password cannot be empty.");
                            }

                            bot = new CurseClient.Bot.BotManager();
                            bot.Run(username, password);
                            bot.NewMessageReceived += NewMessageReceivedHandler;

                            // This gets all the channels the bot is connected to.
                            var availableChannels = new ContactsEndpoint();
                            var contactData = availableChannels.GetContacts(bot.Account);

                            // This is just an example of how to send a message to a group. and sends the message "Test".
                            var testChannel =
                                contactData
                                    // Look for text chats in groups
                                    .Groups.Where(x => x.GroupMode == CurseClient.Models.Enums.GroupMode.TextOnly)
                                    .Select(x => x.Channels 
                                        // Once we've found the relevant group, we need to look at text channels
                                        .Where(y => y.GroupMode == CurseClient.Models.Enums.GroupMode.TextOnly)
                                        // But more specifically, we want the group ID so that we can send a message to it.
                                        .Select(y => y.GroupID).First()
                                    ).First();
                            MessageEndpoint.SendChatMessage(bot.Account, testChannel, $"Test <{Guid.NewGuid()}>"); // NewGuid just for debugging.

                            // Example for creating a new bot command
                            var botCommandSendTestMessage = new BotCommandModel()
                            {
                                CommandTrigger = "!",
                                CommandCall = "sendtestmessage",
                                HelpText = @"Sends a test message to the channel.",
                                TaskCreationOptions = TaskCreationOptions.None,
                                TaskScheduler = TaskScheduler.Default,
                                CancellationToken = new CancellationTokenSource(),
                                ExecuteAction = new Action<CommandTriggerModel>((CommandTriggerModel message) =>
                                {
                                    MessageEndpoint.SendChatMessage(bot.Account, testChannel, $"This is a test message from the CommandManager. <{Guid.NewGuid()}>");
                                })
                            };
                            bot.CommandManager.AddCommand(botCommandSendTestMessage);

                            // Example of a long running task that can be cancelled by another command
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
                                        MessageEndpoint.SendChatMessage(bot.Account, testChannel, $"Let's count to infinity!");
                                        Thread.Sleep(1000);
                                        while(!message.Command.CancellationToken.IsCancellationRequested)
                                        {
                                            CancellationToken token = message.Command.CancellationToken.Token;
                                            i++;
                                            MessageEndpoint.SendChatMessage(bot.Account, testChannel, $"{i}");
                                            Thread.Sleep(1000);
                                        }

                                        MessageEndpoint.SendChatMessage(bot.Account, testChannel, $"Aw, ok. I'll stop counting to infinity.");
                                        message.Command.CancellationToken = new CancellationTokenSource();
                                    }
                                    catch(Exception ex)
                                    {
                                        MessageEndpoint.SendChatMessage(bot.Account, testChannel, $"Something broke. I'll stop counting to infinity.");
                                        Logging.Log.Error(ex.ToString());
                                    }
                                })
                            };
                            bot.CommandManager.AddCommand(botCommandCountToInfinity);

                            // Example of a cancellation command. It kills counting to infinity.
                            // Note: This command will break 'CountToInfinity' if run out of order. (Lazy implementation)
                            var botCommandCancelCountToInfinity = new BotCommandModel()
                            {
                                CommandTrigger = "!",
                                CommandCall = "CancelCountToInfinity",
                                HelpText = @"Cancels Count To Infinity.",
                                TaskCreationOptions = TaskCreationOptions.LongRunning,
                                TaskScheduler = TaskScheduler.Default,
                                CancellationToken = new CancellationTokenSource(),
                                ExecuteAction = new Action<CommandTriggerModel>((CommandTriggerModel message) =>
                                {
                                    bot.CommandManager.Commands["!counttoinfinity"].CancellationToken.Cancel();
                                })
                            };
                            bot.CommandManager.AddCommand(botCommandCancelCountToInfinity);

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
                                    if(bot != null && bot.CommandManager.Commands.Count > 0) // Should always be true, because this is a command, but you get the idea.
                                    {
                                        var commandlist = new StringBuilder();
                                        foreach(var commanditem in bot.CommandManager.Commands.OrderBy(x => x.Key))
                                        {
                                            commandlist.AppendLine($"{commanditem.Key}: {commanditem.Value.HelpText}");
                                        }
                                        if(!string.IsNullOrWhiteSpace(commandlist.ToString()))
                                        {
                                            MessageEndpoint.SendChatMessage(bot.Account, testChannel, commandlist.ToString());
                                        }
                                    }
                                })
                            };
                            bot.CommandManager.AddCommand(botShowCommands);

                            break;
                        }
                        case "help":
                        {
                            DisplayHelp();
                            break;
                        }
                        case "cls":
                        {
                            Console.Clear();
                            break;
                        }
                        case "quit":
                        {
                            appRunning = false;
                            break;
                        }
                    }
                }
            } while(appRunning);
        }

        private static void DisplayHelp()
        {
            Console.WriteLine(@"Available Commands (Only works if the bot is not running.):");
            Console.WriteLine(@"Help: This menu.");
            Console.WriteLine(@"Connect: Begins process to make the bot connect to Curse");
            Console.WriteLine(@"cls: Clears the console screen.");
            Console.WriteLine(@"Quit: Exits the application.");

            if(bot != null && bot.CommandManager.Commands.Count > 0)
            {
                Console.WriteLine("");
                Console.WriteLine(@"Custom Commands:");
                foreach(var command in bot.CommandManager.Commands)
                {
                    Console.WriteLine($"{command.Key}: {command.Value.HelpText}");
                }
            }
        }

        /// <summary>
        /// Show an example of the 'Create Message' event being surfaced to main application for handling
        /// This event is a subset of the 'MessageReceived' event (which contains all [new|edited|deleted] messages)
        /// 'Create Message' only occurrs when a new message is created.
        /// </summary>
        private static void NewMessageReceivedHandler(object sender, NewMessageReceivedEventArgs e)
        {
            Console.WriteLine($"{e.Author.Username} said: {e.MessageBody}");
        }
    }
}
