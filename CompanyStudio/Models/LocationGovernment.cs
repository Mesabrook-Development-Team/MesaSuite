using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyStudio.Models
{
    public class LocationGovernment
    {
        public long? LocationGovernmentID { get; set; }
        public long? LocationID { get; set; }
        public Location Location { get; set; }
        public long? GovernmentID { get; set; }
        public Government Government { get; set; }
        public bool PaySalesTax { get; set; }
    }
}
