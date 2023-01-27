using FleetTracking.Attributes;
using FleetTracking.Interop;
using FleetTracking.Models;
using FleetTracking.Roster;
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;
using MesaSuite.Common.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FleetTracking.Leasing
{
    [SecuredControl(SecuredControlAttribute.Permissions.AllowLeasingManagement)]
    public partial class LeaseBidDetail : UserControl, IFleetTrackingControl
    {
        public event EventHandler Saved;

        private FleetTrackingApplication _application;
        public FleetTrackingApplication Application { set => _application = value; }
        public long? LeaseRequestID { get; set; }
        public long? LeaseBidID { get; set; }

        public LeaseBidDetail()
        {
            InitializeComponent();
        }

        private async void LeaseBidDetail_Load(object sender, EventArgs e)
        {
            if (LeaseRequestID == null && LeaseBidID == null)
            {
                this.ShowError("Not enough data was supplied to open this pane.");
                ParentForm.Close();
                return;
            }

            await LoadData();
        }

        private async Task LoadData()
        {
            try
            {
                loader.BringToFront();
                loader.Visible = true;

                GetData get = _application.GetAccess<GetData>();
                get.API = DataAccess.APIs.FleetTracking;
                get.Resource = $"LeaseRequest/Get/{LeaseRequestID}";
                LeaseRequest leaseRequest = await get.GetObject<LeaseRequest>();
                if (leaseRequest == null)
                {
                    ParentForm.Close();
                    return;
                }

                LeaseBid bid = null;
                if (LeaseBidID != null)
                {
                    get.Resource = $"LeaseBid/Get/{LeaseBidID}";
                    bid = await get.GetObject<LeaseBid>();
                }

                cboRollingStock.Items.Clear();
                if (leaseRequest.LeaseType == LeaseRequest.LeaseTypes.Locomotive)
                {
                    lblRollingStock.Text = "Locomotive:";
                    get.Resource = "Locomotive/GetAll";
                    List<Locomotive> locomotives = await get.GetObject<List<Locomotive>>() ?? new List<Locomotive>();
                    locomotives = locomotives.Where(l => _application.IsCurrentEntity(l.CompanyIDOwner, l.GovernmentIDOwner) && l.CompanyLeasedTo?.CompanyID == null && l.GovernmentLeasedTo?.GovernmentID == null && (l.LocomotiveID == bid?.LocomotiveID || !l.HasOpenBid)).ToList();

                    foreach (Locomotive locomotive in locomotives)
                    {
                        Label closedLabel = new Label()
                        {
                            Text = locomotive.FormattedReportingMark
                        };
                        closedLabel.Size = TextRenderer.MeasureText(closedLabel.Text, closedLabel.Font);

                        LocomotiveDropDownItem locomotiveDDI = new LocomotiveDropDownItem()
                        {
                            Application = _application,
                            LocomotiveID = locomotive.LocomotiveID
                        };

                        ControlSelector.ControlSelectorItem item = new ControlSelector.ControlSelectorItem()
                        {
                            ClosedControl = closedLabel,
                            DropDownControl = locomotiveDDI
                        };
                        cboRollingStock.Items.Add(item);
                    }
                }
                else if (leaseRequest.LeaseType == LeaseRequest.LeaseTypes.Railcar)
                {
                    lblRollingStock.Text = "Railcar:";
                    get.Resource = "Railcar/GetAll";
                    List<Railcar> railcars = await get.GetObject<List<Railcar>>() ?? new List<Railcar>();
                    railcars = railcars.Where(l => _application.IsCurrentEntity(l.CompanyIDOwner, l.GovernmentIDOwner) && l.CompanyLeasedTo?.CompanyID == null && l.GovernmentLeasedTo?.GovernmentID == null && (l.RailcarID == bid?.RailcarID || !l.HasOpenBid)).ToList();

                    foreach (Railcar railcar in railcars)
                    {
                        Label closedLabel = new Label()
                        {
                            Text = railcar.FormattedReportingMark
                        };
                        closedLabel.Size = TextRenderer.MeasureText(closedLabel.Text, closedLabel.Font);

                        RailcarDropDownItem railcarDDI = new RailcarDropDownItem()
                        {
                            Application = _application,
                            RailcarID = railcar.RailcarID
                        };

                        ControlSelector.ControlSelectorItem item = new ControlSelector.ControlSelectorItem()
                        {
                            ClosedControl = closedLabel,
                            DropDownControl = railcarDDI
                        };
                        cboRollingStock.Items.Add(item);
                    }
                }

                long? companyID = _application.GetCurrentCompanyIDGovernmentID().Item1;
                lblReceivedTo.Visible = companyID != null;
                cboReceivedTo.Visible = companyID != null;

                if (companyID != null)
                {
                    get.Resource = $"Company/Get/{companyID}";
                    Company company = await get.GetObject<Company>() ?? new Company();
                    foreach (Location location in company.Locations)
                    {
                        DropDownItem<Location> locationDDI = new DropDownItem<Location>(location, location.Name);
                        cboReceivedTo.Items.Add(locationDDI);
                    }
                }

                foreach (LeaseBid.RecurringAmountTypes recurringType in Enum.GetValues(typeof(LeaseBid.RecurringAmountTypes)))
                {
                    DropDownItem<LeaseBid.RecurringAmountTypes> recurringDDI = new DropDownItem<LeaseBid.RecurringAmountTypes>(recurringType, recurringType.ToString().ToDisplayName());
                    cboRecurringBilling.Items.Add(recurringDDI);
                }

                if (LeaseBidID != null)
                {
                    if (bid == null)
                    {
                        return;
                    }

                    if (leaseRequest.LeaseType == LeaseRequest.LeaseTypes.Locomotive)
                    {
                        cboRollingStock.SelectedItem = cboRollingStock.Items.OfType<ControlSelector.ControlSelectorItem>().FirstOrDefault(csi => csi.DropDownControl is LocomotiveDropDownItem lddi && lddi.LocomotiveID == bid.LocomotiveID);
                    }
                    else if (leaseRequest.LeaseType == LeaseRequest.LeaseTypes.Railcar)
                    {
                        cboRollingStock.SelectedItem = cboRollingStock.Items.OfType<ControlSelector.ControlSelectorItem>().FirstOrDefault(csi => csi.DropDownControl is RailcarDropDownItem rddi && rddi.RailcarID == bid.RailcarID);
                    }

                    txtLeaseAmount.Text = bid.LeaseAmount?.ToString("N2");

                    if (cboReceivedTo.Visible && bid.LocationIDInvoiceDestination != null)
                    {
                        DropDownItem<Location> locationDDI = cboReceivedTo.Items.OfType<DropDownItem<Location>>().FirstOrDefault(ddi => ddi.Object.LocationID == bid.LocationIDInvoiceDestination);
                        cboReceivedTo.SelectedItem = locationDDI;
                    }

                    DropDownItem<LeaseBid.RecurringAmountTypes> recurringAmountDDI = cboRecurringBilling.Items.OfType<DropDownItem<LeaseBid.RecurringAmountTypes>>().FirstOrDefault(ddi => ddi.Object == bid.RecurringAmountType);
                    cboRecurringBilling.SelectedItem = recurringAmountDDI;

                    txtRecurringAmount.Text = bid.RecurringAmount?.ToString("N2");
                    txtTerms.Text = bid.Terms;

                    SetupFormForCurrentEntity(_application.IsCurrentEntity(bid.Locomotive?.CompanyIDOwner ?? bid.Railcar?.CompanyIDOwner,
                                                                           bid.Locomotive?.GovernmentIDOwner ?? bid.Railcar?.GovernmentIDOwner));
                }
                else
                {
                    SetupFormForCurrentEntity(true);
                }
            }
            finally
            {
                loader.Visible = false;
            }
        }

        private void SetupFormForCurrentEntity(bool isForCurrentEntity)
        {
            cboRollingStock.Enabled = isForCurrentEntity;
            txtLeaseAmount.Enabled = isForCurrentEntity;
            cboReceivedTo.Enabled = isForCurrentEntity;
            cboRecurringBilling.Enabled = isForCurrentEntity;
            txtRecurringAmount.Enabled = isForCurrentEntity;
            txtTerms.Enabled = isForCurrentEntity;
            cmdSave.Visible = isForCurrentEntity;
            cmdReset.Visible = isForCurrentEntity;

            if (isForCurrentEntity)
            {
                txtTerms.Size = new Size(txtTerms.Width, Height - txtTerms.Top - (Height - cmdSave.Top + 3));
            }
            else
            {
                txtTerms.Size = new Size(txtTerms.Width, Height - txtTerms.Top - 3);
            }
        }

        private async void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                loader.BringToFront();
                loader.Visible = true;

                if (!this.AreFieldsPresent(new List<(string, Control)>()
                {
                    ("Rolling Stock", cboRollingStock),
                    ("Lease Amount", txtLeaseAmount),
                    ("Recurring Billing", cboRecurringBilling)
                }))
                {
                    return;
                }

                if (!decimal.TryParse(txtLeaseAmount.Text, out decimal leaseAmount))
                {
                    this.ShowError("Lease Amount must be a valid number");
                    return;
                }

                long? locationIDReceivedTo = null;
                if (_application.GetCurrentCompanyIDGovernmentID().Item1 != null && (cboReceivedTo.SelectedItem == null || !(cboReceivedTo.SelectedItem is DropDownItem<Location>)))
                {
                    this.ShowError("Received To is a required field");
                    return;
                }
                else if (_application.GetCurrentCompanyIDGovernmentID().Item1 != null)
                {
                    locationIDReceivedTo = cboReceivedTo.SelectedItem.Cast<DropDownItem<Location>>().Object.LocationID;
                }

                DropDownItem<LeaseBid.RecurringAmountTypes> recurringAmountDDI = cboRecurringBilling.SelectedItem.Cast<DropDownItem<LeaseBid.RecurringAmountTypes>>();
                decimal recurringAmount = 0M;
                if (recurringAmountDDI.Object != LeaseBid.RecurringAmountTypes.None)
                {
                    if (string.IsNullOrEmpty(txtRecurringAmount.Text) || !decimal.TryParse(txtRecurringAmount.Text, out recurringAmount))
                    {
                        this.ShowError("Recurring Amount is a required field when Recurring Billing is not None");
                        return;
                    }
                }

                LeaseBid leaseBid = new LeaseBid()
                {
                    LeaseBidID = LeaseBidID,
                    LeaseRequestID = LeaseRequestID,
                    LocomotiveID = cboRollingStock.SelectedItem.Cast<ControlSelector.ControlSelectorItem>()?.DropDownControl.Cast<LocomotiveDropDownItem>()?.LocomotiveID,
                    RailcarID = cboRollingStock.SelectedItem.Cast<ControlSelector.ControlSelectorItem>()?.DropDownControl.Cast<RailcarDropDownItem>()?.RailcarID,
                    LocationIDInvoiceDestination = locationIDReceivedTo,
                    LeaseAmount = leaseAmount,
                    RecurringAmountType = recurringAmountDDI.Object,
                    RecurringAmount = recurringAmountDDI.Object == LeaseBid.RecurringAmountTypes.None ? (decimal?)null : recurringAmount,
                    Terms = txtTerms.Text
                };

                if (LeaseBidID == null)
                {
                    PostData post = _application.GetAccess<PostData>();
                    post.API = DataAccess.APIs.FleetTracking;
                    post.Resource = "LeaseBid/Post";
                    post.ObjectToPost = leaseBid;
                    LeaseBid savedLeaseBid = await post.Execute<LeaseBid>();

                    if (post.RequestSuccessful)
                    {
                        LeaseBidID = savedLeaseBid.LeaseBidID;
                        Saved?.Invoke(this, EventArgs.Empty);
                        await LoadData();
                    }
                }
                else
                {
                    PutData put = _application.GetAccess<PutData>();
                    put.API = DataAccess.APIs.FleetTracking;
                    put.Resource = "LeaseBid/Put";
                    put.ObjectToPut = leaseBid;
                    await put.ExecuteNoResult();
                    if (put.RequestSuccessful)
                    {
                        Saved?.Invoke(this, EventArgs.Empty);
                        await LoadData();
                    }
                }
            }
            finally
            {
                loader.Visible = false;
            }
        }
    }
}
