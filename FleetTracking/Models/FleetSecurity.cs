using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetTracking.Models
{
    public class FleetSecurity
    {
        public long? FleetSecurityID { get; set; }
        public long? EmployeeID { get; set; }
        public long? OfficialID { get; set; }
        public bool AllowSetup { get; set; }
        public bool AllowLeasingManagement { get; set; }
        public bool IsYardmaster { get; set; }
        public bool IsTrainCrew { get; set; }
        public bool AllowLoadUnload { get; set; }
    }
}
