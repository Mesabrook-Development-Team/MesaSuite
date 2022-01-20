using System;

namespace GovernmentPortal.Models
{
    public class SalesTax
    {
        public long SalesTaxID { get; set; }
        public long GovernmentID { get; set; }
        public DateTime EffectiveDate { get; set; }
        public decimal Rate { get; set; }
    }
}
