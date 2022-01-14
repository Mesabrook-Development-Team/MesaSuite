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
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using WebModels.company;
using WebModels.gov;

namespace WebModels.account
{
    [Table("EE5E32F6-4AA0-4A9E-BD0E-FFBD646A13D1")]
    public class Category : DataObject
    {
        protected Category() : base() { }

        private long? _categoryID;
        [Field("C23D6935-9A30-4664-9B2E-2C7E54ECCD7B")]
        public long? CategoryID
        {
            get { CheckGet(); return _categoryID; }
            set { CheckSet(); _categoryID = value; }
        }

        private long? _companyID;
        [Field("F2C39BA9-F58D-470A-8D5F-462C15173100")]
        public long? CompanyID
        {
            get { CheckGet(); return _companyID; }
            set { CheckSet(); _companyID = value; }
        }

        private Company _company = null;
        [Relationship("14683DA6-1C54-4886-9042-49D25FE0EC2A")]
        public Company Company
        {
            get { CheckGet(); return _company; }
        }

        private long? _governmentID;
        [Field("6A88E419-42F8-4219-9BD5-F26079005D1D")]
        public long? GovernmentID
        {
            get { CheckGet(); return _governmentID; }
            set { CheckSet(); _governmentID = value; }
        }

        private Government _government;
        [Relationship("6992270A-D896-455B-8EB5-797623973F0B")]
        public Government Government
        {
            get { CheckGet(); return _government; }
        }

        private string _name;
        [Field("0DD31BE1-17F4-4803-9C88-60DDEF8B6045", DataSize = 30)]
        public string Name
        {
            get { CheckGet(); return _name; }
            set { CheckSet(); _name = value; }
        }

        private int _accountCount = 0;
        [Field("A9D435F2-D7CA-4192-93C9-0D7CD154E22C", HasOperation = true)]
        public int AccountCount
        {
            get { CheckGet(); return _accountCount; }
        }

        public static OperationDelegate AccountCountOperation
        {
            get
            {
                return (alias) =>
                {
                    ISelectQuery query = SQLProviderFactory.GetSelectQuery();
                    query.SelectList = new List<Select>() { new Select() { SelectOperand = new Count((Field)"A.AccountID") } };
                    query.Table = new Table("account", "Account", "A");
                    query.WhereCondition = new Condition()
                    {
                        Left = (Field)"A.CategoryID",
                        ConditionType = Condition.ConditionTypes.Equal,
                        Right = (Field)$"{alias}.CategoryID"
                    };
                    return new SubQuery(query);
                };
            }
        }

        #region Relationships
        #region account
        private List<Account> _accounts = new List<Account>();
        [RelationshipList("7F23DDE0-B112-42BB-B1A6-4F0F04C078AC", "CategoryID")]
        public IReadOnlyCollection<Account> Accounts
        {
            get { CheckGet(); return _accounts; }
        }
        #endregion
        #endregion
    }
}
