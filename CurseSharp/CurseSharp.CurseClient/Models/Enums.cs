using System;
using System.Runtime.Serialization;

namespace CurseSharp.CurseClient.Models
{
    #region CurseSharp Enums
    public enum BanPhraseResponse
    {
        DoNothing = 0,
        Edit = 1,
        Delete = 2,
        Timeout = 3,
        Ban = 4
    }

    public enum BanPhraseCheckType
    {
        ExactMatch = 0,
        ContainsMatch = 1
    }

    [Flags]
    public enum BanPhraseOptions
    {
        None = 0,
        CheckForCommonSpellingVariants = 1,
        LogActionsTaken = 1 << 1
    }

    public enum BotConnectionStatus
    {
        Disconnected = 0,
        Connected = 1
    }

    #endregion

    #region Curse App Enums

    /// <summary>
    /// Todo: Document. If you use an enum, try to document along the way!
    /// </summary>
    public static class Enums
    {
        /// <summary>
        /// 
        /// </summary>
        public enum AccountType
        {
            Curse = 0,
            Twitch = 1,
            YouTube = 2,
            WorldOfWarcraft = 3
        }

        /// <summary>
        /// 
        /// </summary>
        public enum AvatarType
        {
            User = 1,
            Group = 2,
            SyncedAccount = 3,
            SyncedCommunity = 4,
            GroupEmoticon = 5,
            SyncedEmoticon = 6,
            GroupCover = 7,
            TwitchEmote = 8
        }

        public enum BanUserMessageDeleteMode
        {
            None = 0,
            LastDay = 1,
            LastWeek = 2,
            All = 3
        }

        public enum BattleNetRegion
        {
            US = 1,
            EU = 2,
            KR = 3,
            TW = 4,
            CN = 5
        }

        /// <summary>
        /// 
        /// </summary>
        public enum CallResponseReason
        {
            Accepted = 0,
            Declined = 1,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum CallType
        {
            /// <summary>
            /// Created by clicking the Create button, or using the legacy API
            /// </summary>        
            AdHoc = 1,

            /// <summary>
            /// Created via an auto match game session
            /// </summary>
            AutoMatch = 2,

            /// <summary>
            /// Created by calling a friend directly (Secure)
            /// </summary>
            Friend = 3,

            /// <summary>
            /// Created by initiating a group call (Secure)
            /// </summary>
            Group = 4,

            /// <summary>
            /// Created by adding friends to a call with another friend.
            /// </summary>
            MultiFriend = 5
        }

