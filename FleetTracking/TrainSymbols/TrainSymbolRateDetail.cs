using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FleetTracking.Interop;
using FleetTracking.Models;
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;

namespace FleetTracking.TrainSymbols
{
    public partial class TrainSymbolRateDetail : UserControl, IFleetTrackingControl
    {
        private FleetTrackingApplication _application;
        public FleetTrackingApplication Application { set => _application = value; }

        public event EventHandler OnSave;

        public long? TrainSymbolRateID { get; set; }
        public long? TrainSymbolID { get; set; }

        private DataGridViewRow RatePerCarRow;
        private DataGridViewRow RatePerPartialTripRow;

        public TrainSymbolRateDetail()
        {
            InitializeComponent();
            dataGridViewStylizer.ApplyStyle(dgvRates);
            dgvRates.ReadOnly = false;

            colRateType.ReadOnly = true;
            colAmount.ValueType = typeof(decimal?);
        }

        private async void TrainSymbolRateDetail_Load(object sender, EventArgs e)
        {
            if (TrainSymbolID == null)
            {
                this.ShowError("Train Symbol ID must be provided");
                Dispose();
                ParentForm?.Close();
                return;
            }
            await LoadData();
        }

        private async Task LoadData()
        {
            loader.BringToFront();
            loader.Visible = true;

            try
            {
                dgvRates.Rows.Clear();
                int rowIndex = dgvRates.Rows.Add();
                RatePerCarRow = dgvRates.Rows[rowIndex];
                RatePerCarRow.Cells[colRateType.Name].Value = "Rate Per Car";

                rowIndex = dgvRates.Rows.Add();
                RatePerPartialTripRow = dgvRates.Rows[rowIndex];
                RatePerPartialTripRow.Cells[colRateType.Name].Value = "Rate Per Partial Trip";

                if (TrainSymbolRateID != null)
                {
                    GetData get = _application.GetAccess<GetData>();
                    get.API = DataAccess.APIs.FleetTracking;
                    get.Resource = $"TrainSymbolRate/Get/{TrainSymbolRateID}";
                    TrainSymbolRate trainSymbolRate = await get.GetObject<TrainSymbolRate>();

                    if (trainSymbolRate == null)
                    {
                        return;
                    }

                    dtpEffectiveTime.Value = trainSymbolRate.EffectiveTime ?? DateTime.Now;
                    RatePerCarRow.Cells[colAmount.Name].Value = trainSymbolRate.RatePerCar;
                    RatePerPartialTripRow.Cells[colAmount.Name].Value = trainSymbolRate.RatePerPartialTrip;

                    if (dtpEffectiveTime.Value < DateTime.Now || !_application.IsCurrentEntity(trainSymbolRate.TrainSymbol.CompanyIDOperator, trainSymbolRate.TrainSymbol.GovernmentIDOperator))
                    {
                        dtpEffectiveTime.Enabled = false;
                        dgvRates.ReadOnly = true;

                        cmdSave.Visible = false;
                        cmdReset.Visible = false;

                        groupBox1.Size = new Size(groupBox1.Width, Height - groupBox1.Top - 3);
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
            if (RatePerCarRow.Cells[colAmount.Name].Value == null || RatePerPartialTripRow.Cells[colAmount.Name].Value == null)
            {
                this.ShowError("All rates must have an Amount");
                return;
            }

            if (dtpEffectiveTime.Value <= DateTime.Now && !this.Confirm("Setting the Effective Time will permanently lock in this rate.\r\n\r\nNOTE: Existing Invoice amounts will not be backfilled.\r\n\r\nContinue?"))
            {
                return;
            }

            try
            {
                loader.BringToFront();
                loader.Visible = true;

                TrainSymbolRate rate = new TrainSymbolRate()
                {
                    TrainSymbolRateID = TrainSymbolRateID,
                    TrainSymbolID = TrainSymbolID,
                    EffectiveTime = dtpEffectiveTime.Value,
                    RatePerCar = RatePerCarRow.Cells[colAmount.Name].Value as decimal?,
                    RatePerPartialTrip = RatePerPartialTripRow.Cells[colAmount.Name].Value as decimal?
                };

                if (TrainSymbolRateID == null)
                {
                    PostData post = _application.GetAccess<PostData>();
                    post.API = DataAccess.APIs.FleetTracking;
                    post.Resource = "TrainSymbolRate/Post";
                    post.ObjectToPost = rate;
                    TrainSymbolRate newRate = await post.Execute<TrainSymbolRate>();
                    if (post.RequestSuccessful)
                    {
                        TrainSymbolRateID = newRate.TrainSymbolRateID;
                        OnSave?.Invoke(this, EventArgs.Empty);
                        await LoadData();
                    }
                }
                else
                {
                    PutData put = _application.GetAccess<PutData>();
                    put.API = DataAccess.APIs.FleetTracking;
                    put.Resource = "TrainSymbolRate/Put";
                    put.ObjectToPut = rate;
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
    }
}
