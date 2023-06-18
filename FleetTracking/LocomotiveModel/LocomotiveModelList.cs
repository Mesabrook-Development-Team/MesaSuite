using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FleetTracking.Attributes;
using FleetTracking.Interop;
using MesaSuite.Common.Data;

namespace FleetTracking.LocomotiveModel
{
    [SecuredControl(SecuredControlAttribute.Permissions.AllowSetup)]
    public partial class LocomotiveModelList : UserControl, IFleetTrackingControl
    {
        public event EventHandler<Models.LocomotiveModel> LocomotiveModelChanged;

        public long? SelectedLocomotiveModelID
        {
            get
            {
                if (dgvLocomotiveModels.SelectedRows.Count == 0)
                {
                    return null;
                }

                DataGridViewRow currentRow = dgvLocomotiveModels.SelectedRows.OfType<DataGridViewRow>().First();
                Models.LocomotiveModel currentModel = currentRow.Tag as Models.LocomotiveModel;
                if (currentModel == null)
                {
                    return null;
                }

                return currentModel.LocomotiveModelID;
            }

            set
            {
                foreach(DataGridViewRow row in dgvLocomotiveModels.Rows)
                {
                    Models.LocomotiveModel locomotiveModel = row.Tag as Models.LocomotiveModel;
                    if (locomotiveModel == null)
                    {
                        return;
                    }

                    if (locomotiveModel.LocomotiveModelID == value)
                    {
                        row.Selected = true;
                        return;
                    }
                }
            }
        }

        private FleetTrackingApplication _application = null;
        public FleetTrackingApplication Application { set => _application = value; }

        public LocomotiveModelList()
        {
            InitializeComponent();
        }

        private async void LocomotiveModelList_Load(object sender, EventArgs e)
        {
            await LoadList();
        }

        public async Task LoadList(long? selectedLocomotiveModelID = null)
        {
            loader.BringToFront();
            loader.Visible = true;

            try
            {
                dgvLocomotiveModels.Rows.Clear();
                GetData get = _application.GetAccess<GetData>();
                if (get == null)
                {
                    return;
                }

                get.API = DataAccess.APIs.FleetTracking;
                get.Resource = "LocomotiveModel/GetAll";
                List<Models.LocomotiveModel> locomotiveModels = await get.GetObject<List<Models.LocomotiveModel>>() ?? new List<Models.LocomotiveModel>();
                foreach(Models.LocomotiveModel model in locomotiveModels)
                {
                    int rowIndex = dgvLocomotiveModels.Rows.Add();
                    DataGridViewRow row = dgvLocomotiveModels.Rows[rowIndex];

                    //if (model.Image != null)
                    //{
                    //    using (Stream stream = new MemoryStream(model.Image))
                    //    {
                    //        stream.Position = 0;
                    //        ((DataGridViewImageCell)row.Cells[colImage.Name]).Value = Image.FromStream(stream);
                    //    }
                    //}

                    row.Cells[colName.Name].Value = model.Name;
                    row.Cells[colLength.Name].Value = model.Length.ToString();
                    row.Cells[colSteamPowered.Name].Value = model.IsSteamPowered;
                    row.Tag = model;

                    if (model.LocomotiveModelID == selectedLocomotiveModelID)
                    {
                        row.Selected = true;
                    }
                }

                if (dgvLocomotiveModels.SelectedRows.Count > 0 && selectedLocomotiveModelID == null) // Don't trigger if the user intentionally picked a row since they already know the ID
                {
                    lastRowSelected = -2; // Reset since it got set to the first one when we called Rows.Add()
                    dgvLocomotiveModels_SelectionChanged(this, EventArgs.Empty);
                }
            }
            finally
            {
                loader.Visible = false;
            }

            try
            {
                GetData getImage = _application.GetAccess<GetData>();
                getImage.API = DataAccess.APIs.FleetTracking;

                foreach(DataGridViewRow row in dgvLocomotiveModels.Rows)
                {
                    Models.LocomotiveModel locomotiveModel = row.Tag as Models.LocomotiveModel;
                    if (locomotiveModel == null)
                    {
                        continue;
                    }

                    getImage.Resource = $"LocomotiveModel/GetImageThumbnail/{locomotiveModel.LocomotiveModelID}";
                    byte[] imageData = await getImage.GetObject<byte[]>();
                    if (imageData != null)
                    {
                        using (Stream stream = new MemoryStream(imageData))
                        {
                            stream.Position = 0;
                            ((DataGridViewImageCell)row.Cells[colImage.Name]).Value = Image.FromStream(stream);
                        }
                    }
                }
            }
            catch { }
        }

        int lastRowSelected = -2;
        private void dgvLocomotiveModels_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLocomotiveModels.SelectedRows.OfType<DataGridViewRow>().FirstOrDefault()?.Index != lastRowSelected)
            {
                Models.LocomotiveModel locomotiveModel = dgvLocomotiveModels.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault()?.Tag as Models.LocomotiveModel;
                if (locomotiveModel != null)
                {
                    LocomotiveModelChanged?.Invoke(this, locomotiveModel);
                }

                lastRowSelected = dgvLocomotiveModels.SelectedRows.OfType<DataGridViewRow>().FirstOrDefault()?.Index ?? -2;
            }
        }
    }
}
