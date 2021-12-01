using System;

namespace CompanyStudio.Models
{
    public class FiscalQuarter
    {
        public long FiscalQuarterID { get; set; }
        public long AccountID { get; set; }
        public byte Quarter { get; set; }
        public short Year { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal StartingBalance { get; set; }
        public decimal? EndingBalance { get; set; }
    }
}
