using System.Collections.Generic;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Validation.Attributes;
using WebModels.company;

namespace WebModels.account
{
    [Table("2B91C03F-672C-47C0-AE17-4657967EB54B")]
    public class Account : DataObject
    {
        protected Account() : base() { }

        private long? _accountID;
        [Field("D91F3C4F-5455-432E-9A49-6BC69074EF6A")]
        public long? AccountID
        {
            get { CheckGet(); return _accountID; }
            set { CheckSet(); _accountID = value; }
        }

        private long? _companyID;
        [Field("C8B684BE-CBB0-4013-8DA7-C4CA9CE14CFD")]
        public long? CompanyID
        {
            get { CheckGet(); return _companyID; }
            set { CheckSet(); _companyID = value; }
        }

        private Company _company = null;
        [Relationship("5E8D35E2-A896-4C7B-BFC6-3F5CFF63C1DA")]
        public Company Company
        {
            get { CheckGet(); return _company; }
        }

        private string _accountNumber;
        [Field("B27938A6-FC2B-4701-A3AA-3B098F465634", DataSize = 16)]
        [Required]
        public string AccountNumber
        {
            get { CheckGet(); return _accountNumber; }
            set { CheckSet(); _accountNumber = value; }
        }

        private decimal? _balance;
        [Field("56F17B40-38E6-4246-9AA9-48C6D1A31FD9", DataSize = 11, DataScale = 2)]
        [Required]
        public decimal? Balance
        {
            get { CheckGet(); return _balance; }
            set { CheckSet(); _balance = value; }
        }

        #region Relationships
        #region account
        private List<AccountClearance> _accountClearances = new List<AccountClearance>();
        [RelationshipList("6733E4CD-1C88-42A0-A7DF-CAD5299C19D2", "AccountID")]
        public IReadOnlyCollection<AccountClearance> AccountClearances
        {
            get { CheckGet(); return _accountClearances; }
        }
        #endregion
        #endregion
    }
}
