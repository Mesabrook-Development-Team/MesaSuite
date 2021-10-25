using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompanyStudio.Accounts
{
    public partial class frmAccountExplorer : BaseCompanyStudioContent
    {
        
        public frmAccountExplorer()
        {
            InitializeComponent();
            OnThemeChange += OnThemeChanged;
        }

        private void frmAccountExplorer_Load(object sender, EventArgs e)
        {
            Text += "- " + Company.Name;
            PermissionsManager.OnPermissionChange += PermissionsManager_OnPermissionChange;
        }

        private void OnThemeChanged(object sender, WeifenLuo.WinFormsUI.Docking.ThemeBase e)
        {
            toolStripExtender.SetStyle(toolStrip1, WeifenLuo.WinFormsUI.Docking.VisualStudioToolStripExtender.VsVersion.Vs2015, Theme);
        }

        private void PermissionsManager_OnPermissionChange(object sender, PermissionsManager.PermissionChangeEventArgs e)
        {
            if (e.CompanyID != Company.CompanyID || e.Permission != PermissionsManager.Permissions.ManageAccounts)
            {
                return;
            }

            if (!e.Value)
            {
                MessageBox.Show($"You do not have access to Account Explorer for {Company.Name}", "No Permission", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Close();
            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text.Equals("Search..."))
            {
                txtSearch.Clear();
                txtSearch.ForeColor = SystemColors.WindowText;
                txtSearch.Font = new Font(txtSearch.Font, FontStyle.Regular);
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                txtSearch.Text = "Search...";
                txtSearch.ForeColor = SystemColors.InactiveCaption;
                txtSearch.Font = new Font(txtSearch.Font, FontStyle.Italic);
            }
        }

        private async void FetchAccounts(bool doPopulate = true)
        {

        }

        private void PopulateTreeView()
        {

        }
    }
}
