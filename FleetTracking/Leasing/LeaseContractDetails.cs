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
using FleetTracking.Attributes;
using FleetTracking.Interop;
using FleetTracking.Models;
using FleetTracking.Roster;
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;
using MesaSuite.Common.Utility;

namespace FleetTracking.Leasing
{
    [SecuredControl(SecuredControlAttribute.Permissions.AllowLeasingManagement)]
    public partial class LeaseContractDetails : UserControl, IFleetTrackingControl
    {
        public LeaseContractDetails()
        {
            InitializeComponent();
        }

        public event EventHandler OnSave;

        private FleetTrackingApplication _application;
        public FleetTrackingApplication Application { set => _application = value; }

        public bool AllowSave { get; set; } = true;

        public long? LeaseContractID { get; set; }

        private void LeaseContractDetails_Load(object sender, EventArgs e)
        {
            LoadData();
            dataGridViewStylizer.ApplyStyle(dgvInvoices);
        }

        private async Task LoadData()
        {
            if (!ParentForm.IsHandleCreated)
            {
                return;
            }

            try
            {
                if (LeaseContractID == null)
                {
                    this.ShowError("Lease Contract ID must be supplied");
                    ParentForm.Close();
                    return;
                }

                loader.BringToFront();
                loader.Visible = true;

                GetData get = _application.GetAccess<GetData>();
                get.API = DataAccess.APIs.FleetTracking;
                get.Resource = $"LeaseContract/Get/{LeaseContractID}";
                LeaseContract leaseContract = await get.GetObject<LeaseContract>();
                if (leaseContract == null)
                {
                    return;
                }

                long? companyOwner = leaseContract.Locomotive?.CompanyIDOwner ?? leaseContract.Railcar?.CompanyIDOwner;
                if (companyOwner != null)
                {
                    get.Resource = $"Company/Get/{companyOwner}";
                    Company company = await get.GetObject<Company>();
                    if (company?.Locations != null)
                    {
                        foreach(Location location in company.Locations)
                        {
                            DropDownItem<Location> locationDDI = new DropDownItem<Location>(location, location.Name);
                            cboPaidTo.Items.Add(locationDDI);

                            if (location.LocationID == leaseContract.LocationIDRecurringAmountDestination)
                            {
                                cboPaidTo.SelectedItem = locationDDI;
                            }
                        }
                    }
                }

                if (leaseContract.CompanyIDLessee != null)
                {
                    get.Resource = $"Company/Get/{leaseContract.CompanyIDLessee}";
                    Company company = await get.GetObject<Company>();
                    if (company?.Locations != null)
                    {
                        foreach (Location location in company.Locations)
                        {
                            DropDownItem<Location> locationDDI = new DropDownItem<Location>(location, location.Name);
                            cboChargedTo.Items.Add(locationDDI);

                            if (location.LocationID == leaseContract.LocationIDRecurringAmountSource)
                            {
                                cboChargedTo.SelectedItem = locationDDI;
                            }
                        }
                    }
                }

                lnkReportingMark.Text = leaseContract.Locomotive?.FormattedReportingMark ?? leaseContract.Railcar?.FormattedReportingMark;
                lnkReportingMark.Tag = leaseContract.Locomotive?.FormattedReportingMark == null ? leaseContract.Railcar : (object)leaseContract.Locomotive;

                txtOwner.Text = leaseContract.Locomotive?.CompanyOwner?.Name ?? leaseContract.Locomotive?.GovernmentOwner?.Name ?? leaseContract.Railcar?.CompanyOwner?.Name ?? leaseContract.Railcar?.GovernmentOwner?.Name;
                txtLessee.Text = leaseContract.CompanyLessee?.Name ?? leaseContract.GovernmentLessee?.Name;
                txtInitialAmount.Text = leaseContract.Amount?.ToString("N2");
                txtRecurring.Text = leaseContract.RecurringAmountType.ToString().ToDisplayName();
                txtRecurringAmount.Text = leaseContract.RecurringAmountType == LeaseBid.RecurringAmountTypes.None ? string.Empty : leaseContract.RecurringAmount?.ToString("N2");
                txtTerms.Text = leaseContract.Terms;
                dtpStart.Value = leaseContract.LeaseTimeStart.Value;
                dtpEnd.Value = leaseContract.LeaseTimeEnd ?? dtpEnd.MaxDate;

                bool isHistorical = (leaseContract.LeaseTimeEnd ?? dtpEnd.MaxDate) < DateTime.Now;

                long? governmentOwner = leaseContract.Locomotive?.GovernmentIDOwner ?? leaseContract.Railcar?.GovernmentIDOwner;
                cboPaidTo.Enabled = _application.GetCurrentCompanyIDGovernmentID().Item1 != null && _application.IsCurrentEntity(companyOwner, governmentOwner) && !isHistorical;
                cboChargedTo.Enabled = _application.GetCurrentCompanyIDGovernmentID().Item1 != null && _application.IsCurrentEntity(leaseContract.CompanyIDLessee, leaseContract.GovernmentIDLessee) && !isHistorical;
                dtpEnd.Enabled = (_application.IsCurrentEntity(companyOwner, governmentOwner) || _application.IsCurrentEntity(leaseContract.CompanyIDLessee, leaseContract.GovernmentIDLessee)) && !isHistorical;

                dgvInvoices.Rows.Clear();
                foreach(LeaseContractInvoice leaseContractInvoice in leaseContract.LeaseContractInvoices)
                {
                    int rowIndex = dgvInvoices.Rows.Add();
                    DataGridViewRow row = dgvInvoices.Rows[rowIndex];
                    row.Cells[colIssued.Name].Value = leaseContractInvoice.IssueTime?.ToString("MM/dd/yyyy");
                    row.Cells[colType.Name].Value = leaseContractInvoice.Type.ToString().ToDisplayName();
                    row.Cells[colAmount.Name].Value = leaseContractInvoice.Invoice?.Amount?.ToString("N2");
                    row.Tag = leaseContractInvoice;
                }

                if (!AllowSave || !dtpEnd.Enabled)
                {
                    cmdSave.Visible = false;
                    cmdReset.Visible = false;

                    groupBox3.Size = new Size(groupBox3.Width, Height - groupBox3.Location.Y - 3);
                }
            }
            finally
            {
                loader.Visible = false;
            }

            try
            {
                GetData get = _application.GetAccess<GetData>();
                get.API = DataAccess.APIs.FleetTracking;
                byte[] imageData = null;
                
                if (lnkReportingMark.Tag is Railcar railcar)
                {
                    get.Resource = $"Railcar/GetImage/{railcar.RailcarID}";
                }
                else if (lnkReportingMark.Tag is Locomotive locomotive)
                {
                    get.Resource = $"Locomotive/GetImage/{locomotive.LocomotiveID}";
                }

                imageData = await get.GetObject<byte[]>();
                if (imageData != null)
                {
                    using (MemoryStream stream = new MemoryStream(imageData))
                    {
                        Image image = Image.FromStream(stream);
                        pboxImage.Image = image;
                    }
                }
            }
            catch { }
        }

