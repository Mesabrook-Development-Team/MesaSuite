using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GovernmentPortal.Models;
using GovernmentPortal.Officials;

namespace GovernmentPortal
{
    public partial class frmPortal : Form
    {
        private Government _government = null;
        private Dictionary<PermissionsManager.Permissions, ToolStripItem> _toolStripItemsByPermission = new Dictionary<PermissionsManager.Permissions, ToolStripItem>();

        public frmPortal()
        {
            InitializeComponent();
        }

        private void SetupPermissions()
        {
            _toolStripItemsByPermission = new Dictionary<PermissionsManager.Permissions, ToolStripItem>()
            {
                { PermissionsManager.Permissions.ManageOfficials, toolOfficials }
            };
        }

        private void frmPortal_Shown(object sender, EventArgs e)
        {
            frmSelectGovernment selectGovernment = new frmSelectGovernment();
            if (DialogResult.Cancel == selectGovernment.ShowDialog())
            {
                Close();
                return;
            }

            _government = selectGovernment.SelectedGovernment;
            UpdateMenuVisibility();
        }

        private void UpdateMenuVisibility()
        {
            foreach (KeyValuePair<PermissionsManager.Permissions, ToolStripItem> kvp in _toolStripItemsByPermission)
            {
                if (_government == null)
                {
                    kvp.Value.Visible = false;
                    continue;
                }

                kvp.Value.Visible = PermissionsManager.HasPermission(_government.GovernmentID, kvp.Key);
            }
        }

        private void toolOfficials_Click(object sender, EventArgs e)
        {
            frmGenericExplorer<Official> genericExplorer = new frmGenericExplorer<Official>(new OfficialExplorerContext(_government.GovernmentID));
            genericExplorer.MdiParent = this;
            genericExplorer.Show();
        }

        private void frmPortal_Load(object sender, EventArgs e)
        {
            SetupPermissions();
            PermissionsManager.OnPermissionChange += PermissionsManager_OnPermissionChange;
            PermissionsManager.StartCheckThread(action => Invoke(action));
        }

        private void PermissionsManager_OnPermissionChange(object sender, PermissionsManager.PermissionChangeEventArgs e)
        {
            if (!_toolStripItemsByPermission.ContainsKey(e.Permission))
            {
                return;
            }

            _toolStripItemsByPermission[e.Permission].Visible = e.Value;
        }

        private void frmPortal_FormClosing(object sender, FormClosingEventArgs e)
        {
            PermissionsManager.OnPermissionChange -= PermissionsManager_OnPermissionChange;
            PermissionsManager.StopCheckThread();
        }

        private void tsbSwitchGovernment_Click(object sender, EventArgs e)
        {
            foreach(Form child in MdiChildren)
            {
                child.Close();
            }

            if (MdiChildren.Any())
            {
                return;
            }

            _government = null;
            UpdateMenuVisibility();

            frmSelectGovernment selectGovernment = new frmSelectGovernment();
            DialogResult result = selectGovernment.ShowDialog();

            if (result != DialogResult.OK)
            {
                Close();
            }

            _government = selectGovernment.SelectedGovernment;
            UpdateMenuVisibility();
        }
    }
}
