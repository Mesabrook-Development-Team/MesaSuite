using FleetTracking.Interop;
using FleetTracking.Models;
using MesaSuite.Common;
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FleetTracking.Tracks
{
    [ToolboxItem(false)]
    public partial class TrackExplorer : UserControl, IFleetTrackingControl
    {
        private List<Track> Tracks { get; set; } = new List<Track>();
        private TrackViewer trackViewer;
        private FleetTrackingApplication application;

        private TrackExplorerGrouping _grouping = TrackExplorerGrouping.None;
        private TrackExplorerGrouping Grouping
        {
            get => _grouping;
            set
            {
                _grouping = value;
                toolNoGroup.Checked = _grouping == TrackExplorerGrouping.None;
                toolGroupOwner.Checked = _grouping == TrackExplorerGrouping.Owner;
                toolGroupDistrict.Checked = _grouping == TrackExplorerGrouping.District;
            }
        }

        public TrackExplorer()
        {
            InitializeComponent();
            toolNoGroup.Tag = TrackExplorerGrouping.None;
            toolGroupOwner.Tag = TrackExplorerGrouping.Owner;
            toolGroupDistrict.Tag = TrackExplorerGrouping.District;

            Dictionary<string, object> preferences = UserPreferences.Get().GetPreferencesForSection("fleet");
            string trackExplorerGrouping = preferences.GetOrSetDefault("TrackExplorerGrouping", TrackExplorerGrouping.None.ToString()) as string;
            if (Enum.TryParse(trackExplorerGrouping, out TrackExplorerGrouping grouping))
            {
                Grouping = grouping;
            }

            trackViewer = new TrackViewer();
            splitContainer1.Panel1.Controls.Add(trackViewer);
            trackViewer.Dock = DockStyle.Fill;
            trackViewer.TrackModified += (_, __) => ReloadData();
        }

        public FleetTrackingApplication Application 
        {
            private get => application; 
            set
            {
                application = value;
                trackViewer.Application = value;
            }
        }

        private async void TrackExplorer_Load(object sender, EventArgs e)
        {
            if (ParentForm != null)
            {
                ParentForm.Text = "Track Explorer";
            }
            await ReloadData();
        }

        private async Task ReloadData()
        {
            using (GetLoadVisualHandler())
            {
                GetData get = new GetData(DataAccess.APIs.FleetTracking, "Track/GetAll");
                Tracks = await get.GetObject<List<Track>>() ?? new List<Track>();
            }

            RefreshTree();
        }

        private LoadVisualHandler GetLoadVisualHandler()
        {
            return new LoadVisualHandler(loader, toolStrip1, treTracks);
        }

        private void RefreshTree()
        {
            treTracks.Nodes.Clear();

            Dictionary<long, TreeNode> groupedTreeNodes = null;
            if (Grouping != TrackExplorerGrouping.None)
            {
                groupedTreeNodes = new Dictionary<long, TreeNode>();
            }

            foreach(Track track in Tracks.OrderBy(t => t.Name))
            {
                if (!string.IsNullOrEmpty(txtSearch.Text) && 
                    !track.Name.Contains(txtSearch.Text, StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                TreeNode trackNode = new TreeNode(track.Name);
                trackNode.Tag = track;
                TreeNode parentNode = null;
                switch(Grouping)
                {
                    case TrackExplorerGrouping.Owner:
                        long ownerID = track.CompanyIDOwner ?? track.GovernmentIDOwner ?? 0;
                        if (!groupedTreeNodes.ContainsKey(ownerID))
                        {
                            string ownerName = track.CompanyOwner?.Name ?? track.GovernmentOwner?.Name ?? "Unknown Owner";
                            TreeNode ownerNode = new TreeNode(ownerName);
                            treTracks.Nodes.Add(ownerNode);
                            groupedTreeNodes[ownerID] = ownerNode;
                        }
                        parentNode = groupedTreeNodes[ownerID];
                        break;
                    case TrackExplorerGrouping.District:
                        long districtID = track.RailDistrictID ?? 0;
                        if (!groupedTreeNodes.ContainsKey(districtID))
                        {
                            string districtName = $"{track.RailDistrict?.Name} ({track.RailDistrict?.CompanyOperator?.Name ?? track.RailDistrict?.GovernmentOperator?.Name})" ?? "Unknown District";
                            TreeNode districtNode = new TreeNode(districtName);
                            treTracks.Nodes.Add(districtNode);
                            groupedTreeNodes[districtID] = districtNode;
                        }
                        parentNode = groupedTreeNodes[districtID];
                        break;
                }

                if (parentNode != null)
                {
                    parentNode.Nodes.Add(trackNode);
                }
                else
                {
                    treTracks.Nodes.Add(trackNode);
                }
            }

            treTracks.Sort();
        }

        private enum TrackExplorerGrouping
        {
            None,
            Owner,
            District
        }

        private void toolGroup_Click(object sender, EventArgs e)
        {
            if (!(sender is ToolStripMenuItem menuItem) || !(menuItem.Tag is TrackExplorerGrouping grouping))
            {
                return;
            }

            Grouping = grouping;
            FleetTrackingApplication.GetUserPreferences()["TrackExplorerGrouping"] = Grouping.ToString();
            UserPreferences.Get().Save();
            RefreshTree();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            RefreshTree();
        }

        private void treTracks_AfterSelect(object sender, TreeViewEventArgs e)
        {
            toolDelete.Enabled = false;
            if (!(e.Node?.Tag is Track track))
            {
                return;
            }

            (long? CompanyID, long? GovernmentID) currentEntities = Application.GetCurrentCompanyIDGovernmentID();
            toolDelete.Enabled = (track.CompanyIDOwner != null && track.CompanyIDOwner == currentEntities.CompanyID) ||
                                 (track.GovernmentIDOwner != null && track.GovernmentIDOwner == currentEntities.GovernmentID);

            trackViewer.SetShownTrackID(track.TrackID);
        }

        private void toolAdd_Click(object sender, EventArgs e)
        {
            trackViewer.SetShownTrackID(null);
        }

        private async void toolDelete_Click(object sender, EventArgs e)
        {
            if (!(treTracks.SelectedNode?.Tag is Track track))
            {
                return;
            }

            if (!this.Confirm("Are you sure you want to delete this Track?"))
            {
                return;
            }

            using (GetLoadVisualHandler())
            {
                DeleteData delete = new DeleteData(DataAccess.APIs.FleetTracking, $"Track/Delete/{track.TrackID}");
                await delete.Execute();
            }

            toolDelete.Enabled = false;

            ReloadData();

            trackViewer.LoadTracks();
        }
    }
}
