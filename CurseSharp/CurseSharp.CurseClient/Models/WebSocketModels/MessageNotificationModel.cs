using CurseSharp.CurseClient.Extensions;
using Newtonsoft.Json;
using System.Collections.Generic;
using static CurseSharp.CurseClient.Models.Enums;

namespace CurseSharp.CurseClient.WebSocketModels
{
    /// <summary>
    /// Message Notification Top Level Details, used to deserialize the message body
    /// </summary>
    public class MessageNotificationModel
    {
        public NotificationType TypeID { get; set; }
        [JsonConverter(typeof(BlobJsonConverter))]
        public string Body { get; set; }
    }

    /// <summary>
    /// Message Body Content, populated details change based on the message received. Use 'MessageNotificationModel' to deserialize the message from the wire.
    /// </summary>
    public class ChatMessageReceived
    {
        public string SocketID { get; set; }
        public string ClientID { get; set; }
        public string ServerID { get; set; }
        public string ConversationID { get; set; }
        public string ContactID { get; set; }
        public int ConversationType { get; set; }
        public string RootConversationID { get; set; }
        public long Timestamp { get; set; }
        public int SenderID { get; set; }
        public string SenderName { get; set; }
        public GroupPermissions SenderPermissions { get; set; }
        public List<int> SenderRoles { get; set; }
        public int SenderVanityRole { get; set; }
        public int[] Mentions { get; set; }
        public int RecipientID { get; set; }
        [JsonProperty("Body")]
        public string Content { get; set; }
        public bool IsDeleted { get; set; }
        public long DeletedTimestamp { get; set; }
        public int DeletedUserID { get; set; }
        public string DeletedUsername { get; set; }
        public long EditedTimestamp { get; set; }
        public int EditedUserID { get; set; }
        public string EditedUsername { get; set; }
        public int LikeCount { get; set; }
        public int[] LikeUserIDs { get; set; }
        public string[] LikeUsernames { get; set; }
        public int[] ContentTags { get; set; }
        public AttachmentModel[] Attachments { get; set; }
        public ConversationNotificationType NotificationType { get; set; }
    }
}
