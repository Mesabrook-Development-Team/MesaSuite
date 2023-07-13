using System;
using System.Collections.Generic;

namespace SystemManagement.Models
{
    public class User
    {
        public long UserID { get; set; }
        public string Username { get; set; }
        public string DiscordID { get; set; }
        public bool InactivityWarningServed { get; set; }
        public bool InactivityDOINotificationServed { get; set; }
        public DateTime? LastActivity { get; set; }
        public string LastActivityReason { get; set; }
        public bool IsStoreRegister { get; set; }

        /// <summary>
        /// Only used during insert - this field is obviously never retrieved
        /// </summary>
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<string> MemberOf { get; set; }
    }
}
