using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FleetTracking.Interop;
using FleetTracking.Models;
using FleetTracking.Roster;
using MesaSuite.Common.Extensions;

namespace FleetTracking.Leasing
{
    public partial class SubmitBidsStockPicker : UserControl, IFleetTrackingControl
    {
        public LeaseRequest.LeaseTypes LeaseType { get; set; }

        public long? SelectedRollingStockID { get; set; }

        public IEnumerable<long> ExcludedRollingStockIDs { get; set; }

        private RailcarList railcarList = null;
        private LocomotiveList locomotiveList = null;
        public SubmitBidsStockPicker()
        {
            InitializeComponent();
        }

        private FleetTrackingApplication _application;
        public FleetTrackingApplication Application { set => _application = value; }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            switch(LeaseType)
            {
                case LeaseRequest.LeaseTypes.Locomotive:
                    SelectedRollingStockID = locomotiveList.SelectedLocomotives.FirstOrDefault()?.LocomotiveID;
                    break;
                case LeaseRequest.LeaseTypes.Railcar:
                    SelectedRollingStockID = railcarList.SelectedRailcars?.FirstOrDefault()?.RailcarID;
                    break;
            }

            ParentForm.DialogResult = DialogResult.OK;
            ParentForm.Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            ParentForm.DialogResult = DialogResult.Cancel;
            ParentForm.Close();
        }

        private void txtFilter_KeyUp(object sender, KeyEventArgs e)
        {
            if (locomotiveList != null)
            {
                locomotiveList.ReportingMarkFilter = txtFilter.Text;
            }

            if (railcarList != null)
            {
                railcarList.ReportingMarkFilter = txtFilter.Text;
            }
        }

        private void SubmitBidsStockPicker_Load(object sender, EventArgs e)
        {
            switch (LeaseType)
            {
                case LeaseRequest.LeaseTypes.Locomotive:
                    locomotiveList = new LocomotiveList()
                    {
                        Dock = DockStyle.Fill,
                        Filter = l => _application.IsCurrentEntity(l.CompanyIDOwner, l.GovernmentIDOwner) && 
                                        l.CompanyLeasedTo?.CompanyID == null && 
                                        l.GovernmentLeasedTo?.GovernmentID == null && 
                                        !l.HasOpenBid &&
                                        (l.LocomotiveID != SelectedRollingStockID || !ExcludedRollingStockIDs.Contains(l.LocomotiveID ?? 0)),
                        Application = _application
                    };
                    pnlList.Controls.Add(locomotiveList);
                    break;
                case LeaseRequest.LeaseTypes.Railcar:
                    railcarList = new RailcarList()
                    {
                        Dock = DockStyle.Fill,
                        Filter = r => _application.IsCurrentEntity(r.CompanyIDOwner, r.GovernmentIDOwner) &&
                                        r.CompanyLeasedTo?.CompanyID == null && 
                                        r.GovernmentLeasedTo?.GovernmentID == null && 
                                        !r.HasOpenBid && 
                                        (r.RailcarID == SelectedRollingStockID || !ExcludedRollingStockIDs.Contains(r.RailcarID ?? 0)),
                        Application = _application
                    };
                    pnlList.Controls.Add(railcarList);
                    break;
            }

            ParentForm.Text = "Select Rolling Stock";
        }

        private void cmdNone_Click(object sender, EventArgs e)
        {
            SelectedRollingStockID = null;
            ParentForm.DialogResult = DialogResult.OK;
            ParentForm.Close();
        }
    }
}
