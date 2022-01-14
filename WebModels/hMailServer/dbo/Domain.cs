using ClussPro.Base.Data;
using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Schema;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using WebModels.company;
using WebModels.gov;

namespace WebModels.hMailServer.dbo
{
    [Table("D2996C69-BEC3-4F8A-8D15-D004977209BB", TableName = "hm_domains", ConnectionName = "hmailserver")]
    public class Domain : DataObject
    {
        protected Domain() : base() { }

        private int? _domainID;
        [Field("764F73DA-8E3C-4EBF-BA13-AC9821746A80", IsPrimaryKey = true)]
        public int? DomainID
        {
            get { CheckGet(); return _domainID; }
            set { CheckSet(); _domainID = value; }
        }

        private string _domainName;
        [Field("F242C5F5-D4C4-4BD5-A8F6-375327F80687", DataSize = 80)]
        public string DomainName
        {
            get { CheckGet(); return _domainName; }
            set { CheckSet(); _domainName = value; }
        }

        private byte _domainActive;
        [Field("106BD865-3B8E-424D-ABDE-0FF86D318621")]
        public byte DomainActive
        {
            get { CheckGet(); return _domainActive; }
            set { CheckSet(); _domainActive = value; }
        }

        private string _domainPostMaster;
        [Field("C238563D-4059-4936-A8A3-5EB2013E3BFC", DataSize = 80)]
        public string DomainPostMaster
        {
            get { CheckGet(); return _domainPostMaster; }
            set { CheckSet(); _domainPostMaster = value; }
        }

        private int _domainMaxSize;
        [Field("58158C92-E351-4E51-B476-B5FE4133F92F")]
        public int DomainMaxSize
        {
            get { CheckGet(); return _domainMaxSize; }
            set { CheckSet(); _domainMaxSize = value; }
        }

        private string _domainAdDomain;
        [Field("10D63CC0-1BF7-4494-A43E-F23582C91450", DataSize = 255)]
        public string DomainAdDomain
        {
            get { CheckGet(); return _domainAdDomain; }
            set { CheckSet(); _domainAdDomain = value; }
        }

        private int _domainMaxMessageSize;
        [Field("91F77D69-FFAF-4984-B520-880241F2FE31")]
        public int DomainMaxMessageSize
        {
            get { CheckGet(); return _domainMaxMessageSize; }
            set { CheckSet(); _domainMaxMessageSize = value; }
        }

        private byte _domainUsePlusAddressing;
        [Field("06C6DC56-68D6-42F3-9A9B-35743B24B2E1")]
        public byte DomainUsePlusAddressing
        {
            get { CheckGet(); return _domainUsePlusAddressing; }
            set { CheckSet(); _domainUsePlusAddressing = value; }
        }

        private string _domainPlusAddressingChar;
        [Field("204BD568-F3DB-4BE7-9EBC-19ABC6AC9D76", DataSize = 1)]
        public string DomainPlusAddressingChar
        {
            get { CheckGet(); return _domainPlusAddressingChar; }
            set { CheckSet(); _domainPlusAddressingChar = value; }
        }

        private int _domainAntiSpamOptions;
        [Field("09E86BA6-4F5F-40F5-96A2-3816E8687330")]
        public int DomainAntiSpamOptions
        {
            get { CheckGet(); return _domainAntiSpamOptions; }
            set { CheckSet(); _domainAntiSpamOptions = value; }
        }

        private byte _domainEnableSignature;
        [Field("C04EFEB9-550C-461E-981D-EB29A702C62E")]
        public byte DomainEnableSignature
        {
            get { CheckGet(); return _domainEnableSignature; }
            set { CheckSet(); _domainEnableSignature = value; }
        }

        private byte _domainSignatureMethod;
        [Field("23D928DE-E444-460B-9568-728D00179705")]
        public byte DomainSignatureMethod
        {
            get { CheckGet(); return _domainSignatureMethod; }
            set { CheckSet(); _domainSignatureMethod = value; }
        }

        private string _domainSignaturePlainText;
        [Field("0B5A6711-B984-4C75-8F1E-C6C4DDB3F03C", DataSize = -1)]
        public string DomainSignaturePlainText
        {
            get { CheckGet(); return _domainSignaturePlainText; }
            set { CheckSet(); _domainSignaturePlainText = value; }
        }

        private string _domainSignatureHTML;
        [Field("F50113FF-6CC5-4EDC-A550-4661B387EF6F", DataSize = -1)]
        public string DomainSignatureHTML
        {
            get { CheckGet(); return _domainSignatureHTML; }
            set { CheckSet(); _domainSignatureHTML = value; }
        }

        private byte _domainAddSignaturesToReplies;
        [Field("268626B4-8861-4E5E-BBC7-AB375870EADC")]
        public byte DomainAddSignaturesToReplies
        {
            get { CheckGet(); return _domainAddSignaturesToReplies; }
            set { CheckSet(); _domainAddSignaturesToReplies = value; }
        }

        private byte _domainAddSignaturesToLocalEmail;
        [Field("31C1BD83-2D68-4E88-9A29-80DD5E81648F")]
        public byte DomainAddSignaturesToLocalEmail
        {
            get { CheckGet(); return _domainAddSignaturesToLocalEmail; }
            set { CheckSet(); _domainAddSignaturesToLocalEmail = value; }
        }

        private int _domainMaxNoOfAccounts;
        [Field("4FE5AC17-5C69-46B2-93D8-90D899E79A2B")]
        public int DomainMaxNoOfAccounts
        {
            get { CheckGet(); return _domainMaxNoOfAccounts; }
            set { CheckSet(); _domainMaxNoOfAccounts = value; }
        }

