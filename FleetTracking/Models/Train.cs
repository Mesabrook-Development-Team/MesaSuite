using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetTracking.Models
{
    public class Train
    {
        public long? TrainID { get; set; }
        public long? TrainSymbolID { get; set; }
        public TrainSymbol TrainSymbol { get; set; }
        public DateTime? TimeOnDuty { get; set; }
        public DateTime? TimeOffDuty { get; set; }

    }
}
