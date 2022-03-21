using System.Collections.Generic;

namespace CurseSharp.CurseClient.ApiModels
{
    /// <summary>
    /// 
    /// </summary>
    public class UserModel
    {
        public string SessionID { get; set; }
        public string MachineKey { get; set; }
        public User User { get; set; }
        public List<int> Platforms { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public int ConnectionStatus { get; set; }
        public string CustomStatusMessage { get; set; }
        public string CustomStatusTimestamp { get; set; }
        public int FriendCount { get; set; }
        public object AvatarUrl { get; set; }
        public int CurrentGameID { get; set; }
        public int CurrentGameState { get; set; }
        public object CurrentGameStatusMessage { get; set; }
        public string CurrentGameTimestamp { get; set; }
        public int GroupMessagePushPreference { get; set; }
        public int FriendMessagePushPreference { get; set; }
        public bool FriendRequestPushEnabled { get; set; }
        public object MentionsPushEnabled { get; set; }
    }
}
