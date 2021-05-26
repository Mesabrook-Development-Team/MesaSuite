using System.Collections.Generic;

namespace UserManagement.Models
{
    public class User
    {
        public long UserID { get; set; }
        public string Username { get; set; }

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
