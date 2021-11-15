using System.Collections.Generic;
using System.Windows.Forms;
using CompanyStudio.Models;
using MesaSuite.Common.Data;
using MesaSuite.Common.Utility;
using WeifenLuo.WinFormsUI.Docking;

namespace CompanyStudio.Accounts
{
    public partial class frmCloseAccount : Form
    {
        public Account AccountToClose { get; set; }
        public long CompanyID { get; set; }
        public ThemeBase Theme { get; set; }

        public frmCloseAccount()
        {
            InitializeComponent();
            PermissionsManager.OnPermissionChange += PermissionsManager_OnPermissionChange;
        }

        private void PermissionsManager_OnPermissionChange(object sender, PermissionsManager.PermissionChangeEventArgs e)
        {
            if (e.CompanyID == CompanyID && e.Permission == PermissionsManager.Permissions.ManageAccounts && !e.Value)
            {
                Close();
            }
        }

        private void frmCloseAccount_FormClosed(object sender, FormClosedEventArgs e)
        {
            PermissionsManager.OnPermissionChange -= PermissionsManager_OnPermissionChange;
        }

        private async void frmCloseAccount_Load(object sender, System.EventArgs e)
        {
            studioFormExtender.ApplyStyle(this, Theme);
            loader.BringToFront();
            loader.Visible = true;

            txtAccountToClose.Text = AccountToClose.Description;
            txtBalance.Text = AccountToClose.Balance.ToString("N2");

            GetData getAccounts = new GetData(DataAccess.APIs.CompanyStudio, "Account/GetForCompany");
            getAccounts.Headers.Add("CompanyID", CompanyID.ToString());
            List<Account> accounts = await getAccounts.GetObject<List<Account>>();

            if (accounts != null)
            {
                foreach(Account account in accounts)
                {
                    if (account.AccountID == AccountToClose.AccountID)
                    {
                        continue;
                    }

                    cboDestAccount.Items.Add(DropDownItem.Create(account, account.AccountNumber + " - " + account.Description));
                }
            }

            loader.Visible = false;
        }

        private async void cmdConfirm_Click(object sender, System.EventArgs e)
        {
            if (cboDestAccount.SelectedItem == null)
            {
                MessageBox.Show("You must select a destination account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            loader.BringToFront();
            loader.Visible = true;

            DropDownItem<Account> selectedAccount = (DropDownItem<Account>)cboDestAccount.SelectedItem;

            PutData put = new PutData(DataAccess.APIs.CompanyStudio, "Account/Close", new { closingAccountID = AccountToClose.AccountID, destinationAccountID = selectedAccount.Object.AccountID });
            put.Headers.Add("CompanyID", CompanyID.ToString());
            await put.ExecuteNoResult();

            if (!put.RequestSuccessful)
            {
                loader.Visible = false;
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cmdCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
