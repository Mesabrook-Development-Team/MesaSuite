using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FleetTracking.Interop;
using MesaSuite.Common.Data;

namespace FleetTracking.Reports.RailActivity
{
    public class RailActivityReportContext : IReportContext, IHasParameters
    {
        private FleetTrackingApplication _application;
        public FleetTrackingApplication Application { set => _application = value; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool ShowTrain { get; set; }
        public bool ShowTrack { get; set; }
        public List<long> TrainSymbolIDs { get; set; }
        public List<long> TrackIDs { get; set; }

        public RailActivityReportContext(DateTime startDate, DateTime endDate, bool showTrain, bool showTrack, List<long> trainSymbolIDs, List<long> trackIDs)
        {
            StartDate = startDate;
            EndDate = endDate;
            ShowTrain = showTrain;
            ShowTrack = showTrack;
            TrainSymbolIDs = trainSymbolIDs;
            TrackIDs = trackIDs;
        }

        public string WindowTitle => "Train Activity";

        public string ReportPath => "FleetTracking.Reports.RailActivity.Activity.rdlc";

        private List<RailcarLocationTransactionModel> transactionModels = null;
        public async Task<Dictionary<string, object>> GetReportDataSources()
        {
            if (transactionModels == null)
            {
                GetData get = _application.GetAccess<GetData>();
                get.API = DataAccess.APIs.FleetTracking;
                get.Resource = "RailcarLocationTransaction/GetByDates";
                get.QueryString.Add("startDate", StartDate.ToString("yyyy'-'MM'-'dd"));
                get.QueryString.Add("endDate", EndDate.ToString("yyyy'-'MM'-'dd"));
                transactionModels = await get.GetObject<List<RailcarLocationTransactionModel>>() ?? new List<RailcarLocationTransactionModel>();

                if (TrainSymbolIDs != null && TrainSymbolIDs.Any())
                {
                    transactionModels = transactionModels.Where(tm => tm.TrainIDNew == null || TrainSymbolIDs.Contains(tm.TrainNew.TrainSymbolID.Value)).ToList();
                }

                if (TrackIDs != null && TrackIDs.Any())
                {
                    transactionModels = transactionModels.Where(tm => tm.TrackIDNew == null || TrackIDs.Contains(tm.TrackIDNew.Value)).ToList();
                }
            }

            return new Dictionary<string, object>()
            {
                { "FleetTracking.Reports.RailActivity.TrainActivity.rdlc.TrainActivityDataSet", transactionModels.Where(m => m.TrainIDNew != null) },
                { "FleetTracking.Reports.RailActivity.TrackActivity.rdlc.TrackActivityDataSet", transactionModels.Where(m => m.TrackIDNew != null && m.PreviousTransaction?.TrainIDNew == null) }
            };
        }

        public Dictionary<string, object> GetReportParameters()
        {
            return new Dictionary<string, object>()
            {
                { "StartDate", StartDate },
                { "EndDate", EndDate },
                { "ShowTrainActivity", ShowTrain },
                { "ShowTrackActivity", ShowTrack }
            };
        }
    }
}
