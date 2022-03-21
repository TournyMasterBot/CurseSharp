using CuseSharp;
using Newtonsoft.Json;
using System;
using CurseSharp.CurseClient.BotModels;
using CurseSharp.CurseClient.ApiModels;

namespace CurseSharp.CurseClient.Endpoints
{
    /// <summary>
    /// Todo: Document
    /// </summary>
    public class SessionEndpoint
    {
        /// <summary>
        /// 
        /// </summary>
        private static string SessionUrl = $"https://sessions-v1.curseapp.net";

        /// <summary>
        /// 
        /// </summary>
        private static string Session = @"/sessions";

        /// <summary>
        /// 
        /// </summary>
        public static UserModel GetSessionData(AccountModel account)
        {
            var response = WebWrapper.Post(
                $"{SessionUrl}{Session}",
                account,
                JsonConvert.SerializeObject(new
                {
                    machinekey = account.SessionIdentifier.MachineKey
                }));

            var user = JsonConvert.DeserializeObject<UserModel>(response);
            if(user == null)
            {
                throw new NotImplementedException();
            }

            return user;
        }
    }
}
