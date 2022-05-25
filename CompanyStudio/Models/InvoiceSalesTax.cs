using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyStudio.Models
{
    public class InvoiceSalesTax
    {
        public long? InvoiceSalesTaxID { get; set; }
        public long InvoiceID { get; set; }
        public string Municipality { get; set; }
        public decimal Rate { get; set; }
        public decimal AppliedAmount { get; set; }
    }
}
