using System;
using System.Windows.Forms;
using FleetTracking.Interop;

namespace FleetTracking.Roster
{
    public partial class RosterList : UserControl, IFleetTrackingControl
    {
        private FleetTrackingApplication _application;
        public FleetTrackingApplication Application { set => _application = value; }

        public event EventHandler<Models.Locomotive> LocomotiveSelected;
        public event EventHandler<Models.Railcar> RailcarSelected;

        public RosterList()
        {
            InitializeComponent();
        }

        private void FilterCheckedChanged(object sender, EventArgs e)
        {
            AddListByFilter();
        }

        private void AddListByFilter()
        {
            panelList.Controls.Clear();

            Control controlToAdd = null;
            if (rdoAll.Checked)
            {
                controlToAdd = new RollingStockList()
                {
                    Application = _application
                };
                ((RollingStockList)controlToAdd).LocomotiveSelected += RosterList_LocomotiveSelected;
                ((RollingStockList)controlToAdd).RailcarSelected += RosterList_RailcarSelected;
            }
            else if (rdoLocomotives.Checked)
            {
                controlToAdd = new LocomotiveList()
                {
                    Application = _application
                };
                ((LocomotiveList)controlToAdd).LocomotiveSelected += RosterList_LocomotiveSelected;
            }

            if (controlToAdd == null)
            {
                return;
            }

            controlToAdd.Dock = DockStyle.Fill;
            panelList.Controls.Add(controlToAdd);
        }

        private void RosterList_RailcarSelected(object sender, Models.Railcar e)
        {
            RailcarSelected?.Invoke(this, e);
        }

        private void RosterList_LocomotiveSelected(object sender, Models.Locomotive e)
        {
            LocomotiveSelected?.Invoke(this, e);
        }

        private void RosterList_Load(object sender, EventArgs e)
        {
            AddListByFilter();
        }
    }
}
