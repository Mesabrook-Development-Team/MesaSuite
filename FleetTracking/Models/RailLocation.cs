using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetTracking.Models
{
    public class RailLocation
    {
        public long? RailLocationID { get; set; }
        public long? RailcarID { get; set; }
        public Railcar Railcar { get; set; }
        public long? LocomotiveID { get; set; }
        public Locomotive Locomotive { get; set; }
        public int Position { get; set; }
        public long? TrackID { get; set; }
        public Track Track { get; set; }
        public long? TrainID { get; set; }
        public Train Train { get; set; }
    }
}
