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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FleetTracking.Misc
{
    public partial class MiscellaneousSettings : UserControl, IFleetTrackingControl
    {
        private FleetTrackingApplication _application;
        public FleetTrackingApplication Application { set => _application = value; }
        public MiscellaneousSettings()
        {
            InitializeComponent();
        }

        private long? MiscellaneousSettingsID { get; set; }

        private void MiscellaneousSettings_Load(object sender, EventArgs e)
        {
            if (_application.GetCurrentCompanyIDGovernmentID().Item1 == null)
            {
                grpLocation.Visible = false;
            }
            LoadData();
        }

        private async void LoadData()
        {
            try
            {
                loader.BringToFront();
                loader.Visible = true;

                GetData get = _application.GetAccess<GetData>();
                get.API = DataAccess.APIs.FleetTracking;

                long? companyID = _application.GetCurrentCompanyIDGovernmentID().Item1;

                if (companyID != null)
                {
                    get.Resource = $"Company/Get/{companyID}";

                    Company company = await get.GetObject<Company>();
                    if (company?.Locations != null)
                    {
                        foreach(Location location in company.Locations)
                        {
                            DropDownItem<Location> locationDDI = new DropDownItem<Location>(location, location.Name);
                            cboLocationPayee.Items.Add(locationDDI);
                            locationDDI = locationDDI.CreateCopy();
                            cboLocationPayor.Items.Add(locationDDI);
                        }
                    }
                }

                get.Resource = "MiscellaneousSettings/Get";
                Models.MiscellaneousSettings settings = await get.GetObject<Models.MiscellaneousSettings>();
                if (!get.RequestSuccessful)
                {
                    return;
                }

                MiscellaneousSettingsID = settings.MiscellaneousSettingsID;
                DropDownItem<Location> selectedDDI = cboLocationPayee.Items.OfType<DropDownItem<Location>>().FirstOrDefault(ddi => ddi.Object.LocationID == settings.LocationIDInvoicePayee);
                if (selectedDDI != null)
                {
                    cboLocationPayee.SelectedItem = selectedDDI;
                }

                selectedDDI = cboLocationPayor.Items.OfType<DropDownItem<Location>>().FirstOrDefault(ddi => ddi.Object.LocationID == settings.LocationIDInvoicePayor);
                if (selectedDDI != null)
                {
                    cboLocationPayor.SelectedItem = selectedDDI;
                }
            }
            finally
            {
                loader.Visible = false;
            }
        }

        private void flow_Resize(object sender, EventArgs e)
        {
            foreach(GroupBox groupBox in flow.Controls.OfType<GroupBox>())
            {
                groupBox.Width = flow.Width - 10;
            }
        }

        private async void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                (long?, long?) companyIDGovernmentID = _application.GetCurrentCompanyIDGovernmentID();

                Models.MiscellaneousSettings settings = new Models.MiscellaneousSettings()
                {
                    MiscellaneousSettingsID = MiscellaneousSettingsID,
                    CompanyID = companyIDGovernmentID.Item1,
                    GovernmentID = companyIDGovernmentID.Item2,
                    LocationIDInvoicePayee = cboLocationPayee.SelectedItem.Cast<DropDownItem<Location>>()?.Object.LocationID,
                    LocationIDInvoicePayor = cboLocationPayor.SelectedItem.Cast<DropDownItem<Location>>()?.Object.LocationID
                };

                PutData put = _application.GetAccess<PutData>();
                put.API = DataAccess.APIs.FleetTracking;
                put.Resource = "MiscellaneousSettings/Put";
                put.ObjectToPut = settings;
                await put.ExecuteNoResult();

                if (put.RequestSuccessful)
                {
                    ParentForm?.Close();
                    Dispose();
                }
            }
            finally
            {
                loader.Visible = false;
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            ParentForm?.Close();
            Dispose();
        }
    }
}
