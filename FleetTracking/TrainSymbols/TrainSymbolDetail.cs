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
    }
}
