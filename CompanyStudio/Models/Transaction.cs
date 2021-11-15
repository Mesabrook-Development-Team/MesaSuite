using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyStudio.Models
{
    public class Transaction
    {
        public long TransactionID { get; set; }
        public long FiscalQuarterID { get; set; }
        public DateTime TransactionTime { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
    }
}
