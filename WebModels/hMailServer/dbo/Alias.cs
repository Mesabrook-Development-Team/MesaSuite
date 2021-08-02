using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Validation.Attributes;
using System;

namespace WebModels.hMailServer.dbo
{
    [Table("ECB728D1-06B1-4390-9BB0-A5DA1361A655", TableName = "hm_aliases", ConnectionName = "hmailserver")]
    public class Alias : DataObject
    {
        protected Alias() : base() { }

        private int? _aliasID;
        [Field("2C204E72-3FB8-43A4-BDCA-F58ADDF6C7AD", IsPrimaryKey = true)]
        public int? AliasID
        {
            get { CheckGet(); return _aliasID; }
            set { CheckSet(); _aliasID = value; }
        }

        private int? _aliasDomainID;
        [Field("C0631382-66F4-457E-9CC8-7DBEF5DFE74B")]
        [Required]
        public int? AliasDomainID
        {
            get { CheckGet(); return _aliasDomainID; }
            set { CheckSet(); _aliasDomainID = value; }
        }

        private Domain _aliasDomain;
        [Relationship("8372D7CF-6104-407D-ADC6-C9DED66E2D7A", ParentKeyField = "DomainID")]
        public Domain AliasDomain
        {
            get { CheckGet(); return _aliasDomain; }
        }

        private string _aliasName;
        [Field("E3A34C6F-13FD-40C7-8669-5DD707B33694", DataSize = 255)]
        [Required]
        public string AliasName
        {
            get { CheckGet(); return _aliasName; }
            set { CheckSet(); _aliasName = value; }
        }

        private string _aliasValue;
        [Field("9AB1668D-4972-4553-8EEA-6C5AD1F0BE14", DataSize = 255)]
        [Required]
        public string AliasValue
        {
            get { CheckGet(); return _aliasValue; }
            set { CheckSet(); _aliasValue = value; }
        }

        private byte _aliasActive;
        [Field("82A2E680-8D1A-4344-B531-2AEE34D3EE51")]
        public byte AliasActive
        {
            get { CheckGet(); return _aliasActive; }
            set { CheckSet(); _aliasActive = value; }
        }

        protected override bool PreSave(ITransaction transaction)
        {
            AliasActive = 1;
            return base.PreSave(transaction);
        }

        public static class ValidationFlags
        {
            public static Guid V_AddressEndsWithCompanyAddress = new Guid("2FCBDFF9-947C-4A63-B700-31A648C260CD");
        }
    }
}