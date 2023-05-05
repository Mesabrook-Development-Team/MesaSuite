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

        public RailActivityReportContext(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        public string WindowTitle => "Train Activity";

        public string ReportPath => "FleetTracking.Reports.RailActivity.Activity.rdlc";

        public async Task<Dictionary<string, object>> GetReportDataSources()
        {
            GetData get = _application.GetAccess<GetData>();
            get.API = DataAccess.APIs.FleetTracking;
            get.Resource = "RailcarLocationTransaction/GetByDates";
            get.QueryString.Add("startDate", StartDate.ToString("yyyy'-'MM'-'dd"));
            get.QueryString.Add("endDate", EndDate.ToString("yyyy'-'MM'-'dd"));
            List<RailcarLocationTransactionModel> transactionModels = await get.GetObject<List<RailcarLocationTransactionModel>>();

            return new Dictionary<string, object>()
            {
                { "FleetTracking.Reports.RailActivity.TrainActivity.rdlc.TrainActivityDataSet", transactionModels.Where(m => m.TrainIDNew != null) }
            };
        }

        public Dictionary<string, object> GetReportParameters()
        {
            return new Dictionary<string, object>()
            {
                { "StartDate", StartDate },
                { "EndDate", EndDate },
                { "ShowTrainActivity", true }
            };
        }
    }
}
