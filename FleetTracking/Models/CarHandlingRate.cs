using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetTracking.Models
{
    internal class CarHandlingRate
    {
        public long? CarHandlingRateID { get; set; }
        public long? CompanyID { get; set; }
        public Company Company { get; set; }
        public long? GovernmentID { get; set; }
        public Government Government { get; set; }
        public decimal? IntraDistrictRate { get; set; }
        public decimal? InterDistrictRate { get; set; }
        public decimal? PlacementRate { get; set; }
        public DateTime? EffectiveTime { get; set; }
    }
}
