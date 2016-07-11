using CurseSharp.Logging;
using System;
using System.Runtime.InteropServices;
using CurseSharp.CurseClient.Events;

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

                            var bot = new CurseClient.Bot.BotManager();
                            bot.Run(username, password);
                            bot.CreateMessageReceived += CreateMessageReceivedHandler;

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
        }

        /// <summary>
        /// Show an example of the 'Create Message' event being surfaced to main application for handling
        /// This event is a subset of the 'MessageReceived' event (which contains all [new|edited|deleted] messages)
        /// 'Create Message' only occurrs when a new message is created.
        /// </summary>
        private static void CreateMessageReceivedHandler(object sender, CreateMessageReceivedEventArgs e)
        {
            Console.WriteLine($"{e.Author.Username} said: {e.MessageBody}");
        }
    }
}
