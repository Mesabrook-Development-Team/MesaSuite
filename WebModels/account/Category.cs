using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;

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

        private string _name;
        [Field("0DD31BE1-17F4-4803-9C88-60DDEF8B6045", DataSize = 30)]
        public string Name
        {
            get { CheckGet(); return _name; }
            set { CheckSet(); _name = value; }
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
