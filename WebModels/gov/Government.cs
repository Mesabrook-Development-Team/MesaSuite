using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Validation.Attributes;
using System.Collections.Generic;
using WebModels.account;
using WebModels.hMailServer.dbo;

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
        #region gov
        private List<Official> _officials = new List<Official>();
        [RelationshipList("5BB7CEE6-A449-4DA2-9C00-C5BD6957E460", "GovernmentID", AutoDeleteReferences = true)]
        public IReadOnlyCollection<Official> Officials
        {
            get { CheckGet(); return _officials; }
        }
        #endregion
        #endregion
    }
}
