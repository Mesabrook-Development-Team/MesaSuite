using System;

namespace CompanyStudio.Models
{
    public class StoreSaleItem
    {
        public long? StoreSaleItemID { get; set; }
        public long? StoreSaleID { get; set; }
        public StoreSale StoreSale { get; set; }
        public long? RegisterID => StoreSale?.RegisterID;
        public string RegisterName => StoreSale?.Register?.Name;
        public DateTime? SaleTime => StoreSale?.SaleTime;
        public long? LocationItemID { get; set; }
        public LocationItem LocationItem { get; set; }
        public string ItemNameQuantity => string.Format("{0} (x{1})", LocationItem?.Item?.Name, LocationItem?.Quantity);
        public decimal? RingPrice { get; set; }
        public decimal? SoldPrice { get; set; }
        public string DiscountReason { get; set; }
    }
}
