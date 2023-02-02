using System.Collections.Generic;
using System.Threading.Tasks;
using FleetTracking.Interop;

namespace FleetTracking.Reports
{
    public interface IReportContext
    {
        FleetTrackingApplication Application { set; }
        string WindowTitle { get; }
        string ReportPath { get; }
        Task<Dictionary<string, object>> GetReportDataSources();
    }
}
