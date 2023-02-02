using System;
using System.Collections.Generic;

namespace FleetTracking.Models
{
    public class LeaseContract
    {
        public long? LeaseContractID { get; set; }
        public long? RailcarID { get; set; }
        public Railcar Railcar { get; set; }
        public long? LocomotiveID { get; set; }
        public Locomotive Locomotive { get; set; }
        public long? GovernmentIDLessee { get; set; }
        public Government GovernmentLessee { get; set; }
        public long? CompanyIDLessee { get; set; }
        public Company CompanyLessee { get; set; }
        public decimal? Amount { get; set; }
        public LeaseBid.RecurringAmountTypes RecurringAmountType { get; set; }
        public decimal? RecurringAmount { get; set; }
        public long? LocationIDRecurringAmountSource { get; set; }
        public Location LocationRecurringAmountSource { get; set; }
        public long? LocationIDRecurringAmountDestination { get; set; }
        public Location LocationRecurringAmountDestination { get; set; }
        public string Terms { get; set; }
        public DateTime? LeaseTimeStart { get; set; }
        public DateTime? LeaseTimeEnd { get; set; }

        public List<LeaseContractInvoice> LeaseContractInvoices { get; set; }
    }
}
