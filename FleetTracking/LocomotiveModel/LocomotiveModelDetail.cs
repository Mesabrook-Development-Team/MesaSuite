using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FleetTracking.Interop;
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;

namespace FleetTracking.LocomotiveModel
{
    public partial class LocomotiveModelDetail : UserControl, IFleetTrackingControl
    {
        public event EventHandler Save;
        private long? _locomotiveDetailID = null;
        public long? LocomotiveModelID
        {
            get => _locomotiveDetailID;
            set
            {
                _locomotiveDetailID = value;
                if (IsHandleCreated)
                {
                    LoadData();
                }
            }
        }

        private FleetTrackingApplication _application;
        public FleetTrackingApplication Application { set => _application = value; }

        public LocomotiveModelDetail()
        {
            InitializeComponent();
            dataGridViewStylizer.ApplyStyle(dgvLocomotives);
        }

        private void LocomotiveModelDetail_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {
            LoadGeneralData();
            LoadLocomotiveData();
        }

        private async void LoadGeneralData()
        {
            loaderGeneralTab.BringToFront();
            loaderGeneralTab.Visible = true;

            try
            {
                if (_locomotiveDetailID == null)
                {
                    txtName.Clear();
                    chkIsSteam.Checked = false;
                    txtFuel.Clear();
                    txtWater.Clear();
                    txtLength.Clear();
                    pboxImage.Image = null;
                    return;
                }

                GetData get = _application.GetAccess<GetData>();
                get.API = DataAccess.APIs.FleetTracking;
                get.Resource = $"LocomotiveModel/Get/{_locomotiveDetailID}";
                Models.LocomotiveModel model = await get.GetObject<Models.LocomotiveModel>();

                if (model != null)
                {
                    txtName.Text = model.Name;
                    txtFuel.Text = model.FuelCapacity?.ToString("N0");
                    txtWater.Text = model.WaterCapacity?.ToString("N0");
                    txtLength.Text = model.Length?.ToString("N1");
                    chkIsSteam.Checked = model.IsSteamPowered;
                    txtWater.Enabled = chkIsSteam.Checked;

                    get.Resource = $"LocomotiveModel/GetImage/{model.LocomotiveModelID}";
                    byte[] imageData = await get.GetObject<byte[]>();

                    if (imageData != null)
                    {
                        using(MemoryStream stream = new MemoryStream(imageData))
                        {
                            stream.Position = 0;
                            pboxImage.Image = Image.FromStream(stream);
                        }
                    }
                }
            }
            finally
            {
                loaderGeneralTab.Visible = false;
            }
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            OpenFileDialog openImage = new OpenFileDialog();
            openImage.Filter = "Images|*.bmp;*.gif;*.jpeg;*.jpg;*.png;*.tiff";
            openImage.Title = "Select Locomotive Model Image";
            openImage.Multiselect = false;
            if (openImage.ShowDialog() != DialogResult.OK || string.IsNullOrEmpty(openImage.FileName))
            {
                return;
            }

            Image image;
            using (FileStream stream = new FileStream(openImage.FileName, FileMode.Open))
            {
                MemoryStream memoryStream = new MemoryStream();
                stream.CopyTo(memoryStream);
                memoryStream.Position = 0;
                if (memoryStream.Length > 1_048_576 && !this.Confirm("The selected file is larger than 1MB, which may result in degraded performance during download.\r\n\r\nDo you want to use this file anyway?"))
                {
                    return;
                }
                image = Image.FromStream(memoryStream);
            }

            pboxImage.Image = image;
        }

