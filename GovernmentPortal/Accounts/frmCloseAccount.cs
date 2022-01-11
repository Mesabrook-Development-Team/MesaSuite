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

namespace GovernmentPortal.Accounts
{
    public partial class frmCloseAccount : Form
    {
        private long _accountID;
        private long _governmentID;
        public frmCloseAccount()
        {
            InitializeComponent();
        }

        public frmCloseAccount(long accountID, long governmentID) : this()
        {
            _accountID = accountID;
            _governmentID = governmentID;
        }

        private async void frmCloseAccount_Load(object sender, EventArgs e)
        {
            loader.BringToFront();
            loader.Visible = true;

            GetData get = new GetData(DataAccess.APIs.GovernmentPortal, $"Account/Get/{_accountID}");
            get.AddGovHeader(_governmentID);
            Account currentAccount = await get.GetObject<Account>();

            if (!get.RequestSuccessful)
            {
                Close();
                return;
            }

            if (currentAccount == null)
            {
                this.ShowError("Account no longer exists!");
                Close();
                return;
            }

            txtAccountToClose.Text = currentAccount.Description;
            txtBalance.Text = currentAccount.Balance.ToString("N2");

            get = new GetData(DataAccess.APIs.GovernmentPortal, "Account/GetAll");
            get.AddGovHeader(_governmentID);
            List<Account> accounts = await get.GetObject<List<Account>>();
            if (!get.RequestSuccessful)
            {
                Close();
                return;
            }

            foreach(Account account in accounts.Where(a => a.AccountID != _accountID))
            {
                cboDestAccount.Items.Add(new DropDownItem<Account>(account, $"{account.Description} ({account.AccountNumber}"));
            }

            loader.Visible = false;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void cmdConfirm_Click(object sender, EventArgs e)
        {
            if (cboDestAccount.SelectedItem == null)
            {
                this.ShowError("You must pick an Account to close to.");
                return;
            }

            DropDownItem<Account> destinationAccount = cboDestAccount.SelectedItem as DropDownItem<Account>;

            PutData close = new PutData(DataAccess.APIs.GovernmentPortal, "Account/Close", new { sourceAccountID = _accountID, destinationAccountID = destinationAccount.Object.AccountID });
            close.AddGovHeader(_governmentID);
            await close.ExecuteNoResult();

            if (close.RequestSuccessful)
            {
                DialogResult = DialogResult.OK;
                Close();
                return;
            }
        }
    }
}
