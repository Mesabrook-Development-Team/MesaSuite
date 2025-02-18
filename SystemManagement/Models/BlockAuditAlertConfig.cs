using System.Collections.Generic;

namespace SystemManagement.Models
{
    public class BlockAuditAlertConfig
    {
        public long? BlockAuditAlertConfigID { get; set; }
        public string DiscordIDs { get; set; }

        public List<BlockAuditAlertConfigBlock> BlockAuditAlertConfigBlocks { get; set; } = new List<BlockAuditAlertConfigBlock>();
    }
}
