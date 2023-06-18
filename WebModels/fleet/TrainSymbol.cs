using System.Collections.Generic;
using ClussPro.Base.Data;
using ClussPro.Base.Data.Conditions;
using ClussPro.Base.Data.Operand;
using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Validation.Attributes;
using WebModels.company;
using WebModels.gov;

namespace WebModels.fleet
{
    [Table("8D14543C-895B-409B-B2EF-9298AF326273")]
    [Unique(new[] { nameof(Name) })]
    public class TrainSymbol : DataObject
    {
        protected TrainSymbol() : base() { }

        private long? _trainSymbolID;
        [Field("8CF91B57-5FDA-43A5-BDD5-04E8F93F0CBA")]
        public long? TrainSymbolID
        {
            get { CheckGet(); return _trainSymbolID; }
            set { CheckSet(); _trainSymbolID = value; }
        }

        private long? _companyIDOperator;
        [Field("C9D296F5-FC5D-4F31-8DFE-170174023AC3")]
        public long? CompanyIDOperator
        {
            get { CheckGet(); return _companyIDOperator; }
            set { CheckSet(); _companyIDOperator = value; }
        }

        private Company _companyOperator = null;
        [Relationship("FAACA34A-7A69-4723-8959-3B125AFAB119", ForeignKeyField = nameof(CompanyIDOperator))]
        public Company CompanyOperator
        {
            get { CheckGet(); return _companyOperator; }
        }

        private long? _governmentIDOperator;
        [Field("D6D6D7E8-E892-4BA6-A4E3-E831C2B70C4B")]
        public long? GovernmentIDOperator
        {
            get { CheckGet(); return _governmentIDOperator; }
            set { CheckSet(); _governmentIDOperator = value; }
        }

        private Government _governmentOperator = null;
        [Relationship("767ED93E-C1D9-4C50-A53A-EC674B85ED20", ForeignKeyField = nameof(GovernmentIDOperator))]
        public Government GovernmentOperator
        {
            get { CheckGet(); return _governmentOperator; }
        }

        private string _name;
        [Field("25AF32D5-5DE1-4E08-87FE-9DB04AB8C1CD", DataSize = 15)]
        [Required]
        public string Name
        {
            get { CheckGet(); return _name; }
            set { CheckSet(); _name = value; }
        }

        private string _description;
        [Field("D82E57A3-88CB-4789-B2E4-24C24D9AFD1C", DataSize = 200)]
        [Required]
        public string Description
        {
            get { CheckGet(); return _description; }
            set { CheckSet(); _description = value; }
        }

        private bool _hasTrainInProgress;
        [Field("5146998D-2EB9-4FA1-9E52-2AF02FD436AF", HasOperation = true)]
        public bool HasTrainInProgress
        {
            get { CheckGet(); return _hasTrainInProgress; }
        }

        public static OperationDelegate HasTrainInProgressOperation
        {
            get => (alias) =>
            {
                ISelectQuery selectQuery = SQLProviderFactory.GetSelectQuery();
                selectQuery.Table = new Table("fleet", "Train", "trainexists");
                selectQuery.SelectList = new List<Select>() { new Select() { SelectOperand = (Field)"trainexists.TrainID" } };
                selectQuery.WhereCondition = new ConditionGroup()
                {
                    ConditionGroupType = ConditionGroup.ConditionGroupTypes.And,
                    Conditions = new List<ICondition>()
                    {
                        new Condition()
                        {
                            Left = (Field)$"{alias}.TrainSymbolID",
                            ConditionType = Condition.ConditionTypes.Equal,
                            Right = (Field)"trainexists.TrainSymbolID"
                        },
                        new Condition()
                        {
                            Left = (Field)"trainexists.Status",
                            ConditionType = Condition.ConditionTypes.List,
                            Right = (CSV<int>)new List<int>() { (int)Train.Statuses.NotStarted, (int)Train.Statuses.EnRoute }
                        }
                    }
                };

                return new Case()
                {
                    Whens = new List<Case.When>()
                    {
                        new Case.When()
                        {
                            Condition = new Exists() { ExistType = Exists.ExistTypes.Exists, SelectQuery = selectQuery },
                            Result = new Literal(true)
                        }
                    },
                    Else = new Literal(false)
                };
            };
        }

        #region Relationships
        #region fleet
        private List<Train> _trains = new List<Train>();
        [RelationshipList("C154F5C3-5080-4B8F-A041-7FCAF4B0838C", nameof(Train.TrainSymbolID))]
        public IReadOnlyCollection<Train> Trains
        {
            get { CheckGet(); return _trains; }
        }
        #endregion
        #endregion
    }
}
