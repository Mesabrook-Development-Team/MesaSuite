using System.Collections.Generic;
using System.Linq;
using ClussPro.Base.Data;
using ClussPro.Base.Data.Conditions;
using ClussPro.Base.Data.Operand;
using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Schema;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using WebModels.company;
using WebModels.gov;

namespace WebModels.fleet
{
    [Table("9882F85A-BF24-4DA9-96A3-4DE7028ED44A")]
    public class Railcar : DataObject
    {
        protected Railcar() : base() { }

        private long? _railcarID;
        [Field("BC542631-BBAD-4577-9E3C-0AFD0E4A2864")]
        public long? RailcarID
        {
            get { CheckGet(); return _railcarID; }
            set { CheckSet(); _railcarID = value; }
        }

        private long? _railcarModelID;
        [Field("3D8E9CAC-11E8-4275-8927-AEC060C46EF8")]
        public long? RailcarModelID
        {
            get { CheckGet(); return _railcarModelID; }
            set { CheckSet(); _railcarModelID = value; }
        }

        private RailcarModel _railcarModel = null;
        [Relationship("7B567E44-8C75-479A-B9A9-ADAE6BB5A55C")]
        public RailcarModel RailcarModel
        {
            get { CheckGet(); return _railcarModel; }
        }

        private long? _governmentIDOwner;
        [Field("4BB5C98B-5F6E-4536-B5C8-39AD581379C9")]
        public long? GovernmentIDOwner
        {
            get { CheckGet(); return _governmentIDOwner; }
            set { CheckSet(); _governmentIDOwner = value; }
        }

        private Government _governmentOwner = null;
        [Relationship("D5ACE143-9B86-4044-84E4-E02D486FA9A0", ForeignKeyField = nameof(GovernmentIDOwner))]
        public Government GovernmentOwner
        {
            get { CheckGet(); return _governmentOwner; }
        }

        private long? _companyIDOwner;
        [Field("0C1ACEB6-F0CF-4B2D-BBB3-71A9A6A26CEA")]
        public long? CompanyIDOwner
        {
            get { CheckGet(); return _companyIDOwner; }
            set { CheckSet(); _companyIDOwner = value; }
        }

        private Company _companyOwner = null;
        [Relationship("A04C27FD-5DC3-4F94-A337-B6A71BC0AE1A", ForeignKeyField = nameof(CompanyIDOwner))]
        public Company CompanyOwner
        {
            get { CheckGet(); return _companyOwner; }
        }

        private long? _governmentIDPossessor;
        [Field("810AB8B1-BA64-4784-9C47-5D58156AB5D8")]
        public long? GovernmentIDPossessor
        {
            get { CheckGet(); return _governmentIDPossessor; }
            set { CheckSet(); _governmentIDPossessor = value; }
        }

        private Government _governmentPossessor;
        [Relationship("EA834C1C-DF05-45CB-A533-EDA8BE11AD5B", ForeignKeyField = nameof(GovernmentIDPossessor))]
        public Government GovernmentPossessor
        {
            get { CheckGet(); return _governmentPossessor; }
        }

        private long? _companyIDPossessor;
        [Field("2D08D958-14CD-465E-9DA4-ED4279972481")]
        public long? CompanyIDPossessor
        {
            get { CheckGet(); return _companyIDPossessor; }
            set { CheckSet(); _companyIDPossessor = value; }
        }

        private Company _companyPossessor;
        [Relationship("2D102BF4-4C55-432A-B634-F9632612A2BE", ForeignKeyField = nameof(CompanyIDPossessor))]
        public Company CompanyPossessor
        {
            get { CheckGet(); return _companyPossessor; }
        }

        private RailLocation _railLocation;
        [Relationship("527AEB8C-896E-4D8A-B8E2-95729BA611C4", OneToOneByForeignKey = true)]
        public RailLocation RailLocation
        {
            get { CheckGet(); return _railLocation; }
        }

        private string _reportingMark;
        [Field("DF38F559-C558-476E-B3D0-15828D80DAB0")]
        public string ReportingMark
        {
            get { CheckGet(); return _reportingMark; }
            set { CheckSet(); _reportingMark = value; }
        }

