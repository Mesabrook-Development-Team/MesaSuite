using CompanyStudio.Models;
using CompanyStudio.Wizard;
using MesaSuite.Common.Data;
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

namespace CompanyStudio.Store.ClonePrices
{
    public partial class OriginStep : UserControl, IWizardStep<ClonePricesWizardData>, IUsesWizardLoader
    {
        private long? _currentLocationID;
        public OriginStep()
        {
            InitializeComponent();
        }

        public OriginStep(long? currentLocationID) : this()
        {
            _currentLocationID = currentLocationID;
        }

        private Action _showLoader;
        public Action ShowLoader { set => _showLoader = value; }
        private Action _hideLoader;
        public Action HideLoader { set => _hideLoader = value; }

        public string NavigationName => "Origin";

        public Control Control => this;

        public async Task Commit(ClonePricesWizardData data)
        {
            data.CompanyIDOrigin = cboCompanies.SelectedItem == null ? 0 : ((DropDownItem<Company>)cboCompanies.SelectedItem).Object.CompanyID;
            data.LocationIDOrigin = cboLocations.SelectedItem == null ? 0 : ((DropDownItem<Location>)cboLocations.SelectedItem).Object.LocationID;
        }

        async Task IWizardStep<ClonePricesWizardData>.Load(ClonePricesWizardData data)
        {
            _showLoader();
            try
            {
                cboCompanies.Items.Clear();
                cboLocations.Items.Clear();

                GetData get = new GetData(DataAccess.APIs.CompanyStudio, "Company/GetForEmployee");
                List<Company> companies = await get.GetObject<List<Company>>() ?? new List<Company>();
                foreach(Company company in companies)
                {
                    DropDownItem<Company> ddi = new DropDownItem<Company>(company, company.Name);
                    cboCompanies.Items.Add(ddi);
                }

                if (data.LocationIDOrigin != null)
                {
                    cboCompanies.SelectedItem = cboCompanies.Items.OfType<DropDownItem<Company>>().FirstOrDefault(x => x.Object.Locations.Any(l => l.LocationID == data.LocationIDOrigin));
                    cboLocations.SelectedItem = cboLocations.Items.OfType<DropDownItem<Location>>().FirstOrDefault(x => x.Object.LocationID == data.LocationIDOrigin);
                }
                else if (_currentLocationID != null)
                {
                    cboCompanies.SelectedItem = cboCompanies.Items.OfType<DropDownItem<Company>>().FirstOrDefault(x => x.Object.Locations.Any(l => l.LocationID == _currentLocationID));
                    cboLocations.SelectedItem = cboLocations.Items.OfType<DropDownItem<Location>>().FirstOrDefault(x => x.Object.LocationID == _currentLocationID);
                }
            }
            finally
            {
                _hideLoader();
            }
        }

       async Task<List<string>> IWizardStep<ClonePricesWizardData>.Validate()
        {
            if (cboLocations.SelectedItem == null)
            {
                return new List<string>()
                {
                    "Location is a required field"
                };
            }

            return new List<string>();
        }

        private void cboCompanies_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboLocations.Items.Clear();

            DropDownItem<Company> ddi = cboCompanies.SelectedItem as DropDownItem<Company>;
            if (ddi == null)
            {
                return;
            }

            foreach (Location location in ddi.Object.Locations)
            {
                DropDownItem<Location> locationDDI = new DropDownItem<Location>(location, location.Name);
                cboLocations.Items.Add(locationDDI);
            }
        }
    }
}
