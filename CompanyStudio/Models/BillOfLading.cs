using System;
using System.Collections.Generic;

namespace CompanyStudio.Models
{
    public class BillOfLading
    {
        public long? BillOfLadingID { get; set; }
        public long? PurchaseOrderID { get; set; }
        public PurchaseOrder PurchaseOrder { get; set; }
        public long? CompanyIDShipper { get; set; }
        public Company CompanyShipper { get; set; }
        public long? GovernmentIDShipper { get; set; }
        public Government GovernmentShipper { get; set; }
        public long? CompanyIDConsignee { get; set; }
        public Company CompanyConsignee { get; set; }
        public long? GovernmentIDConsignee { get; set; }
        public Government GovernmentConsignee { get; set; }
        public long? CompanyIDCarrier { get; set; }
        public Company CompanyCarrier { get; set; }
        public long? GovernmentIDCarrier { get; set; }
        public Government GovernmentCarrier { get; set; }
        public long? RailcarID { get; set; }
        public Railcar Railcar { get; set; }
        public DateTime? IssuedDate { get; set; }
        public DateTime? DeliveredDate { get; set; }
        [Flags]
        public enum Types
        {
            FirstMile,
            Interchange,
            LastMile
        }
        public Types Type { get; set; }

        public List<BillOfLadingItem> BillOfLadingItems { get; set; } = new List<BillOfLadingItem>();

        public string From => GovernmentIDShipper == null ? CompanyShipper.Name : GovernmentShipper.Name + " (Government)";
        public string To => GovernmentIDConsignee == null ? CompanyConsignee.Name : GovernmentConsignee.Name + " (Government)";
        public string Via => GovernmentIDCarrier == null ? CompanyCarrier.Name : GovernmentCarrier.Name + " (Government)";
    }
}
