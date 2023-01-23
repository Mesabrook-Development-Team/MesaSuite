using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FleetTracking.Interop;
using MesaSuite.Common.Data;

namespace FleetTracking.Reports.TrainManifest
{
    public class TrainManifestReportContext : IReportContext
    {
        private FleetTrackingApplication _application;
        public FleetTrackingApplication Application { set => _application = value; }

        public List<long?> TrainIDs { get; set; }

        public TrainManifestReportContext(FleetTrackingApplication application, IEnumerable<long?> trainIDs)
        {
            _application = application;
            TrainIDs = trainIDs.ToList();
        }

        public string WindowTitle => "Train Manifest";

        public string ReportPath => "FleetTracking.Reports.TrainManifest.Manifest.rdlc";

        public async Task<Dictionary<string, object>> GetReportDataSources()
        {
            List<RailLocationReportModel> railLocations = new List<RailLocationReportModel>();
            foreach (long? trainID in TrainIDs)
            {
                GetData get = _application.GetAccess<GetData>();
                get.API = DataAccess.APIs.FleetTracking;
                get.Resource = $"RailLocation/GetByTrain/{trainID}";
                railLocations.AddRange(await get.GetObject<List<RailLocationReportModel>>());
            }

            return new Dictionary<string, object>()
            {
                { "RailLocationReportModel", railLocations },
                { "FleetTracking.Reports.TrainManifest.Locomotives.rdlc.RailLocationReportModel", railLocations },
                { "FleetTracking.Reports.TrainManifest.Railcars.rdlc.RailLocationReportModel", railLocations }
            };
        }
    }
}
