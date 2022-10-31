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
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;
using MesaSuite.Common.Utility;

namespace FleetTracking.Leasing
{
    public partial class SubmitBidsDetail : UserControl, IFleetTrackingControl
    {
        public SubmitBidsDetail()
        {
            InitializeComponent();

            dataGridViewStylizer.ApplyStyle(dgvRequests);
            dgvRequests.MultiSelect = true;
        }

        private FleetTrackingApplication _application;
        public FleetTrackingApplication Application { set => _application = value; }

        public delegate List<long> SelectedStockIDsDelegate();
        public delegate List<long> SelectedRailcarsDelegate();
        public SelectedStockIDsDelegate GetSelectedLocomotivesCallback { get; set; }
        public SelectedStockIDsDelegate GetSelectedRailcarsCallback { get; set; }

        public IEnumerable<LeaseRequest> SelectedLeaseRequests
        {
            get
            {
                foreach(DataGridViewRow row in dgvRequests.SelectedRows)
                {
                    yield return row.Tag as LeaseRequest;
                }
            }
        }

        public IEnumerable<LeaseRequest> AllLeaseRequests
        {
            get
            {
                foreach (DataGridViewRow row in dgvRequests.Rows)
                {
                    yield return row.Tag as LeaseRequest;
                }
            }
        }

        private async void dgvRequests_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != colRollingStock.Index)
            {
                return;
            }

            LeaseRequest request = dgvRequests.Rows[e.RowIndex].Tag as LeaseRequest;
            if (request == null)
            {
                return;
            }

            long? currentRollingStockID = dgvRequests[e.ColumnIndex, e.RowIndex].Tag as long?;

            SubmitBidsStockPicker stockPicker = new SubmitBidsStockPicker()
            {
                Application = _application,
                LeaseType = request.LeaseType,
                RailcarType = request.RailcarType,
                ExcludedRollingStockIDs = request.LeaseType == LeaseRequest.LeaseTypes.Locomotive ? GetSelectedLocomotiveIDs().Concat(GetSelectedLocomotivesCallback?.Invoke()) : GetSelectedRailcarIDs().Concat(GetSelectedRailcarsCallback?.Invoke()),
                SelectedRollingStockID = currentRollingStockID
            };
            Form pickerForm = _application.OpenForm(stockPicker, FleetTrackingApplication.OpenFormOptions.Dialog | FleetTrackingApplication.OpenFormOptions.ResizeToControl);
            if (pickerForm.DialogResult != DialogResult.OK)
            {
                return;
            }

            DataGridViewButtonCell buttonCell = (DataGridViewButtonCell)dgvRequests[e.ColumnIndex, e.RowIndex];
            buttonCell.Tag = stockPicker.SelectedRollingStockID;

