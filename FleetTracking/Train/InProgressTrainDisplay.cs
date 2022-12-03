using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FleetTracking.Interop;
using FleetTracking.Models;
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;

namespace FleetTracking.Train
{
    public partial class InProgressTrainDisplay : UserControl, IFleetTrackingControl
    {
        private FleetTrackingApplication _application;
        public FleetTrackingApplication Application { set => _application = value; }

        public long? TrainID { get; set; }

        public InProgressTrainDisplay()
        {
            InitializeComponent();
            dataGridViewStylizer.ApplyStyle(dgvConsist);
            dataGridViewStylizer.ApplyStyle(dgvDutyTrans);
            dataGridViewStylizer.ApplyStyle(dgvLocoFuel);
        }

        private void InProgressTrainDisplay_Load(object sender, EventArgs e)
        {
            LoadEverything();
        }

        private void LoadEverything()
        {
            LoadTrainInfo();
            LoadConsist();
            LoadDutyTransactions();
            LoadLocoFuel();
        }

        private async void LoadTrainInfo()
        {
            try
            {
                loaderTrainInfo.BringToFront();
                loaderTrainInfo.Visible = true;

                GetData get = _application.GetAccess<GetData>();
                get.API = DataAccess.APIs.FleetTracking;
                get.Resource = $"Train/Get/{TrainID}";
                Models.Train train = await get.GetObject<Models.Train>() ?? new Models.Train();

                lnkSymbol.Text = train.TrainSymbol?.Name;
                lnkSymbol.Tag = train.TrainSymbol;
                lblStatus.Text = train.Status.ToString().ToDisplayName();
                if (train.Status == Models.Train.Statuses.NotStarted)
                {
                    lblStatus.BackColor = Color.Yellow;
                }
                TrainDutyTransaction lastetOnDutyTransaction = train?.TrainDutyTransactions?.Where(tdt => tdt.TimeOffDuty == null).FirstOrDefault();
                if (lastetOnDutyTransaction == null)
                {
                    lblOnDutySince.Text = "--/--/---- --:--";
                }
                else
                {
                    lblOnDutySince.Text = lastetOnDutyTransaction.TimeOnDuty?.ToString("MM/dd/yyyy HH:mm");
                }
                txtInstructions.Text = train.TrainInstructions;
            }
            finally
            {
                loaderTrainInfo.Visible = false;
            }
        }

        private async void LoadConsist()
        {
            try
            {
                loaderConsist.BringToFront();
                loaderConsist.Visible = true;

                GetData get = _application.GetAccess<GetData>();
                get.API = DataAccess.APIs.FleetTracking;
                get.Resource = $"RailLocation/GetByTrain/{TrainID}";
                List<RailLocation> railLocations = await get.GetObject<List<RailLocation>>() ?? new List<RailLocation>();
                railLocations = railLocations.OrderBy(rl => rl.Position).ToList();

                foreach(RailLocation railLocation in railLocations)
                {
                    int rowIndex = dgvConsist.Rows.Add();
                    DataGridViewRow row = dgvConsist.Rows[rowIndex];

                    row.Cells[colReportingMark.Name].Value = railLocation.Locomotive?.FormattedReportingMark ?? railLocation.Railcar?.FormattedReportingMark;
                    row.Cells[colPosition.Name].Value = railLocation.Position.ToString();
                    row.Cells[colConsistType.Name].Value = railLocation.LocomotiveID == null ? "Railcar" : "Locomotive";
                    row.Tag = railLocation;
                }
            }
            finally
            {
                loaderConsist.Visible = false;
            }

            try
            {
                GetData get = _application.GetAccess<GetData>();
                get.API = DataAccess.APIs.FleetTracking;

                foreach(DataGridViewRow row in dgvConsist.Rows)
                {
                    RailLocation railLocation = row.Tag as RailLocation;
                    if (railLocation == null)
                    {
                        continue;
                    }

                    byte[] imageData;
                    if (railLocation.LocomotiveID != null)
                    {
                        get.Resource = $"Locomotive/GetImage/{railLocation.LocomotiveID}";
                        imageData = await get.GetObject<byte[]>();
                    }
                    else
                    {
                        get.Resource = $"Railcar/GetImage/{railLocation.RailcarID}";
                        imageData = await get.GetObject<byte[]>();
                    }

                    if (imageData != null)
                    {
                        using (MemoryStream stream = new MemoryStream(imageData))
                        {
                            Image image = Image.FromStream(stream);
                            row.Cells[colConsistImage.Name].Value = image;
                        }
                    }
                }
            }
            catch { }
        }

        private async void LoadDutyTransactions()
        {
            try
            {
                loaderDutyTrans.BringToFront();
                loaderDutyTrans.Visible = true;

                GetData get = _application.GetAccess<GetData>();
                get.API = DataAccess.APIs.FleetTracking;
                get.Resource = $"TrainDutyTransaction/GetByTrain/{TrainID}";
                List<TrainDutyTransaction> dutyTransactions = await get.GetObject<List<TrainDutyTransaction>>() ?? new List<TrainDutyTransaction>();
                foreach(TrainDutyTransaction trainDutyTransaction in dutyTransactions)
                {
                    int rowIndex = dgvDutyTrans.Rows.Add();
                    DataGridViewRow row = dgvDutyTrans.Rows[rowIndex];
                    row.Cells[colOperator.Name].Value = trainDutyTransaction.UserOperator?.Username;
                    row.Cells[colTimeStart.Name].Value = trainDutyTransaction.TimeOnDuty?.ToString("MM/dd/yyyy HH:mm");
                    row.Cells[colTimeEnd.Name].Value = trainDutyTransaction.TimeOffDuty?.ToString("MM/dd/yyyy HH:mm");
                    row.Tag = trainDutyTransaction;
                }
            }
            finally
            {
                loaderDutyTrans.Visible = false;
            }
        }

        private async void LoadLocoFuel()
        {
            try
            {
                loaderLocoFuel.BringToFront();
                loaderLocoFuel.Visible = true;

                GetData get = _application.GetAccess<GetData>();
                get.API = DataAccess.APIs.FleetTracking;
                get.Resource = $"TrainFuelRecord/GetByTrain/{TrainID}";
                List<TrainFuelRecord> fuelRecords = await get.GetObject<List<TrainFuelRecord>>() ?? new List<TrainFuelRecord>();

                foreach(TrainFuelRecord fuelRecord in fuelRecords)
                {
                    int rowIndex = dgvLocoFuel.Rows.Add();
                    DataGridViewRow row = dgvLocoFuel.Rows[rowIndex];
                    row.Cells[colFuelReportingMark.Name].Value = fuelRecord.Locomotive?.FormattedReportingMark;
                    row.Cells[colStartingFuel.Name].Value = fuelRecord.FuelStart?.ToString();
                    row.Cells[colEndingFuel.Name].Value = fuelRecord.FuelEnd?.ToString();
                    row.Tag = fuelRecord;
                }
            }
            finally
            {
                loaderLocoFuel.Visible = false;
            }

            try
            {
                GetData get = _
            }
            catch { }
        }
    }
}
