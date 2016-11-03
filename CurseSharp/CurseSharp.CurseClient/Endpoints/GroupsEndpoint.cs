using CurseSharp.CurseClient.BotModels;
using CurseSharp.CurseClient.Models.ApiModels;
using CuseSharp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurseSharp.CurseClient.Endpoints
{
    public static class GroupsEndpoint
    {
        private static string GroupUrl = $"https://groups-v1.curseapp.net/";

        public static ServerGroupModel[] GetServerGroups(AccountModel account, string rootConversationID)
        {
            if(account == null)
            {
                throw new ArgumentNullException("account");
            }

            if(string.IsNullOrWhiteSpace(rootConversationID))
            {
                throw new ArgumentNullException("rootConversationID");
            }

            var result = WebWrapper.Get($"{GroupUrl}servers/{rootConversationID}/roles", account.SessionData.Session.Token);
            if(!string.IsNullOrWhiteSpace(result))
            {
                Debug.Print(result);
                var data = JsonConvert.DeserializeObject<ServerGroupModel[]>(result);
                if(data == null)
                {
                    return null;
                }
                return data;
            }
            return null;
        }
    }
}
