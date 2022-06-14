using System.Collections.Generic;

namespace GovernmentPortal.Models
{
    public class Location
    {
        public long? LocationID { get; set; }
        public long? CompanyID { get; set; }
        public Company Company { get; set; }
        public string Name { get; set; }
        public string InvoiceNumberPrefix { get; set; }
        public string NextInvoiceNumber { get; set; }
    }
}
