using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GovernmentPortal.Extensions;
using GovernmentPortal.Models;
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;
using MesaSuite.Common.Utility;

namespace GovernmentPortal.Invoicing
{
    internal class PayableInvoiceContext : ExplorerContext<Invoice>
    {
        private long _governmentId;
        public PayableInvoiceContext(long governmentID)
        {
            _governmentId = governmentID;
        }

        internal override Icon ExplorerIcon => Properties.Resources.icn_govt;

        internal override IExplorerControl<Invoice> GetControlForModel(Invoice model)
        {
            return new PayableInvoiceControl(_governmentId) { Model = model };
        }

        internal override async Task<List<DropDownItem<Invoice>>> GetInitialListItems()
        {
            GetData get = new GetData(DataAccess.APIs.GovernmentPortal, "Invoice/GetPayables");
            get.AddGovHeader(_governmentId);
            List<Invoice> invoices = await get.GetObject<List<Invoice>>() ?? new List<Invoice>();

            List<DropDownItem<Invoice>> dropDownItems = new List<DropDownItem<Invoice>>();
            foreach(Invoice invoice in invoices)
            {
                DropDownItem<Invoice> invoiceDDI = new DropDownItem<Invoice>(invoice, GetItemDisplayText(invoice.InvoiceNumber, invoice.Status.Value));
                if (invoice.Status == Invoice.Statuses.Sent && invoice.DueDate <= DateTime.Today)
                {
                    invoiceDDI.BackgroundColor = Color.Red;
                    invoiceDDI.FontColor = Color.White;
                }

                dropDownItems.Add(invoiceDDI);
            }

            return dropDownItems;
        }

        public static string GetItemDisplayText(string invoiceNumber, Invoice.Statuses status)
        {
            return $"{invoiceNumber} ({status.ToString().ToDisplayName()})";
        }

        internal override string ObjectDisplayName => "Payable Invoice";
    }
}
