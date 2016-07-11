namespace CurseSharp.CurseClient.WebSocketModels
{
    /// <summary>
    /// 
    /// </summary>
    public class SendDataModel
    {
        public int CipherAlgorithm { get; set; }
        public int CipherStrength { get; set; }
        public string ClientVersion { get; set; }
        public string PublicKey { get; set; }
        public string MachineKey { get; set; }
        public int UserID { get; set; }
        public string SessionID { get; set; }
        public int Status { get; set; }

        public void PopulateDefaults(string machineKey, int userID, string sessionID)
        {
            CipherAlgorithm = 0;
            CipherStrength = 0;
            ClientVersion = "7.0.62"; // Todo: Always get most recent version, or confirm if a custom version can be used.
            PublicKey = null;
            MachineKey = machineKey;
            UserID = userID;
            SessionID = sessionID;
            Status = 1;
        }
    }
}
