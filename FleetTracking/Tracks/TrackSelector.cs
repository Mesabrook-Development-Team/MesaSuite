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
using MesaSuite.Common.Utility;

namespace FleetTracking.Tracks
{
    [SecuredControl(SecuredControlAttribute.Permissions.AllowSetup, SecuredControlAttribute.Permissions.IsYardmaster)]
    public partial class TrackSelector : UserControl, IFleetTrackingControl
    {
        private FleetTrackingApplication _application;
        public FleetTrackingApplication Application { set => _application = value; }

        private List<Track> _allTracks = new List<Track>();
        public List<Track> SelectedTracks { get; set; } = new List<Track>();

        public TrackSelector()
        {
            InitializeComponent();
        }

        private async void TrackSelector_Load(object sender, EventArgs e)
        {
            ParentForm.Text = "Track Selector";

            try
            {
                loader.BringToFront();
                loader.Visible = true;

                GetData get = _application.GetAccess<GetData>();
                get.API = DataAccess.APIs.FleetTracking;
                get.Resource = "Track/GetAll";
                _allTracks = await get.GetObject<List<Track>>() ?? new List<Track>();
                PopulateCheckboxList();
            }
            finally
            {
                loader.Visible = false;
            }
        }

        private void PopulateCheckboxList()
        {
            chkTracks.Items.Clear();
            foreach (Track track in _allTracks.Where(t => t.Name.Contains(txtFilter.Text) || (t.CompanyOwner?.Name?.Contains(txtFilter.Text) ?? false) || (t.GovernmentOwner?.Name?.Contains(txtFilter.Text) ?? false)))
            {
                DropDownItem<Track> trackItem = new DropDownItem<Track>(track, $"{track.Name} ({track.CompanyOwner?.Name ?? track.GovernmentOwner?.Name})");
                bool isChecked = SelectedTracks.Any(t => t.TrackID == track.TrackID);

                chkTracks.Items.Add(trackItem, isChecked);
            }
        }

        private void txtFilter_KeyUp(object sender, KeyEventArgs e)
        {
            PopulateCheckboxList();
        }

        private void chkTracks_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            DropDownItem<Track> itemChanging = chkTracks.Items[e.Index] as DropDownItem<Track>;
            if (itemChanging == null)
            {
                return;
            }

            if (e.NewValue == CheckState.Checked && !SelectedTracks.Any(t => t.TrackID == itemChanging.Object.TrackID))
            {
                SelectedTracks.Add(itemChanging.Object);
            }
            else if (e.NewValue == CheckState.Unchecked && SelectedTracks.Any(t => t.TrackID == itemChanging.Object.TrackID))
            {
                SelectedTracks.Remove(SelectedTracks.First(t => t.TrackID == itemChanging.Object.TrackID));
            }
        }

        private void cmdSelect_Click(object sender, EventArgs e)
        {
            ParentForm.DialogResult = DialogResult.OK;
            ParentForm.Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            ParentForm.DialogResult = DialogResult.Cancel;
            ParentForm.Close();
        }
    }
}
