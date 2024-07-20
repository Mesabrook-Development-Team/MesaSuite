using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Utility;
using WebModels.mesasys;

namespace WebModels.company
{
    [Table("EA92FE53-9715-4295-B0E1-3BD5B1507933")]
    public class RegisterStatus : DataObject
    {
        protected RegisterStatus() : base() { }

        private long? _registerStatusID;
        [Field("686B85AE-8A0C-4828-8BFD-7CBDC7DE76B0")]
        public long? RegisterStatusID
        {
            get { CheckGet(); return _registerStatusID; }
            set { CheckSet(); _registerStatusID = value; }
        }

        private long? _registerID;
        [Field("7F37156B-225A-4617-BA5E-181BEA5B9FB5")]
        public long? RegisterID
        {
            get { CheckGet(); return _registerID; }
            set { CheckSet(); _registerID = value; }
        }

        private Register _register = null;
        [Relationship("76014624-0FB9-451D-9CC3-28E804904836")]
        public Register Register
        {
            get { CheckGet(); return _register; }
        }

        private DateTime? _changeTime;
        [Field("9280316E-0795-4374-8AE5-423845602161", DataSize = 7)]
        public DateTime? ChangeTime
        {
            get { CheckGet(); return _changeTime; }
            set { CheckSet(); _changeTime = value; }
        }

        public enum Statuses
        {
            Offline,
            InternalStorageFull,
            Online
        }

        private Statuses _status = Statuses.Offline;
        [Field("A4A73FEB-272E-46BA-8F1D-481622783544")]
        public Statuses Status
        {
            get { CheckGet(); return _status; }
            set { CheckSet(); _status = value; }
        }

        private string _initiator;
        [Field("7F700C9D-9370-48FE-9C4D-39BD9A4787C1", DataSize = 50)]
        public string Initiator
        {
            get { CheckGet(); return _initiator; }
            set { CheckSet(); _initiator = value; }
        }

        protected override bool PostSave(ITransaction transaction)
        {
            if (Status != Statuses.Online)
            {
                Register register = DataObject.GetReadOnlyByPrimaryKey<Register>(RegisterID, transaction, FieldPathUtility.CreateFieldPathsAsList<Register>(r => new List<object>()
                {
                    r.LocationID
                }));

                NotificationEvent.SendSystemNotification<RegisterStatus>(NotificationEvent.NotificationEvents.RegisterOffline,
                    RegisterStatusID.Value,
                    new NotificationEvent.NotificationEntityScope() { LocationID = register?.LocationID },
                    transaction);
            }
            return base.PostSave(transaction);
        }
    }
}
