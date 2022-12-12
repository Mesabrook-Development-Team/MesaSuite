using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FleetTracking.Interop;
using FleetTracking.Models;
using FleetTracking.Train;
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;
using MesaSuite.Common.Utility;

namespace FleetTracking.Tracks
{
    public partial class TrackViewer : UserControl, IFleetTrackingControl
    {
        public TrackViewer()
        {
            InitializeComponent();
            dataGridViewStylizer.ApplyStyle(dgvStock);
        }

        private FleetTrackingApplication _application;
        public FleetTrackingApplication Application { set => _application = value; }

        private async void TrackViewer_Load(object sender, EventArgs e)
        {
            LoadTracks();
        }

        private async void LoadTracks(long? selectedTrackID = null)
        {
            try
            {
                cboTrack.SelectedItem = null;
                cboTrack.Items.Clear();

                loaderMain.BringToFront();
                loaderMain.Visible = true;

                GetData get = _application.GetAccess<GetData>();
                get.API = DataAccess.APIs.FleetTracking;
                get.Resource = "Track/GetAll";

                List<Track> tracks = await get.GetObject<List<Track>>() ?? new List<Track>();
                foreach (Track track in tracks)
                {
                    DropDownItem<Track> trackDDI = new DropDownItem<Track>(track, track.Name);
                    cboTrack.Items.Add(trackDDI);

                    if (track.TrackID == selectedTrackID)
                    {
                        cboTrack.SelectedItem = trackDDI;
                    }
                }
            }
            finally
            {
                loaderMain.Visible = false;
            }

            cboTrack_SelectedIndexChanged(cboTrack, EventArgs.Empty);
        }

