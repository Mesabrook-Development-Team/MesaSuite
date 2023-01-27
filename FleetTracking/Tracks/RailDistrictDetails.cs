using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FleetTracking.Attributes;
using FleetTracking.Interop;
using FleetTracking.Models;
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;

namespace FleetTracking.Tracks
{
    [SecuredControl(SecuredControlAttribute.Permissions.AllowSetup, SecuredControlAttribute.Permissions.IsYardmaster)]
    public partial class RailDistrictDetails : UserControl, IFleetTrackingControl
    {
        private FleetTrackingApplication _application;
        public FleetTrackingApplication Application { set => _application = value; }

        public event EventHandler OnSave;
        public long? RailDistrictID { get; set; }

        public RailDistrictDetails()
        {
            InitializeComponent();
            dataGridViewStylizer.ApplyStyle(dgvTracks);
        }

        private void RailDistrictDetails_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private async void LoadData()
        {
            dgvTracks.Rows.Clear();

            if (RailDistrictID == null)
            {
                toolSelectTracks.Enabled = false;
                return;
            }

            try
            {
                loader.BringToFront();
                loader.Visible = true;

                GetData get = _application.GetAccess<GetData>();
                get.API = DataAccess.APIs.FleetTracking;
                get.Resource = $"RailDistrict/Get/{RailDistrictID}";
                RailDistrict railDistrict = await get.GetObject<RailDistrict>() ?? new RailDistrict();
                txtName.Text = railDistrict.Name;

                foreach(Track track in railDistrict.Tracks)
                {
                    int rowIndex = dgvTracks.Rows.Add();
                    DataGridViewRow row = dgvTracks.Rows[rowIndex];

                    row.Cells[colName.Name].Value = track.Name;
                    row.Cells[colOwner.Name].Value = track.CompanyOwner?.Name ?? track.GovernmentOwner?.Name;
                    row.Tag = track;
                }

                txtName.Enabled = _application.IsCurrentEntity(railDistrict.CompanyIDOperator, railDistrict.GovernmentIDOperator);
                cmdSave.Enabled = _application.IsCurrentEntity(railDistrict.CompanyIDOperator, railDistrict.GovernmentIDOperator);
                cmdReset.Enabled = _application.IsCurrentEntity(railDistrict.CompanyIDOperator, railDistrict.GovernmentIDOperator);
                toolSelectTracks.Enabled = _application.IsCurrentEntity(railDistrict.CompanyIDOperator, railDistrict.GovernmentIDOperator);
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
                ("Name", txtName)
            }))
            {
                return;
            }

            RailDistrict railDistrict = new RailDistrict()
            {
                RailDistrictID = RailDistrictID,
                Name = txtName.Text,
                CompanyIDOperator = _application.GetCurrentCompanyIDGovernmentID().Item1,
                GovernmentIDOperator = _application.GetCurrentCompanyIDGovernmentID().Item2
            };

            if (RailDistrictID == null)
            {
                PostData post = _application.GetAccess<PostData>();
                post.API = DataAccess.APIs.FleetTracking;
                post.Resource = "RailDistrict/Post";
                post.ObjectToPost = railDistrict;
                RailDistrict savedDistrict = await post.Execute<RailDistrict>();
                if (post.RequestSuccessful)
                {
                    RailDistrictID = savedDistrict.RailDistrictID;
                    OnSave?.Invoke(this, EventArgs.Empty);
                    LoadData();
                }
            }
            else
            {
                PutData put = _application.GetAccess<PutData>();
                put.API = DataAccess.APIs.FleetTracking;
                put.Resource = "RailDistrict/Put";
                put.ObjectToPut = railDistrict;
                await put.ExecuteNoResult();
                if (put.RequestSuccessful)
                {
                    OnSave?.Invoke(this, EventArgs.Empty);
                    LoadData();
                }
            }
        }

        private async void toolSelectTracks_Click(object sender, EventArgs e)
        {
            List<Track> preSelectTracks = dgvTracks.Rows.Cast<DataGridViewRow>().Where(r => r.Tag is Track).Select(r => r.Tag as Track).ToList();
            TrackSelector selector = new TrackSelector()
            {
                Application = _application,
                SelectedTracks = preSelectTracks.ToList()
            };

            Form selectorForm = _application.OpenForm(selector, FleetTrackingApplication.OpenFormOptions.Dialog);
            if (selectorForm.DialogResult != DialogResult.OK)
            {
                return;
            }

            try
            {
                loader.BringToFront();
                loader.Visible = true;

                List<Track> addedTracks = selector.SelectedTracks.Where(t => !preSelectTracks.Any(pt => pt.TrackID == t.TrackID)).ToList();
                foreach(Track addedTrack in addedTracks)
                {
                    PatchData patchTrack = _application.GetAccess<PatchData>();
                    patchTrack.API = DataAccess.APIs.FleetTracking;
                    patchTrack.Resource = "Track/Patch";
                    patchTrack.PatchMethod = PatchData.PatchMethods.Replace;
                    patchTrack.PrimaryKey = addedTrack.TrackID;
                    patchTrack.Values = new Dictionary<string, object>()
                    {
                        { nameof(Track.RailDistrictID), RailDistrictID }
                    };
                    await patchTrack.Execute();
                    if (!patchTrack.RequestSuccessful)
                    {
                        this.ShowWarning("Not all tracks were successfully selected/deselected. Please re-run the process.");
                        return;
                    }
                }

                List<Track> deselectedTracks = preSelectTracks.Where(t => !selector.SelectedTracks.Any(st => st.TrackID == t.TrackID)).ToList();
                foreach (Track removedTrack in deselectedTracks)
                {
                    PatchData patchTrack = _application.GetAccess<PatchData>();
                    patchTrack.API = DataAccess.APIs.FleetTracking;
                    patchTrack.Resource = "Track/Patch";
                    patchTrack.PatchMethod = PatchData.PatchMethods.Replace;
                    patchTrack.PrimaryKey = removedTrack.TrackID;
                    patchTrack.Values = new Dictionary<string, object>()
                    {
                        { nameof(Track.RailDistrictID), null }
                    };
                    await patchTrack.Execute();
                    if (!patchTrack.RequestSuccessful)
                    {
                        this.ShowWarning("Not all tracks were successfully selected/deselected. Please re-run the process.");
                        return;
                    }
                }
            }
            finally
            {
                loader.Visible = false;
            }

            LoadData();
        }
    }
}
