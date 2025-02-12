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
    [Table("463AC6AA-F2F1-4242-9970-EDD1FCAC34B9")]
    public class BlockAuditAlert : DataObject
    {
        protected BlockAuditAlert() : base() { }

        private long? _blockAuditAlert;
        [Field("3F8BE5E8-3DD4-472C-9725-E76EC9C47187")]
        public long? BlockAuditAlertID
        {
            get { CheckGet(); return _blockAuditAlert; }
            set { CheckSet(); _blockAuditAlert = value; }
        }

        private long? _blockAuditID;
        [Field("AC48A838-0CF1-48CC-8561-8A8DB734933F")]
        [Required]
        public long? BlockAuditID
        {
            get { CheckGet(); return _blockAuditID; }
            set { CheckSet(); _blockAuditID = value; }
        }

        private BlockAudit _blockAudit = null;
        [Relationship("942D31CE-C41F-4378-8B29-A51F2471C5F5")]
        public BlockAudit BlockAudit
        {
            get { CheckGet(); return _blockAudit; }
        }

        private bool _isAcknowledged;
        [Field("D85C4E1F-B9A4-4009-9670-FD27C68AC2C1")]
        public bool IsAcknowledged
        {
            get { CheckGet(); return _isAcknowledged; }
            set { CheckSet(); _isAcknowledged = value; }
        }
    }
}
