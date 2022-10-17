using FleetTracking.Interop;
using FleetTracking.Models;
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;
using MesaSuite.Common.Utility;
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

namespace FleetTracking.Leasing
{
    public partial class LeaseRequestDetail : UserControl, IFleetTrackingControl
    {
        public event EventHandler OnSave;
        private bool _allowSave;

        private FleetTrackingApplication _application;
        public FleetTrackingApplication Application { set => _application = value; }

        public long? LeaseRequestID { get; set; }

        public LeaseRequestDetail()
        {
            InitializeComponent();
            dataGridViewStylizer.ApplyStyle(dgvBids);
        }

        private void SetPositionsForSave()
        {
            if (_allowSave)
            {
                grpBids.Location = new Point(grpBids.Location.X, cmdSave.Location.Y + 29);
                grpBids.Size = new Size(grpBids.Width, Height - (cmdSave.Location.Y + cmdSave.Height) - 9);
            }
            else
            {
                grpBids.Location = new Point(grpBids.Location.X, grpLeaseRequest.Location.Y + grpLeaseRequest.Height + 6);
                grpBids.Size = new Size(grpBids.Width, Height - (grpLeaseRequest.Location.Y + grpLeaseRequest.Height) - 9);
            }

            cmdSave.Visible = _allowSave;
            cmdReset.Visible = _allowSave;
        }

        private void LeaseRequestDetail_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private async Task LoadData()
        {
            loader.BringToFront();
            loader.Visible = true;

            try
            {
                GetData get = _application.GetAccess<GetData>();
                get.API = DataAccess.APIs.FleetTracking;

                LeaseRequest leaseRequest = null;
                if (LeaseRequestID != null)
                {
                    get.Resource = $"LeaseRequest/Get/{LeaseRequestID}";
                    leaseRequest = await get.GetObject<LeaseRequest>();
                }

                if (leaseRequest == null)
                {
                    (long?, long?) companyIDGovernmentID = _application.GetCurrentCompanyIDGovernmentID();
                    if (companyIDGovernmentID.Item1 != null)
                    {
                        get.Resource = $"Company/Get/{companyIDGovernmentID.Item1}";
                        Company company = await get.GetObject<Company>() ?? new Company();
                        txtRequester.Text = company?.Name;
                    }
                    else if (companyIDGovernmentID.Item2 != null)
                    {
                        get.Resource = $"Government/Get/{companyIDGovernmentID.Item2}";
                        Government government = await get.GetObject<Government>() ?? new Government();
                        txtRequester.Text = government?.Name;
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    txtRequester.Text = leaseRequest.CompanyRequester?.Name ?? leaseRequest.GovernmentRequester?.Name;
                }

                cboLeaseType.Items.Clear();
                foreach(LeaseRequest.LeaseTypes leaseType in Enum.GetValues(typeof(LeaseRequest.LeaseTypes)))
                {
                    DropDownItem<LeaseRequest.LeaseTypes> dropDownItem = new DropDownItem<LeaseRequest.LeaseTypes>(leaseType, leaseType.ToString().ToDisplayName());
                    cboLeaseType.Items.Add(dropDownItem);

                    if (leaseRequest?.LeaseType == leaseType)
                    {
                        cboLeaseType.SelectedItem = dropDownItem;

                        if (leaseType == LeaseRequest.LeaseTypes.Railcar)
                        {
                            lblRailcarType.Visible = true;
                            cboRailcarType.Visible = true;
                        }
                    }
                }

                cboRailcarType.Items.Clear();
                foreach(Models.RailcarModel.Types railcarType in Enum.GetValues(typeof(Models.RailcarModel.Types)))
                {
                    DropDownItem<Models.RailcarModel.Types> dropDownItem = new DropDownItem<Models.RailcarModel.Types>(railcarType, railcarType.ToString().ToDisplayName());
                    cboRailcarType.Items.Add(dropDownItem);

                    if (leaseRequest?.RailcarType == railcarType)
                    {
                        cboRailcarType.SelectedItem = dropDownItem;
                    }
                }

                txtDeliveryLocation.Text = leaseRequest?.DeliveryLocation;
                txtPurpose.Text = leaseRequest?.Purpose;
                dtpEndTime.Value = leaseRequest?.BidEndTime ?? DateTime.Now;

                dgvBids.Rows.Clear();
                get.Resource = "LeaseBid/GetAll";
                List<LeaseBid> leaseBids = await get.GetObject<List<LeaseBid>>() ?? new List<LeaseBid>();
                foreach(LeaseBid leaseBid in leaseBids.Where(lb => lb.LeaseRequestID == LeaseRequestID))
                {
                    int rowIndex = dgvBids.Rows.Add();
                    DataGridViewRow row = dgvBids.Rows[rowIndex];
                    row.Cells[colReportingMark.Name].Value = string.IsNullOrEmpty(leaseBid.Railcar?.FormattedReportingMark) ? leaseBid.Locomotive?.FormattedReportingMark : leaseBid.Railcar.FormattedReportingMark;
                    row.Cells[colAmount.Name].Value = leaseBid.LeaseAmount?.ToString("N2");
                    row.Cells[colRecurring.Name].Value = leaseBid.RecurringAmountType.ToString().ToDisplayName();
                    row.Tag = leaseBid;

                    row.Selected = rowIndex == 0;
                }

                // Setup form stuff
                _allowSave = leaseRequest == null || _application.IsCurrentEntity(leaseRequest.CompanyIDRequester, leaseRequest.GovernmentIDRequester);
                SetPositionsForSave();

                cboLeaseType.Enabled = _allowSave;
                cboRailcarType.Enabled = _allowSave;
                txtDeliveryLocation.Enabled = _allowSave;
                txtPurpose.Enabled = _allowSave;
                dtpEndTime.Enabled = _allowSave;
                tsmiAccept.Visible = _allowSave;
                tsmiSubmitBid.Visible = !_allowSave;
                tsmiSubmitBid.Enabled = !leaseBids.Where(lb => lb.LeaseRequestID == LeaseRequestID).Any();
                tsmiDeleteBid.Visible = !_allowSave;

                dgvBids_SelectionChanged(this, EventArgs.Empty);
            }
            finally
            {
                loader.Visible = false;
            }

            try
            {
                GetData get = _application.GetAccess<GetData>();
                get.API = DataAccess.APIs.FleetTracking;

                foreach(DataGridViewRow row in dgvBids.Rows)
                {
                    LeaseBid bid = row.Tag as LeaseBid;
                    if (bid == null)
                    {
                        continue;
                    }

                    if (bid.Locomotive?.LocomotiveID != null)
                    {
                        get.Resource = $"Locomotive/GetImage/{bid.Locomotive.LocomotiveID}";
                    }
                    else if (bid.Railcar?.RailcarID != null)
                    {
                        get.Resource = $"Railcar/GetImage/{bid.Railcar.RailcarID}";
                    }
                    byte[] imageData = await get.GetObject<byte[]>();

                    if (imageData == null)
                    {
                        continue;
                    }

                    using (MemoryStream stream = new MemoryStream(imageData))
                    {
                        row.Cells[colImage.Name].Value = Image.FromStream(stream);
                    }
                }
            }
            catch { }
        }

        private void dgvBids_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void cboLeaseType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void cmdSave_Click(object sender, EventArgs e)
        {

        }
    }
}