        private int _domainMaxNoOfAliases;
        [Field("FD0FFDA1-5809-45B7-A796-37B8C6264B44")]
        public int DomainMaxNoOfAliases
        {
            get { CheckGet(); return _domainMaxNoOfAliases; }
            set { CheckSet(); _domainMaxNoOfAliases = value; }
        }

        private int _domainMaxNoOfDistributionLists;
        [Field("B5E77B0E-9128-4AA5-8123-037FFC9648C9")]
        public int DomainMaxNoOfDistributionLists
        {
            get { CheckGet(); return _domainMaxNoOfDistributionLists; }
            set { CheckSet(); _domainMaxNoOfDistributionLists = value; }
        }

        private int _domainLimitationsEnabled;
        [Field("F61D620D-9862-4D80-8760-336D16278ABA")]
        public int DomainLimitationsEnabled
        {
            get { CheckGet(); return _domainLimitationsEnabled; }
            set { CheckSet(); _domainLimitationsEnabled = value; }
        }

        private int _domainMaxAccountSize;
        [Field("C86E7D3C-C4BC-4D1C-8F69-D1215D88607D")]
        public int DomainMaxAccountSize
        {
            get { CheckGet(); return _domainMaxAccountSize; }
            set { CheckSet(); _domainMaxAccountSize = value; }
        }

        private string _domainDKIMSelector;
        [Field("310DA50B-C827-4A7E-AAC5-6D68B0DB8FD4", DataSize = 255)]
        public string DomainDKIMSelector
        {
            get { CheckGet(); return _domainDKIMSelector; }
            set { CheckSet(); _domainDKIMSelector = value; }
        }

        private string _domainDKIMPrivateKeyFile;
        [Field("310DA50B-C827-4A7E-AAC5-6D68B0DB8FD4", DataSize = 255)]
        public string DomainDKIMPrivateKeyFile
        {
            get { CheckGet(); return _domainDKIMPrivateKeyFile; }
            set { CheckSet(); _domainDKIMPrivateKeyFile = value; }
        }

        protected override bool PreSave(ITransaction transaction)
        {
            DomainActive = 1;
            DomainMaxSize = 0;
            DomainMaxMessageSize = 0;
            DomainUsePlusAddressing = 0;
            DomainAntiSpamOptions = 0;
            DomainEnableSignature = 0;
            DomainSignatureMethod = 1;
            DomainAddSignaturesToReplies = 0;
            DomainAddSignaturesToLocalEmail = 0;
            DomainMaxNoOfAccounts = 0;
            DomainMaxNoOfAliases = 0;
            DomainMaxNoOfDistributionLists = 0;
            DomainLimitationsEnabled = 0;
            DomainMaxAccountSize = 0;

            foreach(Field field in Schema.GetSchemaObject<Domain>().GetFields().Where(f => !f.FieldName.Equals(nameof(DomainName), StringComparison.OrdinalIgnoreCase) && f.ReturnType == typeof(string)))
            {
                field.SetValue(this, string.Empty);
            }

            return base.PreSave(transaction);
        }

        protected override bool PostSave(ITransaction transaction)
        {
            if (!IsInsert && IsFieldDirty("DomainName"))
            {
                return UpdateEmailSetups();
            }

            return base.PostSave(transaction);
        }

        protected override bool PostDelete(ITransaction transaction)
        {
            return UpdateEmailSetups(true);
        }

        private bool UpdateEmailSetups(bool isDelete = false)
        {
            string oldEmailDomain = (string)GetDirtyValue("DomainName");
            using (ITransaction transaction = SQLProviderFactory.GenerateTransaction())
            {
                // Update Companies
                Search<Company> companySearch = new Search<Company>(new StringSearchCondition<Company>()
                {
                    Field = "EmailDomain",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Like,
                    Value = $"%{oldEmailDomain}"
                });

                foreach (Company company in companySearch.GetEditableReader())
                {
                    if (isDelete)
                    {
                        company.EmailDomain = null;
                    }
                    else
                    {
                        company.EmailDomain = company.EmailDomain.Replace($"{oldEmailDomain}", $"{DomainName}");
                    }

                    if (!company.Save(transaction))
                    {
                        Errors.AddBaseMessage($"Could not update Company with ID {company.CompanyID}:\r\n{company.Errors.ToString()}");
                        return false;
                    }
                }

                // Update governments
                Search<Government> governmentSearch = new Search<Government>(new StringSearchCondition<Government>()
                {
                    Field = "EmailDomain",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Like,
                    Value = $"%{oldEmailDomain}"
                });

                foreach (Government government in governmentSearch.GetEditableReader())
                {
                    if (isDelete)
                    {
                        government.EmailDomain = null;
                    }
                    else
                    {
                        government.EmailDomain = government.EmailDomain.Replace($"{oldEmailDomain}", $"{DomainName}");
                    }

                    if (!government.Save(transaction))
                    {
                        Errors.AddBaseMessage($"Could not update Government with ID {government.GovernmentID}:\r\n{government.Errors.ToString()}");
                        return false;
                    }
                }

                transaction.Commit();
            }

            return true;
        }

        #region Relationships
        private List<Alias> _aliases = new List<Alias>();
        [RelationshipList("13D8C559-5BA2-4D96-8F5B-2A61D0233FDB", "AliasDomainID", AutoDeleteReferences = true)]
        public IReadOnlyCollection<Alias> Aliases
        {
            get { CheckGet(); return _aliases; }
        }

        private List<DistributionList> _distributionLists = new List<DistributionList>();
        [RelationshipList("AF1C5C83-8689-4717-B2AF-76B3B2FB9388", "DistributionListDomainID", AutoDeleteReferences = true)]
        public IReadOnlyCollection<DistributionList> DistributionLists
        {
            get { CheckGet(); return _distributionLists; }
        }
        #endregion
    }
}