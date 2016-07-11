namespace CurseSharp.CurseClient.WebSocketModels
{
    /// <summary>
    /// 
    /// </summary>
    public class JoinRequestModel
    {
        public int CipherAlgorithm { get; set; }
        public int CipherStrength { get; set; }
        public string PublicKey { get; set; }
        public string MachineKey { get; set; }
        public int UserID { get; set; }
        public string SessionID { get; set; }
        public int Status { get; set; }
    }
}
