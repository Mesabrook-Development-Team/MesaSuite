using System;
using System.Windows.Forms;
using FleetTracking.Interop;

namespace FleetTracking.Roster
{
    public partial class BrowseRoster : UserControl, IFleetTrackingControl
    {
        private FleetTrackingApplication _application;
        public FleetTrackingApplication Application { set => _application = value; }

        public BrowseRoster()
        {
            InitializeComponent();
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddListByTab();
        }

        private void AddListByTab()
        {
            if (tabControl.SelectedTab == tabAssigned)
            {
                tabAssigned.Controls.Clear();
                RosterList rosterList = new RosterList()
                {
                    Application = _application
                };
                rosterList.LocomotiveSelected += RosterList_LocomotiveSelected;
                rosterList.RailcarSelected += RosterList_RailcarSelected;
                tabAssigned.Controls.Add(rosterList);
                rosterList.Dock = DockStyle.Fill;
            }
        }

        private void RosterList_RailcarSelected(object sender, Models.Railcar e)
        {
            splitContainer1.Panel2.Controls.Clear();
        }

        private void RosterList_LocomotiveSelected(object sender, Models.Locomotive e)
        {
            splitContainer1.Panel2.Controls.Clear();

            LocomotiveDetail detail = new LocomotiveDetail()
            {
                Application = _application,
                LocomotiveID = e.LocomotiveID
            };
            detail.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(detail);
        }

        private void BrowseRoster_Load(object sender, EventArgs e)
        {
            AddListByTab();
        }
    }
}
