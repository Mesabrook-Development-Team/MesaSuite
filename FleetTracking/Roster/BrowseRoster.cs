using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FleetTracking.Attributes;
using FleetTracking.Interop;
using FleetTracking.Models;
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;

namespace FleetTracking.Roster
{
    [SecuredControl(SecuredControlAttribute.Permissions.AllowSetup, SecuredControlAttribute.Permissions.IsTrainCrew, SecuredControlAttribute.Permissions.IsYardmaster)]
    public partial class BrowseRoster : UserControl, IFleetTrackingControl
    {
        private RosterList shownRosterList;

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
            shownRosterList = null;

            if (tabControl.SelectedTab == tabAll)
            {
                tabAll.Controls.Clear();

                shownRosterList = new RosterList()
                {
                    Application = _application
                };
                shownRosterList.LocomotiveSelected += RosterList_LocomotiveSelected;
                shownRosterList.RailcarSelected += RosterList_RailcarSelected;
                shownRosterList.Name = "assignedRosterList";
                tabAll.Controls.Add(shownRosterList);
                shownRosterList.Dock = DockStyle.Fill;
            }
            else if (tabControl.SelectedTab == tabOwned)
            {
                tabOwned.Controls.Clear();

                shownRosterList = new RosterList()
                {
                    Application = _application,
                    RailcarFilter = railcar => _application.IsCurrentEntity(railcar.CompanyIDOwner, railcar.GovernmentIDOwner),
                    LocomotiveFilter = loco => _application.IsCurrentEntity(loco.CompanyIDOwner, loco.GovernmentIDOwner)
                };
                shownRosterList.LocomotiveSelected += RosterList_LocomotiveSelected;
                shownRosterList.RailcarSelected += RosterList_RailcarSelected;
                shownRosterList.Name = "ownedRosterList";
                tabOwned.Controls.Add(shownRosterList);
                shownRosterList.Dock = DockStyle.Fill;
            }
            else if (tabControl.SelectedTab == tabPossessed)
            {
                tabPossessed.Controls.Clear();

                shownRosterList = new RosterList()
                {
                    Application = _application,
                    RailcarFilter = railcar => _application.IsCurrentEntity(railcar.CompanyIDPossessor, railcar.GovernmentIDPossessor),
                    LocomotiveFilter = loco => _application.IsCurrentEntity(loco.CompanyIDPossessor, loco.GovernmentIDPossessor)
                };
                shownRosterList.LocomotiveSelected += RosterList_LocomotiveSelected;
                shownRosterList.RailcarSelected += RosterList_RailcarSelected;
                shownRosterList.Name = "ownedRosterList";
                tabPossessed.Controls.Add(shownRosterList);
                shownRosterList.Dock = DockStyle.Fill;
            }
            else if (tabControl.SelectedTab == tabLeased)
            {
                tabLeased.Controls.Clear();

                shownRosterList = new RosterList()
                {
                    Application = _application,
                    RailcarFilter = railcar => _application.IsCurrentEntity(railcar.CompanyLeasedTo?.CompanyID, railcar.GovernmentLeasedTo?.GovernmentID),
                    LocomotiveFilter = loco => _application.IsCurrentEntity(loco.CompanyLeasedTo?.CompanyID, loco.GovernmentLeasedTo?.GovernmentID)
                };
                shownRosterList.LocomotiveSelected += RosterList_LocomotiveSelected;
                shownRosterList.RailcarSelected += RosterList_RailcarSelected;
                shownRosterList.Name = "leasedRosterList";
                tabLeased.Controls.Add(shownRosterList);
                shownRosterList.Dock = DockStyle.Fill;
            }
            else if (tabControl.SelectedTab == tabOnProperty)
            {
                tabOnProperty.Controls.Clear();

                shownRosterList = new RosterList()
                {
                    Application = _application,
                    RailcarFilter = railcar => _application.IsCurrentEntity(railcar.RailLocation?.Track?.CompanyIDOwner ?? railcar.RailLocation?.Train?.TrainSymbol?.CompanyIDOperator, railcar.RailLocation?.Track?.GovernmentIDOwner ?? railcar.RailLocation?.Train?.TrainSymbol?.GovernmentIDOperator),
                    LocomotiveFilter = loco => _application.IsCurrentEntity(loco.RailLocation?.Track?.CompanyIDOwner ?? loco.RailLocation?.Train?.TrainSymbol?.CompanyIDOperator, loco.RailLocation?.Track?.GovernmentIDOwner ?? loco.RailLocation?.Train?.TrainSymbol?.GovernmentIDOperator)
                };
                shownRosterList.LocomotiveSelected += RosterList_LocomotiveSelected;
                shownRosterList.RailcarSelected += RosterList_RailcarSelected;
                shownRosterList.Name = "onPropertyRosterList";
                tabOnProperty.Controls.Add(shownRosterList);
                shownRosterList.Dock = DockStyle.Fill;
            }
        }

