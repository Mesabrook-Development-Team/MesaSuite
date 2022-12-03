using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetTracking.Models
{
    public class TrainDutyTransaction
    {
        public long? TrainDutyTransactionID { get; set; }
        public long? TrainID { get; set; }
        public Train Train { get; set; }
        public long? UserIDOperator { get; set; }
        public User UserOperator { get; set; }
        public DateTime? TimeOnDuty { get; set; }
        public DateTime? TimeOffDuty { get; set; }
    }
}
