using System.Collections.Generic;

namespace FleetTracking.Reports
{
    public interface IHasParameters
    {
        Dictionary<string, object> GetReportParameters();
    }
}
