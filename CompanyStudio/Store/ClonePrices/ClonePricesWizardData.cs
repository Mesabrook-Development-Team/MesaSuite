using CompanyStudio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyStudio.Store.ClonePrices
{
    public class ClonePricesWizardData
    {
        public bool DefaultAdd { get; set; } = true;
        public bool DefaultUpdate { get; set; } = true;
        public bool DefaultDelete { get; set; }

        public long? CompanyIDOrigin { get; set; }
        public long? LocationIDOrigin { get; set; }
        public List<(long?, long?)> CompanyIDLocationIDDestinations { get; set; } = new List<(long?, long?)>();

        public Dictionary<long?, List<LocationItem>> LocationItemsByLocationID = new Dictionary<long?, List<LocationItem>>();
        public Dictionary<long?, List<long?>> AddedItemsByLocationID = new Dictionary<long?, List<long?>>();
        public Dictionary<long?, List<long?>> UpdatedItemsByLocationID = new Dictionary<long?, List<long?>>();
        public Dictionary<long?, List<long?>> DeletedItemsByLocationID = new Dictionary<long?, List<long?>>();

        
    }
}
