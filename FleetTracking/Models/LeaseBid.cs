namespace FleetTracking.Models
{
    public class LeaseBid
    {
        public long? LeaseBidID { get; set; }
        public long? LeaseRequestID { get; set; }
        public LeaseRequest LeaseRequest { get; set; }
        public long? LocomotiveID { get; set; }
        public Locomotive Locomotive { get; set; }
        public long? RailcarID { get; set; }
        public Railcar Railcar { get; set; }
        public decimal? LeaseAmount { get; set; }
        public enum RecurringAmountTypes
        {
            None,
            Daily,
            Weekly,
            Biweekly,
            Monthly,
            Quarterly
        }
        public RecurringAmountTypes RecurringAmountType { get; set; }
        public decimal? RecurringAmount { get; set; }
        public long? LocatoinIDRecurringAmountDestination { get; set; }
        public Location LocationRecurringAmountDestination { get; set; }
        public string Terms { get; set; }
    }
}
