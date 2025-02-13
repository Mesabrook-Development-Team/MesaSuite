using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebModels.mesasys
{
    [Table("4DA48ED3-CAD3-4B91-A8A4-FBD4A0D50831")]
    public class BlockAudit : DataObject
    {
        protected BlockAudit() : base() { }

        private long? _blockAuditID;
        [Field("EA4B8170-CE21-4155-B5AD-A5FCDD586EA6")]
        public long? BlockAuditID
        {
            get { CheckGet(); return _blockAuditID; }
            set { CheckSet(); _blockAuditID = value; }
        }

        private DateTime? _auditTime;
        [Field("A1370A14-97D7-45FE-B78C-D4A2F30F12DC", DataSize = 7)]
        public DateTime? AuditTime
        {
            get { CheckGet(); return _auditTime; }
            set { CheckSet(); _auditTime = value; }
        }

        private int? _positionX;
        [Field("1F252BC5-D4E5-4281-AB06-D8C9B4752824")]
        public int? PositionX
        {
            get { CheckGet(); return _positionX; }
            set { CheckSet(); _positionX = value; }
        }

        private int? _positionY;
        [Field("968E7654-4221-451A-A86C-87BF88521B15")]
        public int? PositionY
        {
            get { CheckGet(); return _positionY; }
            set { CheckSet(); _positionY = value; }
        }

        private int? _positionZ;
        [Field("7FDC51FF-72AE-4C99-9DE9-1BF55C4673A2")]
        public int? PositionZ
        {
            get { CheckGet(); return _positionZ; }
            set { CheckSet(); _positionZ = value; }
        }

        private string _blockName;
        [Field("1031BA2B-8FEF-4118-AE4B-78D7BE68FED8", DataSize = 100)]
        public string BlockName
        {
            get { CheckGet(); return _blockName; }
            set { CheckSet(); _blockName = value; }
        }

        private string _playerName;
        [Field("76B09963-B208-45E9-8D99-06BE23A02223", DataSize = 50)]
        public string PlayerName
        {
            get { CheckGet(); return _playerName; }
            set { CheckSet(); _playerName = value; }
        }

        public enum AuditTypes
        {
            Unknown = 0,
            Place,
            Break,
            Use
        }

        private AuditTypes _auditType;
        [Field("68A13A52-F4B2-4AF1-959E-86D56EC6A4B0")]
        public AuditTypes AuditType
        {
            get { CheckGet(); return _auditType; }
            set { CheckSet(); _auditType = value; }
        }

        protected override bool PostSave(ITransaction transaction)
        {
            Search<BlockAuditAlertConfigBlock> alertSearch = new Search<BlockAuditAlertConfigBlock>(new StringSearchCondition<BlockAuditAlertConfigBlock>()
            {
                Field = nameof(BlockAuditAlertConfigBlock.BlockName),
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = BlockName
            });

            foreach(BlockAuditAlertConfigBlock blockAuditAlertConfigBlock in alertSearch.GetReadOnlyReader(transaction, FieldPathUtility.CreateFieldPathsAsList<BlockAuditAlertConfigBlock>(baacb => new object[]
            {
                baacb.AlertBreak,
                baacb.AlertPlace,
                baacb.AlertUse
            })))
            {
                if ((blockAuditAlertConfigBlock.AlertBreak && AuditType == AuditTypes.Break) ||
                    (blockAuditAlertConfigBlock.AlertPlace && AuditType == AuditTypes.Place) ||
                    (blockAuditAlertConfigBlock.AlertUse && AuditType == AuditTypes.Use))
                {
                    BlockAuditAlert alert = DataObjectFactory.Create<BlockAuditAlert>();
                    alert.BlockAuditID = BlockAuditID;
                    if (!alert.Save(transaction))
                    {
                        Errors.AddRange(alert.Errors.ToArray());
                        return false;
                    }
                }
            }

            return base.PostSave(transaction);
        }

        #region Relationships
        #region mesasys
        private List<BlockAuditAlert> _blockAuditAlerts = new List<BlockAuditAlert>();
        [RelationshipList("9F0C238E-4561-4B50-9EA7-BBFC34D8851A", nameof(BlockAuditAlert.BlockAuditID))]
        public IReadOnlyCollection<BlockAuditAlert> BlockAuditAlerts
        {
            get { CheckGet(); return _blockAuditAlerts; }
        }
        #endregion
        #endregion
    }
}
