using System;
using System.Windows.Forms;
using GovernmentPortal.Extensions;
using GovernmentPortal.Models;
using MesaSuite.Common.Data;

namespace GovernmentPortal
{
    public partial class frmManageInterest : Form
    {
        public long? GovernmentID { get; set; }
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
                txtRateGov.Text = interestConfiguration.RateGovernment?.ToString();
                txtCapGov.Text = interestConfiguration.WealthCapGovernment?.ToString();
                txtRateLocation.Text = interestConfiguration.RateLocation?.ToString();
                txtCapLocation.Text = interestConfiguration.WealthCapLocation?.ToString();
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
    }
}
