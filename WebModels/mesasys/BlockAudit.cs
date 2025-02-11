using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebModels.mesasys
{
    [Table("1D134757-3C4B-4497-BF2E-52EB9D0CCA0D")]
    public class BlockAudit : DataObject
    {
        protected BlockAudit() : base() { }

        private long? _blockAuditID;
        [Field("BAC6644E-20C1-4A68-A9E1-007BCD7E336D")]
        public long? BlockAuditID
        {
            get { CheckGet(); return _blockAuditID; }
            set { CheckSet(); _blockAuditID = value; }
        }

        private DateTime? _auditTime;
        [Field("AF7ABD0C-C224-4885-9B6A-CF9EF0E3C4AD", DataSize = 7)]
        public DateTime? AuditTime
        {
            get { CheckGet(); return _auditTime; }
            set { CheckSet(); _auditTime = value; }
        }

        private int? _positionX;
        [Field("BBC7E270-CE5C-40EC-A580-CF69C3287623")]
        public int? PositionX
        {
            get { CheckGet(); return _positionX; }
            set { CheckSet(); _positionX = value; }
        }

        private int? _positionY;
        [Field("66684571-A928-4429-9753-C5AAA133F3E5")]
        public int? PositionY
        {
            get { CheckGet(); return _positionY; }
            set { CheckSet(); _positionY = value; }
        }

        private int? _positionZ;
        [Field("44BBD494-0625-4A9E-B46E-1D1DFD96185F")]
        public int? PositionZ
        {
            get { CheckGet(); return _positionZ; }
            set { CheckSet(); _positionZ = value; }
        }

        private string _blockName;
        [Field("4DA704B9-1425-49C1-A523-E72ED613CB4E", DataSize = 100)]
        public string BlockName
        {
            get { CheckGet(); return _blockName; }
            set { CheckSet(); _blockName = value; }
        }

        private string _playerName;
        [Field("5F41DAA6-7DFE-4123-A73D-123E0A38C7CD", DataSize = 50)]
        public string PlayerName
        {
            get { CheckGet(); return _playerName; }
            set { CheckSet(); _playerName = value; }
        }

        public enum AuditTypes
        {
            Place = 1,
            Break,
            Use
        }

        private AuditTypes _auditType;
        [Field("B216899E-E75F-4AD9-AF96-033447DD639D")]
        public AuditTypes AuditType
        {
            get { CheckGet(); return _auditType; }
            set { CheckSet(); _auditType = value; }
        }

        protected override void PreValidate()
        {
            // Truncate strings if they're too long to ensure data saves
            Field field = Schema.GetSchemaObject<BlockAudit>().GetField(nameof(BlockName));
            if (!string.IsNullOrEmpty(BlockName) && BlockName.Length > field.DataSize)
            {
                BlockName = BlockName.Substring(0, field.DataSize);
            }

            field = Schema.GetSchemaObject<BlockAudit>().GetField(nameof(PlayerName));
            if (!string.IsNullOrEmpty(PlayerName) && PlayerName.Length > field.DataSize)
            {
                PlayerName = PlayerName.Substring(0, field.DataSize);
            }

            // Use current time if time is null
            if (AuditTime == null)
            {
                AuditTime = DateTime.Now;
            }
        }
    }
}
