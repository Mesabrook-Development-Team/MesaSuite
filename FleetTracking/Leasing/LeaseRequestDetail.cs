using FleetTracking.Interop;
using FleetTracking.Models;
using MesaSuite.Common;
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
            cmdClone.Visible = _allowSave;
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
                cmdClone.Enabled = LeaseRequestID != null;

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
            tsmiAccept.Enabled = dgvBids.SelectedRows.Count > 0;
            tsmiDeleteBid.Enabled = dgvBids.SelectedRows.Count > 0;
        }

        private void cboLeaseType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownItem<LeaseRequest.LeaseTypes> leaseType = cboLeaseType.SelectedItem as DropDownItem<LeaseRequest.LeaseTypes>;
            lblRailcarType.Visible = leaseType.Object == LeaseRequest.LeaseTypes.Railcar;
            cboRailcarType.Visible = leaseType.Object == LeaseRequest.LeaseTypes.Railcar;
        }

        private async void cmdSave_Click(object sender, EventArgs e)
        {
            if (!this.AreFieldsPresent(new List<(string, Control)>()
            {
                ("Lease Type", cboLeaseType),
                ("Delivery Location", txtDeliveryLocation),
                ("Purpose", txtPurpose)
            }))
            {
                return;
            }

            LeaseRequest.LeaseTypes leaseType = (cboLeaseType.SelectedItem as DropDownItem<LeaseRequest.LeaseTypes>).Object;
            if (leaseType == LeaseRequest.LeaseTypes.Railcar && cboRailcarType.SelectedItem == null)
            {
                this.ShowError("Railcar Type is a required field when Lease Type is Railcar");
                return;
            }

            LeaseRequest leaseRequest = new LeaseRequest()
            {
                LeaseRequestID = LeaseRequestID,
                CompanyIDRequester = _application.GetCurrentCompanyIDGovernmentID().Item1,
                GovernmentIDRequester = _application.GetCurrentCompanyIDGovernmentID().Item2,
                LeaseType = leaseType,
                RailcarType = (cboRailcarType.SelectedItem as DropDownItem<Models.RailcarModel.Types>).Object,
                DeliveryLocation = txtDeliveryLocation.Text,
                Purpose = txtPurpose.Text,
                BidEndTime = dtpEndTime.Value
            };

            if (LeaseRequestID == null)
            {
                PostData post = _application.GetAccess<PostData>();
                post.API = DataAccess.APIs.FleetTracking;
                post.Resource = "LeaseRequest/Post";
                post.ObjectToPost = leaseRequest;
                LeaseRequest postedLR = await post.Execute<LeaseRequest>();
                if (post.RequestSuccessful)
                {
                    LeaseRequestID = postedLR.LeaseRequestID;
                    OnSave?.Invoke(this, EventArgs.Empty);
                    LoadData();
                }
            }
            else
            {
                PutData put = _application.GetAccess<PutData>();
                put.API = DataAccess.APIs.FleetTracking;
                put.Resource = "LeaseRequest/Put";
                put.ObjectToPut = leaseRequest;
                await put.ExecuteNoResult();
                if (put.RequestSuccessful)
                {
                    OnSave?.Invoke(this, EventArgs.Empty);
                    LoadData();
                }
            }
        }

        private async void cmdClone_Click(object sender, EventArgs e)
        {
            InputBox inputBox = new InputBox()
            {
                Application = _application,
                InputValueType = typeof(int)
            };
            inputBox.lblPrompt.Text = "How many times would you like to clone this Lease Request?";
            inputBox.Text = "Enter Clone Count";
            inputBox.cmdOK.Text = "Clone";

            Form frmInput = _application.OpenForm(inputBox, FleetTrackingApplication.OpenFormOptions.Dialog);
            if (frmInput.DialogResult != DialogResult.OK)
            {
                return;
            }
            int cloneCount = (int)Convert.ChangeType(inputBox.InputValue, typeof(int));

            if (!this.AreFieldsPresent(new List<(string, Control)>()
            {
                ("Lease Type", cboLeaseType),
                ("Delivery Location", txtDeliveryLocation),
                ("Purpose", txtPurpose)
            }))
            {
                return;
            }

            LeaseRequest.LeaseTypes leaseType = (cboLeaseType.SelectedItem as DropDownItem<LeaseRequest.LeaseTypes>).Object;
            if (leaseType == LeaseRequest.LeaseTypes.Railcar && cboRailcarType.SelectedItem == null)
            {
                this.ShowError("Railcar Type is a required field when Lease Type is Railcar");
                return;
            }

            LeaseRequest leaseRequest = new LeaseRequest()
            {
                CompanyIDRequester = _application.GetCurrentCompanyIDGovernmentID().Item1,
                GovernmentIDRequester = _application.GetCurrentCompanyIDGovernmentID().Item2,
                LeaseType = leaseType,
                RailcarType = (cboRailcarType.SelectedItem as DropDownItem<Models.RailcarModel.Types>).Object,
                DeliveryLocation = txtDeliveryLocation.Text,
                Purpose = txtPurpose.Text,
                BidEndTime = dtpEndTime.Value
            };

            try
            {
                loader.BringToFront();
                loader.Visible = true;

                for (int i = 0; i < cloneCount; i++)
                {
                    PostData post = _application.GetAccess<PostData>();
                    post.API = DataAccess.APIs.FleetTracking;
                    post.Resource = "LeaseRequest/Post";
                    post.ObjectToPost = leaseRequest;
                    await post.ExecuteNoResult();
                    if (!post.RequestSuccessful)
                    {
                        return;
                    }
                }
            }
            finally
            {
                loader.Visible = false;
            }

            this.ShowInformation($"Lease Request succesfully cloned {cloneCount} times!");
            OnSave?.Invoke(this, EventArgs.Empty);
            LoadData();
        }

        private void tsmiSubmitBid_Click(object sender, EventArgs e)
        {
            LeaseBidDetail detail = new LeaseBidDetail()
            {
                Application = _application,
                LeaseRequestID = LeaseRequestID
            };

            Size bidDetailSize = detail.Size;
            Form detailForm = _application.OpenForm(detail, FleetTrackingApplication.OpenFormOptions.Popout);
            detailForm.Size = bidDetailSize;
        }

        private void dgvBids_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvBids.Rows.Count)
            {
                return;
            }

            DataGridViewRow row = dgvBids.Rows[e.RowIndex];
            LeaseBid bid = row.Tag as LeaseBid;
            if (bid == null)
            {
                return;
            }

            LeaseBidDetail detail = new LeaseBidDetail()
            {
                Application = _application,
                LeaseRequestID = LeaseRequestID,
                LeaseBidID = bid.LeaseBidID
            };

            Form detailForm = _application.OpenForm(detail, FleetTrackingApplication.OpenFormOptions.Popout);
        }
    }
}
