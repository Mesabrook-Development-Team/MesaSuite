using ClussPro.Base.Data;
using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Validation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using WebModels.account;
using WebModels.hMailServer.dbo;
using WebModels.mesasys;

namespace WebModels.company
{
    [Table("A093C2E1-2DF9-4BF2-A56C-2C3B99073792")]
    public class Company : DataObject
    {
        protected Company() : base() { }

        private long? _companyID;
        [Field("4C5C6ED3-055B-405C-B888-4B40A799FAC0")]
        public long? CompanyID
        {
            get { CheckGet(); return _companyID; }
            set { CheckSet(); _companyID = value; }
        }

        private string _name;
        [Field("BBEE1AE6-34F3-4BCB-90AA-A137CE7EA655", DataSize = 50)]
        [Required]
        public string Name
        {
            get { CheckGet(); return _name; }
            set { CheckSet(); _name = value; }
        }

        private string _emailDomain;
        [Field("B28C2CCC-5BE7-4667-AB66-96A11067055B", DataSize = 80)]
        public string EmailDomain
        {
            get { CheckGet(); return _emailDomain; }
            set { CheckSet(); _emailDomain = value; }
        }

        private long? _emailImplementationIDWireTransferHistory;
        [Field("ADCD5F15-B180-4BEC-9CFD-E8FDB72BC51B")]
        public long? EmailImplementationIDWireTransferHistory
        {
            get { CheckGet(); return _emailImplementationIDWireTransferHistory; }
            set { CheckSet();_emailImplementationIDWireTransferHistory = value; }
        }

        private EmailImplementation _emailImplementationWireTransferHistory = null;
        [Relationship("E57BB310-8467-4963-AE74-0D7CDFD76E07", ForeignKeyField = nameof(EmailImplementationIDWireTransferHistory))]
        public EmailImplementation EmailImplementationWireTransferHistory
        {
            get { CheckGet(); return _emailImplementationWireTransferHistory; }
        }

        protected override bool PostSave(ITransaction transaction)
        {
            if (!IsInsert)
            {
                bool savesSuccessful = true;
                if (IsFieldDirty("EmailDomain") && !string.IsNullOrEmpty(EmailDomain))
                {
                    savesSuccessful &= UpdateEmailInfo();
                }

                if (IsFieldDirty(nameof(EmailImplementationIDWireTransferHistory)))
                {
                    long? previousEmailImpID = GetDirtyValue(nameof(EmailImplementationIDWireTransferHistory)) as long?;
                    if (previousEmailImpID != null)
                    {
                        EmailImplementation oldImplementation = DataObject.GetEditableByPrimaryKey<EmailImplementation>(previousEmailImpID, transaction, null);
                        if (!oldImplementation.Delete(transaction))
                        {
                            Errors.AddRange(oldImplementation.Errors.ToArray());
                            savesSuccessful = false;
                        }
                    }
                }

                return savesSuccessful;
            }

            return base.PostSave(transaction);
        }

        private bool UpdateEmailInfo()
        {
            string oldEmailInfo = (string)GetDirtyValue("EmailDomain");
            using (ITransaction transaction = SQLProviderFactory.GenerateTransaction("hmailserver"))
            {
                Search<Alias> aliasSearch = new Search<Alias>(new StringSearchCondition<Alias>()
                {
                    Field = "AliasName",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Like,
                    Value = $"%@{oldEmailInfo}"
                });

                foreach(Alias alias in aliasSearch.GetEditableReader())
                {
                    alias.AliasName = alias.AliasName.Replace($"@{oldEmailInfo}", $"@{EmailDomain}");

                    if (!alias.Save(transaction, new List<Guid>() { Alias.ValidationFlags.V_AddressEndsWithCompanyAddress }))
                    {
                        Errors.AddBaseMessage($"Could not update Alias with ID {alias.AliasID}:\r\n{alias.Errors.ToString()}");
                        return false;
                    }
                }

                Search<DistributionList> distListSearch = new Search<DistributionList>(new StringSearchCondition<DistributionList>()
                {
                    Field = "DistributionListAddress",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Like,
                    Value = $"%@{oldEmailInfo}"
                });

                foreach(DistributionList distList in distListSearch.GetEditableReader())
                {
                    distList.DistributionListAddress = distList.DistributionListAddress.Replace($"@{oldEmailInfo}", $"@{EmailDomain}");

                    if (!distList.Save(transaction, new List<Guid>() { DistributionList.ValidationFlags.V_AddressEndsWithCompanyAddress }))
                    {
                        Errors.AddBaseMessage($"Could not update Distribution List with ID {distList.DistributionListID}:\r\n{distList.Errors.ToString()}");
                        return false;
                    }
                }

                transaction.Commit();
            }

            return true;
        }

        #region Relationships
        #region account
        private List<Account> _accounts = new List<Account>();
        [RelationshipList("010B01A9-4656-4327-9B89-5B234EA7DF7D", "CompanyID")]
        public IReadOnlyCollection<Account> Accounts
        {
            get { CheckGet(); return _accounts; }
        }

        private List<Category> _categories = new List<Category>();
        [RelationshipList("83489E3E-4CE9-4D03-AB42-E08D738E74BD", "CompanyID")]
        public IReadOnlyCollection<Category> Categories
        {
            get { CheckGet(); return _categories; }
        }

        private List<account.WireTransferHistory> _wireTransferHistoryFroms = new List<WireTransferHistory>();
        [RelationshipList("1C4ADE88-1C88-49F2-BA2B-4233B163F010", nameof(account.WireTransferHistory.CompanyIDTo))]
        public IReadOnlyCollection<account.WireTransferHistory> WireTransferHistoryFroms
        {
            get { CheckGet(); return _wireTransferHistoryFroms; }
        }

        private List<account.WireTransferHistory> _wireTransferHistoryTos = new List<account.WireTransferHistory>();
        [RelationshipList("72AF3D64-C652-48AE-B43C-369ABDB83F2B", nameof(account.WireTransferHistory.CompanyIDFrom))]
        public IReadOnlyCollection<account.WireTransferHistory> WireTransferHistoryTos
        {
            get { CheckGet(); return _wireTransferHistoryTos; }
        }
        
        #endregion
        #region company
        private List<Employee> _employees = new List<Employee>();
        [RelationshipList("6C0E982B-0D55-466E-8E56-9A466D7A982C", "CompanyID", AutoDeleteReferences = true)]
        public IReadOnlyCollection<Employee> Employees
        {
            get { CheckGet(); return _employees; }
        }
        #endregion
        #region gov
        private List<Location> _locations = new List<Location>();
        [RelationshipList("FF16FF45-B566-4FA1-B2B4-616F9A58A1CE", "CompanyID")]
        public IReadOnlyCollection<Location> Locations
        {
            get { CheckGet(); return _locations; }
        }
        #endregion
        #endregion
    }
}
