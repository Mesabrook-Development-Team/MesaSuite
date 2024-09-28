namespace CompanyStudio.Models
{
    public class BillOfLadingItem
    {
        public long? BillOfLadingItemID { get; set; }
        public long? BillOfLadingID { get; set; }
        public BillOfLading BillOfLading { get; set; }
        public long? ItemID { get; set; }
        public Item Item { get; set; }
        public string ItemDescription { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? UnitCost { get; set; }
    }
}
