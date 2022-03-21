using static CurseSharp.CurseClient.Models.Enums;

namespace CurseSharp.CurseClient.BotModels
{
    /// <summary>
    /// 
    /// </summary>
    public class MessageEnvelopeModel
    {
        public NotificationType TypeID { get; set; }
        public dynamic Body { get; set; }
    }
}
