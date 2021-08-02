using ClussPro.Base.Data;
using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Validation.Attributes;
using System;
using System.Collections.Generic;
using WebModels.hMailServer.dbo;

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

        protected override bool PostSave(ITransaction transaction)
        {
            if (!IsInsert && IsFieldDirty("EmailDomain") && !string.IsNullOrEmpty(EmailDomain))
            {
                return UpdateEmailInfo();
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
        private List<Employee> _employees = new List<Employee>();
        [RelationshipList("6C0E982B-0D55-466E-8E56-9A466D7A982C", "CompanyID", AutoDeleteReferences = true)]
        public IReadOnlyCollection<Employee> Employees
        {
            get { CheckGet(); return _employees; }
        }
        #endregion
    }
}
