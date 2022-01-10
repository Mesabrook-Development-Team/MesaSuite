using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovernmentPortal.Models
{
    public class Official
    {
        public long OfficialID { get; set; }
        public long GovernmentID { get; set; }
        public long UserID { get; set; }
        public bool ManageEmails { get; set; }
        public bool ManageOfficials { get; set; }
        public bool ManageAccounts { get; set; }
        public string OfficialName { get; set; }
    }
}
