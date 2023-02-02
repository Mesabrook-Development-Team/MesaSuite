using System;

namespace FleetTracking.Models
{
    public class LiveLoadSession
    {
        public long? LiveLoadSessionID { get; set; }
        public long? LiveLoadID { get; set; }
        public LiveLoad LiveLoad { get; set; }
        public long? UserID { get; set; }
        public User User { get; set; }
        public long? CompanyID { get; set; }
        public Company Company { get; set; }
        public long? GovernmentID { get; set; }
        public Government Government { get; set; }
        public DateTime? LastHeartbeat { get; set; }
    }
}
