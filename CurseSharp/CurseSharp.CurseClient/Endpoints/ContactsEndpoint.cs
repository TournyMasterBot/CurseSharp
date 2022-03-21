using CurseSharp.CurseClient.BotModels;
using CurseSharp.CurseClient.Models.CurseClientModels.ContactModels;
using CuseSharp;
using Newtonsoft.Json;
using System;

namespace CurseSharp.CurseClient.Endpoints
{
    public class ContactsEndpoint
    {
        private static string contactsUrl = $"https://contacts-v1.curseapp.net/contacts";

        public ContactApiModel GetContacts(AccountModel account)
        {
            var response = WebWrapper.Get(contactsUrl, account.SessionData.Session.Token);
            ContactApiModel result = null;
            try
            {
                result = JsonConvert.DeserializeObject<ContactApiModel>(response);
            }
            catch(Exception ex)
            {
                Logging.Log.Error(ex.ToString());
            }
            return result;
        }
    }
}
