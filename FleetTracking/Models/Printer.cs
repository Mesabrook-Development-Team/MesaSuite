using System;
using System.Collections.Generic;

namespace FleetTracking.Models
{
    public class Printer
    {
        public long? PrinterID { get; set; }
        public Guid? Address { get; set; }
        public string Name { get; set; }

        public List<PrintJob> PrintJobs { get; set; }
    }
}
