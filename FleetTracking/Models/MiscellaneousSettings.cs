namespace FleetTracking.Models
{
    public class MiscellaneousSettings
    {
        public long? MiscellaneousSettingsID { get; set; }
        public long? CompanyID { get; set; }
        public long? GovernmentID { get; set; }
        public long? EmailImplementationIDCarReleased { get; set; }
        public long? EmailImplementationIDLocomotiveReleased { get; set; }
        public long? EmailImplementationIDLeaseRequestAvailable { get; set; }
        public long? EmailImplementationIDLeaseBidReceived { get; set; }
    }
}
