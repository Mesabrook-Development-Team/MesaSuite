using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;

namespace WebModels.fleet
{
    [Table("6D34A822-8AEB-403A-BA96-7E73D081106E")]
    public class LiveLoad : DataObject
    {
        protected LiveLoad() : base() { }

        private long? _liveLoadID;
        [Field("B7E2AEDE-6579-42E8-8372-D0B93B41164A")]
        public long? LiveLoadID
        {
            get { CheckGet(); return _liveLoadID; }
            set { CheckSet(); _liveLoadID = value; }
        }

        private long? _trainID;
        [Field("A2114E5F-D018-4C52-B958-0422C37A759C")]
        public long? TrainID
        {
            get { CheckGet(); return _trainID; }
            set { CheckSet(); _trainID = value; }
        }

        private Train _train = null;
        [Relationship("4575C6A6-9580-4DAD-AA66-8011EFF8853F")]
        public Train Train
        {
            get { CheckGet(); return _train; }
        }

        private string _code;
        [Field("B87CA811-3CA5-426E-8BD0-371A5861CDC8", DataSize = 4)]
        public string Code
        {
            get { CheckGet(); return _code; }
            set { CheckSet(); _code = value; }
        }

        #region Relationships
        #region fleet
        private List<LiveLoadSession> _liveLoadSessions = new List<LiveLoadSession>();
        [RelationshipList("D7CD0F01-C09C-4013-9F95-90F36012087C", nameof(LiveLoadSession.LiveLoadID), AutoDeleteReferences = true)]
        public IReadOnlyCollection<LiveLoadSession> LiveLoadSessions
        {
            get { CheckGet(); return _liveLoadSessions; }
        }
        #endregion
        #endregion
    }
}
