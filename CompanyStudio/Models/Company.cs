using System.Collections.Generic;

namespace CompanyStudio.Models
{
    public class Company
    {
        public long CompanyID { get; set; }
        public string Name { get; set; }
        public string EmailDomain { get; set; }
        public List<Location> Locations { get; set; }
    }
}
