using System;

namespace CurseSharp.CurseClient.ApiModels
{
    /// <summary>
    /// 
    /// </summary>
    public class SessionModel
    {
        public int Status { get; set; }
        public string StatusMessage { get; set; }
        public Session Session { get; set; }
        public long Timestamp { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Session
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string SessionID { get; set; }
        public string Token { get; set; }
        public string EmailAddress { get; set; }
        public bool EffectivePremiumStatus { get; set; }
        public bool ActualPremiumStatus { get; set; }
        public int SubscriptionToken { get; set; }
        public long Expires { get; set; }
        public long RenewAfter { get; set; }
        public bool IsTemporaryAccount { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class SessionIdentifier
    {
        public string MachineKey { get; set; }
        public int Platform { get; set; }
        public string DeviceID { get; set; }
        public string PushKitToken { get; set; }
        
        public SessionIdentifier()
        {
            MachineKey = Guid.NewGuid().ToString();
            Platform = 7;
            DeviceID = null;
            PushKitToken = null;
        }
    }
}
