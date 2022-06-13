﻿using System;
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
                { PermissionsManager.Permissions.ManageOfficials, toolOfficials },
                { PermissionsManager.Permissions.ManageEmails, toolEmail },
                { PermissionsManager.Permissions.ManageAccounts, toolAccounts },
                { PermissionsManager.Permissions.CanMintCurrency, tsbMintCurrency },
                { PermissionsManager.Permissions.ManageTaxes, tsmiTaxes },
                { PermissionsManager.Permissions.ManageInvoices, mnuInvoices }
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

                kvp.Value.Visible = PermissionsManager.HasPermission(_government.GovernmentID.Value, kvp.Key);
            }
        }

        private void toolOfficials_Click(object sender, EventArgs e)
        {
            frmGenericExplorer<Official> genericExplorer = new frmGenericExplorer<Official>(new OfficialExplorerContext(_government.GovernmentID.Value, _government.CanMintCurrency));
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

        private void tsmiAliases_Click(object sender, EventArgs e)
        {
            frmGenericExplorer<Alias> aliasExplorer = new frmGenericExplorer<Alias>(new Email.AliasExplorerContext(_government.GovernmentID.Value));
            aliasExplorer.MdiParent = this;
            aliasExplorer.Show();
        }

        private void tsmiDistributionLists_Click(object sender, EventArgs e)
        {
            frmGenericExplorer<DistributionList> distributionListExplorer = new frmGenericExplorer<DistributionList>(new Email.DistributionListExplorerContext(_government.GovernmentID.Value, _government.EmailDomain));
            distributionListExplorer.MdiParent = this;
            distributionListExplorer.Show();
        }

        private void tsmiAccountList_Click(object sender, EventArgs e)
        {
            frmGenericExplorer<Account> accountExplorer = new frmGenericExplorer<Account>(new Accounts.AccountExplorerContext(_government.GovernmentID.Value));
            accountExplorer.MdiParent = this;
            accountExplorer.Show();
        }

        private void tsmiAccountCategories_Click(object sender, EventArgs e)
        {
            new frmGenericExplorer<Category>(new Accounts.CategoryExplorerContext(_government.GovernmentID.Value))
            {
                MdiParent = this
            }.Show();
        }

        private void tsbMintCurrency_Click(object sender, EventArgs e)
        {
            new frmMintCurrency(_government.GovernmentID.Value).ShowDialog();
        }

        private void tsmiSalesTax_Click(object sender, EventArgs e)
        {
            new frmGenericExplorer<SalesTax>(new Taxes.SalesTaxContext(_government.GovernmentID.Value))
            {
                MdiParent = this
            }.Show();
        }

        private void mnuInvoiceReceivable_Click(object sender, EventArgs e)
        {
            new frmGenericExplorer<Invoice>(new Invoicing.ReceivableInvoiceContext(_government.GovernmentID.Value))
            {
                MdiParent = this
            }.Show();
        }

        private void mnuInvoicesInvoiceConfiguration_Click(object sender, EventArgs e)
        {
            new Invoicing.frmInvoiceConfiguration(_government.GovernmentID.Value).ShowDialog();
        }

        private void mnuInvoicePayable_Click(object sender, EventArgs e)
        {
            new frmGenericExplorer<Invoice>(new Invoicing.PayableInvoiceContext(_government.GovernmentID.Value))
            {
                MdiParent = this
            }.Show();
        }
    }
}
