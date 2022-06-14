using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CompanyStudio.Models;
using MesaSuite.Common.Data;
using MesaSuite.Common.Utility;
using WeifenLuo.WinFormsUI.Docking;

namespace CompanyStudio.Accounts
{
    public partial class frmTransferFunds : Form
    {
        public long? AccountIDFrom { get; set; }
        public long? CompanyID { get; set; }
        public ThemeBase Theme { get; set; }
        public frmTransferFunds()
        {
            InitializeComponent();
        }

        private void frmTransferFunds_Load(object sender, EventArgs e)
        {
            studioFormExtender1.ApplyStyle(this, Theme);
            PermissionsManager.OnCompanyPermissionChange += PermissionsManager_OnPermissionChange;
            PopulateBoxes();
        }

        private void PermissionsManager_OnPermissionChange(object sender, PermissionsManager.CompanyWidePermissionChangeEventArgs e)
        {
            if (e.CompanyID == CompanyID && e.Permission == PermissionsManager.CompanyWidePermissions.ManageAccounts && !e.Value)
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private async void PopulateBoxes()
        {
            loader.BringToFront();
            loader.Visible = true;

            cboFrom.Items.Clear();
            cboTo.Items.Clear();
            txtAvailable.Clear();
            txtTransfer.Clear();

            GetData get = new GetData(DataAccess.APIs.CompanyStudio, "Account/GetForCompany");
            get.Headers.Add("CompanyID", CompanyID.ToString());

            List<Account> accounts = await get.GetObject<List<Account>>();

            foreach(Account account in accounts)
            {
                DropDownItem<Account> accountItem = DropDownItem.Create(account, account.AccountNumber + " - " + account.Description);
                cboFrom.Items.Add(accountItem);
                cboTo.Items.Add(accountItem);
            }

            if (cboFrom.Items.Cast<DropDownItem<Account>>().Any(ddi => ddi.Object.AccountID == AccountIDFrom))
            {
                cboFrom.SelectedItem = cboFrom.Items.Cast<DropDownItem<Account>>().First(ddi => ddi.Object.AccountID == AccountIDFrom);
                txtAvailable.Text = ((DropDownItem<Account>)cboFrom.SelectedItem).Object.Balance.ToString("N2");
            }

            loader.Visible = false;
        }

        private void frmTransferFunds_FormClosed(object sender, FormClosedEventArgs e)
        {
            PermissionsManager.OnCompanyPermissionChange -= PermissionsManager_OnPermissionChange;
        }

        private void txtTransfer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '\b')
            {
                return;
            }

            if (e.KeyChar == '.')
            {
                if (txtTransfer.Text.Contains('.'))
                {
                    txtTransfer.Select(txtTransfer.Text.IndexOf('.') + 1, 0);
                }
                else
                {
                    return;
                }
            }

            e.Handled = true;
        }

        private void txtTransfer_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtAvailable.Text))
            {
                txtAvailable.Text = decimal.Parse(txtAvailable.Text).ToString("N2");
            }
        }

        private async void cmdTransfer_Click(object sender, EventArgs e)
        {
            if (cboFrom.SelectedItem == null)
            {
                MessageBox.Show("From Account is a required field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cboTo.SelectedItem == null)
            {
                MessageBox.Show("To Account is a required field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cboFrom.SelectedItem == cboTo.SelectedItem)
            {
                MessageBox.Show("Cannot transfer to same account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(txtTransfer.Text) || !decimal.TryParse(txtTransfer.Text, out decimal transferAmount) || transferAmount == 0)
            {
                MessageBox.Show("Transfer Amount is a required field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Account sourceAccount = ((DropDownItem<Account>)cboFrom.SelectedItem).Object;
            if (sourceAccount.Balance < transferAmount)
            {
                MessageBox.Show("Cannot transfer more funds than are available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Account destinationAccount = ((DropDownItem<Account>)cboTo.SelectedItem).Object;
            PutData put = new PutData(DataAccess.APIs.CompanyStudio, "Account/Transfer", new
            {
                sourceAccountID = sourceAccount.AccountID,
                destinationAccountID = destinationAccount.AccountID,
                amount = transferAmount
            });
            put.Headers.Add("CompanyID", CompanyID.ToString());
            await put.ExecuteNoResult();
            if (put.RequestSuccessful)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void cboFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFrom.SelectedItem == null)
            {
                txtAvailable.Clear();
                return;
            }

            DropDownItem<Account> dropDownItem = (DropDownItem<Account>)cboFrom.SelectedItem;
            txtAvailable.Text = dropDownItem.Object.Balance.ToString("N2");
        }
    }
}
