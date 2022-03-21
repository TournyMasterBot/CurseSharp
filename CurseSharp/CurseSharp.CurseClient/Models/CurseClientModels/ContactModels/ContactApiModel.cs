using System.Collections.Generic;

namespace CurseSharp.CurseClient.Models.CurseClientModels.ContactModels
{
    /// <summary>
    /// Root api object for Contacts, Gets Friends and Groups
    /// </summary>
    public class ContactApiModel
    {
        /// <summary>
        /// TODO: Finish
        /// </summary>
        public List<FriendModel> Friends { get; set; }
        /// <summary>
        /// Groups the account is connected to
        /// </summary>
        public List<GroupModel> Groups { get; set; }
    }
}
