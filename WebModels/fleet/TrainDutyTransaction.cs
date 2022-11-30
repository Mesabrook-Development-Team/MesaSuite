using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using System;

namespace WebModels.fleet
{
    [Table("A96D5E60-3AA9-473E-B938-5002923219D0")]
    public class TrainDutyTransaction : DataObject
    {
        protected TrainDutyTransaction() : base() { }

        private long? _trainDutyTransactionID;
        [Field("B87BAA6A-CC03-4585-A3FE-F8F5F5FAF7F0")]
        public long? TrainDutyTransactionID
        {
            get { CheckGet(); return _trainDutyTransactionID; }
            set { CheckSet(); _trainDutyTransactionID = value; }
        }

        private long? _trainID;
        [Field("0ABF9C96-AC4D-4040-9873-04189EBD23A6")]
        public long? TrainID
        {
            get { CheckGet(); return _trainID; }
            set { CheckSet(); _trainID = value; }
        }

        private Train _train = null;
        [Relationship("96208FCC-A042-4F20-ABE1-6E455B332646")]
        public Train Train
        {
            get { CheckGet(); return _train; }
        }

        private DateTime? _timeOnDuty;
        [Field("B00C3629-DACE-484B-864D-861754905501", DataSize = 7)]
        public DateTime? TimeOnDuty
        {
            get { CheckGet(); return _timeOnDuty; }
            set { CheckSet(); _timeOnDuty = value; }
        }

        private DateTime? _timeOffDuty;
        [Field("473C213B-B9A6-451C-84A2-748C78C4239B", DataSize = 7)]
        public DateTime? TimeOffDuty
        {
            get { CheckGet(); return _timeOffDuty; }
            set { CheckSet(); _timeOffDuty = value; }
        }
    }
}
