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
    internal class ReceivableInvoiceContext : ExplorerContext<Invoice>
    {
        public long GovernmentID { get; set; }

        public ReceivableInvoiceContext(long governmentID)
        {
            GovernmentID = governmentID;
        }

        internal override Icon ExplorerIcon => Properties.Resources.icn_govt;

        internal override IExplorerControl<Invoice> GetControlForModel(Invoice model)
        {
            return new ReceivableInvoiceControl(GovernmentID) { Model = model };
        }

        internal override async Task<List<DropDownItem<Invoice>>> GetInitialListItems()
        {
            GetData getInvoices = new GetData(DataAccess.APIs.GovernmentPortal, "Invoice/GetReceivables");
            getInvoices.AddGovHeader(GovernmentID);
            Func<Invoice, string> getName = inv =>
            {
                if (!string.IsNullOrEmpty(inv.LocationFrom?.Name) && !string.IsNullOrEmpty(inv.LocationFrom?.Company?.Name))
                {
                    return $"{inv.LocationFrom.Company.Name} - {inv.LocationFrom.Name}";
                }
                else if (!string.IsNullOrEmpty(inv.GovernmentFrom?.Name))
                {
                    return inv.GovernmentFrom.Name;
                }

                return string.Empty;
            };

            List<Invoice> invoices = await getInvoices.GetObject<List<Invoice>>() ?? new List<Invoice>();
            List<DropDownItem<Invoice>> dropDownItems = new List<DropDownItem<Invoice>>();
            foreach(Invoice invoice in invoices)
            {
                DropDownItem<Invoice> ddi = DropDownItem.Create<Invoice>(invoice, GetItemDisplayText(invoice.InvoiceNumber, invoice.Status.Value));
                if (invoice.Status != Invoice.Statuses.Complete && invoice.DueDate < DateTime.Today)
                {
                    ddi.BackgroundColor = Color.Red;
                    ddi.FontColor = Color.White;
                }
                dropDownItems.Add(ddi);
            }

            return dropDownItems;
        }

        public static string GetItemDisplayText(string invoiceNumber, Invoice.Statuses status)
        {
            return $"{invoiceNumber} ({status.ToString().ToDisplayName()})";
        }

        internal override string ObjectDisplayName => "Receivable Invoice";
    }
}
