using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GovernmentPortal.Extensions;
using GovernmentPortal.Models;
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;
using MesaSuite.Common.Utility;

namespace GovernmentPortal.WireTransfers
{
    public partial class frmIssue : Form
    {
        private long _governmentID;

        public frmIssue()
        {
            InitializeComponent();
        }

        public frmIssue(long governmentID) : this()
        {
            _governmentID = governmentID;
        }

        private async void frmIssue_Load(object sender, EventArgs e)
        {
            loader.BringToFront();
            loader.Visible = true;

            GetData get = new GetData(DataAccess.APIs.GovernmentPortal, "Account/MyAccounts");
            get.AddGovHeader(_governmentID);
            List<Account> accounts = await get.GetObject<List<Account>>() ?? new List<Account>();

            foreach(Account account in accounts)
            {
                cboFromAccount.Items.Add(new DropDownItem<Account>(account, $"{account.AccountNumber} ({account.Description})"));
            }

            loader.Visible = false;
        }

        private async void cmdSend_Click(object sender, EventArgs e)
        {
            if (cboFromAccount.SelectedItem == null)
            {
                this.ShowError("From Account is a required field.");
                return;
            }

            if (string.IsNullOrEmpty(txtToAccount.Text))
            {
                this.ShowError("To Account is a required field.");
                return;
            }

            if (txtToAccount.Text.Length != 16)
            {
                this.ShowError("To Account is not a valid account number.");
                return;
            }

            if (string.IsNullOrEmpty(txtTransferAmount.Text))
            {
                this.ShowError("Transfer Amount is a required field.");
                return;
            }

            if (!decimal.TryParse(txtTransferAmount.Text, out decimal transferAmount))
            {
                this.ShowError("Transfer Amount is not a valid number.");
                return;
            }

            Account selectedAccount = ((DropDownItem<Account>)cboFromAccount.SelectedItem).Object;
            if (selectedAccount.Balance < transferAmount)
            {
                this.ShowError("You do not have sufficient funds to transfer this amount.");
                return;
            }

            loader.BringToFront();
            loader.Visible = true;

            PutData put = new PutData(DataAccess.APIs.GovernmentPortal, "WireTransferHistory/PerformWireTransfer", new
            {
                AccountIDFrom = selectedAccount.AccountID,
                AccountTo = txtToAccount.Text,
                Amount = transferAmount,
                Memo = txtMemo.Text
            });
            put.AddGovHeader(_governmentID);
            await put.ExecuteNoResult();

            if (put.RequestSuccessful)
            {
                Close();
            }

            loader.Visible = false;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cboFromAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownItem<Account> item = (DropDownItem<Account>)cboFromAccount.SelectedItem;
            txtAvailableAmount.Text = item?.Object.Balance.ToString("N2");
        }
    }
}
