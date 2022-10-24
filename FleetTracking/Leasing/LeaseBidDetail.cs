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
    public partial class LeaseBidDetail : UserControl, IFleetTrackingControl
    {
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
            }

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

                cboRollingStock.Items.Clear();
                if (leaseRequest.LeaseType == LeaseRequest.LeaseTypes.Locomotive)
                {
                    lblRollingStock.Text = "Locomotive:";
                    get.Resource = "Locomotive/GetAll";
                    List<Locomotive> locomotives = await get.GetObject<List<Locomotive>>() ?? new List<Locomotive>();
                    locomotives = locomotives.Where(l => _application.IsCurrentEntity(l.CompanyIDOwner, l.GovernmentIDOwner) && l.CompanyLeasedTo?.CompanyID == null && l.GovernmentLeasedTo?.GovernmentID == null).ToList();

                    foreach(Locomotive locomotive in locomotives)
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
                    railcars = railcars.Where(l => _application.IsCurrentEntity(l.CompanyIDOwner, l.GovernmentIDOwner) && l.CompanyLeasedTo?.CompanyID == null && l.GovernmentLeasedTo?.GovernmentID == null).ToList();

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
                    foreach(Location location in company.Locations)
                    {
                        DropDownItem<Location> locationDDI = new DropDownItem<Location>(location, location.Name);
                        cboReceivedTo.Items.Add(locationDDI);
                    }
                }

                foreach(LeaseBid.RecurringAmountTypes recurringType in Enum.GetValues(typeof(LeaseBid.RecurringAmountTypes)))
                {
                    DropDownItem<LeaseBid.RecurringAmountTypes> recurringDDI = new DropDownItem<LeaseBid.RecurringAmountTypes>(recurringType, recurringType.ToString().ToDisplayName());
                    cboRecurringBilling.Items.Add(recurringDDI);
                }

                if (LeaseBidID != null)
                {
                    get.Resource = $"LeaseBid/Get/{LeaseBidID}";
                    LeaseBid bid = await get.GetObject<LeaseBid>();
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
                    
                    if (cboReceivedTo.Visible && bid.LocationIDRecurringAmountDestination != null)
                    {
                        DropDownItem<Location> locationDDI = cboReceivedTo.Items.OfType<DropDownItem<Location>>().FirstOrDefault(ddi => ddi.Object.LocationID == bid.LocationIDRecurringAmountDestination);
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
                txtTerms.Size = new Size(txtTerms.Width, Height - txtTerms.Top - (Height - cmdSave.Top - 3));
            }
            else
            {
                txtTerms.Size = new Size(txtTerms.Width, Height - txtTerms.Top - 3);
            }
        }
    }
}
