using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FleetTracking.Attributes;
using FleetTracking.Interop;
using FleetTracking.Models;
using FleetTracking.Roster;
using FleetTracking.Train;
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;

namespace FleetTracking.TrainSymbols
{
    [SecuredControl(SecuredControlAttribute.Permissions.AllowSetup, SecuredControlAttribute.Permissions.IsYardmaster)]
    public partial class TrainSymbolDetail : UserControl, IFleetTrackingControl
    {
        private FleetTrackingApplication _application;
        public FleetTrackingApplication Application { set => _application = value; }

        public event EventHandler OnSave;

        public long? TrainSymbolID { get; set; }
        private bool _canSave;

        public TrainSymbolDetail()
        {
            InitializeComponent();
            dataGridViewStylizer.ApplyStyle(dgvRates);
            dataGridViewStylizer.ApplyStyle(dgvTrains);
            dataGridViewStylizer.ApplyStyle(dgvFuelByModel);
        }

        private async void TrainSymbolDetail_Load(object sender, EventArgs e)
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            loader.BringToFront();
            loader.Visible = true;

            try
            {
                dgvRates.Rows.Clear();

                TrainSymbol symbol = null;
                if (TrainSymbolID != null)
                {
                    GetData get = _application.GetAccess<GetData>();
                    get.API = DataAccess.APIs.FleetTracking;
                    get.Resource = $"TrainSymbol/Get/{TrainSymbolID}";
                    symbol = await get.GetObject<TrainSymbol>();
                }

                _canSave = symbol == null || _application.IsCurrentEntity(symbol.CompanyIDOperator, symbol.GovernmentIDOperator);

                if (!_canSave)
                {
                    cmdSave.Visible = false;
                    cmdReset.Visible = false;

                    txtDescription.Size = new Size(txtDescription.Width, groupBox1.Height - txtDescription.Top - 3);
                    txtDescription.ReadOnly = true;
                    txtName.ReadOnly = true;
                    toolAddRate.Enabled = false;
                }
                else
                {
                    toolAddRate.Enabled = symbol != null;
                }

                if (symbol != null)
                {
                    txtName.Text = symbol.Name;
                    txtDescription.Text = symbol.Description;

                    if (symbol.TrainSymbolRates != null)
                    {
                        bool foundOnOrBefore = false;
                        foreach(TrainSymbolRate trainSymbolRate in symbol.TrainSymbolRates.OrderByDescending(tsr => tsr.EffectiveTime))
                        {
                            int rowIndex = dgvRates.Rows.Add();
                            DataGridViewRow row = dgvRates.Rows[rowIndex];

                            row.Cells[colEffective.Name].Value = trainSymbolRate.EffectiveTime?.ToString("MM/dd/yyyy HH:mm");
                            row.Cells[colCar.Name].Value = trainSymbolRate.RatePerCar?.ToString("N2");
                            row.Cells[colPartial.Name].Value = trainSymbolRate.RatePerPartialTrip?.ToString("N2");
                            row.Tag = trainSymbolRate;

                            if (trainSymbolRate.EffectiveTime != null && trainSymbolRate.EffectiveTime.Value <= DateTime.Now && !foundOnOrBefore)
                            {
                                row.DefaultCellStyle.BackColor = Color.Yellow;
                                row.DefaultCellStyle.Font = new Font(dgvRates.Font, FontStyle.Italic);
                                foundOnOrBefore = true;
                            }
                        }
                    }
                }
            }
            finally
            {
                loader.Visible = false;
            }
        }

