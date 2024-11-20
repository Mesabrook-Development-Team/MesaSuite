using System;
using System.Collections.Generic;

namespace CompanyStudio.Models
{
    public class PurchaseOrder
    {
        public long? PurchaseOrderID { get; set; }
        public long? LocationIDOrigin { get; set; }
        public Location LocationOrigin { get; set; }
        public long? GovernmentIDOrigin { get; set; }
        public Government GovernmentOrigin { get; set; }
        public long? LocationIDDestination { get; set; }
        public Location LocationDestination { get; set; }
        public long? GovernmentIDDestination { get; set; }
        public Government GovernmentDestination { get; set; }

        public long? PurchaseOrderIDClonedFrom { get; set; }

        public string DestinationString
        {
            get
            {
                if (GovernmentIDDestination != null)
                {
                    return GovernmentDestination?.Name;
                }
                else
                {
                    return $"{LocationDestination?.Company?.Name} - ({LocationDestination?.Name})";
                }
            }
        }

        public DateTime? PurchaseOrderDate { get; set; }
        public enum Statuses
        {
            Draft,
            Pending,
            Accepted,
            Rejected,
            InProgress,
            Completed
        }
        public Statuses Status { get; set; }
        public string Description { get; set; }
        public enum InvoiceSchedules
        {
            UponShipment,
            UponDelivery,
            Manual
        }
        public InvoiceSchedules InvoiceSchedule { get; set; }
        public long? AccountIDReceiving { get; set; }

        public List<PurchaseOrderLine> PurchaseOrderLines { get; set; }
        public List<PurchaseOrderApproval> PurchaseOrderApprovals { get; set; }
        public List<Invoice> Invoices { get; set; }
        public List<PurchaseOrder> PurchaseOrderClones { get; set; }
        public List<PurchaseOrderTemplate> PurchaseOrderTemplates { get; set; }

        public static readonly IReadOnlyCollection<Statuses> RECEIVED_STATUSES = new List<Statuses>()
        {
            Statuses.Pending,
            Statuses.Accepted,
            Statuses.InProgress,
            Statuses.Completed
        };
    }
}
