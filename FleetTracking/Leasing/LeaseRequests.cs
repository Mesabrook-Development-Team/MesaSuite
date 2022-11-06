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
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;

namespace FleetTracking.Leasing
{
    public partial class LeaseRequests : UserControl, IFleetTrackingControl
    {
        private FleetTrackingApplication _application;
        public FleetTrackingApplication Application { set => _application = value; }

        public LeaseRequests()
        {
            InitializeComponent();
            dataGridViewStylizer.ApplyStyle(dgvRequests);
            dgvRequests.MultiSelect = true;
            dataGridViewStylizer.ApplyStyle(dgvSent);
            dgvSent.MultiSelect = true;
            dataGridViewStylizer.ApplyStyle(dgvReceivedBids);
            dgvReceivedBids.MultiSelect = true;
        }

        private List<LeaseBid> LeaseBids { get; set; }
        private List<LeaseRequest> SelectedLeaseRequests => dgvRequests.SelectedRows.Cast<DataGridViewRow>().Select(dgvr => dgvr.Tag as LeaseRequest).Where(lr => lr != null).ToList();

        private async void LeaseRequests_Load(object sender, EventArgs e)
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            loader.BringToFront();
            loader.Visible = true;

            try
            {
                dgvRequests.Rows.Clear();

                GetData get = _application.GetAccess<GetData>();
                get.API = DataAccess.APIs.FleetTracking;
                get.Resource = "LeaseRequest/GetAll";
                List<LeaseRequest> leaseRequests = await get.GetObject<List<LeaseRequest>>() ?? new List<LeaseRequest>();

                if (rdoFilterMyRequests.Checked)
                {
                    leaseRequests = leaseRequests.Where(lr => _application.IsCurrentEntity(lr.CompanyIDRequester, lr.GovernmentIDRequester)).ToList();
                }
                else if (rdoRequestsFromOthers.Checked)
                {
                    leaseRequests = leaseRequests.Where(lr => !_application.IsCurrentEntity(lr.CompanyIDRequester, lr.GovernmentIDRequester)).ToList();
                }

                leaseRequests = leaseRequests.OrderBy(lr => lr.BidEndTime).ToList();

                get.Resource = "LeaseBid/GetAll";
                LeaseBids = await get.GetObject<List<LeaseBid>>() ?? new List<LeaseBid>();

                foreach (LeaseRequest leaseRequest in leaseRequests)
                {
                    int rowIndex = dgvRequests.Rows.Add();
                    DataGridViewRow row = dgvRequests.Rows[rowIndex];

                    row.Cells[colLeaseID.Name].Value = leaseRequest.LeaseRequestID?.ToString();
                    row.Cells[colRequester.Name].Value = leaseRequest.CompanyRequester?.Name ?? leaseRequest.GovernmentRequester?.Name;
                    row.Cells[colLeaseType.Name].Value = leaseRequest.LeaseType.ToString();
                    DataGridViewCell endTimeCell = row.Cells[colEndTime.Name];
                    endTimeCell.Value = leaseRequest.BidEndTime?.ToString("MM/dd/yyyy HH:mm");
                    if (leaseRequest.BidEndTime != null)
                    {
                        if (leaseRequest.BidEndTime.Value < DateTime.Now) // Already ended - can't bid
                        {
                            endTimeCell.Style.BackColor = Color.Red;
                            endTimeCell.Style.ForeColor = Color.White;
                        }
                        else if (leaseRequest.BidEndTime.Value.AddHours(-24) < DateTime.Now) // Ends within 24-hours
                        {
                            endTimeCell.Style.BackColor = Color.Yellow;
                        }
                    }
                    row.Cells[colBidPlaced.Name].Value = !_application.IsCurrentEntity(leaseRequest.CompanyIDRequester, leaseRequest.GovernmentIDRequester) && LeaseBids.Any(lb => lb.LeaseRequestID == leaseRequest.LeaseRequestID);
                    row.Cells[colPurpose.Name].Value = leaseRequest.Purpose;
                    row.Tag = leaseRequest;
                }

                dgvRequests_SelectionChanged(dgvRequests, EventArgs.Empty);
            }
            finally
            {
                loader.Visible = false;
            }
        }

        private async void FilterCheckedChanged(object sender, EventArgs e)
        {
            if (!((RadioButton)sender).Checked)
            {
                return;
            }

            await LoadData();
        }

