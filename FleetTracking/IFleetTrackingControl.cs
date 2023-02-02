using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FleetTracking.Interop;

namespace FleetTracking
{
    public interface IFleetTrackingControl
    {
        FleetTrackingApplication Application { set; }
    }
}