        private int? _reportingNumber;
        [Field("0EBE9191-DCA9-49A4-BE99-C0FEC9E27CAA")]
        public int? ReportingNumber
        {
            get { CheckGet(); return _reportingNumber; }
            set { CheckSet(); _reportingNumber = value; }
        }

        private byte[] _imageOverride;
        [Field("E3AC3FC5-C625-4BD2-9DB8-1E2AFDA60CCB")]
        public byte[] ImageOverride
        {
            get { CheckGet(); return _imageOverride; }
            set { CheckSet(); _imageOverride = value; }
        }

        private bool _hasOpenBid;
        [Field("E1ACECA1-C305-4AAF-A4AE-DEBEE8DCEDCD", HasOperation = true)]
        public bool HasOpenBid
        {
            get { CheckGet(); return _hasOpenBid; }
        }

        public static OperationDelegate HasOpenBidOperation
        {
            get => (alias) =>
            {
                ISelectQuery selectQuery = SQLProviderFactory.GetSelectQuery();
                selectQuery.SelectList = new List<Select>()
                {
                    new Select()
                    {
                        SelectOperand = new Case()
                        {
                            Whens = new List<Case.When>()
                            {
                                new Case.When()
                                {
                                    Condition = new Condition()
                                    {
                                        Left = new Count((ClussPro.Base.Data.Operand.Field)$"RailcarID"),
                                        ConditionType = Condition.ConditionTypes.Greater,
                                        Right = new Literal(0)
                                    },
                                    Result = new Literal(true)
                                }
                            },
                            Else = new Literal(false)
                        }
                    }
                };
                selectQuery.Table = new Table("fleet", "LeaseBid");
                selectQuery.WhereCondition = new Condition()
                {
                    Left = (ClussPro.Base.Data.Operand.Field)"RailcarID",
                    ConditionType = Condition.ConditionTypes.Equal,
                    Right = (ClussPro.Base.Data.Operand.Field)$"{alias}.RailcarID"
                };

                return new SubQuery(selectQuery);
            };
        }

        protected override bool PostSave(ITransaction transaction)
        {
            if (IsInsert)
            {
                RailLocation newRailLocation = DataObjectFactory.Create<RailLocation>();
                newRailLocation.RailcarID = RailcarID;
                if (!newRailLocation.Save(transaction))
                {
                    Errors.AddRange(newRailLocation.Errors.ToArray());
                    return false;
                }
            }
            return base.PostSave(transaction);
        }

        protected override bool PreDelete(ITransaction transaction)
        {
            RailLocation railLocation = new Search<RailLocation>(new LongSearchCondition<RailLocation>()
            {
                Field = "RailcarID",
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = RailcarID
            }).GetEditable(transaction, null);

            if (railLocation != null)
            {
                if (!railLocation.Delete(transaction))
                {
                    Errors.AddRange(railLocation.Errors.ToArray());
                    return false;
                }
            }
            return base.PreDelete(transaction);
        }

        #region Custom Relationships
        public override ICondition GetRelationshipCondition(Relationship relationship, string myAlias, string otherAlias)
        {
            switch (relationship.RelationshipName)
            {
                case nameof(CompanyLeasedTo):
                    return CompanyLeasedToCondition(myAlias, otherAlias);
                case nameof(GovernmentLeasedTo):
                    return GovernmentLeasedToCondition(myAlias, otherAlias);
            }

            return base.GetRelationshipCondition(relationship, myAlias, otherAlias);
        }

        private Company _companyLeasedTo;
        [Relationship("46ECFAC8-D234-4A5A-84DD-4B491D23FF7C", HasForeignKey = false)]
        public Company CompanyLeasedTo
        {
            get { CheckGet(); return _companyLeasedTo; }
        }

