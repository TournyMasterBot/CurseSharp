using CurseSharp.CurseClient.Models.CurseClientModels.ContactModels;
using System;
using System.Collections.Generic;
using static CurseSharp.CurseClient.Models.Enums;

namespace CurseSharp.CurseClient.Models.ApiModels
{
    public class ServerGroupModel
    {
        public GroupRoleNotificationModel Role { get; set; }
        public Dictionary<string, int> EffectivePermissions { get; set; }
        public Dictionary<string, Dictionary<GroupPermissions, GroupPermissionState>>  Permissions { get; set; }
    }
}
