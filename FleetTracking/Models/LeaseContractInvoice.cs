using System;
using System.Collections.Generic;

namespace FleetTracking.Models
{
    public class LeaseContractInvoice
    {
        public long? LeaseContractInvoiceID { get; set; }
        public long? LeaseContractID { get; set; }
        public LeaseContract LeaseContract { get; set; }
        public long? InvoiceID { get; set; }
        public Invoice Invoice { get; set; }
        public enum Types
        {
            Initial,
            Recurring
        }
        public Types Type { get; set; }
        public DateTime? IssueTime { get; set; }
    }
}
