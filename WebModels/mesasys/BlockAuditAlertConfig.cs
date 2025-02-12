using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebModels.mesasys
{
    [Table("E0583FEC-A719-4E84-BFC7-08B3131A90F8")]
    public class BlockAuditAlertConfig : DataObject
    {
        protected BlockAuditAlertConfig() : base() { }

        private long? _blockAuditAlertConfigID;
        [Field("69AE4D4F-FADB-4C6C-B7EB-5B8A7B84DAA5")]
        public long? BlockAuditAlertConfigID
        {
            get { CheckGet(); return _blockAuditAlertConfigID; }
            set { CheckSet(); _blockAuditAlertConfigID = value; }
        }

        private string _discordIDs;
        [Field("763A7B3F-1568-4514-BC18-4EF1B3114F4D", DataSize = 300)]
        public string DiscordIDs
        {
            get { CheckGet(); return _discordIDs; }
            set { CheckSet(); _discordIDs = value; }
        }

        #region Relationships
        #region mesasys
        private List<BlockAuditAlertConfigBlock> _blockAuditAlertConfigBlocks = new List<BlockAuditAlertConfigBlock>();
        [RelationshipList("A89B0DB1-AA9F-41A5-80A5-FFC7955B50F1", nameof(BlockAuditAlertConfigBlock.BlockAuditAlertConfigID))]
        public IReadOnlyCollection<BlockAuditAlertConfigBlock> BlockAuditAlertConfigBlocks
        {
            get { CheckGet(); return _blockAuditAlertConfigBlocks; }
        }
        #endregion
        #endregion

        public static async Task<BlockAuditAlertConfig> GetOrCreate(IEnumerable<string> fields)
        {
            Search<BlockAuditAlertConfig> configSearch = new Search<BlockAuditAlertConfig>();
            if (!await Task.Run(() => configSearch.ExecuteExists(null)))
            {
                BlockAuditAlertConfig config = DataObjectFactory.Create<BlockAuditAlertConfig>();
                config.Save();
            }

            return await Task.Run(() => configSearch.GetReadOnly(null, fields));
        }
    }
}
