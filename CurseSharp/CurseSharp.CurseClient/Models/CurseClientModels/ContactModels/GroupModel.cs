using System.Collections.Generic;
using static CurseSharp.CurseClient.Models.Enums;

namespace CurseSharp.CurseClient.Models.CurseClientModels.ContactModels
{
    /// <summary>
    /// Todo: Work In Progress
    /// </summary>
    public class GroupModel
    {
        public string GroupTitle { get; set; }
        public string GroupID { get; set; }
        public FileRegion HomeRegionID { get; set; }
        public string HomeRegionKey { get; set; }
        public string ParentGroupID { get; set; }
        public string RootGroupID { get; set; }
        public string VoiceSessionCode { get; set; }
        public string MessageOfTheDay { get; set; }
        public GroupType GroupType { get; set; }
        public GroupSubType GroupSubtype { get; set; }
        public int DisplayOrder { get; set; }
        public bool MetaDataOnly { get; set; }
        public bool AllowTemporaryChildGroups { get; set; }
        public bool ForcePushToTalk { get; set; }
        public GroupStatus Status { get; set; }
        public bool IsDefaultChannel { get; set; }
        public List<GroupRoleModel> Roles { get; set; }
        public Dictionary<string, int> RolePermissions { get; set; }
        public MembershipModel Membership { get; set; }
        public int MemberCount { get; set; }
        /// <summary>
        /// Todo: Finish
        /// </summary>
        public object Emotes { get; set; }
        /// <summary>
        /// Todo: Finish
        /// </summary>
        public object Members { get; set; }
        public List<ChannelModel> Channels { get; set; }
        public GroupMode GroupMode { get; set; }
        public bool IsPublic { get; set; }
        public string UrlPath { get; set; }
        public string UrlHost { get; set; }
        public bool ChatThrottleEnabled { get; set; }
        public int ChatThrottleSeconds { get; set; }
        public bool IsStreaming { get; set; }
        /// <summary>
        /// Todo: Finish
        /// </summary>
        public object LinkedCommunities { get; set; }
        public int AfkTimerMins { get; set; }
        public long AvatarTimestamp { get; set; }
        public bool FlaggedAsInappropriate { get; set; }
        public int MembersOnline { get; set; }
        public bool HideNoAccess { get; set; }
    }
}