        private async void cmdSave_Click(object sender, EventArgs e)
        {
            if (!this.AreFieldsPresent(new List<(string, Control)>()
            {
                ("Name", txtName),
                ("Description", txtDescription)
            }))
            {
                return;
            }

            loader.BringToFront();
            loader.Visible = true;

            try
            {
                TrainSymbol trainSymbol = new TrainSymbol()
                {
                    TrainSymbolID = TrainSymbolID,
                    CompanyIDOperator = _application.GetCurrentCompanyIDGovernmentID().Item1,
                    GovernmentIDOperator = _application.GetCurrentCompanyIDGovernmentID().Item2,
                    Name = txtName.Text,
                    Description = txtDescription.Text
                };

                if (TrainSymbolID == null)
                {
                    PostData post = _application.GetAccess<PostData>();
                    post.API = DataAccess.APIs.FleetTracking;
                    post.Resource = "TrainSymbol/Post";
                    post.ObjectToPost = trainSymbol;
                    TrainSymbol savedSymbol = await post.Execute<TrainSymbol>();
                    if (post.RequestSuccessful)
                    {
                        TrainSymbolID = savedSymbol.TrainSymbolID;
                        OnSave?.Invoke(this, EventArgs.Empty);
                        await LoadData();
                    }
                }
                else
                {
                    PutData put = _application.GetAccess<PutData>();
                    put.API = DataAccess.APIs.FleetTracking;
                    put.Resource = "TrainSymbol/Put";
                    put.ObjectToPut = trainSymbol;
                    await put.ExecuteNoResult();
                    if (put.RequestSuccessful)
                    {
                        OnSave?.Invoke(this, EventArgs.Empty);
                        await LoadData();
                    }
                }
            }
            finally
            {
                loader.Visible = false;
            }
        }

        private void toolAddRate_Click(object sender, EventArgs e)
        {
            TrainSymbolRateDetail newDetail = new TrainSymbolRateDetail()
            {
                Application = _application,
                TrainSymbolID = TrainSymbolID
            };
            newDetail.OnSave += (s, ea) => LoadData();

            Form shownForm = _application.OpenForm(newDetail, FleetTrackingApplication.OpenFormOptions.Popout);
            shownForm.Text = "Train Symbol Rate";
        }

