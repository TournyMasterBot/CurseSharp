using System.Collections.Generic;
using static CurseSharp.CurseClient.Models.Enums;

namespace CurseSharp.CurseClient.Models.CurseClientModels.ContactModels
{
    /// <summary>
    /// Todo: Work In Progress
    /// </summary>
    public class ChannelModel
    {
        public string GroupTitle { get; set; }
        public string GroupID { get; set; }
        public string ParentGroupID { get; set; }
        public string RootGroupID { get; set; }
        /// <summary>
        /// Todo: Finish
        /// </summary>
        public object VoiceSessionCode { get; set; }
        /// <summary>
        /// This is the channel's Topic
        /// </summary>
        public string MessageOfTheDay { get; set; }
        public GroupMode GroupMode { get; set; }
        public GroupType GroupType { get; set; }
        public GroupStatus GroupStatus { get; set; }
        public int DisplayOrder { get; set; }
        public bool AllowTemporaryChildGroups { get; set; }
        public bool ForcePushToTalk { get; set; }
        public bool IsDefaultChannel { get; set; }
        public Dictionary<string, int> RolePermissions { get; set; }
        public bool IsPublic { get; set; }
        public MembershipModel Membership { get; set; }
        public string UrlPath { get; set; }
        /// <summary>
        /// Todo: Finish
        /// </summary>
        public object VoiceMembers { get; set; }
        public bool HideNoAccess { get; set; }
    }
}
