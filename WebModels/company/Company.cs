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

        private fleet.MiscellaneousSettings _fleetMiscSettings = null;
        [Relationship("0307C719-B4CD-4F99-9704-E1C20A5950BF", OneToOneByForeignKey = true)]
        public fleet.MiscellaneousSettings FleetMiscSettings
        {
            get { CheckGet(); return _fleetMiscSettings; }
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
        #region fleet
        private List<fleet.Locomotive> _locomotivesOwned = new List<fleet.Locomotive>();
        [RelationshipList("500A7C05-EA28-4460-80E7-031E2EAB7A4C", nameof(fleet.Locomotive.CompanyIDOwner))]
        public IReadOnlyCollection<fleet.Locomotive> LocomotivesOwned
        {
            get { CheckGet(); return _locomotivesOwned; }
        }

        private List<fleet.Railcar> _railcarsOwned = new List<fleet.Railcar>();
        [RelationshipList("73980C31-26C2-4063-85FF-C9921B5CF0E1", nameof(fleet.Railcar.CompanyIDOwner))]
        public IReadOnlyCollection<fleet.Railcar> RailcarsOwned
        {
            get { CheckGet(); return _railcarsOwned; }
        }

        private List<fleet.Locomotive> _locomotivesPossessed = new List<fleet.Locomotive>();
        [RelationshipList("1B224D6C-9898-4F6D-A281-8F100AA32A81", nameof(fleet.Locomotive.CompanyIDPossessor))]
        public IReadOnlyCollection<fleet.Locomotive> LocomotivesPossessed
        {
            get { CheckGet(); return _locomotivesPossessed; }
        }

        private List<fleet.Railcar> _railcarsPossessed = new List<fleet.Railcar>();
        [RelationshipList("BEC24E2F-9F4C-4372-AD71-877331321DEE", nameof(fleet.Railcar.CompanyIDPossessor))]
        public IReadOnlyCollection<fleet.Railcar> RailcarsPossessed
        {
            get { CheckGet(); return _railcarsPossessed; }
        }

        private List<fleet.LeaseRequest> _leaseRequests = new List<fleet.LeaseRequest>();
        [RelationshipList("ABAD4624-7CB5-49F0-8B49-13C1F3C1788A", nameof(fleet.LeaseRequest.CompanyIDRequester))]
        public IReadOnlyCollection<fleet.LeaseRequest> LeaseRequests
        {
            get { CheckGet(); return _leaseRequests; }
        }

        private List<fleet.LeaseContract> _leaseContracts = new List<fleet.LeaseContract>();
        [RelationshipList("94DF511B-660A-441B-8EE4-F4D434A38EC5", nameof(fleet.LeaseContract.CompanyIDLessee))]
        public IReadOnlyCollection<fleet.LeaseContract> LeaseContracts
        {
            get { CheckGet(); return _leaseContracts; }
        }

        private List<fleet.Track> _tracksOwned = new List<fleet.Track>();
        [RelationshipList("616A35B8-366A-404F-8701-EF609B771622", nameof(fleet.Track.CompanyIDOwner))]
        public IReadOnlyCollection<fleet.Track> TracksOwned
        {
            get { CheckGet(); return _tracksOwned; }
        }

        private List<fleet.TrainSymbol> _trainSymbols = new List<fleet.TrainSymbol>();
        [RelationshipList("A4D050C4-3338-44CC-84E5-B7A98AC7658F", nameof(fleet.TrainSymbol.CompanyIDOperator))]
        public IReadOnlyCollection<fleet.TrainSymbol> TrainSymbols
        {
            get { CheckGet(); return _trainSymbols; }
        }

        private List<fleet.CarHandlingRate> _carHandlingRates = new List<fleet.CarHandlingRate>();
        [RelationshipList("59786644-5035-4688-8DFC-DB80A59DF37A", nameof(fleet.CarHandlingRate.CompanyID))]
        public IReadOnlyCollection<fleet.CarHandlingRate> CarHandlingRates
        {
            get { CheckGet(); return _carHandlingRates; }
        }

        private List<fleet.LiveLoadSession> _liveLoadSessions = new List<fleet.LiveLoadSession>();
        [RelationshipList("9DDB3DE6-FEB4-42C7-8AB7-19E44636C0D3", nameof(fleet.LiveLoadSession.CompanyID))]
        public IReadOnlyCollection<fleet.LiveLoadSession> LiveLoadSessions
        {
            get { CheckGet(); return _liveLoadSessions; }
        }

        private List<fleet.RailDistrict> _railDistricts = new List<fleet.RailDistrict>();
        [RelationshipList("5101CE2E-00F0-4559-95D5-F27850C7123A", nameof(fleet.RailDistrict.CompanyIDOperator))]
        public IReadOnlyCollection<fleet.RailDistrict> RailDistricts
        {
            get { CheckGet(); return _railDistricts; }
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