        private async void cmdSave_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtFuel.Text, out int fuelCapacity))
            {
                this.ShowError("Fuel Capacity must be a valid number");
                return;
            }

            if (!int.TryParse(txtWater.Text, out int waterCapacity) && chkIsSteam.Checked)
            {
                this.ShowError("Water Capacity must be a valid number");
                return;
            }

            if (!decimal.TryParse(txtLength.Text, out decimal length))
            {
                this.ShowError("Length must be a valid number");
                return;
            }

            loaderGeneralTab.BringToFront();
            loaderGeneralTab.Visible = true;

            try
            {
                if (_locomotiveDetailID != null)
                {
                    PatchData patch = _application.GetAccess<PatchData>();
                    patch.API = DataAccess.APIs.FleetTracking;
                    patch.Resource = "LocomotiveModel/Patch";
                    patch.PatchMethod = PatchData.PatchMethods.Replace;
                    patch.PrimaryKey = _locomotiveDetailID;
                    patch.Values = new Dictionary<string, object>()
                    {
                        { nameof(Models.LocomotiveModel.Name), txtName.Text },
                        { nameof(Models.LocomotiveModel.IsSteamPowered), chkIsSteam.Checked },
                        { nameof(Models.LocomotiveModel.FuelCapacity), fuelCapacity },
                        { nameof(Models.LocomotiveModel.WaterCapacity), waterCapacity },
                        { nameof(Models.LocomotiveModel.Length), length }
                    };
                    await patch.Execute();
                    if (!patch.RequestSuccessful)
                    {
                        return;
                    }
                }
                else
                {
                    PostData post = _application.GetAccess<PostData>();
                    post.API = DataAccess.APIs.FleetTracking;
                    post.Resource = "LocomotiveModel/Post";
                    post.ObjectToPost = new Models.LocomotiveModel()
                    {
                        Name = txtName.Text,
                        IsSteamPowered = chkIsSteam.Checked,
                        FuelCapacity = fuelCapacity,
                        WaterCapacity = waterCapacity,
                        Length = length
                    };
                    Models.LocomotiveModel newModel = await post.Execute<Models.LocomotiveModel>();
                    if (!post.RequestSuccessful)
                    {
                        return;
                    }

                    _locomotiveDetailID = newModel.LocomotiveModelID;
                }

                if (pboxImage.Image != null)
                {
                    byte[] imageData;
                    using (MemoryStream stream = new MemoryStream())
                    {
                        pboxImage.Image.Save(stream, ImageFormat.Png);

                        stream.Position = 0;
                        imageData = new byte[stream.Length];
                        stream.Read(imageData, 0, imageData.Length);
                    }

                    PutData put = _application.GetAccess<PutData>();
                    put.API = DataAccess.APIs.FleetTracking;
                    put.Resource = "LocomotiveModel/UpdateImage";

                    put.ObjectToPut = new { locomotiveModelID = _locomotiveDetailID, image = imageData };
                    await put.ExecuteNoResult();
                    if (put.RequestSuccessful)
                    {
                        LoadData();
                        Save?.Invoke(this, EventArgs.Empty);
                    }
                }
                else
                {
                    LoadData();
                    Save?.Invoke(this, EventArgs.Empty);
                }
            }
            finally
            {
                loaderGeneralTab.Visible = false;
            }
        }

        private void chkIsSteam_CheckedChanged(object sender, EventArgs e)
        {
            txtWater.Enabled = chkIsSteam.Checked;
            lblFuelUnits.Text = chkIsSteam.Checked ? "fuel" : "buckets";
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private async void LoadLocomotiveData()
        {
            dgvLocomotives.Rows.Clear();

            if (LocomotiveModelID == null)
            {
                return;
            }

            try
            {
                loaderLocomotives.BringToFront();
                loaderLocomotives.Visible = true;

                GetData get = _application.GetAccess<GetData>();
                get.API = DataAccess.APIs.FleetTracking;
                get.Resource = $"Locomotive/GetByModel/{LocomotiveModelID}";
                List<Models.Locomotive> locomotives = await get.GetObject<List<Models.Locomotive>>() ?? new List<Models.Locomotive>();
                foreach (Models.Locomotive locomotive in locomotives)
                {
                    int rowIndex = dgvLocomotives.Rows.Add();
                    DataGridViewRow row = dgvLocomotives.Rows[rowIndex];
                    row.Cells[colReportingMark.Index].Value = $"{locomotive.ReportingMark}{locomotive.ReportingNumber}";
                    row.Cells[colOwner.Index].Value = locomotive.CompanyOwner?.Name ?? locomotive.GovernmentOwner?.Name;
                    row.Tag = locomotive;
                }
            }
            finally
            {
                loaderLocomotives.Visible = false;
            }

            try
            {
                GetData getImage = _application.GetAccess<GetData>();
                getImage.API = DataAccess.APIs.FleetTracking;
                foreach(DataGridViewRow row in dgvLocomotives.Rows)
                {
                    Models.Locomotive locomotive = row.Tag as Models.Locomotive;
                    if (locomotive == null)
                    {
                        continue;
                    }

                    getImage.Resource = $"Locomotive/GetImage/{locomotive.LocomotiveID}";
                    byte[] image = await getImage.GetObject<byte[]>();

                    if (image != null)
                    {
                        using (MemoryStream stream = new MemoryStream(image))
                        {
                            row.Cells[colImage.Index].Value = Image.FromStream(stream);
                        }
                    }
                }
            }
            catch { }
        }
    }
}
