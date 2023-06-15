using System;
using System.Windows.Forms;
using GovernmentPortal.Extensions;
using GovernmentPortal.Models;
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;

namespace GovernmentPortal
{
    public partial class frmManageInterest : Form
    {
        public long? GovernmentID { get; set; }
        private long? InterestConfigurationID { get; set; }
        public frmManageInterest()
        {
            InitializeComponent();
        }

        private void frmManageInterest_Load(object sender, EventArgs e)
        {
            PermissionsManager.OnPermissionChange += PermissionsManager_OnPermissionChange;

            LoadData();
        }

        private async void LoadData()
        {
            loader.BringToFront();
            loader.Visible = true;

            try
            {
                GetData get = new GetData(DataAccess.APIs.GovernmentPortal, "InterestConfiguration/Get");
                get.AddGovHeader(GovernmentID.Value);
                InterestConfiguration interestConfiguration = await get.GetObject<InterestConfiguration>() ?? new InterestConfiguration();
                InterestConfigurationID = interestConfiguration.InterestConfigurationID;
                txtRateGov.Text = interestConfiguration.RateGovernment?.ToString();
                txtCapGov.Text = interestConfiguration.WealthCapGovernment?.ToString();
                txtRateLocation.Text = interestConfiguration.RateLocation?.ToString();
                txtCapLocation.Text = interestConfiguration.WealthCapLocation?.ToString();
                dtpNextInterestRun.Value = interestConfiguration.NextInterestRun ?? DateTime.Now;
            }
            finally
            {
                loader.Visible = false;
            }
        }

        private void PermissionsManager_OnPermissionChange(object sender, PermissionsManager.PermissionChangeEventArgs e)
        {
            if (e.GovernmentID == GovernmentID && e.Permission == PermissionsManager.Permissions.CanConfigureInterest && !e.Value)
            {
                Close();
            }
        }

        private void frmManageInterest_FormClosed(object sender, FormClosedEventArgs e)
        {
            PermissionsManager.OnPermissionChange -= PermissionsManager_OnPermissionChange;
        }

        private async void cmdSave_Click(object sender, EventArgs e)
        {
            if (!this.AreFieldsPresent(new System.Collections.Generic.List<(string, Control)>()
            {
                ("Government Interest Rate", txtRateGov),
                ("Government Wealth Cap", txtCapGov),
                ("Commercial Interest Rate", txtRateLocation),
                ("Commercial Wealth Cap", txtCapLocation)
            }))
            {
                return;
            }

            if (!decimal.TryParse(txtRateGov.Text, out decimal govRate) ||
                !decimal.TryParse(txtCapGov.Text, out decimal govCap) ||
                !decimal.TryParse(txtRateLocation.Text, out decimal locationRate) ||
                !decimal.TryParse(txtCapLocation.Text, out decimal locationCap))
            {
                this.ShowError("All values must be numeric");
                return;
            }

            loader.BringToFront();
            loader.Visible = true;

            try
            {
                InterestConfiguration interestConfiguration = new InterestConfiguration()
                {
                    InterestConfigurationID = InterestConfigurationID,
                    NextInterestRun = dtpNextInterestRun.Value,
                    RateGovernment = govRate,
                    WealthCapGovernment = govCap,
                    RateLocation = locationRate,
                    WealthCapLocation = locationCap
                };

                PutData put = new PutData(DataAccess.APIs.GovernmentPortal, "InterestConfiguration/Put", interestConfiguration);
                put.AddGovHeader(GovernmentID.Value);
                await put.ExecuteNoResult();
                if (put.RequestSuccessful)
                {
                    Close();
                }
            }
            finally
            {
                loader.Visible = false;
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
