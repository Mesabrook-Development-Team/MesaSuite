using System.Collections.Generic;

namespace CompanyStudio.Models
{
    public class StorePricingAutomation
    {
        public long? StorePricingAutomationID { get; set; }
        public long? LocationID { get; set; }
        public Location Location { get; set; }
        public bool IsEnabled { get; set; }
        public bool PushAdd { get; set; }
        public bool PushUpdate { get; set; }
        public bool PushDelete { get; set; }

        public List<StorePricingAutomationLocation> StorePricingAutomationLocations { get; set; } = new List<StorePricingAutomationLocation>();
    }
}
