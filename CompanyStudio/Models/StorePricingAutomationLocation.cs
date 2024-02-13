namespace CompanyStudio.Models
{
    public class StorePricingAutomationLocation
    {
        public long? StorePricingAutomationLocationID { get; set; }
        public long? StorePricingAutomationID { get; set; }
        public StorePricingAutomation StorePriceAutomation { get; set; }
        public long? LocationIDDestination { get; set; }
        public Location LocationDestination { get; set; }
    }
}
