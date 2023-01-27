using FleetTracking.Attributes;
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
    [SecuredControl(SecuredControlAttribute.Permissions.AllowSetup)]
    public partial class CarHandlingRateDetail : UserControl, IFleetTrackingControl
    {
        public event EventHandler OnSave;

        private FleetTrackingApplication _application;
        public FleetTrackingApplication Application { set => _application = value; }

        public long? CarHandlingRateID { get; set; }

        private DataGridViewRow _interDistrictRateRow;
        private DataGridViewRow _intraDistrictRateRow;
        private DataGridViewRow _placementRateRow;

        public CarHandlingRateDetail()
        {
            InitializeComponent();
            dataGridViewStylizer.ApplyStyle(dgvRates);
            dgvRates.ReadOnly = false;

            colRate.ValueType = typeof(decimal?);
        }

        private void NonTrainRateList_Load(object sender, EventArgs e)
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

                int rowIndex = dgvRates.Rows.Add();
                _intraDistrictRateRow = dgvRates.Rows[rowIndex];
                _intraDistrictRateRow.Cells[colName.Name].Value = "Intradistrict Rate";

                rowIndex = dgvRates.Rows.Add();
                _interDistrictRateRow = dgvRates.Rows[rowIndex];
                _interDistrictRateRow.Cells[colName.Name].Value = "Interdistrict Rate";

                rowIndex = dgvRates.Rows.Add();
                _placementRateRow = dgvRates.Rows[rowIndex];
                _placementRateRow.Cells[colName.Name].Value = "Placement Rate";

                if (CarHandlingRateID != null)
                {
                    GetData get = _application.GetAccess<GetData>();
                    get.API = DataAccess.APIs.FleetTracking;
                    get.Resource = $"CarHandlingRate/Get/{CarHandlingRateID}";
                    CarHandlingRate carHandlingRate = await get.GetObject<CarHandlingRate>();

                    dtpEffectiveTime.Value = carHandlingRate.EffectiveTime ?? DateTime.Now;
                    _intraDistrictRateRow.Cells[colRate.Name].Value = carHandlingRate.IntraDistrictRate?.ToString("N2");
                    _interDistrictRateRow.Cells[colRate.Name].Value = carHandlingRate.InterDistrictRate?.ToString("N2");
                    _placementRateRow.Cells[colRate.Name].Value = carHandlingRate.PlacementRate?.ToString("N2");

                    bool isLocked = carHandlingRate.EffectiveTime == null || carHandlingRate.EffectiveTime.Value <= DateTime.Now;
                    dtpEffectiveTime.Enabled = !isLocked && _application.IsCurrentEntity(carHandlingRate.CompanyID, carHandlingRate.GovernmentID);
                    dgvRates.ReadOnly = isLocked || !_application.IsCurrentEntity(carHandlingRate.CompanyID, carHandlingRate.GovernmentID);
                    cmdSave.Enabled = !isLocked && _application.IsCurrentEntity(carHandlingRate.CompanyID, carHandlingRate.GovernmentID);
                    cmdCancel.Enabled = !isLocked && _application.IsCurrentEntity(carHandlingRate.CompanyID, carHandlingRate.GovernmentID);
                }
            }
            finally
            {
                loader.Visible = false;
            }
        }

        private async void cmdSave_Click(object sender, EventArgs e)
        {
            if (_intraDistrictRateRow.Cells[colRate.Name].Value == null ||
                _interDistrictRateRow.Cells[colRate.Name].Value == null ||
                _placementRateRow.Cells[colRate.Name].Value == null)
            {
                this.ShowError("All rates must be completed");
                return;
            }

            if (dtpEffectiveTime.Value <= DateTime.Now && !this.Confirm("Setting an effective date in the past will lock this rate.\r\n\r\nAre you sure you want to save?"))
            {
                return;
            }

            try
            {
                loader.BringToFront();
                loader.Visible = true;

                CarHandlingRate carHandlingRate = new CarHandlingRate()
                {
                    CarHandlingRateID = CarHandlingRateID,
                    CompanyID = _application.GetCurrentCompanyIDGovernmentID().Item1,
                    GovernmentID = _application.GetCurrentCompanyIDGovernmentID().Item2,
                    EffectiveTime = dtpEffectiveTime.Value,
                    InterDistrictRate = _interDistrictRateRow.Cells[colRate.Name].Value as decimal?,
                    IntraDistrictRate = _intraDistrictRateRow.Cells[colRate.Name].Value as decimal?,
                    PlacementRate = _placementRateRow.Cells[colRate.Name].Value as decimal?
                };

                if (CarHandlingRateID == null)
                {
                    PostData post = _application.GetAccess<PostData>();
                    post.API = DataAccess.APIs.FleetTracking;
                    post.Resource = "CarHandlingRate/Post";
                    post.ObjectToPost = carHandlingRate;
                    CarHandlingRate savedRate = await post.Execute<CarHandlingRate>();
                    if (post.RequestSuccessful)
                    {
                        OnSave?.Invoke(this, EventArgs.Empty);
                        CarHandlingRateID = savedRate.CarHandlingRateID;
                        LoadData();
                    }
                }
                else
                {
                    PutData put = _application.GetAccess<PutData>();
                    put.API = DataAccess.APIs.FleetTracking;
                    put.Resource = "CarHandlingRate/Put";
                    put.ObjectToPut = carHandlingRate;
                    await put.ExecuteNoResult();

                    if (put.RequestSuccessful)
                    {
                        OnSave?.Invoke(this, EventArgs.Empty);
                        LoadData();
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
