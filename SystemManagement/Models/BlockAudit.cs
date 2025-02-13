using System;

namespace SystemManagement.Models
{
    public class BlockAudit
    {
        public long? BlockAuditID { get; set; }
        public DateTime? AuditTime { get; set; }
        public string BlockName { get; set; }
        public string PlayerName { get; set; }
        public int? PositionX { get; set; }
        public int? PositionY { get; set; }
        public int? PositionZ { get; set; }

        public string BlockPos => $"{PositionX}, {PositionY}, {PositionZ}";

        public enum AuditTypes
        {
            Place = 1,
            Break,
            Use
        }
        public AuditTypes AuditType { get; set; }
    }
}
