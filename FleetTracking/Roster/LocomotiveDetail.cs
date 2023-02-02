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
using FleetTracking.Models;
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;
using MesaSuite.Common.Utility;

namespace FleetTracking.Roster
{
    [SecuredControl(SecuredControlAttribute.Permissions.AllowSetup, SecuredControlAttribute.Permissions.IsTrainCrew, SecuredControlAttribute.Permissions.IsYardmaster)]
    public partial class LocomotiveDetail : UserControl, IFleetTrackingControl
    {
        public event EventHandler<Models.Locomotive> LocomotiveSaved;

        private FleetTrackingApplication _application;
        public FleetTrackingApplication Application { set => _application = value; }

        public long? LocomotiveID { get; set; }

        public LocomotiveDetail()
        {
            InitializeComponent();
        }

        private void LocomotiveDetail_Load(object sender, EventArgs e)
        {
            if (ParentForm != null)
            {
                ParentForm.Text = "Locomotive";
            }
            LoadData();
        }

        private async void LoadData()
        {
            try
            {
                loader.BringToFront();
                loader.Visible = true;

                GetData get = _application.GetAccess<GetData>();
                get.API = DataAccess.APIs.FleetTracking;

                Models.Locomotive locomotive = new Models.Locomotive();
                if (LocomotiveID != null)
                {
                    get.Resource = $"Locomotive/Get/{LocomotiveID}";
                    locomotive = await get.GetObject<Models.Locomotive>() ?? new Models.Locomotive();

                    txtReportingMark.Text = locomotive.ReportingMark;
                    txtReportingNumber.Text = locomotive.ReportingNumber?.ToString();
                    if (ParentForm != null)
                    {
                        ParentForm.Text = locomotive.FormattedReportingMark;
                    }
                    txtLessee.Text = locomotive.CompanyLeasedTo?.CompanyID != null ? locomotive.CompanyLeasedTo.Name : locomotive.GovernmentLeasedTo.Name;
                    txtCurrentLocation.Text = locomotive.Location;
                    lnkLocation.Tag = locomotive.RailLocation.TrackID != null ? (object)locomotive.RailLocation.Track : locomotive.RailLocation.Train;

                    bool isOwner = _application.IsCurrentEntity(locomotive.CompanyIDOwner, locomotive.GovernmentIDOwner);
                    bool isPossessor = _application.IsCurrentEntity(locomotive.CompanyIDPossessor, locomotive.GovernmentIDPossessor);

                    cboModel.Enabled = isOwner;
                    txtReportingMark.Enabled = isOwner;
                    txtReportingNumber.Enabled = isOwner;
                    cboOwner.Enabled = isOwner;
                    cboPossessor.Enabled = isPossessor;

                    cmdUpdateImage.Enabled = isOwner;
                }
                else
                {
                    txtCurrentLocation.Visible = false;
                    cboCurrentLocation.Visible = true;
                }

                get.Resource = "LocomotiveModel/GetAll";
                List<Models.LocomotiveModel> locomotiveModels = await get.GetObject<List<Models.LocomotiveModel>>() ?? new List<Models.LocomotiveModel>();

                foreach (Models.LocomotiveModel locomotiveModel in locomotiveModels)
                {
                    LocomotiveModel.LocomotiveModelDropDownItem ddi = new LocomotiveModel.LocomotiveModelDropDownItem()
                    {
                        Application = _application,
                        LocomotiveModelID = locomotiveModel.LocomotiveModelID
                    };
                    Label closedControl = new Label()
                    {
                        Text = locomotiveModel.Name
                    };
                    closedControl.Size = TextRenderer.MeasureText(closedControl.Text, closedControl.Font);
                    ControlSelector.ControlSelectorItem dropDownItem = new ControlSelector.ControlSelectorItem(ddi, closedControl);
                    cboModel.Items.Add(dropDownItem);

                    if (locomotiveModel.LocomotiveModelID == locomotive.LocomotiveModelID)
                    {
                        cboModel.SelectedItem = dropDownItem;
                    }
                }

                get.Resource = $"Company/GetAll";
                List<Models.Company> companies = await get.GetObject<List<Models.Company>>() ?? new List<Models.Company>();
                foreach(Models.Company company in companies)
                {
                    DropDownItem<Models.Company> dropDownItem = new DropDownItem<Models.Company>(company, company.Name);
                    cboOwner.Items.Add(dropDownItem);

                    if (locomotive.CompanyIDOwner != null && company.CompanyID == locomotive.CompanyIDOwner)
                    {
                        cboOwner.SelectedItem = dropDownItem;
                    }

                    dropDownItem = dropDownItem.CreateCopy();
                    cboPossessor.Items.Add(dropDownItem);
                    if (locomotive.CompanyIDPossessor != null && company.CompanyID == locomotive.CompanyIDPossessor)
                    {
                        cboPossessor.SelectedItem = dropDownItem;
                    }
                }

                get.Resource = $"Government/GetAll";
                List<Models.Government> governments = await get.GetObject<List<Models.Government>>() ?? new List<Models.Government>();
                foreach(Models.Government government in governments)
                {
                    DropDownItem<Models.Government> dropDownItem = new DropDownItem<Models.Government>(government, government.Name);
                    cboOwner.Items.Add(dropDownItem);

                    if (locomotive.GovernmentIDOwner != null && locomotive.GovernmentIDOwner == government.GovernmentID)
                    {
                        cboOwner.SelectedItem = dropDownItem;
                    }

                    dropDownItem = dropDownItem.CreateCopy();
                    cboPossessor.Items.Add(dropDownItem);
                    if (locomotive.GovernmentIDPossessor != null && government.GovernmentID == locomotive.GovernmentIDPossessor)
                    {
                        cboPossessor.SelectedItem = dropDownItem;
                    }
                }

                get.Resource = "Track/GetAll";
                List<Track> tracks = await get.GetObject<List<Track>>() ?? new List<Track>();
                foreach(Track track in tracks)
                {
                    DropDownItem<Track> ddi = new DropDownItem<Track>(track, track.Name);
                    cboCurrentLocation.Items.Add(ddi);
                }
            }
            finally
            {
                loader.Visible = false;
            }

            if (LocomotiveID != null)
            {
                try
                {
                    GetData get = _application.GetAccess<GetData>();
                    get.API = DataAccess.APIs.FleetTracking;
                    get.Resource = $"Locomotive/GetImage/{LocomotiveID}";
                    byte[] imageData = await get.GetObject<byte[]>();

                    if (imageData != null)
                    {
                        MemoryStream stream = new MemoryStream(imageData);
                        Image image = Image.FromStream(stream);
                        pboxImage.Image = image;
                    }
                }
                catch { }
            }
        }

