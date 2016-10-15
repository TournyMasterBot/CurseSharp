using CurseSharp.CurseClient.Endpoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurseSharp.UI.Service
{
    public sealed class Bot
    {
        private static volatile Bot instance;
        private static object syncRoot = new Object();

        public static CurseClient.Bot.BotManager Client = null;
        // Test debug stuff
        public static ContactsEndpoint AvailableChannels = new ContactsEndpoint();
        public static string TestChannel = String.Empty;

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

        public static void AssignTestChannel()
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