        private async void PopulateStock()
        {
            DropDownItem<Track> selectedItem = cboTrack.SelectedItem as DropDownItem<Track>;
            if (selectedItem == null)
            {
                return;
            }

            try
            {
                loaderStock.BringToFront();
                loaderStock.Visible = true;
                dgvStock.Rows.Clear();

                GetData get = _application.GetAccess<GetData>();
                get.API = DataAccess.APIs.FleetTracking;
                get.Resource = "RailLocation/GetByTrack";
                
                if (selectedItem.Object?.TrackID != null)
                {
                    get.Resource = $"RailLocation/GetByTrack/{selectedItem.Object.TrackID}";
                }
                else
                {
                    get.Resource = "RailLocation/GetByTrack";
                }
                
                List<RailLocation> railLocations = await get.GetObject<List<RailLocation>>() ?? new List<RailLocation>();
                foreach(RailLocation railLocation in railLocations)
                {
                    int rowIndex = dgvStock.Rows.Add();
                    DataGridViewRow row = dgvStock.Rows[rowIndex];
                    
                    if (railLocation.Railcar?.RailcarID != null)
                    {
                        row.Cells[colReportingMark.Name].Value = railLocation.Railcar.FormattedReportingMark;
                        row.Cells[colType.Name].Value = railLocation.Railcar.RailcarModel?.Name;
                        row.Cells[colPos.Name].Value = railLocation.Position;
                    }
                    else if (railLocation.Locomotive?.LocomotiveID != null)
                    {
                        row.Cells[colReportingMark.Name].Value = railLocation.Locomotive.FormattedReportingMark;
                        row.Cells[colType.Name].Value = railLocation.Locomotive.LocomotiveModel?.Name;
                        row.Cells[colPos.Name].Value = railLocation.Position;
                    }

                    row.Tag = railLocation;
                }
            }
            finally
            {
                loaderStock.Visible = false;
            }

            try
            {
                GetData get = _application.GetAccess<GetData>();
                get.API = DataAccess.APIs.FleetTracking;
                
                foreach(DataGridViewRow row in dgvStock.Rows)
                {
                    RailLocation railLocation = row.Tag as RailLocation;
                    if (railLocation == null)
                    {
                        continue;
                    }

                    byte[] imageData = null;
                    if (railLocation.Railcar?.RailcarID != null)
                    {
                        get.Resource = $"Railcar/GetImage/{railLocation.RailcarID}";
                        imageData = await get.GetObject<byte[]>();
                    }
                    else if (railLocation.Locomotive?.LocomotiveID != null)
                    {
                        get.Resource = $"Locomotive/GetImage/{railLocation.LocomotiveID}";
                        imageData = await get.GetObject<byte[]>();
                    }

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

        private void toolAddTrack_Click(object sender, EventArgs e)
        {
            cboTrack.SelectedItem = null;
            txtDistrict.Clear();
            txtName.Clear();
            txtName.Enabled = true;
            txtLength.Clear();
            txtLength.Enabled = true;
            cmdSave.Enabled = true;
            cmdReset.Enabled = true;
            dgvStock.Rows.Clear();

            txtName.Focus();
        }

        private async void cmdSave_Click(object sender, EventArgs e)
        {
            if (!this.AreFieldsPresent(new List<(string, Control)>()
            {
                ("Name", txtName),
                ("Length", txtLength)
            }))
            {
                return;
            }

            if (!decimal.TryParse(txtLength.Text, out decimal length))
            {
                this.ShowError("Length must be a valid number");
                return;
            }

            try
            {
                loaderMain.BringToFront();
                loaderMain.Visible = true;

                DropDownItem<Track> selectedTrack = cboTrack.SelectedItem as DropDownItem<Track>;
                Track track = new Track()
                {
                    TrackID = selectedTrack?.Object?.TrackID,
                    RailDistrictID = selectedTrack?.Object?.RailDistrictID,
                    Name = txtName.Text,
                    Length = length,
                    CompanyIDOwner = _application.GetCurrentCompanyIDGovernmentID().Item1,
                    GovernmentIDOwner = _application.GetCurrentCompanyIDGovernmentID().Item2
                };

                if (selectedTrack?.Object?.TrackID == null)
                {
                    PostData post = _application.GetAccess<PostData>();
                    post.API = DataAccess.APIs.FleetTracking;
                    post.Resource = "Track/Post";
                    post.ObjectToPost = track;
                    Track savedTrack = await post.Execute<Track>();
                    if (post.RequestSuccessful)
                    {
                        LoadTracks(savedTrack.TrackID);
                    }
                }
                else
                {
                    PutData put = _application.GetAccess<PutData>();
                    put.API = DataAccess.APIs.FleetTracking;
                    put.Resource = "Track/Put";
                    put.ObjectToPut = track;
                    await put.ExecuteNoResult();
                    if (put.RequestSuccessful)
                    {
                        LoadTracks(selectedTrack.Object.TrackID);
                    }
                }
            }
            finally
            {
                loaderMain.Visible = false;
            }
        }

        private void cboTrack_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownItem<Track> selectedTrack = cboTrack.SelectedItem as DropDownItem<Track>;
            cmdSave.Enabled = selectedTrack?.Object?.TrackID == null || _application.IsCurrentEntity(selectedTrack?.Object?.CompanyIDOwner, selectedTrack?.Object?.GovernmentIDOwner);
            cmdReset.Enabled = selectedTrack?.Object?.TrackID == null || _application.IsCurrentEntity(selectedTrack?.Object?.CompanyIDOwner, selectedTrack?.Object?.GovernmentIDOwner);
            txtName.Enabled = _application.IsCurrentEntity(selectedTrack?.Object?.CompanyIDOwner, selectedTrack?.Object?.GovernmentIDOwner);
            txtLength.Enabled = _application.IsCurrentEntity(selectedTrack?.Object?.CompanyIDOwner, selectedTrack?.Object?.GovernmentIDOwner);
            toolDeleteTrack.Enabled = _application.IsCurrentEntity(selectedTrack?.Object?.CompanyIDOwner, selectedTrack?.Object?.GovernmentIDOwner);

            if (selectedTrack?.Object?.TrackID == null)
            {
                dgvStock.Rows.Clear();
                txtDistrict.Clear();
                txtName.Clear();
                txtLength.Clear();
                return;
            }

            txtDistrict.Text = selectedTrack.Object.RailDistrict?.Name;
            txtName.Text = selectedTrack.Object.Name;
            txtLength.Text = selectedTrack.Object.Length?.ToString();

            PopulateStock();
        }

        private async void toolDeleteTrack_Click(object sender, EventArgs e)
        {
            DropDownItem<Track> selectedTrack = cboTrack.SelectedItem as DropDownItem<Track>;
            if (selectedTrack == null || !_application.IsCurrentEntity(selectedTrack.Object?.CompanyIDOwner, selectedTrack.Object?.GovernmentIDOwner))
            {
                return;
            }

            if (!this.Confirm("Are you sure you want to delete this Track?"))
            {
                return;
            }

            try
            {
                loaderMain.BringToFront();
                loaderMain.Visible = true;

                DeleteData delete = _application.GetAccess<DeleteData>();
                delete.API = DataAccess.APIs.FleetTracking;
                delete.Resource = $"Track/Delete/{selectedTrack.Object.TrackID}";
                await delete.Execute();

                if (delete.RequestSuccessful)
                {
                    LoadTracks();
                }
            }
            finally
            {
                loaderMain.Visible = false;
            }
        }

        private void toolModify_Click(object sender, EventArgs e)
        {
            DropDownItem<Track> selectedTrack = cboTrack.SelectedItem as DropDownItem<Track>;

            RailLocationModifier modifier = new RailLocationModifier()
            {
                Application = _application,
                SelectedTrackID = selectedTrack?.Object?.TrackID
            };

            _application.OpenForm(modifier, FleetTrackingApplication.OpenFormOptions.Dialog);

            PopulateStock();
        }
    }
}
