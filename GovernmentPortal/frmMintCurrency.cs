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

namespace GovernmentPortal
{
    public partial class frmMintCurrency : Form
    {
        private long _governmentID;

        public frmMintCurrency()
        {
            InitializeComponent();
        }

        public frmMintCurrency(long governmentID) : this()
        {
            _governmentID = governmentID;
        }

        private async void frmMintCurrency_Load(object sender, EventArgs e)
        {
            loader.BringToFront();
            loader.Visible = true;

            GetData get = new GetData(DataAccess.APIs.GovernmentPortal, "Account/MyAccounts");
            get.AddGovHeader(_governmentID);
            List<Account> accounts = await get.GetObject<List<Account>>();
            if (!get.RequestSuccessful)
            {
                loader.Visible = false;
                return;
            }

            cboAccount.Items.AddRange(accounts.Select(a => new DropDownItem<Account>(a, $"{a.AccountNumber} ({a.Description})")).ToArray());

            loader.Visible = false;
        }

        private async void cmdMint_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAmount.Text) || !decimal.TryParse(txtAmount.Text, out decimal amount))
            {
                this.ShowError("Amount is a required field");
                return;
            }

            if (amount <= 0)
            {
                this.ShowError("Amount must be greater than 0");
                return;
            }

            if (cboAccount.SelectedItem == null)
            {
                this.ShowError("Destination Account is a required field");
                return;
            }

            loader.BringToFront();
            loader.Visible = true;

            PutData put = new PutData(DataAccess.APIs.GovernmentPortal, "Government/MintCurrency", new { AccountIDDeposit = cboAccount.SelectedItem.Cast<DropDownItem<Account>>().Object.AccountID, Amount = amount });
            put.AddGovHeader(_governmentID);
            await put.ExecuteNoResult();
            if (!put.RequestSuccessful)
            {
                loader.Visible = false;
                return;
            }

            Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
