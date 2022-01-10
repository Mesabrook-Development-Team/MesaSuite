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
    public partial class frmTransfer : Form
    {
        private long _governmentID;
        private long _sourceAccountID;

        public frmTransfer()
        {
            InitializeComponent();
        }

        public frmTransfer(long sourceAccountID, long governmentID) : this()
        {
            _sourceAccountID = sourceAccountID;
            _governmentID = governmentID;
        }

        private async void frmTransfer_Load(object sender, EventArgs e)
        {
            loader.BringToFront();
            loader.Visible = true;

            GetData get = new GetData(DataAccess.APIs.GovernmentPortal, "Account/GetAll");
            get.AddGovHeader(_governmentID);
            List<Account> accounts = await get.GetObject<List<Account>>();
            if (!get.RequestSuccessful)
            {
                this.ShowError("Could not retrieve government Accounts");
                Close();
            }

            foreach(Account account in accounts)
            {
                DropDownItem<Account> accountItem = new DropDownItem<Account>(account, $"{account.Description} ({account.AccountNumber})");
                cboFrom.Items.Add(accountItem);
                cboTo.Items.Add(accountItem);
            }

            cboFrom.SelectedItem = cboFrom.Items.Cast<DropDownItem<Account>>().FirstOrDefault(a => a.Object.AccountID == _sourceAccountID);

            get = new GetData(DataAccess.APIs.GovernmentPortal, $"Account/Get/{_sourceAccountID}");
            get.AddGovHeader(_governmentID);
            Account sourceData = await get.GetObject<Account>();
            if (get.RequestSuccessful)
            {
                txtAvailable.Text = sourceData.Balance.ToString("N2");
            }

            loader.Visible = false;
        }

        private async void cboFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            loader.BringToFront();
            loader.Visible = true;

            DropDownItem<Account> item = cboFrom.SelectedItem.Cast<DropDownItem<Account>>();

            GetData get = new GetData(DataAccess.APIs.GovernmentPortal, $"Account/Get/{item?.Object.AccountID}");
            get.AddGovHeader(_governmentID);
            Account sourceData = await get.GetObject<Account>();
            txtAvailable.Text = sourceData?.Balance.ToString("N2");

            loader.Visible = false;
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
            PutData put = new PutData(DataAccess.APIs.GovernmentPortal, "Account/Transfer", new
            {
                sourceAccountID = sourceAccount.AccountID,
                destinationAccountID = destinationAccount.AccountID,
                amount = transferAmount
            });
            put.AddGovHeader(_governmentID);
            await put.ExecuteNoResult();
            if (put.RequestSuccessful)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