        private void lnkReportingMark_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form openedForm;
            if (lnkReportingMark.Tag is Railcar railcar)
            {
                RailcarDetail railcarDetail = new RailcarDetail()
                {
                    RailcarID = railcar.RailcarID,
                    Application = _application
                };
                openedForm = _application.OpenForm(railcarDetail);
                openedForm.Text = "Railcar";
            }
            else if (lnkReportingMark.Tag is Locomotive locomotive)
            {
                LocomotiveDetail locomotiveDetail = new LocomotiveDetail()
                {
                    LocomotiveID = locomotive.LocomotiveID,
                    Application = _application
                };
                openedForm = _application.OpenForm(locomotiveDetail);
                openedForm.Text = "Locomotive";
            }
            else
            {
                return;
            }

            openedForm.FormClosed += OpenedForm_FormClosed;
        }

        private void OpenedForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadData();
        }

        private async void cmdSave_Click(object sender, EventArgs e)
        {
            if (!dtpEnd.Enabled)
            {
                return;
            }

            if (dtpEnd.Value < DateTime.Now && !this.Confirm("Back dating the End Date will lock this Lease Contract immediately. You will not be able to change the Lease End Date again.\r\n\r\nContinue?"))
            {
                return;
            }

            PatchData patch = _application.GetAccess<PatchData>();
            patch.API = DataAccess.APIs.FleetTracking;
            patch.PatchMethod = PatchData.PatchMethods.Replace;
            patch.PrimaryKey = LeaseContractID;
            patch.Resource = "LeaseContract/Patch";
            patch.Values = new Dictionary<string, object>()
            {
                { nameof(LeaseContract.LeaseTimeEnd), dtpEnd.Value == dtpEnd.MaxDate ? (DateTime?)null : dtpEnd.Value }
            };
            await patch.Execute();
            if (patch.RequestSuccessful)
            {
                OnSave?.Invoke(this, EventArgs.Empty);
                await LoadData();
            }
        }

        private void cmdReset_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