        private async void cmdSave_Click(object sender, EventArgs e)
        {
            if (cboModel.SelectedItem == null)
            {
                this.ShowError("Locomotive Model is a required field");
                return;
            }

            if (string.IsNullOrEmpty(txtReportingMark.Text) || string.IsNullOrEmpty(txtReportingNumber.Text))
            {
                this.ShowError("Reporting Mark is a required field");
                return;
            }

            if (!int.TryParse(txtReportingNumber.Text, out int reportingNumber) || reportingNumber < 0 || reportingNumber > 999999)
            {
                this.ShowError("Reporting Number is invalid");
                return;
            }

            if (cboOwner.SelectedItem == null)
            {
                this.ShowError("Owner is a required field");
                return;
            }

            if (cboPossessor.SelectedItem == null)
            {
                this.ShowError("Possessor is a required field");
                return;
            }

            if (LocomotiveID == null && cboCurrentLocation.SelectedItem == null)
            {
                this.ShowError("Current Location is a required field");
                return;
            }

            ControlSelector.ControlSelectorItem selectedModelItem = cboModel.SelectedItem as ControlSelector.ControlSelectorItem;
            long? modelID = ((LocomotiveModel.LocomotiveModelDropDownItem)selectedModelItem.DropDownControl).LocomotiveModelID;
            long? governmentIDOwner = null;
            long? companyIDOwner = null;
            long? governmentIDPossessor = null;
            long? companyIDPossessor = null;
            if (cboOwner.SelectedItem is DropDownItem<Models.Government> government)
            {
                governmentIDOwner = government.Object.GovernmentID;
            }
            else if (cboOwner.SelectedItem is DropDownItem<Models.Company> company)
            {
                companyIDOwner = company.Object.CompanyID;
            }

            if (cboPossessor.SelectedItem is DropDownItem<Models.Government> governmentPossessor)
            {
                governmentIDPossessor = governmentPossessor.Object.GovernmentID;
            }
            else if (cboPossessor.SelectedItem is DropDownItem<Models.Company> company)
            {
                companyIDPossessor = company.Object.CompanyID;
            }

            Models.Locomotive locomotive = new Models.Locomotive()
            {
                LocomotiveID = this.LocomotiveID,
                GovernmentIDOwner = governmentIDOwner,
                CompanyIDOwner = companyIDOwner,
                GovernmentIDPossessor = governmentIDPossessor,
                CompanyIDPossessor = companyIDPossessor,
                LocomotiveModelID = modelID,
                ReportingMark = txtReportingMark.Text,
                ReportingNumber = reportingNumber
            };

            bool saveSuccessful = false;
            if (LocomotiveID == null)
            {
                PostData post = _application.GetAccess<PostData>();
                post.API = DataAccess.APIs.FleetTracking;
                post.Resource = "Locomotive/Post";
                post.ObjectToPost = locomotive;
                locomotive = await post.Execute<Models.Locomotive>();
                saveSuccessful = post.RequestSuccessful;
            }
            else
            {
                PutData put = _application.GetAccess<PutData>();
                put.API = DataAccess.APIs.FleetTracking;
                put.Resource = "Locomotive/Put";
                put.ObjectToPut = locomotive;
                await put.ExecuteNoResult();
                saveSuccessful = put.RequestSuccessful;
            }

            if (saveSuccessful && pboxImage.Image != null)
            {
                byte[] imageData;
                using (MemoryStream stream = new MemoryStream())
                {
                    pboxImage.Image.Save(stream, ImageFormat.Png);
                    stream.Position = 0;

                    imageData = new byte[stream.Length];
                    stream.Read(imageData, 0, (int)stream.Length);
                }
                
                PutData updateImage = _application.GetAccess<PutData>();
                updateImage.API = DataAccess.APIs.FleetTracking;
                updateImage.Resource = "Locomotive/UpdateImage";
                updateImage.ObjectToPut = new { locomotiveID = locomotive.LocomotiveID, image = imageData };
                await updateImage.ExecuteNoResult();
            }

            if (saveSuccessful && LocomotiveID == null)
            {
                GetData get = _application.GetAccess<GetData>();
                get.API = DataAccess.APIs.FleetTracking;
                get.Resource = $"RailLocation/GetForLocomotive/{locomotive.LocomotiveID}";

                RailLocation railLocation = await get.GetObject<RailLocation>();
                if (railLocation != null)
                {
                    railLocation.TrackID = cboCurrentLocation.SelectedItem.Cast<DropDownItem<Track>>().Object.TrackID;
                    railLocation.Position = int.MaxValue;

                    get.Resource = $"RailLocation/GetByTrack/{railLocation.TrackID}";
                    List<RailLocation> railLocations = await get.GetObject<List<RailLocation>>() ?? new List<RailLocation>();
                    railLocations.Add(railLocation);

                    PutData modify = _application.GetAccess<PutData>();
                    modify.API = DataAccess.APIs.FleetTracking;
                    modify.Resource = "RailLocation/Modify";
                    modify.ObjectToPut = new
                    {
                        ModifiedTracksByID = new Dictionary<long?, List<RailLocation>>() { { railLocation.TrackID, railLocations } },
                        TimeMoved = DateTime.Now
                    };
                    await modify.ExecuteNoResult();
                    saveSuccessful = modify.RequestSuccessful;
                }
            }
            
            if (saveSuccessful)
            {
                LocomotiveSaved?.Invoke(this, locomotive);
            }
        }

        private void cmdUpdateImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openImage = new OpenFileDialog();
            openImage.Filter = "Images|*.bmp;*.gif;*.jpeg;*.jpg;*.png;*.tiff";
            openImage.Title = "Select Locomotive Image";
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

        private void lnkLocation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lnkLocation.Tag == null)
            {
                return;
            }

            if (lnkLocation.Tag is Track track)
            {
                Tracks.TrackViewer viewer = new Tracks.TrackViewer()
                {
                    Application = _application,
                    InitialTrackID = track.TrackID
                };

                _application.OpenForm(viewer);
            }

            if (lnkLocation.Tag is Models.Train train)
            {
                Train.InProgressTrainDisplay trainDisplay = new Train.InProgressTrainDisplay()
                {
                    Application = _application,
                    TrainID = train.TrainID
                };

                _application.OpenForm(trainDisplay, FleetTrackingApplication.OpenFormOptions.Popout);
            }
        }

        private void cmdReset_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