        private async void dgvRequests_SelectionChanged(object sender, EventArgs e)
        {
            dgvSent.Rows.Clear();
            dgvReceivedBids.Rows.Clear();

            foreach(LeaseBid leaseBid in LeaseBids.Where(lb => SelectedLeaseRequests.Any(lr => lr.LeaseRequestID == lb.LeaseRequestID && !_application.IsCurrentEntity(lr.CompanyIDRequester, lr.GovernmentIDRequester))))
            {
                int rowIndex = dgvSent.Rows.Add();
                DataGridViewRow row = dgvSent.Rows[rowIndex];

                row.Cells[colSentRequestID.Name].Value = leaseBid.LeaseRequestID?.ToString();
                row.Cells[colSentReportingMark.Name].Value = leaseBid.Railcar?.FormattedReportingMark ?? leaseBid.Locomotive?.FormattedReportingMark;
                row.Cells[colSentAmount.Name].Value = leaseBid.LeaseAmount?.ToString("N2");
                row.Cells[colSentRecurringType.Name].Value = leaseBid.RecurringAmountType.ToString().ToDisplayName();
                row.Cells[colSentTerms.Name].Value = leaseBid.Terms;
                row.Tag = leaseBid;
            }

            foreach (LeaseBid leaseBid in LeaseBids.Where(lb => SelectedLeaseRequests.Any(lr => lr.LeaseRequestID == lb.LeaseRequestID && _application.IsCurrentEntity(lr.CompanyIDRequester, lr.GovernmentIDRequester))))
            {
                int rowIndex = dgvReceivedBids.Rows.Add();
                DataGridViewRow row = dgvReceivedBids.Rows[rowIndex];

                row.Cells[colReceivedRequestID.Name].Value = leaseBid.LeaseRequestID?.ToString();
                row.Cells[colReceivedReportingMark.Name].Value = leaseBid.Railcar?.FormattedReportingMark ?? leaseBid.Locomotive?.FormattedReportingMark;
                row.Cells[colReceivedAmount.Name].Value = leaseBid.LeaseAmount?.ToString("N2");
                row.Cells[colReceivedRecurringType.Name].Value = leaseBid.RecurringAmountType.ToString().ToDisplayName();
                row.Cells[colReceivedTerms.Name].Value = leaseBid.Terms;
                row.Tag = leaseBid;
            }

            mnuDeleteRequests.Enabled = SelectedLeaseRequests.Any(lr => _application.IsCurrentEntity(lr.CompanyIDRequester, lr.GovernmentIDRequester));

            dgvSent_SelectionChanged(this, EventArgs.Empty);
            dgvReceivedBids_RowCountChanged(this, EventArgs.Empty);

            try
            {
                GetData getImage = _application.GetAccess<GetData>();
                getImage.API = DataAccess.APIs.FleetTracking;

                foreach(DataGridViewRow row in dgvSent.Rows.Cast<DataGridViewRow>().Concat(dgvReceivedBids.Rows.Cast<DataGridViewRow>()))
                {
                    LeaseBid leaseBid = row.Tag as LeaseBid;
                    if (leaseBid == null)
                    {
                        continue;
                    }

                    if (leaseBid.Locomotive?.LocomotiveID != null)
                    {
                        getImage.Resource = $"Locomotive/GetImage/{leaseBid.Locomotive.LocomotiveID}";
                    }
                    else if (leaseBid.Railcar?.RailcarID != null)
                    {
                        getImage.Resource = $"Railcar/GetImage/{leaseBid.Railcar.RailcarID}";
                    }
                    else
                    {
                        continue;
                    }

                    byte[] imageData = await getImage.GetObject<byte[]>();
                    if (imageData == null)
                    {
                        continue;
                    }

                    Image image;
                    using(MemoryStream stream = new MemoryStream(imageData))
                    {
                        image = Image.FromStream(stream);
                    }

                    string columnName = row.DataGridView == dgvSent ? colSentImage.Name : colReceivedImage.Name;
                    row.Cells[columnName].Value = image;
                }
            }
            catch { }
        }

        private void dgvSent_SelectionChanged(object sender, EventArgs e)
        {
            mnuDeleteBids.Enabled = dgvSent.SelectedRows.Count > 0;
        }

        private void dgvReceivedBids_RowCountChanged(object sender, EventArgs e)
        {
            mnuAcceptBids.Enabled = dgvReceivedBids.Rows.Count > 0;
        }

        private void mnuAddRequest_Click(object sender, EventArgs e)
        {
            LeaseRequestDetail leaseRequestDetail = new LeaseRequestDetail() { Application = _application };
            leaseRequestDetail.OnSave += LeaseRequestDetail_OnSave;
            Form newRequestForm = _application.OpenForm(leaseRequestDetail, FleetTrackingApplication.OpenFormOptions.Popout);
            newRequestForm.Text = "New Lease Request";
        }