        /// <summary>
        /// 
        /// </summary>
        public enum ChangeUsernameStatus
        {
            Error = 0,
            Success = 1,
            InvalidPassword = 2,
            InvalidUsername = 3,
            UsernameInUse = 4,
            TooManyAttempts = 5,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum ContentTag
        {
            Image = 1,
            Video = 2,
            Hyperlink = 3,
            File = 4,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum ConversationEntryType
        {
            Message = 0,
            Notification = 1,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum ConversationNotificationType
        {
            Normal = 0,
            Edited = 1,
            Liked = 2,
            Deleted = 3,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum ConversationType
        {
            Friendship = 0,
            Group = 1,
            AdHoc = 2,
            GroupPrivateConversation = 3,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum CreateGroupInvitationErrorType
        {
            NoRequest = 0,
            Success = 1,
            LifeSpanOutOfRange = 2,
            MaxUsesOutOfRange = 3,
            AdminDescriptionOutOfRange = 4,
            NotAServer = 5,
            WrongServer = 6,
            ChannelNotAccessibleByGuests = 7,
            TooManyInvites = 8,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum DevicePlatform
        {
            Windows = 0,
            Mac = 1,
            iOS = 2,
            Android = 3,
            WindowsPhone = 4,
            Blackberry = 5,
            Chrome = 6,
            Unknown = 7,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum EmoticonSource
        {
            Curse = 0,
            Twitch = 1,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum ExternalAccountChangeType
        {
            NeedsRelink = 0,
            Partnered = 1,
            Linked = 2,
            Unlinked = 3
        }

        /// <summary>
        /// 
        /// </summary>
        public enum ExternalCommunityLinkChangeType
        {
            Linked = 0,
            Unlinked = 1,
            LiveStatus = 2,
            InfoChanged = 3
        }

        /// <summary>
        /// 
        /// </summary>
        public enum FriendHintStatus
        {
            Normal = 0,
            Deleted = 1,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum FriendHintType
        {
            Unknown = 0,
            CentralID = 1,
            Username = 2,
            Email = 3,
            Site = 4,
            Game = 5,
            Platform = 6,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum FriendHintVerification
        {
            Unknown = 0,
            ManualEntry = 1,
            ClientSubmitted = 100,
            ClientObserved = 200,
            Verified = 300,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum FriendHintVisibility
        {
            VisibleToFriends = 0,
            VisibleToEveryone = 1,
            Hidden = 2,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum FriendPlatform
        {
            Unknown = 0,
            BattleNet = 1,
            Steam = 2,
            Facebook = 3,
            Skype = 4,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum FriendRequestPrivacy
        {
            Anyone = 0,
            FriendsOfFriends = 1,
            NoOne = 2,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum FriendshipRequestAvailability
        {
            Allowed = 0,
            NotAllowed = 1,
            NoMutualFriends = 2,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum FriendshipStatus
        {
            AwaitingMe = 0,
            AwaitingThem = 1,
            Confirmed = 2,
            DeclinedByMe = 3,
            DeclinedByThem = 4,
            Removing = 5,
            Deleted = 6,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum FriendSuggestionStatus
        {
            Pending = 0,
            Declined = 1,
            Accepted = 2,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum FriendSuggestionType
        {
            MutualFriend = 0,
            GameFriend = 1,
            PlatformFriend = 2,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum GroupBannedUserSortType
        {
            Username = 0,
            Date = 1,
            Reason = 2,
            Requestor = 3,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum GroupChangeType
        {
            Unknown = 0,
            CreateGroup = 1,
            AddUsers = 2,
            RemoveUsers = 3,
            UpdateUsers = 4,
            ChangeInfo = 5,
            VoiceSessionStarted = 6,
            VoiceSessionEnded = 7,
            VoiceSessionUserJoined = 8,
            VoiceSessionUserLeft = 9,
            RemoveGroup = 10,
            GroupReorganized = 11,
            PermissionsChanged = 12,
            RoleNamesChanged = 13,
            UpdateEmoticons = 14,
            UpdateUserPresence = 15,
        }

        /* Removed / Changed?
        /// <summary>
        /// 
        /// </summary>
        public enum GroupEventCategory
        {
            Group = 0,
            User = 1,
            Giveaway = 2,
            Poll = 3,
            CommunityLink = 4,
            Role = 5,
            Channel = 6,
        }
        */

        /// <summary>
        /// 
        /// </summary>
        [Flags]
        public enum GroupEventChannelChangeFlags
        {
            None = 0,
            Title = 1,
            Motd = 1 << 1,
            Permissions = 1 << 2,
            Access = 1 << 3
        }

        /// <summary>
        /// 
        /// </summary>
        public enum GroupEventCommunityChangeFlags
        {
            None = 0,
            SyncEmotes = 1,
            GracePeriod = 2,
        }

        /// <summary>
        /// 
        /// </summary>
        [Flags]
        public enum GroupEventRoleChangeFlags
        {
            None = 0,
            Name = 1,
            Rank = 1 << 1,
            Permissions = 1 << 2,
            Color = 1 << 3,
            Badge = 1 << 4,
        }

        /// <summary>
        /// 
        /// </summary>
        [Flags]
        public enum GroupEventRootChangeFlags
        {
            None = 0,
            Title = 1,
            Motd = 1 << 1,
            VoiceRegion = 1 << 2,
            AfkTimer = 1 << 3,
            Access = 1 << 4,
            ChatThrottle = 1 << 5,
            SearchSettings = 1 << 6,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum GroupEventSearchSortType
        {
            Timestamp = 0,
            InitiatingUsername = 1,
            Category = 2,
            EventType = 3,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum GroupEventCategory
        {
            Group = 0,
            User = 1,
            Giveaway = 2,
            Poll = 3,
            CommunityLink = 4,
            Role = 5,
            Channel = 6,
            GuildLink = 7,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum GroupEventType
        {
            // Group Events
            GroupCreated = 1,
            GroupDeleted = 2,
            GroupSettingsChanged = 3,
            // User Events
            UsersAdded = 2001,
            UsersRemoved = 2002,
            UserRolesAdded = 2003,
            UserRolesRemoved = 2004,
            UserNickname = 2005,
            // Giveaway Events
            GiveawayStarted = 3001,
            GiveawayRoll = 3002,
            GiveawayEnded = 3003,
            // Poll Events
            PollStarted = 4001,
            PollEnded = 4002,
            // Community Link Events
            CommunityLinked = 5001,
            CommunityUnlinked = 5002,
            CommunitySettingsChanged = 5003,
            // Channel Events
            ChannelCreated = 6001,
            ChannelRemoved = 6002,
            ChannelInfoChanged = 6003,
            // Role Events
            RoleAdded = 7001,
            RoleRemoved = 7002,
            RoleInfoChanged = 7003,
            // Guild Link Events
            GuildLinked = 8001,
            GuildUnlinked = 8002,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum GroupGiveawayChangeType
        {
            Unknown = 0,
            Started = 1,
            Ended = 2,
            Removed = 3,
            ParticipantAdded = 4,
            ParticipantRemoved = 5,
            WinnerSelected = 6,
            InvalidWinnerSelected = 7,
            PrizeClaimed = 8,
            ClaimExpired = 9,
            EntriesUpdated = 10,
            InvalidRoll = 11,
            FakeRoll = 12,
            Rolling = 13,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum GroupGiveawayRollStatus
        {
            Pending = 0,
            Invalid = 1,
            Claimed = 2,
            ClaimExpired = 3,
            Fake = 4,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum GroupGiveawayStatus
        {
            Active = 0,
            Rolling = 1,
            WaitingForClaim = 2,
            Claimed = 3,
            Ended = 4,
            Inactive = 5,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum GroupGiveawayWinnerValidStatus
        {
            Unknown = 0,
            Valid = 1,
            MissingRole = 2,
            Offline = 3,
            FakeRoll = 4,
            NoMembership = 5,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum GroupInvitationStatus
        {
            Active = 0,
            Invalid = 1,
            Defunct = 2,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum GroupMemberNicknameStatus
        {
            Invalid = 0,
            ModeratorName = 1,
            Throttled = 2,
            Success = 3,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum GroupMemberSearchSortType
        {
            Default = 0,
            Role = 1,
            Username = 2,
            DateJoined = 3,
            DateLastActive = 4,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum GroupMembershipStatus
        {
            Subscribed = 0,
            Unsubscribed = 1,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum GroupMode
        {
            TextAndVoice = 0,
            TextOnly = 1,
        }

        /// <summary>
        /// 
        /// </summary>
        [DataContract]
        [Flags]
        public enum GroupPermissions : long
        {
            [EnumMember]
            None = 0,
            [EnumMember]
            All = -1,

            /// <summary>
            /// Grants access to the server and/or channel
            /// </summary>
            [EnumMember]
            Access = 1,

            /// <summary>
            /// Allows a user to change the title, roles and other server-level settings.
            /// </summary>
            [EnumMember]
            ManageServer = 2,

            /// <summary>
            /// Allows a user to create, edit and delete channels.
            /// </summary>
            [EnumMember]
            ManageChannels = 4,

            /// <summary>
            /// Allows a user to create a temporary voice channel, within a channel that allows it.
            /// </summary>
            [EnumMember]
            CreateTemporaryGroup = 8,

            /// <summary>
            /// Allows a user to view the admin panel (included viewing analytics and other stats)
            /// </summary>
            [EnumMember]
            AccessAdminPanel = 16,

            /// <summary>
            /// Invites a user to a group/server
            /// </summary>
            [EnumMember]
            InviteUsers = 32,

            /// <summary>
            /// Remove a user from the group/server
            /// </summary>
            [EnumMember]
            RemoveUser = 64,

            /// <summary>
            /// Allows a user to view and delete any active server invitations
            /// </summary>
            [EnumMember]
            ManageInvitations = 128,

            /// <summary>
            /// Allows a user to promote or demote another user, at their rank or lower.
            /// </summary>
            [EnumMember]
            ChangeUserRole = 256,


            /// <summary>
            /// Allows a user to ban another user, at their rank or lower
            /// </summary>
            [EnumMember]
            BanUser = 512,


            // Voice Management        
            [EnumMember]
            VoiceKickUser = 1024,
            [EnumMember]
            VoiceMuteUser = 2048,
            [EnumMember]
            VoiceDeafenUser = 4096,
            [EnumMember]
            VoiceSpeak = 8192,
            [EnumMember]
            VoiceMoveUser = 16384,
            [EnumMember]
            VoiceChangeSettings = 32768,

            // Chat
            [EnumMember]
            ChatSendMessages = 65536,
            [EnumMember]
            ChatEmbedLinks = 131072,
            [EnumMember]
            ChatUploadPhotos = 262144,
            [EnumMember]
            ChatAttachFiles = 524288,
            [EnumMember]
            ChatReadHistory = 1048576,
            [EnumMember]
            ChatMentionUsers = 2097152,
            [EnumMember]
            ChatMentionEveryone = 4194304,
            [EnumMember]
            ChatBypassChatThrottle = 268435456,

            /// <summary>
            /// Allows a user to edit and delete another user's chat messages (at their rank or below)
            /// </summary>
            [EnumMember]
            ChatModerateMessages = 8388608,


            /// <summary>
            /// Allows a user to send a private message to another user, regardless if they are friends
            /// </summary>
            [EnumMember]
            SendPrivateMessage = 16777216,

            /// <summary>
            /// Allows a user to run a poll.
            /// </summary>
            [EnumMember]
            ManagePolls = 33554432L,

            /// <summary>
            /// Allows a user to run a giveaway.
            /// </summary>
            [EnumMember]
            ManageGiveaways = 67108864L,

            /// <summary>
            /// Allows a user to edit another user's chat messages (at their rank or below)
            /// </summary>
            [EnumMember]
            ChatEditOtherMessages = 134217728L,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum GroupPermissionState
        {
            Allowed = 0,
            AllowedInherited = 1,
            NotAllowed = 2,
            NotAllowedInherited = 3,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum GroupPollChangeType
        {
            Started = 0,
            Ended = 1,
            VotesUpdated = 2,
            Deactivated = 3,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum GroupPollDisplayType
        {
            BarGraph = 0,
            PieChart = 1,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum GroupPollDuplicateMode
        {
            Legacy = 0,
            PreventByUserID = 1,
            PreventByIP = 2,
            PreventByCookie = 3,
            AllowDuplicates = 4,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum GroupPollStatus
        {
            Starting = 0,
            Running = 1,
            Ended = 2,
            Inactive = 3,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum GroupMemberRemovedReason
        {
            Left = 0,
            Kicked = 1,
            Banned = 2
        }

        /// <summary>
        /// 
        /// </summary>
        public enum GroupRoleSource
        {
            Curse = 0,
            Twitch = 1,
            YouTube = 2,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum GroupRoleTag
        {
            None = 0,
            SyncedFollower = 1,
            SyncedSubscriber = 2,
            SyncedModerator = 3,
            SyncedOwner = 4,

            GuildMasterRank = 5,
            GuildRank1 = 6,
            GuildRank2 = 7,
            GuildRank3 = 8,
            GuildRank4 = 9,
            GuildRank5 = 10,
            GuildRank6 = 11,
            GuildRank7 = 12,
            GuildRank8 = 13,
            GuildRank9 = 14,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum GroupSearchSortType
        {
            Default = 0,
            Title = 1,
            MemberCount = 2,
            DateStreaming = 3,
            DateFeatured = 4,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum GroupSearchTag
        {
            Casual = 0,
            Hardcore = 1,
            Competitive = 2,
            LFM = 3,
            Twitch = 4,
            YouTube = 5,
            Guild = 6,
            Azubu = 7,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum GroupStatus
        {
            Normal = 0,
            Deleted = 1,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum GroupSubType
        {
            Custom = 0,
            Guild = 1,
            Stream = 2,

            WowNeutral = 3,
            WowAlliance = 4,
            WowHorde = 5,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum GroupSuggestionStatus
        {
            Pending = 0,
            Declined = 1,
            Accepted = 2,
            Invalid = 3,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum GroupSuggestionType
        {
            ExternalAccountSync = 0,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum GroupType
        {
            Normal = 0,
            Large = 1,
            Temporary = 2,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum GuildServerCreationErrorType
        {
            NoError = 0,
            TitleLength = 1,
            OwnerRoleMissing = 2,
            OwnerRoleNameLength = 3,
            GuestRoleMissing = 4,
            GuestRoleNameLength = 5,
            AdditionalRoleNameLength = 6,
            GeneralChatNameLength = 7,
            OfficerChatNameLength = 8,
            PveChatNameLength = 9,
            PvpChatNameLength = 10,
            DefaultVoiceChatNameLength = 11,

            SyncedGuildCount = 12,
            SyncedGuildNameLength = 13,
            SyncedGuildRegion = 14,
            SyncedGuildGameServerLength = 15
        }

        /// <summary>
        /// 
        /// </summary>
        public enum HostEnvironment
        {
            Unknown = 0,
            Debug = 1,
            Staging = 2,
            Beta = 3,
            Release = 4,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum NotificationPreference
        {
            Enabled = 0,
            Disabled = 1,
            Filtered = 2,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum PrivateMessagePrivacy
        {
            Anyone = 0,
            FriendsOnly = 1,
            OnlyContactedUsers = 2,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum PushNotificationPreference
        {
            All = 0,
            Favorites = 1,
            None = 2,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum PushNotificationType
        {
            Unknown = 0,
            InstantMessage = 1,
            GroupMessage = 2,
            FriendRequest = 3,
            FriendConfirmation = 4,
            IncomingCall = 5,
            ConversationMessage = 6,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum SyncedMemberGracePeriodAction
        {
            None = 0,
            RemoveRoles = 1,
            RemoveMember = 2,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum UserConnectionStatus
        {
            Offline = 0,
            Online = 1,
            Away = 2,
            Invisible = 3,
            Idle = 4,
            DoNotDisturb = 5,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum VoiceRegion
        {
            Default = 0,
            NorthAmericaEast = 1,
            NorthAmericaWest = 2,
            EuropeWest = 3,
            AsiaSouth = 4,
            AsiaNorth = 5,
            Oceania = 6,
            SouthAmerica = 7,
            CanadaEast = 8,
            EuropeNordicAndEast = 10,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum NotificationType
        {
            ConversationMarkReadRequest = -342895375,
            ConversationMessageRequest = -2124552136,
            HealthCheckRequest = -1422086075,
            JoinRequest = -2101997347,
            Handshake = -476754606,
            CallNotification = -1669214322,
            CallRespondedNotification = -1145188782,
            ConversationMessageNotification = -635182161,
            ConversationMessageResponse = 705131365,
            ConversationReadNotification = -695526586,
            ExternalAccountChangedNotification = 285733175,
            ExternalCommunityLinkChangedNotification = 738704822,
            FriendshipChangeNotification = 580569888,
            FriendshipRemovedNotification = 1216900677,
            FriendSuggestionNotification = -1001397130,
            GroupChangeNotification = 149631008,
            GroupGiveawayChangedNotification = 1519023790,
            GroupGiveawaySettingsNotification = -1318725298,
            GroupInvitationNotification = -1732183626,
            GroupPollChangedNotification = -1942550100,
            GroupPollSettingsNotification = -34150280,
            GroupPreferenceNotification = 72981382,
            GroupPresenceNotification = 1260535191,
            JoinResponse = -815187584,
            UserChangeNotification = 937250613,
            UserClientSettingsNotification = -1641871686
        }

        /// <summary>
        /// 
        /// </summary>
        public enum ChangePasswordStatus
        {
            InvalidOldPassword = 0,
            InvalidNewPassword = 1,
            PasswordMismatch = 2,
            Success = 3,
            Error = 4,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum ChangeEmailStatus
        {
            Successful = 0,
            EmailInUse = 1,
            InvalidEmail = 2,
            Error = 3,
            InvalidPassword = 4,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum ChangeUsernameAvailability
        {
            NotAvailable = 0,
            Available = 1,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum BugReportType
        {
            CrashReport = 1,
            BugOrDefect = 2,
            FeatureSuggestion = 3,
            LoginIssue = 4,
            StartupIssue = 5,
            OtherIssue = 6,
            AutoReport = 7,
            GameCrash = 8,
            CallQuality = 9,
            PostiveFeedback = 10,
            NegativeFeedback = 11,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum BugReportProcessType
        {
            Executable = 1,
            Library = 2,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum FeedbackType
        {
            Positive = 0,
            Negative = 1,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum VoiceHostCallbackType
        {
            CallStarted = 0,
            CallEnded = 1,
            UsersJoined = 2,
            UsersLeft = 3,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum KickReason
        {
            UserRemoved = 0,
            UserLeft = 1,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum FriendSearchStatus
        {
            Unknown = 0,
            Successful = 1,
            Error = 2,
            Invalid = 3,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum ContactUrlType
        {
            Group = 0,
            Server = 1,
            Friend = 2,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum FileRegion
        {
            NA = 1,
            EU = 3,
            AP = 5,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum LoginStatus
        {
            Success = 1,
            UnauthorizedLogin = 3,
            InvalidPassword = 4,
            UnknownUsername = 5,
            UnknownEmail = 6,
            CorruptLibrary = 102,
            SubscriptionMismatch = 104,
            SubscriptionExpired = 105,
            MissingGrant = 108,
            GeneralError = 1000,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum RegisterStatus
        {
            Success = 0,
            EmailInUse = 1,
            UsernameInUse = 2,
            InvalidEmail = 3,
            InvalidProfile = 4,
            InvalidUsername = 5,
            InvalidPassword = 6,
            GeneralError = 7,
            TooManyAccountsSameIp = 8,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum DeliveryStatus
        {
            UnknownUser = 0,
            Error = 1,
            Forbidden = 2,
            FriendOffline = 3,
            Successful = 4,
            Throttled = 5,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum JoinStatus
        {
            Successful = 1,
            FailedUnhandledException = 2,
            InvalidClientVersion = 3,
            InvalidSessionID = 4,
            Timeout = 5,
            Throttled = 6,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum ServiceContractDirection
        {
            Unknown = 0,
            Request = 1,
            Response = 2,
            Notification = 4,
            Embedded = 65536,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum ChatMessageStatus
        {
            Successful = 1,
            FloodControl = 2,
            MessageTooLarge = 3,
            Error = 4,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum JoinSessionStatus
        {
            Successful = 1,
            FailedNameAlreadyTaken = 2,
            FailedUnhandledException = 3,
            InvalidClientVersion = 4,
            SessionNotFound = 5,
            FailedSessionFull = 6,
            Timeout = 7,
            Throttled = 8,
            Forbidden = 9,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum MultiStreamType
        {
            None = 0,
            PlanA = 1,
            PlanB = 2,
            Unified = 3,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum RemovePendingUserReason
        {
            Declined = 0,
            NoAnswer = 1,
            Kicked = 2,
            LeftGroup = 3,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum UserDisconnectReason
        {
            Kicked = 0,
            Duplicate = 1,
            CallEnded = 2,
            NoAnswer = 3,
            LeftGroup = 4,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum VoiceInstanceType
        {
            AdHoc = 1,
            AutoMatch = 2,
            Friend = 3,
            Group = 4,
            MultiFriend = 5,
        }
    }
    #endregion
}
