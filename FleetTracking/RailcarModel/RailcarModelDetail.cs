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
using FleetTracking.Attributes;
using FleetTracking.Interop;
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;
using MesaSuite.Common.Utility;

namespace FleetTracking.RailcarModel
{
    [SecuredControl(SecuredControlAttribute.Permissions.AllowSetup)]
    public partial class RailcarModelDetail : UserControl, IFleetTrackingControl
    {
        public event EventHandler<Models.RailcarModel> RailcarModelSaved;

        private FleetTrackingApplication _application;
        public FleetTrackingApplication Application { set => _application = value; }

        public long? RailcarModelID { get; set; }

        public RailcarModelDetail()
        {
            InitializeComponent();
            dataGridViewStylizer.ApplyStyle(dgvRailcars);

            foreach (Models.RailcarModel.Types type in Enum.GetValues(typeof(Models.RailcarModel.Types)))
            {
                DropDownItem<Models.RailcarModel.Types> ddi = new DropDownItem<Models.RailcarModel.Types>(type, type.ToString().ToDisplayName());
                cboType.Items.Add(ddi);
            }
        }

        private void RailcarModelDetail_Load(object sender, EventArgs e)
        {
            LoadGeneralData();
        }

        public async Task LoadGeneralData()
        {
            loaderGeneral.BringToFront();
            loaderGeneral.Visible = true;

            try
            {
                if (RailcarModelID != null)
                {
                    GetData getData = _application.GetAccess<GetData>();
                    getData.API = DataAccess.APIs.FleetTracking;
                    getData.Resource = $"RailcarModel/Get/{RailcarModelID}";
                    Models.RailcarModel railcarModel = await getData.GetObject<Models.RailcarModel>() ?? new Models.RailcarModel();

                    txtName.Text = railcarModel.Name;
                    txtCargoCapacity.Text = railcarModel.CargoCapacity?.ToString() ?? "0";
                    txtLength.Text = railcarModel.Length?.ToString() ?? "0";
                    cboType.SelectedItem = cboType.Items.OfType<DropDownItem<Models.RailcarModel.Types>>().FirstOrDefault(ddi => ddi.Object == railcarModel.Type);

                    getData.Resource = $"RailcarModel/GetImage/{RailcarModelID}";
                    byte[] imageData = await getData.GetObject<byte[]>();
                    if (imageData != null)
                    {
                        MemoryStream memoryStream = new MemoryStream(imageData);
                        Image image = Image.FromStream(memoryStream);
                        pboxImage.Image = image;
                    }
                }
            }
            finally
            {
                loaderGeneral.Visible = false;
            }
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            OpenFileDialog openImage = new OpenFileDialog();
            openImage.Filter = "Images|*.bmp;*.gif;*.jpeg;*.jpg;*.png;*.tiff";
            openImage.Title = "Select Railcar Model Image";
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
            if (!this.AreFieldsPresent(new List<(string, Control)>()
            {
                ("Name", txtName),
                ("Cargo Capacity", txtCargoCapacity),
                ("Length", txtLength),
                ("Type", cboType)
            }))
            {
                return;
            }

            if (!decimal.TryParse(txtCargoCapacity.Text, out decimal cargoCapacity))
            {
                this.ShowError("Cargo Capacity must be a valid number");
                return;
            }

            if (!decimal.TryParse(txtLength.Text, out decimal length))
            {
                this.ShowError("Length must be a valid number");
                return;
            }

            loaderGeneral.BringToFront();
            loaderGeneral.Visible = true;

            try
            {
                Models.RailcarModel railcarModel = new Models.RailcarModel()
                {
                    RailcarModelID = RailcarModelID,
                    CargoCapacity = cargoCapacity,
                    Length = length,
                    Name = txtName.Text,
                    Type = cboType.SelectedItem.Cast<DropDownItem<Models.RailcarModel.Types>>().Object
                };

                bool saveSuccessful = false;
                if (RailcarModelID == null)
                {
                    PostData post = _application.GetAccess<PostData>();
                    post.API = DataAccess.APIs.FleetTracking;
                    post.Resource = "RailcarModel/Post";
                    post.ObjectToPost = railcarModel;
                    railcarModel = await post.Execute<Models.RailcarModel>();
                    saveSuccessful = post.RequestSuccessful;
                }
                else
                {
                    PutData put = _application.GetAccess<PutData>();
                    put.API = DataAccess.APIs.FleetTracking;
                    put.Resource = "RailcarModel/Put";
                    put.ObjectToPut = railcarModel;
                    await put.ExecuteNoResult();
                    saveSuccessful = put.RequestSuccessful;
                }

                if (!saveSuccessful)
                {
                    return;
                }

                if (pboxImage.Image != null)
                {
                    byte[] imageData;
                    using (MemoryStream stream = new MemoryStream())
                    {
                        pboxImage.Image.Save(stream, ImageFormat.Png);
                        stream.Position = 0;

                        imageData = stream.ToArray();
                    }

                    PutData putImage = _application.GetAccess<PutData>();
                    putImage.API = DataAccess.APIs.FleetTracking;
                    putImage.Resource = "RailcarModel/UpdateImage";
                    putImage.ObjectToPut = new
                    {
                        railcarModelID = railcarModel.RailcarModelID,
                        image = imageData
                    };
                    await putImage.ExecuteNoResult();

                    saveSuccessful = putImage.RequestSuccessful;
                }

                if (saveSuccessful)
                {
                    RailcarModelSaved?.Invoke(this, railcarModel);
                }
            }
            finally
            {
                loaderGeneral.Visible = false;
            }
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == tabGeneral)
            {
                LoadGeneralData();
            }