        private ICondition CompanyLeasedToCondition(string myAlias, string otherAlias)
        {
            ISelectQuery select = SQLProviderFactory.GetSelectQuery();
            select.SelectList = new List<Select>()
            {
                new Select() { SelectOperand = (ClussPro.Base.Data.Operand.Field)"LC.CompanyIDLessee" }
            };
            select.Table = new Table("fleet", "LeaseContract", "LC");
            select.PageSize = 1;
            select.WhereCondition = new ConditionGroup()
            {
                ConditionGroupType = ConditionGroup.ConditionGroupTypes.And,
                Conditions = new List<ICondition>()
                {
                    new Condition()
                    {
                        Left = (ClussPro.Base.Data.Operand.Field)"LC.RailcarID",
                        ConditionType = Condition.ConditionTypes.Equal,
                        Right = (ClussPro.Base.Data.Operand.Field)$"{myAlias}.RailcarID"
                    },
                    new Condition()
                    {
                        Left = (ClussPro.Base.Data.Operand.Field)"LC.LeaseTimeEnd",
                        ConditionType = Condition.ConditionTypes.Null
                    }
                }
            };

            return new Condition()
            {
                Left = new SubQuery(select),
                ConditionType = Condition.ConditionTypes.Equal,
                Right = (ClussPro.Base.Data.Operand.Field)$"{otherAlias}.CompanyID"
            };
        }

        private Government _governmentLeasedTo;
        [Relationship("32BFE4A3-8E92-4CE7-9A7C-028EAB85E2DE", HasForeignKey = false)]
        public Government GovernmentLeasedTo
        {
            get { CheckGet(); return _governmentLeasedTo; }
        }

        private ICondition GovernmentLeasedToCondition(string myAlias, string otherAlias)
        {
            ISelectQuery select = SQLProviderFactory.GetSelectQuery();
            select.SelectList = new List<Select>()
            {
                new Select() { SelectOperand = (ClussPro.Base.Data.Operand.Field)"LC.GovernmentIDLessee" }
            };
            select.Table = new Table("fleet", "LeaseContract", "LC");
            select.PageSize = 1;
            select.WhereCondition = new ConditionGroup()
            {
                ConditionGroupType = ConditionGroup.ConditionGroupTypes.And,
                Conditions = new List<ICondition>()
                {
                    new Condition()
                    {
                        Left = (ClussPro.Base.Data.Operand.Field)"LC.RailcarID",
                        ConditionType = Condition.ConditionTypes.Equal,
                        Right = (ClussPro.Base.Data.Operand.Field)$"{myAlias}.RailcarID"
                    },
                    new Condition()
                    {
                        Left = (ClussPro.Base.Data.Operand.Field)"LC.LeaseTimeEnd",
                        ConditionType = Condition.ConditionTypes.Null
                    }
                }
            };

            return new Condition()
            {
                Left = new SubQuery(select),
                ConditionType = Condition.ConditionTypes.Equal,
                Right = (ClussPro.Base.Data.Operand.Field)$"{otherAlias}.GovernmentID"
            };
        }
        #endregion

        #region Relationships
        #region fleet
        private List<LeaseBid> _leaseBids = new List<LeaseBid>();
        [RelationshipList("0F70EFD5-AF06-4301-A5AD-48B7F7282AB0", nameof(LeaseBid.RailcarID))]
        public IReadOnlyCollection<LeaseBid> LeaseBids
        {
            get { CheckGet(); return _leaseBids; }
        }

        private List<LeaseContract> _leaseContracts = new List<LeaseContract>();
        [RelationshipList("DAF79BB5-BDD8-473B-B1E9-2DCEA47946D0", nameof(LeaseContract.RailcarID))]
        public IReadOnlyCollection<LeaseContract> LeaseContracts
        {
            get { CheckGet(); return _leaseContracts; }
        }

        private List<RailcarLocationTransaction> _railcarLocationTransactions = new List<RailcarLocationTransaction>();
        [RelationshipList("FCF6E1FE-F852-4D1D-B6C9-1816E07CD304", nameof(RailcarLocationTransaction.RailcarID))]
        public IReadOnlyCollection<RailcarLocationTransaction> RailcarLocationTransactions
        {
            get { CheckGet(); return _railcarLocationTransactions; }
        }
        #endregion
        #endregion
    }
}
