using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CompanyStudio.Extensions;
using CompanyStudio.Models;
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;

namespace CompanyStudio.Invoicing
{
    public partial class frmAccountsReceivableExplorer : BaseCompanyStudioContent, ILocationScoped
    {
        private List<Invoice> invoices = new List<Invoice>();
        public frmAccountsReceivableExplorer()
        {
            InitializeComponent();
        }

        public Location LocationModel { get; set; }

        private void mnuAdd_Click(object sender, EventArgs e)
        {
            frmReceivableInvoice receivableInvoice = new frmReceivableInvoice();
            Studio.DecorateStudioContent(receivableInvoice);
            receivableInvoice.Company = Company;
            receivableInvoice.OnSave += ReceivableInvoice_OnSave;
            receivableInvoice.FormClosed += ReceivableInvoice_FormClosed;
            receivableInvoice.Show(Studio.dockPanel, WeifenLuo.WinFormsUI.Docking.DockState.Document);
        }

        private void ReceivableInvoice_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((frmReceivableInvoice)sender).FormClosed -= ReceivableInvoice_FormClosed;
        }

        private void ReceivableInvoice_OnSave(object sender, EventArgs e)
        {
            LoadInvoices();
        }

        private void frmAccountsReceivableExplorer_Load(object sender, EventArgs e)
        {
            LoadInvoices();
        }

        private async void LoadInvoices()
        {
            loader.BringToFront();
            loader.Visible = true;

            GetData get = new GetData(DataAccess.APIs.CompanyStudio, "Invoice/GetAll");
            get.AddLocationHeader(Company.CompanyID, LocationModel.LocationID);
            invoices = await get.GetObject<List<Invoice>>() ?? new List<Invoice>();
            invoices = invoices.Where(inv => (inv.CreationType == Invoice.CreationTypes.AccountsReceivable && inv.LocationIDFrom == LocationModel.LocationID) || (inv.CreationType == Invoice.CreationTypes.AccountsPayable && inv.LocationIDFrom == LocationModel.LocationID && (inv.Status == Invoice.Statuses.Sent || inv.Status == Invoice.Statuses.Complete))).ToList();

            loader.Visible = false;

            AddInvoicesToList();
        }

        private void AddInvoicesToList()
        {
            lstInvoices.Items.Clear();

            foreach (Invoice invoice in invoices)
            {
                string payor = "";
                if (invoice.LocationIDTo != default)
                {
                    payor = $"{invoice.LocationTo.Company.Name} ({invoice.LocationTo.Name})";
                }
                else if (invoice.GovernmentIDTo != default)
                {
                    payor = invoice.GovernmentTo.Name;
                }

                string amount = invoice.InvoiceLines.Sum(il => il.Total).ToString("N2");

                lstInvoices.Items.Add(new ListViewItem(new[] { invoice.InvoiceNumber, payor, amount, invoice.Status.ToString() }) { Tag = invoice });
            }
        }

        private void lstInvoices_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstInvoices.SelectedItems.Count == 0)
            {
                return;
            }

            frmReceivableInvoice frmReceivableInvoice = new frmReceivableInvoice();
            Studio.DecorateStudioContent(frmReceivableInvoice);
            frmReceivableInvoice.Company = Company;
            frmReceivableInvoice.LocationModel = LocationModel;
            frmReceivableInvoice.Invoice = (Invoice)lstInvoices.SelectedItems[0].Tag;
            frmReceivableInvoice.OnSave += frmReceivableInvoice_OnSave;
            frmReceivableInvoice.FormClosed += frmReceivableInvoice_FormClosed;
            frmReceivableInvoice.Show(Studio.dockPanel, WeifenLuo.WinFormsUI.Docking.DockState.Document);
        }

        private void frmReceivableInvoice_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmReceivableInvoice receivableInvoice = (frmReceivableInvoice)sender;
            receivableInvoice.FormClosed -= frmReceivableInvoice_FormClosed;
            receivableInvoice.OnSave -= frmReceivableInvoice_OnSave;
        }

        private void frmReceivableInvoice_OnSave(object sender, EventArgs e)
        {
            LoadInvoices();
        }

        private void lstInvoices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstInvoices.SelectedItems.Count <= 0)
            {
                mnuDelete.Enabled = false;
            }

            foreach(ListViewItem item in lstInvoices.SelectedItems)
            {
                Invoice invoice = (Invoice)item.Tag;
                if (invoice.Status == Invoice.Statuses.WorkInProgress || invoice.Status == Invoice.Statuses.Sent)
                {
                    mnuDelete.Enabled = true;
                    return;
                }
            }

            mnuDelete.Enabled = false;
        }

        private async void DeleteSelectedInvoices()
        {
            List<Invoice> invoicesToDelete = new List<Invoice>();
            foreach(ListViewItem item in lstInvoices.SelectedItems)
            {
                Invoice invoice = (Invoice)item.Tag;
                if (invoice.Status == Invoice.Statuses.WorkInProgress || invoice.Status == Invoice.Statuses.Sent)
                {
                    invoicesToDelete.Add(invoice);
                }
            }

            if (!invoicesToDelete.Any())
            {
                return;
            }

            if (!this.Confirm("Are you sure you want to delete these Invoices?"))
            {
                return;
            }

            loader.BringToFront();
            loader.Visible = true;

            foreach(Invoice invoice in invoicesToDelete)
            {
                DeleteData delete = new DeleteData(DataAccess.APIs.CompanyStudio, $"Invoice/Delete/{invoice.InvoiceID}");
                delete.AddLocationHeader(Company.CompanyID, LocationModel.LocationID);
                await delete.Execute();

                frmReceivableInvoice receivableInvoice = Studio.dockPanel.Contents.OfType<frmReceivableInvoice>().FirstOrDefault(content => content.Invoice?.InvoiceID == invoice.InvoiceID);
                if (receivableInvoice != null)
                {
                    receivableInvoice.Close();
                }
            }

            LoadInvoices();
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            DeleteSelectedInvoices();
        }

        private void lstInvoices_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DeleteSelectedInvoices();
            }
        }
    }
}
