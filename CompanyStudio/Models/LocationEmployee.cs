using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyStudio.Models
{
    public class LocationEmployee
    {
        public long? LocationEmployeeID { get; set; }
        public long? LocationID { get; set; }
        public long? EmployeeID { get; set; }
        public Employee Employee { get; set; }
        public bool ManageInvoices { get; set; }
        public bool ManagePrices { get; set; }
        public bool ManageRegisters { get; set; }
        public bool ManageInventory { get; set; }
    }
}
