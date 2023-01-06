using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClussPro.Base.Data;
using ClussPro.Base.Data.Conditions;
using ClussPro.Base.Data.Operand;
using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Validation;
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

        private LiveLoad _liveLoad = null;
        [Relationship("833E1C4D-F43F-4231-8B10-5E94F65A9458", OneToOneByForeignKey = true)]
        public LiveLoad LiveLoad
        {
            get { CheckGet(); return _liveLoad; }
        }

        private DateTime? _timeOnDuty = null;
        [Field("8A47991B-D1FE-4FB6-A143-722DC4626D3A", HasOperation = true)]
        public DateTime? TimeOnDuty
        {
            get { CheckGet(); return _timeOnDuty; }
        }

        public static OperationDelegate TimeOnDutyOperation => (alias) =>
        {
            ISelectQuery select = SQLProviderFactory.GetSelectQuery();
            select.SelectList = new List<Select>()
            {
                new Select() { SelectOperand = (Field)"TimeOnDuty"}
            };
            select.Table = new Table("fleet", "TrainDutyTransaction", "tdt");
            select.WhereCondition = new ConditionGroup()
            {
                ConditionGroupType = ConditionGroup.ConditionGroupTypes.And,
                Conditions = new List<ICondition>()
                {
                    new Condition()
                    {
                        Left = (Field)"tdt.TrainID",
                        ConditionType = Condition.ConditionTypes.Equal,
                        Right = (Field)$"{alias}.TrainID"
                    },
                    new Condition()
                    {
                        Left = (Field)"tdt.TimeOffDuty",
                        ConditionType = Condition.ConditionTypes.Null
                    }
                }
            };

            return new SubQuery(select);
        };

        public static Errors Reorder(long? trainID, ITransaction transaction = null)
        {
            Errors errors = new Errors();
            ITransaction localTransaction = transaction;
            try
            {
                if (localTransaction == null)
                {
                    localTransaction = SQLProviderFactory.GenerateTransaction();
                }

                Search<RailLocation> railLocationsForTrain = new Search<RailLocation>(new LongSearchCondition<RailLocation>()
                {
                    Field = nameof(RailLocation.TrainID),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = trainID
                });
                railLocationsForTrain.SearchOrders.Add(new SearchOrder()
                {
                    OrderField = nameof(RailLocation.Position)
                });

                int position = 1;
                foreach (RailLocation railLocation in railLocationsForTrain.GetEditableReader(localTransaction))
                {
                    if (railLocation.Position != position)
                    {
                        railLocation.Position = position;
                        if (!railLocation.Save(localTransaction))
                        {
                            errors.AddRange(railLocation.Errors.ToArray());
                        }
                    }

                    position++;
                }

                if (transaction == null)
                {
                    if (errors.Any())
                    {
                        localTransaction.Rollback();
                    }
                    else
                    {
                        localTransaction.Commit();
                    }
                }
            }
            finally
            {
                if (transaction == null && localTransaction != null && localTransaction.IsActive)
                {
                    localTransaction.Rollback();
                }
            }

            return errors;
        }

        protected override bool PostSave(ITransaction transaction)
        {
            if (IsFieldDirty(nameof(Status)) && Status == Statuses.Complete)
            {
                Search<TrainDutyTransaction> trainDutyTransaction = new Search<TrainDutyTransaction>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                    new LongSearchCondition<TrainDutyTransaction>()
                    {
                        Field = nameof(TrainDutyTransaction.TrainID),
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = TrainID
                    },
                    new DateTimeSearchCondition<TrainDutyTransaction>()
                    {
                        Field = nameof(TrainDutyTransaction.TimeOffDuty),
                        SearchConditionType = SearchCondition.SearchConditionTypes.Null
                    }));

                foreach(TrainDutyTransaction trainTransaction in trainDutyTransaction.GetEditableReader(transaction))
                {
                    trainTransaction.TimeOffDuty = DateTime.Now;
                    if (!trainTransaction.Save(transaction))
                    {
                        Errors.AddRange(trainTransaction.Errors.ToArray());
                    }
                }
            }

            return Errors.Count() == 0 && base.PostSave(transaction);
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
