using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using WebModels.company;
using WebModels.gov;
using WebModels.mesasys;

namespace WebModels.account
{
    [Table("7150BBD0-9C9A-4E47-AC50-F8A56FFBA60A")]
    public class WireTransferHistory : DataObject
    {
        protected WireTransferHistory() : base() { }

        private long? _wireTransferHistoryID;
        [Field("5808695E-C0C5-4A10-B972-060123A91C75")]
        public long? WireTransferHistoryID
        {
            get { CheckGet(); return _wireTransferHistoryID; }
            set { CheckSet(); _wireTransferHistoryID = value; }
        }

        private long? _governmentIDFrom;
        [Field("230AF060-EFFD-4907-B5FE-7D92D232F424")]
        public long? GovernmentIDFrom
        {
            get { CheckGet(); return _governmentIDFrom; }
            set { CheckSet(); _governmentIDFrom = value; }
        }

        private Government _governmentFrom = null;
        [Relationship("96711BD7-DDFE-47BE-BD08-DF145B71F085", ForeignKeyField = nameof(GovernmentIDFrom))]
        public Government GovernmentFrom
        {
            get { CheckGet(); return _governmentFrom; }
        }

        private long? _companyIDFrom;
        [Field("5EC9731C-1B74-4B74-B59C-EEE181C88AA5")]
        public long? CompanyIDFrom
        {
            get { CheckGet(); return _companyIDFrom; }
            set { CheckSet(); _companyIDFrom = value; }
        }

        private Company _companyFrom = null;
        [Relationship("1F20202A-2CEA-40A2-BDF9-1C4E7DBA7094", ForeignKeyField = nameof(CompanyIDFrom))]
        public Company CompanyFrom
        {
            get { CheckGet(); return _companyFrom; }
        }

        private long? _governmentIDTo;
        [Field("020E3090-720A-42CF-8FA4-D1AE41CD3567")]
        public long? GovernmentIDTo
        {
            get { CheckGet(); return _governmentIDTo; }
            set { CheckSet(); _governmentIDTo = value; }
        }

        private Government _governmentTo = null;
        [Relationship("7531E5D4-665A-487B-A575-A6F24246EF03", ForeignKeyField = nameof(GovernmentIDTo))]
        public Government GovernmentTo
        {
            get { CheckGet(); return _governmentTo; }
        }

        private long? _companyIDTo;
        [Field("9CA6B2FF-B016-4312-8661-5AE01C307472")]
        public long? CompanyIDTo
        {
            get { CheckGet(); return _companyIDTo; }
            set { CheckSet(); _companyIDTo = value; }
        }

        private Company _companyTo = null;
        [Relationship("956D9527-7705-4BA6-971D-B21F30DE254F", ForeignKeyField = nameof(CompanyIDTo))]
        public Company CompanyTo
        {
            get { CheckGet(); return _companyTo; }
        }

        private DateTime? _transferTime;
        [Field("A25E1562-E7F2-4BED-978B-05864196EE29", DataSize = 7)]
        public DateTime? TransferTime
        {
            get { CheckGet(); return _transferTime; }
            set { CheckSet(); _transferTime = value; }
        }

        private string _accountFromHistorical;
        [Field("36E26D03-23F0-431F-8506-FB9ED4A8AFB2", DataSize = 69)]
        public string AccountFromHistorical
        {
            get { CheckGet(); return _accountFromHistorical; }
            set { CheckSet(); _accountFromHistorical = value; }
        }

        private string _accountFromMasked;
        [Field("0ADBF493-A2BA-4A8F-84B0-4DBB352B48F9", DataSize = 16)]
        public string AccountFromMasked
        {
            get { CheckGet(); return _accountFromMasked; }
            set { CheckSet(); _accountFromMasked = value; }
        }

        private string _accountToHistorical;
        [Field("4774C26D-F98A-4415-BA31-E92F4FE58919", DataSize = 69)]
        public string AccountToHistorical
        {
            get { CheckGet(); return _accountToHistorical; }
            set { CheckSet(); _accountToHistorical = value; }
        }

        private string _accountToMasked;
        [Field("61658C74-7810-4B70-B071-EF7430EC74F3", DataSize = 16)]
        public string AccountToMasked
        {
            get { CheckGet(); return _accountToMasked; }
            set { CheckSet(); _accountToMasked = value; }
        }

        private decimal? _amount;
        [Field("8197F6B0-E48C-44BD-9D8F-B7822A148F70", DataSize = 9, DataScale = 2)]
        public decimal? Amount
        {
            get { CheckGet(); return _amount; }
            set { CheckSet(); _amount = value; }
        }

        private string _memo;
        [Field("E0A71C7F-EF1D-47AB-9B94-1208DADEBE84", DataSize = 100)]
        public string Memo
        {
            get { CheckGet(); return _memo; }
            set { CheckSet(); _memo = value; }
        }

        protected override bool PostSave(ITransaction transaction)
        {
            long? emailImpID;
            if (GovernmentIDTo != null)
            {
                emailImpID = DataObject.GetReadOnlyByPrimaryKey<Government>(GovernmentIDTo, transaction, new[] { nameof(Government.EmailImplementationIDWireTransferHistory) }).EmailImplementationIDWireTransferHistory;
            }
            else
            {
                emailImpID = DataObject.GetReadOnlyByPrimaryKey<Company>(CompanyIDTo, transaction, new[] { nameof(Company.EmailImplementationIDWireTransferHistory) }).EmailImplementationIDWireTransferHistory;
            }

            if (emailImpID != null)
            {
                EmailImplementation emailImplementation = DataObject.GetReadOnlyByPrimaryKey<EmailImplementation>(emailImpID, transaction, Schema.GetSchemaObject<EmailImplementation>().GetFields().Select(f => f.FieldName));
                if (emailImplementation != null)
                {
                    emailImplementation.SendEmail<WireTransferHistory>(WireTransferHistoryID, transaction);
                }
            }
            return base.PostSave(transaction);
        }
    }
}
