using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using WebModels.company;
using WebModels.gov;

namespace WebModels.fleet
{
    [Table("9ACE90C2-5203-48ED-808F-238555C12E77")]
    public class Train : DataObject
    {
        protected Train() : base() { }

        private long? _trainID;
        [Field("25B5FFA0-5F20-491B-ADE1-FA445180FD0C")]
        public long? TrainID
        {
            get { CheckGet(); return _trainID; }
            set { CheckSet(); _trainID = value; }
        }

        private long? _trainSymbolID;
        [Field("BD6A260E-193D-456A-BE01-9F9A5B880B41")]
        public long? TrainSymbolID
        {
            get { CheckGet(); return _trainSymbolID; }
            set { CheckSet(); _trainSymbolID = value; }
        }

        private TrainSymbol _trainSymbol = null;
        [Relationship("24522B28-C029-4ED3-A172-24517C73E978")]
        public TrainSymbol TrainSymbol
        {
            get { CheckGet(); return _trainSymbol; }
        }

        private DateTime? _timeOnDuty;
        [Field("997AFB49-F679-4360-B4AE-95C037512661", DataSize = 7)]
        public DateTime? TimeOnDuty
        {
            get { CheckGet(); return _timeOnDuty; }
            set { CheckSet(); _timeOnDuty = value; }
        }

        private DateTime? _timeOffDuty;
        [Field("805A0509-F96C-4686-B348-A00E245A65C1", DataSize = 7)]
        public DateTime? TimeOffDuty
        {
            get { CheckGet(); return _timeOffDuty; }
            set { CheckSet(); _timeOffDuty = value; }
        }

        #region Relationships
        #region fleet
        private List<RailLocation> _railLocations = new List<RailLocation>();
        [RelationshipList("A5DD6D71-8916-4004-BA00-DE511958D2EA", nameof(RailLocation.TrainID))]
        public IReadOnlyCollection<RailLocation> RailLocations
        {
            get { CheckGet(); return _railLocations; }
        }

        private List<RailcarLocationTransaction> _railcarLocationTransactions = new List<RailcarLocationTransaction>();
        [RelationshipList("0D916797-2FD8-4D9F-9973-CA082A99AED6", nameof(RailcarLocationTransaction.TrainIDNew))]
        public IReadOnlyCollection<RailcarLocationTransaction> RailcarLocationTransactions
        {
            get { CheckGet(); return _railcarLocationTransactions; }
        }
        #endregion
        #endregion
    }
}
