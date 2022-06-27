using ClussPro.Base.Data;
using ClussPro.Base.Data.Conditions;
using ClussPro.Base.Data.Operand;
using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Validation.Attributes;
using System;
using System.Collections.Generic;
using WebModels.account;
using WebModels.company;
using WebModels.hMailServer.dbo;
using WebModels.invoicing;

namespace WebModels.gov
{
    [Table("D15CC830-79DE-4E62-B94C-C9B0BCDF87E1")]
    public class Government : DataObject
    {
        protected Government() : base() { }

        private long? _governmentID;
        [Field("1D644994-0A53-45E9-B390-4FAE8517F15A")]
        public long? GovernmentID
        {
            get { CheckGet(); return _governmentID; }
            set { CheckSet(); _governmentID = value; }
        }

        private string _name;
        [Field("F36C5AC3-A345-4B0E-808B-B6D205234659", DataSize = 50)]
        [Required]
        public string Name
        {
            get { CheckGet(); return _name; }
            set { CheckSet(); _name = value; }
        }

        private string _emailDomain;
        [Field("917C14A1-301B-44F1-B9FA-535B988F3FB1", DataSize = 80)]
        public string EmailDomain
        {
            get { CheckGet(); return _emailDomain; }
            set { CheckSet(); _emailDomain = value; }
        }

        private bool _canMintCurrency;
        [Field("039FCFE6-8ABB-4ECF-BDDF-7650CB225BCE")]
        public bool CanMintCurrency
        {
            get { CheckGet(); return _canMintCurrency; }
            set { CheckSet(); _canMintCurrency = value; }
        }

        private string _invoiceNumberPrefix;
        [Field("0F5A0F5F-A6D1-46E8-95ED-634E9A6931CE", DataSize = 3)]
        public string InvoiceNumberPrefix
        {
            get { CheckGet(); return _invoiceNumberPrefix; }
            set { CheckSet(); _invoiceNumberPrefix = value; }
        }

        private string _nextInvoiceNumber;
        [Field("32424A24-C76A-4E3C-8050-B1257E1E6045", DataSize = 8)]
        public string NextInvoiceNumber
        {
            get { CheckGet(); return _nextInvoiceNumber; }
            set { CheckSet(); _nextInvoiceNumber = value; }
        }

        private SalesTax _effectiveSalesTax = null;
        [Relationship("A639E317-BBD6-40B2-87B3-F42E2FBB7123", HasForeignKey = false)]
        public SalesTax EffectiveSalesTax
        {
            get { CheckGet(); return _effectiveSalesTax; }
        }

        public override ICondition GetRelationshipCondition(Relationship relationship, string myAlias, string otherAlias)
        {
            if (relationship.RelationshipName == nameof(EffectiveSalesTax))
            {
                return EffectiveSalesTaxRelationship(myAlias, otherAlias);
            }
            return base.GetRelationshipCondition(relationship, myAlias, otherAlias);
        }

        private ICondition EffectiveSalesTaxRelationship(string myAlias, string otherAlias)
        {
            ISelectQuery selectQuery = SQLProviderFactory.GetSelectQuery();
            selectQuery.SelectList = new List<Select>() { new Select() { SelectOperand = (ClussPro.Base.Data.Operand.Field)"effective_sales_tax_subquery.SalesTaxID" } };
            selectQuery.Table = new Table("gov", "SalesTax", "effective_sales_tax_subquery");
            selectQuery.WhereCondition = new ConditionGroup()
            {
                ConditionGroupType = ConditionGroup.ConditionGroupTypes.And,
                Conditions = new List<ICondition>()
                {
                    new Condition()
                    {
                        Left = (ClussPro.Base.Data.Operand.Field)$"effective_sales_tax_subquery.GovernmentID",
                        ConditionType = Condition.ConditionTypes.Equal,
                        Right = (ClussPro.Base.Data.Operand.Field)$"{myAlias}.GovernmentID"
                    },
                    new Condition()
                    {
                        Left = (ClussPro.Base.Data.Operand.Field)$"effective_sales_tax_subquery.EffectiveDate",
                        ConditionType = Condition.ConditionTypes.LessEqual,
                        Right = new Literal(DateTime.Today)
                    }
                }
            };
            selectQuery.OrderByList = new List<Order>()
            {
                new Order()
                {
                    Field = "effective_sales_tax_subquery.EffectiveDate",
                    OrderDirection = Order.OrderDirections.Descending
                }
            };
            selectQuery.PageSize = 1;

            return new Condition()
            {
                Left = (ClussPro.Base.Data.Operand.Field)$"{otherAlias}.SalesTaxID",
                ConditionType = Condition.ConditionTypes.Equal,
                Right = new SubQuery(selectQuery)
            };
        }

        #region Relationships
        #region account
        private List<Account> _accounts = new List<Account>();
        [RelationshipList("133FB533-0F54-452F-A3CF-15A1EBDECF42", "GovernmentID")]
        public IReadOnlyCollection<Account> Accounts
        {
            get { CheckGet(); return _accounts; }
        }
        private List<Category> _categories = new List<Category>();
        [RelationshipList("1C488F28-E5E1-4BC1-B62E-A2C8FE572199", "GovernmentID")]
        public IReadOnlyCollection<Category> Categories
        {
            get { CheckGet(); return _categories; }
        }
        #endregion
        #region company
        private List<LocationGovernment> _locationGovernments = new List<LocationGovernment>();
        [RelationshipList("A49440B9-B080-4AF5-A76E-6E9290F019D3", "GovernmentID")]
        public IReadOnlyCollection<LocationGovernment> LocationGovernments
        {
            get { CheckGet(); return _locationGovernments; }
        }
        #endregion
        #region gov
        private List<Official> _officials = new List<Official>();
        [RelationshipList("5BB7CEE6-A449-4DA2-9C00-C5BD6957E460", "GovernmentID", AutoDeleteReferences = true)]
        public IReadOnlyCollection<Official> Officials
        {
            get { CheckGet(); return _officials; }
        }

        private List<SalesTax> _salesTaxes = new List<SalesTax>();
        [RelationshipList("100D8EB8-BA7C-414A-9B6D-35E501A6D3E9", "GovernmentID", AutoDeleteReferences = true)]
        public IReadOnlyCollection<SalesTax> SalesTaxes
        {
            get { CheckGet(); return _salesTaxes; }
        }
        #endregion
        #region invoicing
        private List<Invoice> _invoicesFrom = new List<Invoice>();
        [RelationshipList("951A3ECC-A13B-4369-A164-B5FA43609BED", "GovernmentIDFrom")]
        public IReadOnlyCollection<Invoice> InvoicesFrom
        {
            get { CheckGet(); return _invoicesFrom;}
        }

        private List<Invoice> _invoicesTo = new List<Invoice>();
        [RelationshipList("26113316-061E-44F7-9021-2B9F1C4B68B4", "GovernmentIDTo")]
        public IReadOnlyCollection<Invoice> InvoicesTo
        {
            get { CheckGet(); return _invoicesTo; }
        }

        private List<WireTransferHistory> _wireTransferHistories = new List<WireTransferHistory>();
        [RelationshipList("79AE85AC-F5CF-4BB4-98AC-72F38EEACD1E", nameof(WireTransferHistory.GovernmentIDFrom))]
        public IReadOnlyCollection<WireTransferHistory> WireTransferHistories
        {
            get { CheckGet(); return _wireTransferHistories; }
        }
        #endregion
        #endregion
    }
}
