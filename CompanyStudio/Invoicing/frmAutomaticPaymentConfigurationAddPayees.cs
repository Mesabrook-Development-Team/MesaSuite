using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CompanyStudio.Extensions;
using CompanyStudio.Models;
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;
using MesaSuite.Common.Utility;
using WeifenLuo.WinFormsUI.Docking;

namespace CompanyStudio.Invoicing
{
    public partial class frmAutomaticPaymentConfigurationAddPayees : Form
    {
        public long? CompanyID { get; set; }
        public long? LocationID { get; set; }
        public ThemeBase Theme { get; set; }

        private List<AutomaticInvoicePaymentConfiguration> _otherLocationConfigurations = new List<AutomaticInvoicePaymentConfiguration>();

        public frmAutomaticPaymentConfigurationAddPayees()
        {
            InitializeComponent();
            colCloneFrom.ValueType = typeof(long?);
            colCloneFrom.DisplayMember = nameof(Models.Location.DisplayName);
            colCloneFrom.ValueMember = nameof(Models.Location.LocationID);
        }

        private async void frmAutomaticPaymentConfigurationAddPayees_Load(object sender, EventArgs e)
        {
            loader.BringToFront();
            loader.Visible = true;

            try
            {
                studioFormExtender.ApplyStyle(this, Theme);

                // Get all configs for this location
                GetData get = new GetData(DataAccess.APIs.CompanyStudio, "AutomaticInvoicePaymentConfiguration/GetAll");
                get.AddLocationHeader(CompanyID, LocationID);
                List<AutomaticInvoicePaymentConfiguration> automaticInvoicePaymentConfigurations = await get.GetObject<List<AutomaticInvoicePaymentConfiguration>>() ?? new List<AutomaticInvoicePaymentConfiguration>();

                HashSet<long?> existingLocations = automaticInvoicePaymentConfigurations.Where(c => c.LocationIDPayee != null).Select(c => c.LocationIDPayee).ToHashSet();
                HashSet<long?> existingGovernments = automaticInvoicePaymentConfigurations.Where(c => c.GovernmentIDPayee != null).Select(c => c.GovernmentIDPayee).ToHashSet();

                // Get configs that this user has access to for other locations (so we can clone if necessary)
                get.Resource = "Company/GetAll";
                List<Company> companies = await get.GetObject<List<Company>>() ?? new List<Company>();

                foreach (long? locationID in PermissionsManager.AccessibleLocationIDs.Where(l => companies.FirstOrDefault(c => c.Locations.Any(loc => loc.LocationID == l)).CompanyID == CompanyID))
                {
                    if (LocationID == locationID)
                    {
                        continue;
                    }

                    if (PermissionsManager.HasPermission(locationID.Value, PermissionsManager.LocationWidePermissions.ManageInvoices))
                    {
                        GetData getOtherLocation = new GetData(DataAccess.APIs.CompanyStudio, "AutomaticInvoicePaymentConfiguration/GetAll");
                        getOtherLocation.AddLocationHeader(CompanyID, locationID);
                        _otherLocationConfigurations.AddRange(await getOtherLocation.GetObject<List<AutomaticInvoicePaymentConfiguration>>() ?? new List<AutomaticInvoicePaymentConfiguration>());
                    }
                }

                // Load available locations
                foreach (Company company in companies)
                {
                    foreach (Location location in company.Locations.Where(l => !existingLocations.Contains(l.LocationID)))
                    {
                        bool isCloneable = _otherLocationConfigurations.Any(c => c.LocationIDPayee == location.LocationID);

                        ListViewItem newItem = new ListViewItem(new[] { $"{company.Name} ({location.Name})", isCloneable ? "Yes" : "No" });
                        newItem.Tag = location;
                        lstAvailable.Items.Add(newItem);
                    }
                }

                // Load available govs
                get.Resource = "Government/GetAll";
                List<Government> governments = await get.GetObject<List<Government>>() ?? new List<Government>();
                foreach (Government government in governments.Where(g => !existingGovernments.Contains(g.GovernmentID)))
                {
                    bool isCloneable = _otherLocationConfigurations.Any(c => c.GovernmentIDPayee == government.GovernmentID);

                    ListViewItem newItem = new ListViewItem(new[] { government.Name + " (Government)", isCloneable ? "Yes" : "No" });
                    newItem.Tag = government;
                    lstAvailable.Items.Add(newItem);
                }

                HashSet<long?> otherLocationIDs = new HashSet<long?>();
                foreach(AutomaticInvoicePaymentConfiguration otherConfig in _otherLocationConfigurations.Where(c => otherLocationIDs.Add(c.LocationIDConfiguredFor)))
                {
                    DropDownItem<Location> ddi = new DropDownItem<Location>(otherConfig.LocationConfiguredFor, otherConfig.LocationConfiguredFor.DisplayName);
                    cboCloneAllFrom.Items.Add(ddi);
                }
            }
            finally { loader.Visible = false; }
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lstAvailable.SelectedItems.ToList())
            {
                DataGridViewRow row = dgvChosen.Rows[dgvChosen.Rows.Add()];
                row.Cells[colPayee.Name].Value = item.Text;

                Location locationPayee = item.Tag as Location;
                Government governmentPayee = item.Tag as Government;

                List<AutomaticInvoicePaymentConfiguration> cloneableConfigurations = _otherLocationConfigurations.Where(aipc => aipc.LocationIDPayee == locationPayee?.LocationID && aipc.GovernmentIDPayee == governmentPayee?.GovernmentID).ToList();
                if (cloneableConfigurations.Any())
                {
                    ((DataGridViewComboBoxCell)row.Cells[colCloneFrom.Name]).DataSource = cloneableConfigurations;
                }
                else
                {
                    row.Cells[colCloneFrom.Name].ReadOnly = true;
                    ((DataGridViewComboBoxCell)row.Cells[colCloneFrom.Name]).DataSource = new List<object>()
                    {
                        new { LocationID = (long?)0, DisplayName = "[Not Cloneable]" }
                    };
                    row.Cells[colCloneFrom.Name].Value = (long?)0;
                }

                lstAvailable.Items.Remove(item);
            }
        }
    }
}
