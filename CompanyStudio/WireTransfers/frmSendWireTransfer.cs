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
using MesaSuite.Common.Extensions;
using MesaSuite.Common.Utility;
using WeifenLuo.WinFormsUI.Docking;

namespace CompanyStudio.WireTransfers
{
    public partial class frmSendWireTransfer : Form
    {
        public Company Company { get; set; }
        public ThemeBase Theme { get; set; }

        public frmSendWireTransfer()
        {
            InitializeComponent();
        }

        private async void frmSendWireTransfer_Load(object sender, EventArgs e)
        {
            studioFormExtender.ApplyStyle(this, Theme);
            PermissionsManager.OnCompanyPermissionChange += PermissionsManager_OnCompanyPermissionChange;
            await LoadAccounts();
        }

        private async Task LoadAccounts()
        {
            loader.BringToFront();
            loader.Visible = true;

            GetData get = new GetData(DataAccess.APIs.CompanyStudio, "Account/GetAllForUser");
            get.AddCompanyHeader(Company.CompanyID);
            List<Account> accounts = await get.GetObject<List<Account>>() ?? new List<Account>();

            foreach(Account account in accounts)
            {
                cboFromAccount.Items.Add(new DropDownItem<Account>(account, account.Description + " (" + account.AccountNumber + ")"));
            }

            loader.Visible = false;
        }

        private void PermissionsManager_OnCompanyPermissionChange(object sender, PermissionsManager.CompanyWidePermissionChangeEventArgs e)
        {
            if (e.CompanyID == Company.CompanyID && e.Permission == PermissionsManager.CompanyWidePermissions.IssueWireTransfers && !e.Value)
            {
                Close();
            }
        }

        private void frmSendWireTransfer_FormClosed(object sender, FormClosedEventArgs e)
        {
            PermissionsManager.OnCompanyPermissionChange -= PermissionsManager_OnCompanyPermissionChange;
        }

        private void cboFromAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownItem<Account> account = (DropDownItem<Account>)cboFromAccount.SelectedItem;
            if (account == null)
            {
                txtAvailableAmount.Clear();
                return;
            }

            txtAvailableAmount.Text = account.Object.Balance.ToString("N2");
        }

        private async void cmdSend_Click(object sender, EventArgs e)
        {
            DropDownItem<Account> accountFrom = (DropDownItem<Account>)cboFromAccount.SelectedItem;
            if (accountFrom == null)
            {
                this.ShowError("A valid From Account must be selected.");
                return;
            }

            if (txtToAccount.Text.Length != 16)
            {
                this.ShowError("A valid To Account must be entered.");
                return;
            }

            if (accountFrom.Object.AccountNumber.Equals(txtToAccount.Text, StringComparison.OrdinalIgnoreCase))
            {
                this.ShowError("Wire Transfers From and To the same account are not permitted.");
                return;
            }

            if (!decimal.TryParse(txtTransferAmount.Text, out decimal amount))
            {
                this.ShowError("A valid amount must be entered.");
                return;
            }

            if (amount < 0)
            {
                this.ShowError("Transfer amount must be greater than 0.");
                return;
            }

            loader.BringToFront();
            loader.Visible = true;

            PutData put = new PutData(DataAccess.APIs.CompanyStudio, "WireTransferHistory/PerformWireTransfer", new
            {
                AccountIDFrom = accountFrom.Object.AccountID,
                AccountTo = txtToAccount.Text,
                Amount = amount,
                Memo = txtMemo.Text
            });
            put.AddCompanyHeader(Company.CompanyID);
            await put.ExecuteNoResult();

            if (put.RequestSuccessful)
            {
                Close();
            }

            loader.Visible = false;
        }
    }
}
