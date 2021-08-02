using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Validation.Attributes;
using System;
using System.Collections.Generic;

namespace WebModels.hMailServer.dbo
{
    [Table("E1DC948D-A808-49D6-AB0F-3C886D0D0574", TableName = "hm_distributionlists", ConnectionName = "hmailserver")]
    public class DistributionList : DataObject
    {
        protected DistributionList() : base() { }

        private int? _distributionListID;
        [Field("58B21273-BE50-43D6-824C-896CC6F31A0C", IsPrimaryKey = true)]
        public int? DistributionListID
        {
            get { CheckGet(); return _distributionListID; }
            set { CheckSet(); _distributionListID = value; }
        }

        private int? _distributionListDomainID;
        [Field("A9F16868-47E0-47ED-AD01-F36F90B34B58")]
        [Required]
        public int? DistributionListDomainID
        {
            get { CheckGet(); return _distributionListDomainID; }
            set { CheckSet(); _distributionListDomainID = value; }
        }

        private Domain _distributionListDomain;
        [Relationship("E61166B1-9828-403D-94E5-8E5BF2A1BBCE", ParentKeyField = "DomainID")]
        public Domain DistributionListDomain
        {
            get { CheckGet(); return _distributionListDomain; }
        }

        private string _distributionListAddress;
        [Field("7DB6DB16-DE56-462A-B0F7-EC5DEBCFE1E9", DataSize = 255)]
        [Required]
        public string DistributionListAddress
        {
            get { CheckGet(); return _distributionListAddress; }
            set { CheckSet(); _distributionListAddress = value; }
        }

        private byte _distributionListEnabled;
        [Field("D43BF6D5-B5E2-4029-8C29-B79585BAF176")]
        public byte DistributionListEnabled
        {
            get { CheckGet(); return _distributionListEnabled; }
            set { CheckSet(); _distributionListEnabled = value; }
        }

        private byte _distributionListRequireAuth;
        [Field("29039441-13AC-4360-A128-6B14F5629425")]
        public byte DistributionListRequireAuth
        {
            get { CheckGet(); return _distributionListRequireAuth; }
            set { CheckSet(); _distributionListRequireAuth = value; }
        }

        private string _distributionListRequireAddress;
        [Field("4C037E65-D9E9-4D79-B4B6-08DE6D6FB3E7", DataSize = 255)]
        public string DistributionListRequireAddress
        {
            get { CheckGet(); return _distributionListRequireAddress; }
            set { CheckSet(); _distributionListRequireAddress = value; }
        }

        private byte _distributionListMode;
        [Field("D58442C3-FC1A-4AE3-8A99-D8E580736030")]
        [Required]
        public byte DistributionListMode
        {
            get { CheckGet(); return _distributionListMode; }
            set { CheckSet(); _distributionListMode = value; }
        }

        protected override bool PreSave(ITransaction transaction)
        {
            DistributionListEnabled = 1;
            DistributionListRequireAuth = 1;
            return base.PreSave(transaction);
        }

        #region Relationships
        private List<DistributionListRecipient> _distributionListRecipients = new List<DistributionListRecipient>();
        [RelationshipList("10DF3DFD-1349-4EB9-ADB5-D57DB6AA2255", "DistributionListRecipientListID", AutoDeleteReferences = true)]
        public IReadOnlyCollection<DistributionListRecipient> DistributionListRecipients
        {
            get { CheckGet(); return _distributionListRecipients; }
        }
        #endregion

        public static class ValidationFlags
        {
            public static Guid V_AddressEndsWithCompanyAddress = new Guid("2FCBDFF9-947C-4A63-B700-31A648C260CD");
        }
    }
}