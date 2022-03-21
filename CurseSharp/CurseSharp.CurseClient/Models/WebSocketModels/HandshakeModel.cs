namespace CurseSharp.CurseClient.WebSocketModels
{
    /// <summary>
    /// 
    /// </summary>
    public class HandshakeModel
    {
        public bool Signal { get; set; }

        public HandshakeModel()
        {
            Signal = true;
        }
    }
}
