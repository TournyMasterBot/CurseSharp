using CurseSharp.CurseClient.ApiModels;

namespace CurseSharp.CurseClient.BotModels
{
    /// <summary>
    /// 
    /// </summary>
    public class AccountModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public SessionIdentifier SessionIdentifier { get; set; }
        public SessionModel SessionData { get; set; }
        public UserModel UserData { get; set; }

        public AccountModel()
        {
            SessionIdentifier = new SessionIdentifier();
        }
    }
}
