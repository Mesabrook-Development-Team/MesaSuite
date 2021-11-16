using System;

namespace SystemManagement.Models
{
    public class CrashReport
    {
        public long CrashReportID { get; set; }
        public DateTime Time { get; set; }
        public string Program { get; set; }
        public string Exception { get; set; }
        public string User { get; set; }
    }
}
