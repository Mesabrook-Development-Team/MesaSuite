using System.Collections.Generic;
using ClussPro.Base.Data;
using ClussPro.Base.Data.Conditions;
using ClussPro.Base.Data.Operand;
using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using WebModels.company;
using WebModels.gov;

namespace WebModels.fleet
{
    [Table("26F0E07C-E054-49E2-92DB-E535B77D2D66")]
    public class Locomotive : DataObject
    {
        protected Locomotive() : base() { }

        private long? _locomotiveID;
        [Field("D384203E-3299-4C49-8665-1D0E6DACA869")]
        public long? LocomotiveID
        {
            get { CheckGet(); return _locomotiveID; }
            set { CheckSet(); _locomotiveID = value; }
        }

        private long? _locomotiveModelID;
        [Field("8022037A-D18B-4079-91B7-1548ECF7DB57")]
        public long? LocomotiveModelID
        {
            get { CheckGet(); return _locomotiveModelID; }
            set { CheckSet(); _locomotiveModelID = value; }
        }

        private LocomotiveModel _locomotiveModel;
        [Relationship("7EB177E3-4349-4911-A33A-383021795AFC")]
        public LocomotiveModel LocomotiveModel
        {
            get { CheckGet(); return _locomotiveModel; }
        }

        private long? _governmentIDOwner;
        [Field("4D5DAEC4-CC37-4A13-9ED7-2F3424BA857C")]
        public long? GovernmentIDOwner
        {
            get { CheckGet(); return _governmentIDOwner; }
            set { CheckSet(); _governmentIDOwner = value; }
        }

        private Government _governmentOwner;
        [Relationship("81492311-52BE-4428-9AC4-D22A3683035D", ForeignKeyField = nameof(GovernmentIDOwner))]
        public Government GovernmentOwner
        {
            get { CheckGet(); return _governmentOwner; }
        }

        private long? _companyIDOwner;
        [Field("50320BAA-1C2D-4E1A-B866-8EF94895A068")]
        public long? CompanyIDOwner
        {
            get { CheckGet(); return _companyIDOwner; }
            set { CheckSet(); _companyIDOwner = value; }
        }

        private Company _companyOwner;
        [Relationship("5B907DAA-5DF5-4850-97AF-4C67124312BC", ForeignKeyField = nameof(CompanyIDOwner))]
        public Company CompanyOwner
        {
            get { CheckGet(); return _companyOwner; }
        }

        private long? _governmentIDPossessor;
        [Field("A12D2731-0611-4B02-AE43-9390FCAA62C1")]
        public long? GovernmentIDPossessor
        {
            get { CheckGet(); return _governmentIDPossessor; }
            set { CheckSet(); _governmentIDPossessor = value; }
        }

        private Government _governmentPossessor;
        [Relationship("055ABC1D-5D08-4F54-A641-FDFCCF89289A", ForeignKeyField = nameof(GovernmentIDPossessor))]
        public Government GovernmentPossessor
        {
            get { CheckGet(); return _governmentPossessor; }
        }

        private long? _companyIDPossessor;
        [Field("90C3B7B8-ED84-43A2-B6AD-C26627593724")]
        public long? CompanyIDPossessor
        {
            get { CheckGet(); return _companyIDPossessor; }
            set { CheckSet(); _companyIDPossessor = value; }
        }

        private Company _companyPossessor;
        [Relationship("B5040FBA-048E-4755-8DC0-B3EC5F8FB2A5", ForeignKeyField = nameof(CompanyIDPossessor))]
        public Company CompanyPossessor
        {
            get { CheckGet(); return _companyPossessor; }
        }

        private string _reportingMark;
        [Field("5F2C40A0-5BB6-4B9A-BF69-C70F207653BF", DataSize = 4)]
        public string ReportingMark
        {
            get { CheckGet(); return _reportingMark; }
            set { CheckSet(); _reportingMark = value; }
        }

        private int? _reportingNumber;
        [Field("562D76BB-B754-4DCA-9D1F-AAE91058E69C")]
        public int? ReportingNumber
        {
            get { CheckGet(); return _reportingNumber; }
            set { CheckSet(); _reportingNumber = value; }
        }

        private byte[] _imageOverride;
        [Field("AB6F6E20-63FC-4E70-BA04-7D55A146A622")]
        public byte[] ImageOverride
        {
            get { CheckGet(); return _imageOverride; }
            set { CheckSet(); _imageOverride = value; }
        }

        private bool _hasOpenBid;
        [Field("D83BAE12-2E19-4A57-A652-D123A3AC5183", HasOperation = true)]
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
                                        Left = new Count((ClussPro.Base.Data.Operand.Field)$"LocomotiveID"),
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
                    Left = (ClussPro.Base.Data.Operand.Field)"LocomotiveID",
                    ConditionType = Condition.ConditionTypes.Equal,
                    Right = (ClussPro.Base.Data.Operand.Field)$"{alias}.LocomotiveID"
                };

                return new SubQuery(selectQuery);
            };
        }

        #region Custom Relationships
        public override ICondition GetRelationshipCondition(Relationship relationship, string myAlias, string otherAlias)
        {
            switch(relationship.RelationshipName)
            {
                case nameof(CompanyLeasedTo):
                    return CompanyLeasedToCondition(myAlias, otherAlias);
                case nameof(GovernmentLeasedTo):
                    return GovernmentLeasedToCondition(myAlias, otherAlias);
            }

            return base.GetRelationshipCondition(relationship, myAlias, otherAlias);
        }

        private Company _companyLeasedTo;
        [Relationship("97687814-179D-4F91-8A6E-274961AC81D1", HasForeignKey = false)]
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
                        Left = (ClussPro.Base.Data.Operand.Field)"LC.LocomotiveID",
                        ConditionType = Condition.ConditionTypes.Equal,
                        Right = (ClussPro.Base.Data.Operand.Field)$"{myAlias}.LocomotiveID"
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
        [Relationship("197ADDC3-A1DA-4369-BB9C-05B312F9765C", HasForeignKey = false)]
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
                        Left = (ClussPro.Base.Data.Operand.Field)"LC.LocomotiveID",
                        ConditionType = Condition.ConditionTypes.Equal,
                        Right = (ClussPro.Base.Data.Operand.Field)$"{myAlias}.LocomotiveID"
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
        [RelationshipList("A6D33502-F8EC-4C06-B2DD-B0E8700AE2A5", nameof(LeaseBid.LocomotiveID))]
        public IReadOnlyCollection<LeaseBid> LeaseBids
        {
            get { CheckGet(); return _leaseBids; }
        }

        private List<LeaseContract> _leaseContracts = new List<LeaseContract>();
        [RelationshipList("979F5983-3692-44F5-B4B3-F643E972A945", nameof(LeaseContract.LocomotiveID))]
        public IReadOnlyCollection<LeaseContract> LeaseContracts
        {
            get { CheckGet(); return _leaseContracts; }
        }
        #endregion
        #endregion
    }
}
