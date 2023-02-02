using System.Collections.Generic;

namespace FleetTracking.Models
{
    public class Company
    {
        public long? CompanyID { get; set; }
        public string Name { get; set; }

        public List<Location> Locations { get; set; } = new List<Location>();
    }
}
