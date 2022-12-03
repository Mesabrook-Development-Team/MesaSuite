using FleetTracking.Interop;
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FleetTracking.Train
{
    public partial class TrainList : UserControl, IFleetTrackingControl
    {
        private FleetTrackingApplication _application;
        public FleetTrackingApplication Application { set => _application = value; }

        private int _skip;
        private const int TAKE = 50;

        public TrainList()
        {
            InitializeComponent();
            dataGridViewStylizer.ApplyStyle(dgvTrains);
        }

        private async void TrainList_Load(object sender, EventArgs e)
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            loader.BringToFront();
            loader.Visible = true;

            try
            {
                dgvTrains.Rows.Clear();

                GetData get = _application.GetAccess<GetData>();
                get.API = DataAccess.APIs.FleetTracking;
                get.Resource = "Train/GetFiltered";
                get.QueryString.Add("status", rdoInProgress.Checked ? "inprogress" : "all");
                get.QueryString.Add("operableonly", chkOperableTrainsOnly.Checked.ToString());
                get.QueryString.Add("skip", _skip.ToString());
                get.QueryString.Add("take", TAKE.ToString());

                var responseObject = new
                {
                    maxItems = 0,
                    trains = new List<Models.Train>()
                };

                responseObject = await get.GetAnonymousObject(responseObject);

                if (responseObject == null)
                {
                    return;
                }

                foreach(Models.Train train in responseObject.trains)
                {
                    int rowIndex = dgvTrains.Rows.Add();
                    DataGridViewRow row = dgvTrains.Rows[rowIndex];
                    row.Cells[colSymbol.Name].Value = train.TrainSymbol?.Name;
                    row.Cells[colStatus.Name].Value = train.Status.ToString().ToDisplayName();
                    row.Cells[colStartTime.Name].Value = train.TrainDutyTransactions?.OrderBy(tdt => tdt.TimeOnDuty).FirstOrDefault()?.TimeOnDuty?.ToString("MM/dd/yyyy HH:mm");
                    row.Cells[colEndTime.Name].Value = train.TrainDutyTransactions?.OrderByDescending(tdt => tdt.TimeOffDuty).FirstOrDefault()?.TimeOffDuty?.ToString("MM/dd/yyyy HH:mm");
                    row.Cells[colLocomotive.Name].Value = train.RailLocations?.OrderBy(rl => rl.Position).FirstOrDefault(rl => rl.Locomotive?.LocomotiveID != null)?.Locomotive.FormattedReportingMark;
                    row.Cells[colStockTotal.Name].Value = train.RailLocations?.Count;
                    row.Cells[colLength.Name].Value = train.RailLocations?.Sum(rl => rl.Locomotive?.LocomotiveModel?.Length ?? rl.Railcar?.RailcarModel?.Length ?? 0);
                    row.Tag = train;
                }

                cmdFirst.Enabled = _skip != 0;
                cmdPrev.Enabled = _skip != 0;
                cmdNext.Enabled = _skip + TAKE < responseObject.maxItems;
                cmdLast.Enabled = _skip + TAKE < responseObject.maxItems;
            }
            finally
            {
                loader.Visible = false;
            }
        }

        private void toolAddTrain_Click(object sender, EventArgs e)
        {
            NewTrainSelectSymbol selectSymbol = new NewTrainSelectSymbol()
            {
                Application = _application
            };

            _application.OpenForm(selectSymbol, FleetTrackingApplication.OpenFormOptions.Dialog);
        }

        private void dgvTrains_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Models.Train train = dgvTrains.Rows[e.RowIndex].Tag as Models.Train;
            if (train == null)
            {
                return;
            }

            // Need to check later based on whether or not it's completed
            InProgressTrainDisplay display = new InProgressTrainDisplay()
            {
                Application = _application,
                TrainID = train.TrainID
            };
            Form trainDisplay = _application.OpenForm(display, FleetTrackingApplication.OpenFormOptions.Popout);
            trainDisplay.Text = train.TrainSymbol.Name;
        }
    }
}
