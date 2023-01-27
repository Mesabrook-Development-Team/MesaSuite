using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FleetTracking.Attributes;
using FleetTracking.Interop;

namespace FleetTracking.Roster
{
    [SecuredControl(SecuredControlAttribute.Permissions.AllowSetup, SecuredControlAttribute.Permissions.IsTrainCrew, SecuredControlAttribute.Permissions.IsYardmaster)]
    public partial class RosterList : UserControl, IFleetTrackingControl
    {
        private FleetTrackingApplication _application;
        public FleetTrackingApplication Application { set => _application = value; }

        public event EventHandler<Models.Locomotive> LocomotiveSelected;
        public event EventHandler<Models.Railcar> RailcarSelected;

        public Func<Models.Locomotive, bool> LocomotiveFilter { private get; set; }
        public Func<Models.Railcar, bool> RailcarFilter { private get; set; }

        public IReadOnlyCollection<Models.Locomotive> SelectedLocomotives
        {
            get
            {
                if (panelList.Controls.Count <= 0)
                {
                    return new List<Models.Locomotive>();
                }

                if (panelList.Controls[0] is RollingStockList rollingStockList)
                {
                    return rollingStockList.SelectedLocomotives;
                }

                if (panelList.Controls[0] is LocomotiveList locomotiveList)
                {
                    return locomotiveList.SelectedLocomotives;
                }

                return new List<Models.Locomotive>();
            }
        }

        public IReadOnlyCollection<Models.Railcar> SelectedRailcars
        {
            get
            {
                if (panelList.Controls.Count <= 0)
                {
                    return new List<Models.Railcar>();
                }

                if (panelList.Controls[0] is RollingStockList rollingStockList)
                {
                    return rollingStockList.SelectedRailcars;
                }

                if (panelList.Controls[0] is RailcarList railcarList)
                {
                    return railcarList.SelectedRailcars;
                }

                return new List<Models.Railcar>();
            }
        }

        public RosterList()
        {
            InitializeComponent();
        }

        private void FilterCheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton radioButton && !radioButton.Checked)
            {
                return;
            }

            AddListByFilter();
        }

        private void AddListByFilter()
        {
            panelList.Controls.Clear();
            LocomotiveSelected?.Invoke(this, null);
            RailcarSelected?.Invoke(this, null);

            Control controlToAdd = null;
            if (rdoAll.Checked)
            {
                RollingStockList rollingStockList = new RollingStockList()
                {
                    Application = _application
                };
                rollingStockList.LocomotiveSelected += RosterList_LocomotiveSelected;
                rollingStockList.RailcarSelected += RosterList_RailcarSelected;
                rollingStockList.RailcarFilter = RailcarFilter;
                rollingStockList.LocomotiveFilter = LocomotiveFilter;

                controlToAdd = rollingStockList;
            }
            else if (rdoLocomotives.Checked)
            {
                LocomotiveList locomotiveList = new LocomotiveList()
                {
                    Application = _application
                };
                locomotiveList.LocomotiveSelected += RosterList_LocomotiveSelected;
                locomotiveList.Filter = LocomotiveFilter;

                controlToAdd = locomotiveList;
            }
            else if (rdoRailcars.Checked)
            {
                RailcarList railcarList = new RailcarList()
                {
                    Application = _application
                };
                railcarList.RailcarSelected += RosterList_RailcarSelected;
                railcarList.Filter = RailcarFilter;

                controlToAdd = railcarList;
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

        public void LoadData(string selectedReportingMark = null)
        {
            if (panelList.Controls.Count == 0)
            {
                return;
            }

            Control listControl = panelList.Controls[0];
            if (listControl is RollingStockList rollingStockList)
            {
                rollingStockList.LoadData(selectedReportingMark);
            }

            if (listControl is LocomotiveList locomotiveList)
            {
                locomotiveList.LoadData(selectedReportingMark);
            }

            if (listControl is RailcarList railcarList)
            {
                railcarList.LoadData(selectedReportingMark);
            }
        }
    }
}
