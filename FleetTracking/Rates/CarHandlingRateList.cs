using FleetTracking.Interop;
using FleetTracking.Models;
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FleetTracking.Rates
{
    public partial class CarHandlingRateList : UserControl, IFleetTrackingControl
    {
        private FleetTrackingApplication _application;
        public FleetTrackingApplication Application { set => _application = value; }
        public CarHandlingRateList()
        {
            InitializeComponent();
            dataGridViewStylizer.ApplyStyle(dgvRates);            
        }

        private void CarHandlingRateList_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private async void LoadData()
        {
            try
            {
                loader.BringToFront();
                loader.Visible = true;

                dgvRates.Rows.Clear();

                GetData get = _application.GetAccess<GetData>();
                get.API = DataAccess.APIs.FleetTracking;

                (long?, long?) companyIDGovernmentID = _application.GetCurrentCompanyIDGovernmentID();
                if (companyIDGovernmentID.Item1 != null)
                {
                    get.Resource = $"CarHandlingRate/GetByCompanyID/{companyIDGovernmentID.Item1}";
                }
                else
                {
                    get.Resource = $"CarHandlingRate/GetByGovernmentID/{companyIDGovernmentID.Item2}";
                }

                List<CarHandlingRate> carHandlingRates = await get.GetObject<List<CarHandlingRate>>() ?? new List<CarHandlingRate>();
                carHandlingRates = carHandlingRates.OrderByDescending(chr => chr.EffectiveTime).ToList();

                bool foundCurrentRate = false;
                foreach (CarHandlingRate carHandlingRate in carHandlingRates)
                {
                    int rowIndex = dgvRates.Rows.Add();
                    DataGridViewRow row = dgvRates.Rows[rowIndex];

                    row.Cells[colEffectiveTime.Name].Value = carHandlingRate.EffectiveTime?.ToString("MM/dd/yyyy HH:mm");
                    row.Cells[colIntraDistrictRate.Name].Value = carHandlingRate.IntraDistrictRate?.ToString("N2");
                    row.Cells[colInterDistrictRate.Name].Value = carHandlingRate.InterDistrictRate?.ToString("N2");
                    row.Cells[colPlacementRate.Name].Value = carHandlingRate.PlacementRate?.ToString("N2");

                    if (carHandlingRate.EffectiveTime <= DateTime.Now && !foundCurrentRate)
                    {
                        foundCurrentRate = true;
                        row.Cells[colEffectiveTime.Name].Style.Font = new Font(ParentForm.Font, FontStyle.Italic);
                    }

                    row.Tag = carHandlingRate;
                }

                dgvRates_SelectionChanged(this, EventArgs.Empty);
            }
            finally
            {
                loader.Visible = false;
            }
        }

        private void toolAdd_Click(object sender, EventArgs e)
        {
            CarHandlingRateDetail detail = new CarHandlingRateDetail()
            {
                Application = _application
            };
            detail.OnSave += (s, ea) => LoadData();

            Form detailForm = _application.OpenForm(detail);
            detailForm.Text = "Car Handling Rate";
        }

        private void dgvRates_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvRates.Rows.Count)
            {
                return;
            }

            CarHandlingRate rate = dgvRates.Rows[e.RowIndex].Tag as CarHandlingRate;
            if (rate == null)
            {
                return;
            }

            CarHandlingRateDetail detail = new CarHandlingRateDetail()
            {
                Application = _application,
                CarHandlingRateID = rate.CarHandlingRateID
            };
            detail.OnSave += (s, ea) => LoadData();

            Form detailForm = _application.OpenForm(detail);
            detailForm.Text = "Car Handling Rate";
        }

        private async void toolDelete_Click(object sender, EventArgs e)
        {
            if (dgvRates.SelectedRows.Count > 0 && !this.Confirm("Are you sure you want to delete these rate(s)?"))
            {
                return;
            }

            try
            {
                loader.BringToFront();
                loader.Visible = true;

                DeleteData delete = _application.GetAccess<DeleteData>();
                delete.API = DataAccess.APIs.FleetTracking;
                foreach (DataGridViewRow selectedRow in dgvRates.SelectedRows)
                {
                    CarHandlingRate rate = selectedRow.Tag as CarHandlingRate;
                    if (rate == null)
                    {
                        continue;
                    }

                    delete.Resource = $"CarHandlingRate/Delete/{rate.CarHandlingRateID}";
                    await delete.Execute();
                }
            }
            finally
            {
                loader.Visible = false;
            }

            LoadData();
        }

        private void dgvRates_SelectionChanged(object sender, EventArgs e)
        {
            toolDelete.Enabled = dgvRates.SelectedRows.Cast<DataGridViewRow>().Select(dgvr => dgvr.Tag).OfType<CarHandlingRate>().Any(chr => chr.EffectiveTime > DateTime.Now);
        }
    }
}
