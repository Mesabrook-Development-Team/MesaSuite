using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetTracking.Models
{
    public class RailDistrict
    {
        public long? RailDistrictID { get; set; }
        public long? CompanyIDOperator { get; set; }
        public Company CompanyOperator { get; set; }
        public long? GovernmentIDOperator { get; set; }
        public Government GovernmentOperator { get; set; }
        public string Name { get; set; }

        public List<Track> Tracks { get; set; }
    }
}