        private void dgvRates_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvRates.Rows.Count || !(dgvRates.Rows[e.RowIndex].Tag is TrainSymbolRate rate))
            {
                return;
            }

            TrainSymbolRateDetail editDetail = new TrainSymbolRateDetail()
            {
                Application = _application,
                TrainSymbolRateID = rate.TrainSymbolRateID,
                TrainSymbolID = TrainSymbolID
            };
            editDetail.OnSave += (s, ea) => LoadData();

            Form shownForm = _application.OpenForm(editDetail, FleetTrackingApplication.OpenFormOptions.Popout);
            shownForm.Text = "Train Symbol Rate";
        }

        private async Task LoadTrains()
        {
            if (TrainSymbolID == null)
            {
                return;
            }

            try
            {
                loaderTrains.BringToFront();
                loaderTrains.Visible = true;

                GetData get = _application.GetAccess<GetData>();
                get.API = DataAccess.APIs.FleetTracking;
                get.Resource = $"Train/GetByTrainSymbol/{TrainSymbolID}";
                List<Models.Train> trains = await get.GetObject<List<Models.Train>>() ?? new List<Models.Train>();
                trains = trains.OrderByDescending(t => t.TimeOnDuty).ToList();

                dgvTrains.Rows.Clear();
                foreach(Models.Train train in trains)
                {
                    List<TrainDutyTransaction> dutyTransactions = train.TrainDutyTransactions ?? new List<TrainDutyTransaction>();
                    List<TrainFuelRecord> fuelRecords = train.TrainFuelRecords ?? new List<TrainFuelRecord>();

                    TimeSpan span = new TimeSpan(0, 0, 0);
                    foreach(TrainDutyTransaction dutyTransaction in dutyTransactions.Where(tdt => tdt.TimeOnDuty != null && tdt.TimeOffDuty != null))
                    {
                        span += dutyTransaction.TimeOffDuty.Value - dutyTransaction.TimeOnDuty.Value;
                    }
                    
                    int rowIndex = dgvTrains.Rows.Add();
                    DataGridViewRow row = dgvTrains.Rows[rowIndex];
                    row.Cells[colStart.Name].Value = dutyTransactions.OrderByDescending(tdt => tdt.TimeOnDuty).FirstOrDefault()?.TimeOnDuty?.ToString("MM/dd/yyyy HH:mm");
                    row.Cells[colEndTime.Name].Value = dutyTransactions.OrderByDescending(tdt => tdt.TimeOffDuty).FirstOrDefault()?.TimeOffDuty?.ToString("MM/dd/yyyy HH:mm");
                    row.Cells[colFuelUsage.Name].Value = fuelRecords.Where(fr => fr.FuelStart != null && fr.FuelEnd != null).Sum(fr => fr.FuelStart - fr.FuelEnd)?.ToString("N2");
                    row.Cells[colTimeTaken.Name].Value = span.ToString(@"hh\:mm");
                    row.Tag = train;
                }
            }
            finally
            {
                loaderTrains.Visible = false;
            }
        }

        private async void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1)
            {
                await LoadData();
            }
            else if (tabControl1.SelectedTab == tabPage2)
            {
                await LoadTrains();
            }
            else if (tabControl1.SelectedTab == tabPage3)
            {
                await LoadStats();
            }
        }

        private void dgvTrains_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvTrains.Rows.Count)
            {
                return;
            }

            DataGridViewRow row = dgvTrains.Rows[e.RowIndex];
            Models.Train train = row.Tag as Models.Train;

            if (train == null)
            {
                return;
            }

            InProgressTrainDisplay trainDisplay = new InProgressTrainDisplay()
            {
                Application = _application,
                TrainID = train.TrainID
            };

            _application.OpenForm(trainDisplay, FleetTrackingApplication.OpenFormOptions.Popout);
        }

        private async Task LoadStats()
        {
            try
            {
                loaderStats.BringToFront();
                loaderStats.Visible = true;

                GetData get = _application.GetAccess<GetData>();
                get.API = DataAccess.APIs.FleetTracking;
                get.Resource = $"Train/GetByTrainSymbol/{TrainSymbolID}";
                List<Models.Train> trains = await get.GetObject<List<Models.Train>>() ?? new List<Models.Train>();
                decimal averageFuelUsage = 0;

                if (trains.Any(t => t.TrainFuelRecords.Any(tfr => tfr.FuelStart != null && tfr.FuelEnd != null)))
                {
                    averageFuelUsage = trains
                        .SelectMany(t => t.TrainFuelRecords)
                        .Where(t => t.FuelStart != null && t.FuelEnd != null)
                        .GroupBy(t => t.TrainID)
                        .Average(group => group.Sum(tfr => tfr.FuelStart.Value - tfr.FuelEnd.Value));
                }


                TimeSpan averageTimeSpan = new TimeSpan();

                if (trains.Any(t => t.TrainDutyTransactions.Any(tdt => tdt.TimeOnDuty != null && tdt.TimeOffDuty != null)))
                {
                    averageTimeSpan = TimeSpan.FromMinutes(trains
                                                .SelectMany(t => t.TrainDutyTransactions)
                                                .Where(tdt => tdt.TimeOnDuty != null && tdt.TimeOffDuty != null)
                                                .GroupBy(tdt => tdt.TrainID)
                                                .Average(group => group.Sum(tdt => (tdt.TimeOffDuty.Value - tdt.TimeOnDuty.Value).TotalMinutes)));
                }

                lblAverageFuel.Text = averageFuelUsage.ToString("N2");
                lblAverageDuty.Text = averageTimeSpan.ToString(@"hh\:mm");

                dgvFuelByModel.Rows.Clear();
                foreach (IGrouping<long?, TrainFuelRecord> fuelRecordsByModel in trains.SelectMany(t => t.TrainFuelRecords).Where(tfr => tfr.FuelStart != null && tfr.FuelEnd != null).GroupBy(tfr => tfr.Locomotive.LocomotiveModelID))
                {
                    int rowIndex = dgvFuelByModel.Rows.Add();
                    DataGridViewRow row = dgvFuelByModel.Rows[rowIndex];

                    row.Cells[colModel.Name].Value = fuelRecordsByModel.First().Locomotive?.LocomotiveModel?.Name;
                    row.Cells[colAvgFuel.Name].Value = fuelRecordsByModel.Where(tfr => tfr.FuelStart != null && tfr.FuelEnd != null).Average(tfr => tfr.FuelStart.Value - tfr.FuelEnd.Value).ToString("N2");
                }
            }
            finally
            {
                loaderStats.Visible = false;
            }
        }
    }
}
