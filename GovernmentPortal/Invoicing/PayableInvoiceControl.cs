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

namespace GovernmentPortal.Invoicing
{
    public partial class PayableInvoiceControl : UserControl, IExplorerControl<Invoice>
    {
        public event EventHandler IsDirtyChanged;
        private long _governmentID;
        public PayableInvoiceControl()
        {
            InitializeComponent();
        }

        public PayableInvoiceControl(long governmentID) : this()
        {
            _governmentID = governmentID;
        }

        private bool _isDirty;
        public bool IsDirty
        {
            get => _isDirty;
            set
            {
                _isDirty = value;
                IsDirtyChanged?.Invoke(this, EventArgs.Empty);
            }
        }
        public Invoice Model { get; set; }
        private frmGenericExplorer<Invoice> _explorer;
        public frmGenericExplorer<Invoice> Explorer { set => _explorer = value; }


        public void OnDeleteClicked()
        {
            this.ShowError("Cannot delete Accounts Payable Invoices.");
        }

        public async void OnSaveClicked()
        {
            if (Model.Status != Invoice.Statuses.Sent)
            {
                this.ShowError("Cannot save an Invoice that is not marked as Sent.");
                return;
            }

            await InternalSave();

            Dispose();
            _explorer.LoadAllItems(true, PayableInvoiceContext.GetItemDisplayText(Model.InvoiceNumber, Model.Status.Value));
        }

        private async Task<bool> InternalSave()
        {
            try
            {
                loader.BringToFront();
                loader.Visible = true;

                if (Model == null)
                {
                    this.ShowError("Cannot save a new Accounts Payable Invoice.");
                    return false;
                }

                if (Model.Status != Invoice.Statuses.Sent)
                {
                    this.ShowError("Can only save an Accounts Payable Invoice that is in Sent status.");
                    return false;
                }

                DropDownItem<Account> accountItem = cboPayableAccount.SelectedItem.Cast<DropDownItem<Account>>();

                PatchData patch = new PatchData(DataAccess.APIs.GovernmentPortal, "Invoice/Patch", PatchData.PatchMethods.Replace, Model.InvoiceID, new Dictionary<string, object>()
            {
                { nameof(Invoice.AccountIDFrom), accountItem?.Object.AccountID }
            });
                patch.AddGovHeader(_governmentID);
                await patch.Execute();
                if (!patch.RequestSuccessful)
                {
                    return false;
                }


                IsDirty = false;
                return true;
            }
            finally 
            {
                loader.Visible = false;
            }
        }

        private async void PayableInvoiceControl_Load(object sender, EventArgs e)
        {
            if (Model == null)
            {
                this.ShowError("Cannot create Accounts Payable Invoices.");
                Dispose();
                return;
            }

            loader.BringToFront();
            loader.Visible = true;

            txtPayee.Text = Model.LocationFrom != null ? $"{Model.LocationFrom.Name} ({Model.LocationFrom.Company?.Name})" : Model.GovernmentFrom?.Name;
            txtPayor.Text = Model.GovernmentTo?.Name;
            txtInvoiceNumber.Text = Model.InvoiceNumber;
            dtpInvoiceDate.Value = Model.InvoiceDate;
            dtpDueDate.Value = Model.DueDate;
            txtDescription.Text = Model.Description;
            decimal invoiceTotal = Model.InvoiceLines.Sum(x => x.Total);
            txtInvoiceTotalInfoTab.Text = invoiceTotal.ToString("N2");
            txtInvoiceTotalLinesTab.Text = invoiceTotal.ToString("N2");
            lblStatus.Text = Model.Status.ToString().ToDisplayName();

            if (Model.Status == Invoice.Statuses.Complete)
            {
                DropDownItem<Account> accountItem = new DropDownItem<Account>(new Account(), Model.AccountFromHistorical);
                cboPayableAccount.Items.Add(accountItem);
                cboPayableAccount.SelectedItem = accountItem;
            }
            else
            {
                GetData get = new GetData(DataAccess.APIs.GovernmentPortal, "Account/MyAccounts");
                get.AddGovHeader(_governmentID);
                List<Account> accounts = await get.GetObject<List<Account>>() ?? new List<Account>();

                foreach(Account account in accounts)
                {
                    DropDownItem<Account> accountItem = new DropDownItem<Account>(account, $"{account.Description} ({account.AccountNumber})");
                    cboPayableAccount.Items.Add(accountItem);

                    if (account.AccountID == Model.AccountIDFrom)
                    {
                        cboPayableAccount.SelectedItem = accountItem;
                    }
                }
            }

            foreach(InvoiceLine line in Model.InvoiceLines)
            {
                int rowIndex = dgvLines.Rows.Add();
                dgvLines[colDescription.Name, rowIndex].Value = line.Description;
                dgvLines[colQuantity.Name, rowIndex].Value = line.Quantity.ToString("N2");
                dgvLines[colUnitCost.Name, rowIndex].Value = line.UnitCost.ToString("N2");
                dgvLines[colTotal.Name, rowIndex].Value = line.Total.ToString("N2");
            }

            cboPayableAccount.Enabled = Model.Status == Invoice.Statuses.Sent;
            cmdAuthorizePayment.Visible = Model.Status == Invoice.Statuses.Sent;

            loader.Visible = false;
        }

        private async void cmdAuthorizePayment_Click(object sender, EventArgs e)
        {
            if (!await InternalSave())
            {
                return;
            }

            DropDownItem<Account> accountItem = cboPayableAccount.SelectedItem.Cast<DropDownItem<Account>>();
            if (accountItem == null)
            {
                this.ShowError("You must select an account to authorize payment from.");
                return;
            }

            PutData authorizePut = new PutData(DataAccess.APIs.GovernmentPortal, $"Invoice/AuthorizePayment/{Model.InvoiceID}", new { });
            authorizePut.AddGovHeader(_governmentID);
            await authorizePut.ExecuteNoResult();

            if (!authorizePut.RequestSuccessful)
            {
                return;
            }

            Dispose();
            _explorer.LoadAllItems(true, PayableInvoiceContext.GetItemDisplayText(Model.InvoiceNumber, Invoice.Statuses.ReadyForReceipt));
        }
    }
}