        private void RosterList_RailcarSelected(object sender, Models.Railcar e)
        {
            splitContainer1.Panel2.Controls.Clear();

            if (e != null)
            {
                RailcarDetail detail = new RailcarDetail()
                {
                    Application = _application,
                    RailcarID = e.RailcarID
                };
                detail.Dock = DockStyle.Fill;
                detail.RailcarSaved += RailcarDetail_RailcarSaved;
                splitContainer1.Panel2.Controls.Add(detail);
            }

            UpdateMenuButtonsEnabled();
        }

        private void RailcarDetail_RailcarSaved(object sender, Railcar e)
        {
            RefreshShownList($"{e.ReportingMark}{e.ReportingNumber}");
        }

        private void RosterList_LocomotiveSelected(object sender, Models.Locomotive e)
        {
            splitContainer1.Panel2.Controls.Clear();

            if (e != null)
            {
                LocomotiveDetail detail = new LocomotiveDetail()
                {
                    Application = _application,
                    LocomotiveID = e.LocomotiveID
                };
                detail.Dock = DockStyle.Fill;
                detail.LocomotiveSaved += LocomotiveDetail_LocomotiveSaved;
                splitContainer1.Panel2.Controls.Add(detail);
            }

            UpdateMenuButtonsEnabled();
        }

        private void LocomotiveDetail_LocomotiveSaved(object sender, Models.Locomotive locomotive)
        {
            RefreshShownList($"{locomotive.ReportingMark}{locomotive.ReportingNumber}");
        }

        private void BrowseRoster_Load(object sender, EventArgs e)
        {
            AddListByTab();
        }

        private void RefreshShownList(string reportingMark)
        {
            if (shownRosterList != null)
            {
                shownRosterList.LoadData(reportingMark);
            }
        }

        private void UpdateMenuButtonsEnabled()
        {
            if (shownRosterList != null)
            {
                mnuDeleteLocomotive.Enabled = shownRosterList.SelectedLocomotives.Where(l => _application.IsCurrentEntity(l.CompanyIDOwner, l.GovernmentIDOwner)).Any();
                mnuDeleteRailcar.Enabled = shownRosterList.SelectedRailcars.Where(r => _application.IsCurrentEntity(r.CompanyIDOwner, r.GovernmentIDOwner)).Any();
            }
        }

        private void mnuAddLocomotive_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();

            LocomotiveDetail detailEntry = new LocomotiveDetail();
            detailEntry.Application = _application;
            detailEntry.LocomotiveSaved += LocomotiveDetail_LocomotiveSaved;
            detailEntry.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(detailEntry);
        }

        private void mnuAddRailcar_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();

            RailcarDetail detailEntry = new RailcarDetail();
            detailEntry.Application = _application;
            detailEntry.RailcarSaved += RailcarDetail_RailcarSaved;
            detailEntry.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(detailEntry);
        }

        private async void mnuDeleteLocomotive_Click(object sender, EventArgs e)
        {
            if (!this.Confirm("Are you sure you want to delete these Locomotives?"))
            {
                return;
            }

            loader.BringToFront();
            loader.Visible = true;

            try
            {
                List<Models.Locomotive> locosToDelete = null;
                if (shownRosterList != null)
                {
                    locosToDelete = shownRosterList.SelectedLocomotives.Where(l => _application.IsCurrentEntity(l.CompanyIDOwner, l.GovernmentIDOwner)).ToList();
                }

                if (locosToDelete == null)
                {
                    return;
                }

                foreach (Models.Locomotive locomotive in locosToDelete)
                {
                    DeleteData delete = _application.GetAccess<DeleteData>();
                    delete.API = DataAccess.APIs.FleetTracking;
                    delete.Resource = $"Locomotive/Delete/{locomotive.LocomotiveID}";
                    await delete.Execute();
                }
            }
            finally
            {
                loader.Visible = false;
            }

            RefreshShownList(null);
        }

        private async void mnuDeleteRailcar_Click(object sender, EventArgs e)
        {
            if (!this.Confirm("Are you sure you want to delete these Railcars?"))
            {
                return;
            }

            loader.BringToFront();
            loader.Visible = true;

            try
            {
                List<Models.Railcar> carsToDelete = null;
                if (shownRosterList != null)
                {
                    carsToDelete = shownRosterList.SelectedRailcars.Where(r => _application.IsCurrentEntity(r.CompanyIDOwner, r.GovernmentIDOwner)).ToList();
                }

                if (carsToDelete == null)
                {
                    return;
                }

                foreach (Models.Railcar railcar in carsToDelete)
                {
                    DeleteData delete = _application.GetAccess<DeleteData>();
                    delete.API = DataAccess.APIs.FleetTracking;
                    delete.Resource = $"Railcar/Delete/{railcar.RailcarID}";
                    await delete.Execute();
                }
            }
            finally
            {
                loader.Visible = false;
            }

            RefreshShownList(null);
        }

        private void toolMassAdd_Click(object sender, EventArgs e)
        {
            MassAddStock massAdd = new MassAddStock()
            {
                Application = _application
            };
            Form massAddForm = _application.OpenForm(massAdd);
            massAddForm.FormClosed += (s, ea) => { if (IsHandleCreated) AddListByTab(); };
        }
    }
}
