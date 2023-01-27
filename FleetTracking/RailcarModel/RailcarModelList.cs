using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using FleetTracking.Attributes;
using FleetTracking.Interop;
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;

namespace FleetTracking.RailcarModel
{
    [SecuredControl(SecuredControlAttribute.Permissions.AllowSetup)]
    public partial class RailcarModelList : UserControl, IFleetTrackingControl
    {
        private FleetTrackingApplication _application;
        public FleetTrackingApplication Application { set => _application = value; }

        public event EventHandler<Models.RailcarModel> RailcarModelSelectionChanged;

        public Models.RailcarModel SelectedRailcarModel
        {
            get
            {
                if (dgvModels.SelectedRows.Count <= 0)
                {
                    return null;
                }

                return dgvModels.SelectedRows[0].Tag as Models.RailcarModel;
            }
        }

        public RailcarModelList()
        {
            InitializeComponent();
            dataGridViewStylizer.ApplyStyle(dgvModels);
        }

        private void RailcarModelList_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public async Task LoadData(string selectedName = null)
        {
            loader.BringToFront();
            loader.Visible = true;

            try
            {
                dgvModels.Rows.Clear();

                GetData get = _application.GetAccess<GetData>();
                get.API = DataAccess.APIs.FleetTracking;
                get.Resource = "RailcarModel/GetAll";
                List<Models.RailcarModel> railcarModels = await get.GetObject<List<Models.RailcarModel>>() ?? new List<Models.RailcarModel>();

                foreach(Models.RailcarModel railcarModel in railcarModels)
                {
                    int rowIndex = dgvModels.Rows.Add();
                    DataGridViewRow row = dgvModels.Rows[rowIndex];

                    row.Cells[colName.Name].Value = railcarModel.Name;
                    row.Cells[colCargoCapacity.Name].Value = railcarModel.CargoCapacity?.ToString() ?? "0";
                    row.Cells[colLength.Name].Value = railcarModel.Length?.ToString() ?? "0";
                    row.Cells[colType.Name].Value = railcarModel.Type.ToString().ToDisplayName();
                    row.Tag = railcarModel;

                    if (string.Equals(railcarModel.Name, selectedName))
                    {
                        row.Selected = true;
                    }
                }

                if (string.IsNullOrEmpty(selectedName) && dgvModels.Rows.Count > 0)
                {
                    dgvModels.Rows[0].Selected = true;

                    Models.RailcarModel railcarModel = dgvModels.SelectedRows[0].Tag as Models.RailcarModel;
                    if (railcarModel != null)
                    {
                        RailcarModelSelectionChanged?.Invoke(this, railcarModel);
                    }
                }
            }
            finally
            {
                loader.Visible = false;
            }

            try
            {
                GetData get = _application.GetAccess<GetData>();
                get.API = DataAccess.APIs.FleetTracking;

                foreach (DataGridViewRow row in dgvModels.Rows)
                {
                    Models.RailcarModel railcarModel = row.Tag as Models.RailcarModel;
                    if (railcarModel == null)
                    {
                        continue;
                    }

                    get.Resource = $"RailcarModel/GetImage/{railcarModel.RailcarModelID}";
                    byte[] imageData = await get.GetObject<byte[]>();

                    if (imageData != null)
                    {
                        using (MemoryStream memoryStream = new MemoryStream(imageData))
                        {
                            Image image = Image.FromStream(memoryStream);
                            row.Cells[colImage.Name].Value = image;
                        }
                    }
                }
            }
            catch { }
        }

        private void dgvModels_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvModels.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow row = dgvModels.SelectedRows[0];
            Models.RailcarModel railcarModel = row.Tag as Models.RailcarModel;
            if (railcarModel == null)
            {
                return;
            }

            RailcarModelSelectionChanged?.Invoke(this, railcarModel);
        }
    }
}
