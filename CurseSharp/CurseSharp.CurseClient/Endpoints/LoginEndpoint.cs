using CurseSharp.CurseClient.ApiModels;
using CurseSharp.CurseClient.BotModels;
using CurseSharp.Logging;
using CuseSharp;
using Newtonsoft.Json;
using System;

namespace CurseSharp.CurseClient.Endpoints
{
    /// <summary>
    /// Todo: Document
    /// </summary>
    public class LoginEndpoint
    {
        /// <summary>
        /// 
        /// </summary>
        private static string LoginUrl = $"https://logins-v1.curseapp.net";

        /// <summary>
        /// 
        /// </summary>
        private static string NewLogin = "/login";

        /// <summary>
        /// 
        /// </summary>
        private static string RenewLogin = "/login/renew";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public AccountModel Login(AccountModel account)
        {
            var response = WebWrapper.Post($"{LoginUrl}{NewLogin}", JsonConvert.SerializeObject(new { account.Username, account.Password }));
            if(!string.IsNullOrWhiteSpace(response))
            {
                var session = JsonConvert.DeserializeObject<SessionModel>(response);
                // StatusMessage: null (Valid login)
                if(session.Status == 1)
                {
                    account.SessionData = session;
                    return account;
                }
                // StatusMessage: "InvalidPassword"
                else if(session.Status == 4)
                {
                    throw new InvalidOperationException(@"Invalid Password");
                }
                // StatusMessage: "UnknownUsername"
                else if(session.Status == 5)
                {
                    throw new InvalidOperationException(@"Invalid Username");
                }
                else
                {
                    throw new InvalidOperationException(@"Undefined session status");
                }
            }
            else
            {
#if VERBOSE_LOGGING
                Log.Verbose(response);
#endif
                throw new InvalidOperationException(@"Unable to retrieve session data.");
            }
        }
    }
}