        private void LeaseRequestDetail_OnSave(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvRequests_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cell = dgvRequests[e.ColumnIndex, e.RowIndex];
            LeaseRequest leaseRequest = cell.OwningRow.Tag as LeaseRequest;
            if (leaseRequest == null)
            {
                return;
            }

            LeaseRequestDetail leaseRequestDetail = new LeaseRequestDetail()
            {
                Application = _application,
                LeaseRequestID = leaseRequest.LeaseRequestID,
            };
            leaseRequestDetail.OnSave += LeaseRequestDetail_OnSave;
            Form leaseRequestForm = _application.OpenForm(leaseRequestDetail);
            leaseRequestForm.Text = $"Lease Request ({leaseRequest.LeaseRequestID})";
        }

        private async void mnuDeleteRequests_Click(object sender, EventArgs e)
        {
            IEnumerable<LeaseRequest> myLeaseRequests = dgvRequests.SelectedRows.Cast<DataGridViewRow>().Where(dgvr => dgvr.Tag is LeaseRequest leaseRequest && _application.IsCurrentEntity(leaseRequest.CompanyIDRequester, leaseRequest.GovernmentIDRequester)).Select(dgvr => dgvr.Tag as LeaseRequest);
            if (!myLeaseRequests.Any())
            {
                return;
            }

            if (!this.Confirm("Are you sure you want to delete these Lease Requests?"))
            {
                return;
            }

            loader.BringToFront();
            loader.Visible = true;

            try
            {
                foreach (LeaseRequest leaseRequest in myLeaseRequests)
                {
                    DeleteData delete = _application.GetAccess<DeleteData>();
                    delete.API = DataAccess.APIs.FleetTracking;
                    delete.Resource = $"LeaseRequest/Delete/{leaseRequest.LeaseRequestID}";
                    await delete.Execute();
                    if (!delete.RequestSuccessful)
                    {
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

        private void LeaseBid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = sender as DataGridView;
            if (dataGridView == null)
            {
                return;
            }

            DataGridViewRow row = dataGridView.Rows[e.RowIndex];
            LeaseBid leaseBid = row.Tag as LeaseBid;
            if (leaseBid == null)
            {
                return;
            }

            LeaseBidDetail leaseBidDetail = new LeaseBidDetail()
            {
                Application = _application,
                LeaseRequestID = leaseBid.LeaseRequestID,
                LeaseBidID = leaseBid.LeaseBidID
            };
            leaseBidDetail.Saved += LeaseBidDetail_Saved;

            Size detailSize = leaseBidDetail.Size;
            Form detailForm = _application.OpenForm(leaseBidDetail, FleetTrackingApplication.OpenFormOptions.Popout);
            detailForm.Size = detailSize;
            detailForm.Text = "Lease Bid";
        }

        private void LeaseBidDetail_Saved(object sender, EventArgs e)
        {
            // TODO: Try to preserve the selected rows
            LoadData();
        }

        private async void mnuDeleteBids_Click(object sender, EventArgs e)
        {
            if (!this.Confirm("Are you sure you want to delete these Bids?"))
            {
                return;
            }

            try
            {
                loader.BringToFront();
                loader.Visible = true;

                foreach (DataGridViewRow row in dgvSent.SelectedRows)
                {
                    LeaseBid bid = row.Tag as LeaseBid;
                    if (bid == null)
                    {
                        continue;
                    }

                    DeleteData delete = _application.GetAccess<DeleteData>();
                    delete.API = DataAccess.APIs.FleetTracking;
                    delete.Resource = $"LeaseBid/Delete/{bid.LeaseBidID}";
                    await delete.Execute();
                }

                LoadData();
            }
            finally
            {
                loader.Visible = false;
            }
        }

        private void mnuSubmitBids_Click(object sender, EventArgs e)
        {
            IEnumerable<long> selectedLeaseRequestIDs = SelectedLeaseRequests.Select(lr => lr.LeaseRequestID.Value);
            Form submitBidsForm = _application.OpenForm(new SubmitBids() { Application = _application, SelectedLeaseRequests = selectedLeaseRequestIDs }, FleetTrackingApplication.OpenFormOptions.Popout);
            submitBidsForm.Text = "Submit Bids";
            submitBidsForm.FormClosed += (s, ea) => LoadData();
        }

        private async void mnuAcceptBids_Click(object sender, EventArgs e)
        {
            if (!this.Confirm("Are you sure you want to accept these bids?"))
            {
                return;
            }

            try
            {
                loader.BringToFront();
                loader.Visible = true;

                foreach(DataGridViewRow row in dgvReceivedBids.SelectedRows)
                {
                    LeaseBid bid = row.Tag as LeaseBid;
                    if (bid == null)
                    {
                        continue;
                    }

                    PutData put = _application.GetAccess<PutData>();
                    put.API = DataAccess.APIs.FleetTracking;
                    put.Resource = "LeaseContract/CreateFromLeaseBid";
                    put.ObjectToPut = new { leaseBidID = bid.LeaseBidID };
                    await put.ExecuteNoResult();
                }

                await LoadData();
            }
            finally
            {
                loader.Visible = false;
            }
        }
    }
}
