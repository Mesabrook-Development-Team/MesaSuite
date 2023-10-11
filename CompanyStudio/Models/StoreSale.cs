using System;
using System.Collections.Generic;

namespace CompanyStudio.Models
{
    public class StoreSale
    {
        public long? StoreSaleID { get; set; }
        public long? RegisterID { get; set; }
        public Register Register { get; set; }
        public DateTime? SaleTime { get; set; }

        public List<StoreSaleItem> StoreSaleItems { get; set; }
    }
}
