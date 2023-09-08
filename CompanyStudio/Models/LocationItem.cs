using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyStudio.Models
{
    public class LocationItem
    {
        public long? LocationItemID { get; set; }
        public long? LocationID { get; set; }
        public Location Location { get; set; }
        public long? ItemID { get; set; }
        public Item Item { get; set; }
        public short? Quantity { get; set; }
        public decimal? BasePrice { get; set; }

    }
}
