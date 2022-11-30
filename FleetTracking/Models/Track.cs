using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetTracking.Models
{
    public class Track
    {
        public long? TrackID { get; set; }
        public long? RailDistrictID { get; set; }
        public RailDistrict RailDistrict { get; set; }
        public long? CompanyIDOwner { get; set; }
        public Company CompanyOwner { get; set; }
        public long? GovernmentIDOwner { get; set; }
        public Government GovernmentOwner { get; set; }
        public string Name { get; set; }
        public decimal? Length { get; set; }

        public List<RailLocation> RailLocations { get; set; }
    }
}
