namespace SystemManagement.Models
{
    public class BlockAuditAlertConfigBlock
    {
        public long? BlockAuditAlertConfigBlockID { get; set; }
        public long? BlockAuditAlertConfigID { get; set; }
        public string BlockName { get; set; }
        public bool AlertPlace { get; set; }
        public bool AlertBreak { get; set; }
        public bool AlertUse { get; set; }
    }
}
