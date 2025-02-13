using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Validation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebModels.mesasys
{
    [Table("7E485968-256C-4F1B-B1E0-2621B9B184A1")]
    public class BlockAuditAlertConfigBlock : DataObject
    {
        protected BlockAuditAlertConfigBlock() : base() { }

        private long? _blockAuditAlertConfigBlockID;
        [Field("38C10518-D0B6-493D-BE73-6CE4EAB39E0E")]
        public long? BlockAuditAlertConfigBlockID
        {
            get { CheckGet(); return _blockAuditAlertConfigBlockID; }
            set { CheckSet(); _blockAuditAlertConfigBlockID = value; }
        }

        private long? _blockAuditAlertConfigID;
        [Field("EC37FE03-8B18-45F5-B1C3-D138DBD77ED6")]
        [Required]
        public long? BlockAuditAlertConfigID
        {
            get { CheckGet(); return _blockAuditAlertConfigID; }
            set { CheckSet(); _blockAuditAlertConfigID = value; }
        }

        private BlockAuditAlertConfig _blockAuditAlertConfig = null;
        [Relationship("BC65E350-497E-4471-95F3-A41F278FEFA2")]
        public BlockAuditAlertConfig BlockAuditAlertConfig
        {
            get { CheckGet(); return _blockAuditAlertConfig; }
        }

        private string _blockName;
        [Field("EA7C9C98-52A3-4849-85CA-A8095645A2E6", DataSize = 100)]
        public string BlockName
        {
            get { CheckGet(); return _blockName; }
            set { CheckSet(); _blockName = value; }
        }

        private bool _alertPlace;
        [Field("5C88FC14-873A-4DF3-8F6C-34826856663D")]
        public bool AlertPlace
        {
            get { CheckGet(); return _alertPlace; }
            set { CheckSet(); _alertPlace = value; }
        }

        private bool _alertBreak;
        [Field("5015DBA4-5B36-41AB-B4F5-797E7B104AF7")]
        public bool AlertBreak
        {
            get { CheckGet(); return _alertBreak; }
            set { CheckSet(); _alertBreak = value; }
        }

        private bool _alertUse;
        [Field("1C8547DF-FC66-4A08-A39D-F709EC7CB039")]
        public bool AlertUse
        {
            get { CheckGet(); return _alertUse; }
            set { CheckSet(); _alertUse = value; }
        }
    }
}