            if (tabControl.SelectedTab == tabRailcars)
            {
                LoadRailcars();
            }
        }

        private async Task LoadRailcars()
        {
            loaderRailcars.BringToFront();
            loaderRailcars.Visible = true;

            try
            {
                dgvRailcars.Rows.Clear();

                if (RailcarModelID == null)
                {
                    return;
                }

                GetData get = _application.GetAccess<GetData>();
                get.API = DataAccess.APIs.FleetTracking;
                get.Resource = $"Railcar/GetByModel/{RailcarModelID}";

                List<Models.Railcar> railcars = await get.GetObject<List<Models.Railcar>>() ?? new List<Models.Railcar>();
                foreach(Models.Railcar railcar in railcars)
                {
                    int rowIndex = dgvRailcars.Rows.Add();
                    DataGridViewRow row = dgvRailcars.Rows[rowIndex];

                    row.Cells[colReportingMark.Name].Value = $"{railcar.ReportingMark}{railcar.ReportingNumber}";
                    row.Cells[colOwner.Name].Value = $"{railcar.CompanyOwner?.Name ?? railcar.GovernmentOwner?.Name}";
                    row.Tag = railcar;
                }
            }
            finally
            {
                loaderRailcars.Visible = false;
            }

            try
            {
                GetData get = _application.GetAccess<GetData>();
                get.API = DataAccess.APIs.FleetTracking;

                foreach(DataGridViewRow row in dgvRailcars.Rows)
                {
                    Models.Railcar railcar = row.Tag as Models.Railcar;
                    if (railcar == null)
                    {
                        continue;
                    }

                    get.Resource = $"Railcar/GetImage/{railcar.RailcarID}";
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

        private void dgvRailcars_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvRailcars.Rows.Count)
            {
                return;
            }

            DataGridViewRow row = dgvRailcars.Rows[e.RowIndex];
            Models.Railcar railcar = row.Tag as Models.Railcar;
            if (railcar == null)
            {
                return;
            }

            Roster.RailcarDetail detail = new Roster.RailcarDetail()
            {
                Application = _application,
                RailcarID = railcar.RailcarID
            };
            _application.OpenForm(detail);
        }

        private void cmdReset_Click(object sender, EventArgs e)
        {
            LoadGeneralData();
        }
    }
}
