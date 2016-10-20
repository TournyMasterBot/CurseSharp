using CurseSharp.CurseClient.Bot;
using CurseSharp.CurseClient.Endpoints;
using CurseSharp.UI.Commands;
using CurseSharp.UI.Commands.BanPhrases;
using System;
using System.Linq;

namespace CurseSharp.UI.Service
{
    public sealed class Bot
    {
        private static volatile Bot instance;
        private static object syncRoot = new Object();

        public static BotManager Client = null;
        // Test debug stuff
        public static ContactsEndpoint AvailableChannels = new ContactsEndpoint();
        public static string TestChannel = String.Empty;
        public static string CommandTrigger = String.Empty;

        private Bot()
        {
            
        }

        public static Bot Instance
        {
            get
            {
                if(instance == null)
                {
                    lock(syncRoot)
                    {
                        if(instance == null)
                        {
                            instance = new Bot();
                        }
                    }
                }

                return instance;
            }
        }

        public static void InitializeBot()
        {
            CommandTrigger = "!";
            CustomCommands.AddDemoCommands();
            AssignTestChannel();
            Bot.Client.NewMessageReceived += CommandParser.ProcessNewMessage;
        }

        private static void AssignTestChannel()
        {
            var contactData = AvailableChannels.GetContacts(Client.Account);
            TestChannel =
                contactData
                    // Look for text chats in groups
                    .Groups.Where(x => x.GroupMode == CurseClient.Models.Enums.GroupMode.TextOnly)
                    .Select(x => x.Channels // Once we've found the relevant group, we need to look at the channels
                                            // Specifically, text channels
                        .Where(y => y.GroupMode == CurseClient.Models.Enums.GroupMode.TextOnly)
                        // But more specifically, we want the group ID so that we can send a message to it.
                        .Select(y => y.GroupID).First()
                    ).First();
        }
    }
}
