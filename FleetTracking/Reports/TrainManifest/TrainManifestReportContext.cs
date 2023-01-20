using System.Collections.Generic;
using System.Threading.Tasks;
using FleetTracking.Interop;
using MesaSuite.Common.Data;

namespace FleetTracking.Reports.TrainManifest
{
    public class TrainManifestReportContext : IReportContext
    {
        private FleetTrackingApplication _application;
        public FleetTrackingApplication Application { set => _application = value; }

        public long? TrainID { get; set; }

        public TrainManifestReportContext(FleetTrackingApplication application, long? trainID)
        {
            _application = application;
            TrainID = trainID;
        }

        public string WindowTitle => "Train Manifest";

        public string ReportPath => "FleetTracking.Reports.TrainManifest.Manifest.rdlc";

        public async Task<Dictionary<string, object>> GetReportDataSources()
        {
            GetData get = _application.GetAccess<GetData>();
            get.API = DataAccess.APIs.FleetTracking;
            get.Resource = $"RailLocation/GetByTrain/{TrainID}";
            List<RailLocationReportModel> railLocations = await get.GetObject<List<RailLocationReportModel>>();

            return new Dictionary<string, object>()
            {
                { "RailLocationReportModel", railLocations },
                { "FleetTracking.Reports.TrainManifest.Locomotives.rdlc.RailLocationReportModel", railLocations },
                { "FleetTracking.Reports.TrainManifest.Railcars.rdlc.RailLocationReportModel", railLocations }
            };
        }
    }
}
