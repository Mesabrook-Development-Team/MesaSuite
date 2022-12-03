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

        private string _trainInstructions;
        [Field("B84D274C-ED8C-4F7D-8533-319A52FEC005", DataSize = 300)]
        public string TrainInstructions
        {
            get { CheckGet(); return _trainInstructions; }
            set { CheckSet(); _trainInstructions = value; }
        }

        public enum Statuses
        {
            NotStarted,
            EnRoute,
            Complete
        }

        private Statuses _status;
        [Field("3B35E70A-EB20-4C53-B597-3755341D63AD")]
        public Statuses Status
        {
            get { CheckGet(); return _status; }
            set { CheckSet(); _status = value; }
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

        private List<TrainDutyTransaction> _trainDutyTransactions = new List<TrainDutyTransaction>();
        [RelationshipList("F9EEFB24-0788-4FEC-A9E8-8512C2D8180B", nameof(TrainDutyTransaction.TrainID))]
        public IReadOnlyCollection<TrainDutyTransaction> TrainDutyTransactions
        {
            get { CheckGet(); return _trainDutyTransactions; }
        }

        private List<TrainFuelRecord> _trainFuelRecords = new List<TrainFuelRecord>();
        [RelationshipList("A6ADE06B-BA77-4E30-85DE-3B074CC52E89", nameof(TrainFuelRecord.TrainID))]
        public IReadOnlyCollection<TrainFuelRecord> TrainFuelRecords
        {
            get { CheckGet(); return _trainFuelRecords; }
        }
        #endregion
        #endregion
    }
}
