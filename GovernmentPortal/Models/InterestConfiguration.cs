using System;

namespace GovernmentPortal.Models
{
    public class InterestConfiguration
    {
        public long? InterestConfigurationID { get; set; }
        public decimal? RateGovernment { get; set; }
        public decimal? WealthCapGovernment { get; set; }
        public decimal? RateLocation { get; set; }
        public decimal? WealthCapLocation { get; set; }
        public DateTime? NextInterestRun { get; set; }
    }
}
