using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CompanyStudio.Extensions;
using CompanyStudio.Models;
using MesaSuite.Common.Data;
using WeifenLuo.WinFormsUI.Docking;

namespace CompanyStudio.Invoicing
{
    public partial class frmAutomaticPaymentConfigurationAddPayees : Form
    {
        public long? CompanyID { get; set; }
        public long? LocationID { get; set; }
        public ThemeBase Theme { get; set; }

        private Dictionary<int, CloneFromItem> _clonedFromItemsByHashCode = new Dictionary<int, CloneFromItem>();

        public frmAutomaticPaymentConfigurationAddPayees()
        {
            InitializeComponent();
            colCloneFrom.ValueType = typeof(int);
            colCloneFrom.DisplayMember = nameof(CloneFromItem.Display);
            colCloneFrom.ValueMember = nameof(CloneFromItem.HashCode);
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

                List<AutomaticInvoicePaymentConfiguration> paymentConfigurationsFromOtherLocations = new List<AutomaticInvoicePaymentConfiguration>();
                foreach (long? locationID in PermissionsManager.AccessibleLocationIDs)
                {
                    if (LocationID == locationID)
                    {
                        continue;
                    }

                    if (PermissionsManager.HasPermission(locationID.Value, PermissionsManager.LocationWidePermissions.ManageInvoices))
                    {
                        GetData getOtherLocation = new GetData(DataAccess.APIs.CompanyStudio, "AutomaticInvoicePaymentConfiguration/GetAll");
                        getOtherLocation.AddLocationHeader(companies.First(c => c.Locations.Any(l => l.LocationID == locationID)).CompanyID, locationID);
                        automaticInvoicePaymentConfigurations.AddRange(await getOtherLocation.GetObject<List<AutomaticInvoicePaymentConfiguration>>() ?? new List<AutomaticInvoicePaymentConfiguration>());
                    }
                }

                // Load available locations
                foreach (Company company in companies)
                {
                    foreach (Location location in company.Locations.Where(l => !existingLocations.Contains(l.LocationID)))
                    {
                        bool isCloneable = paymentConfigurationsFromOtherLocations.Any(c => c.LocationIDPayee == location.LocationID);

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
                    bool isCloneable = automaticInvoicePaymentConfigurations.Any(c => c.GovernmentIDPayee == government.GovernmentID);

                    ListViewItem newItem = new ListViewItem(new[] { government.Name + " (Government)", isCloneable ? "Yes" : "No" });
                    newItem.Tag = government;
                    lstAvailable.Items.Add(newItem);
                }

                // Keep a record of locations and governments we can clone from and populate respective boxes
                foreach (AutomaticInvoicePaymentConfiguration otherConfiguration in paymentConfigurationsFromOtherLocations)
                {
                    CloneFromItem cloneFromItem = new CloneFromItem()
                    {
                        Government = otherConfiguration.GovernmentPayee,
                        Location = otherConfiguration.LocationPayee
                    };

                    cboCloneAllFrom.Items.Add(cloneFromItem);
                    _clonedFromItemsByHashCode.Add(cloneFromItem.HashCode, cloneFromItem);
                }

                colCloneFrom.DataSource = _clonedFromItemsByHashCode.Values.ToList();
            }
            finally { loader.Visible = false; }
        }

        private class CloneFromItem
        {
            public Location Location { get; set; }
            public Government Government { get; set; }

            public override string ToString()
            {
                return Display;
            }

            public string Display => Location != null ? $"{Location.Company.Name} ({Location.Name})" : $"{Government.Name} (Government)";
            public int HashCode => GetHashCode();
        }
    }
}
