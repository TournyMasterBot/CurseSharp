using System.Collections.Generic;

namespace CurseSharp.CurseClient.Models.CurseClientModels.ContactModels
{
    /// <summary>
    /// Todo: Work In Progress
    /// </summary>
    public class MembershipModel
    {
        public string Nickname { get; set; }
        public bool CanChangeNickname { get; set; }
        public int BestRole { get; set; }
        public List<int> Roles { get; set; }
        public string DateJoined { get; set; }
        public string DateMessaged { get; set; }
        public string DateRead { get; set; }
        public int UnreadCount { get; set; }
        public bool IsFavorite { get; set; }
        public int NotificationPreference { get; set; }
        /// <summary>
        /// Todo: Finish
        /// </summary>
        public List<object> NotificationFilters { get; set; }
        public string NotificationMuteDate { get; set; }
        public bool IsVoiceMuted { get; set; }
        public bool IsVoiceDeafened { get; set; }
    }
}