            if (stockPicker.SelectedRollingStockID == null)
            {
                buttonCell.Value = "[click to select]";
            }
            else
            {
                GetData get = _application.GetAccess<GetData>();
                get.API = DataAccess.APIs.FleetTracking;

                switch (request.LeaseType)
                {
                    case LeaseRequest.LeaseTypes.Locomotive:
                        get.Resource = $"Locomotive/Get/{stockPicker.SelectedRollingStockID}";
                        Locomotive locomotive = await get.GetObject<Locomotive>();
                        buttonCell.Value = locomotive?.FormattedReportingMark ?? "[click to select]";
                        break;
                    case LeaseRequest.LeaseTypes.Railcar:
                        get.Resource = $"Railcar/Get/{stockPicker.SelectedRollingStockID}";
                        Railcar railcar = await get.GetObject<Railcar>();
                        buttonCell.Value = railcar?.FormattedReportingMark ?? "[click to select]";
                        break;
                }
            }
        }

        private void dgvRequests_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvRequests.Rows[e.RowIndex];
            LeaseRequest request = row.Tag as LeaseRequest;
            if (request == null)
            {
                return;
            }

            LeaseRequestDetail detail = new LeaseRequestDetail()
            {
                Application = _application,
                LeaseRequestID = request.LeaseRequestID
            };
            Form detailForm = _application.OpenForm(detail);
            detailForm.Text = $"({request.LeaseRequestID}) Lease Request";
        }

        public void AddLeaseRequest(LeaseRequest leaseRequest)
        {
            int rowIndex = dgvRequests.Rows.Add();

            DataGridViewRow row = dgvRequests.Rows[rowIndex];
            row.Cells[colLeaseRequest.Name].Value = $"({leaseRequest.LeaseRequestID}) {leaseRequest.CompanyRequester.Name}{leaseRequest.GovernmentRequester.Name}";
            row.Cells[colType.Name].Value = leaseRequest.LeaseType.ToString().ToDisplayName();
            row.Cells[colEndTime.Name].Value = leaseRequest.BidEndTime?.ToString("MM/dd/yyyy HH:mm");
            row.Cells[colPurpose.Name].Value = leaseRequest.Purpose;
            row.Cells[colRollingStock.Name].Value = "[click to select]";
            row.Tag = leaseRequest;
        }

        public void RemoveSelectedRequests()
        {
            foreach(DataGridViewRow row in dgvRequests.SelectedRows.OfType<DataGridViewRow>().ToList())
            {
                dgvRequests.Rows.Remove(row);
            }
        }

        public IEnumerable<long> GetSelectedLocomotiveIDs()
        {
            foreach(DataGridViewRow row in dgvRequests.Rows)
            {
                LeaseRequest request = row.Tag as LeaseRequest;
                if (request == null || request.LeaseType != LeaseRequest.LeaseTypes.Locomotive || !(row.Cells[colRollingStock.Name].Tag is long locomotiveID))
                {
                    continue;
                }

                yield return locomotiveID;
            }
        }

        public IEnumerable<long> GetSelectedRailcarIDs()
        {
            foreach (DataGridViewRow row in dgvRequests.Rows)
            {
                LeaseRequest request = row.Tag as LeaseRequest;
                if (request == null || request.LeaseType != LeaseRequest.LeaseTypes.Railcar || !(row.Cells[colRollingStock.Name].Tag is long railcarID))
                {
                    continue;
                }

                yield return railcarID;
            }
        }

        private async void SubmitBidsDetail_Load(object sender, EventArgs e)
        {
            try
            {
                loader.BringToFront();
                loader.Visible = true;

                long? companyID = _application.GetCurrentCompanyIDGovernmentID().Item1;

                if (companyID != null)
                {
                    lblReceivedTo.Visible = true;
                    cboReceivedTo.Visible = true;

                    GetData get = _application.GetAccess<GetData>();
                    get.API = DataAccess.APIs.FleetTracking;
                    get.Resource = $"Company/Get/{companyID}";

                    Company company = await get.GetObject<Company>();
                    if (company != null && company.Locations != null)
                    {
                        foreach(Location location in company.Locations)
                        {
                            DropDownItem<Location> locationDDI = new DropDownItem<Location>(location, location.Name);
                            cboReceivedTo.Items.Add(locationDDI);
                        }
                    }
                }

                foreach(LeaseBid.RecurringAmountTypes recurringType in Enum.GetValues(typeof(LeaseBid.RecurringAmountTypes)))
                {
                    DropDownItem<LeaseBid.RecurringAmountTypes> recurringTypeDDI = new DropDownItem<LeaseBid.RecurringAmountTypes>(recurringType, recurringType.ToString().ToDisplayName());
                    cboRecurringBilling.Items.Add(recurringTypeDDI);
                }
            }
            finally
            {
                loader.Visible = false;
            }
        }

        public bool ValidateScreen()
        {
            if (!this.AreFieldsPresent(new List<(string, Control)>()
            {
                ("Lease Amount", txtLeaseAmount),
                ("Recurring Billing", cboRecurringBilling)
            }))
            {
                return false;
            }

            if (!decimal.TryParse(txtLeaseAmount.Text, out _))
            {
                this.ShowError("Lease Amount must be a valid number");
                return false;
            }

            if (_application.GetCurrentCompanyIDGovernmentID().Item1 != null && cboReceivedTo.SelectedItem == null)
            {
                this.ShowError("Receive Invoice To is a required field");
                return false;
            }

            DropDownItem<LeaseBid.RecurringAmountTypes> recurringTypeDDI = cboRecurringBilling.SelectedItem as DropDownItem<LeaseBid.RecurringAmountTypes>;
            if (recurringTypeDDI.Object != LeaseBid.RecurringAmountTypes.None)
            {
                if (string.IsNullOrEmpty(txtRecurringAmount.Text))
                {
                    this.ShowError("Recurring Amount is a required field when Recurring Billing is not set to None");
                    return false;
                }

                if (!decimal.TryParse(txtRecurringAmount.Text, out decimal nonNullableRecurringAmount))
                {
                    this.ShowError("Recurring Amount must be a valid number");
                    return false;
                }
            }

            foreach(DataGridViewRow row in dgvRequests.Rows)
            {
                if (row.Cells[colRollingStock.Name].Tag == null)
                {
                    this.ShowError("All selected Lease Requests must have an assigned Rolling Stock");
                    return false;
                }
            }

            return true;
        }

        public IEnumerable<LeaseBid> GetLeaseBids()
        {
            decimal leaseAmount = decimal.Parse(txtLeaseAmount.Text);
            long? receivedToID = null;
            if (cboReceivedTo.Visible)
            {
                receivedToID = (cboReceivedTo.SelectedItem as DropDownItem<Location>).Object.LocationID;
            }
            LeaseBid.RecurringAmountTypes recurringType = (cboRecurringBilling.SelectedItem as DropDownItem<LeaseBid.RecurringAmountTypes>).Object;
            decimal? recurringAmount = null;
            if (recurringType != LeaseBid.RecurringAmountTypes.None)
            {
                recurringAmount = decimal.Parse(txtRecurringAmount.Text);
            }

            foreach(DataGridViewRow row in dgvRequests.Rows)
            {
                LeaseRequest request = row.Tag as LeaseRequest;

                yield return new LeaseBid()
                {
                    LeaseRequestID = request.LeaseRequestID,
                    LeaseAmount = leaseAmount,
                    LocationIDInvoiceDestination = receivedToID,
                    RecurringAmountType = recurringType,
                    RecurringAmount = recurringAmount,
                    Terms = txtTerms.Text,
                    LocomotiveID = request.LeaseType == LeaseRequest.LeaseTypes.Locomotive ? row.Cells[colRollingStock.Name].Tag as long? : (long?)null,
                    RailcarID = request.LeaseType == LeaseRequest.LeaseTypes.Railcar ? row.Cells[colRollingStock.Name].Tag as long? : (long?)null
                };
            }
        }
    }
}
