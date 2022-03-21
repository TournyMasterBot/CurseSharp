using static CurseSharp.CurseClient.Models.Enums;

namespace CurseSharp.CurseClient.Models.CurseClientModels.ContactModels
{
    public class GroupRoleModel
    {
        public int RoleID { get; set; }
        public string Name { get; set; }
        public int Rank { get; set; }
        public int VanityColor { get; set; }
        public int VanityBadge { get; set; }
        public bool HasCustomVanityBadge { get; set; }
        public bool IsDefault { get; set; }
        public bool IsOwner { get; set; }
        public GroupRoleTag Tag { get; set; }
        public AccountType Source { get; set; }
        public bool IsHidden { get; set; }
    }
}
