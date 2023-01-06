using System.Collections.Generic;

namespace FleetTracking.Models
{
    public class LiveLoad
    {
        public long? LiveLoadID { get; set; }
        public long? TrainID { get; set; }
        public Train Train { get; set; }
        public string Code { get; set; }
        public List<LiveLoadSession> LiveLoadSessions { get; set; }
    }
}
