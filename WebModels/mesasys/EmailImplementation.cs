using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using WebModels.company;
using WebModels.fleet;
using WebModels.gov;

namespace WebModels.mesasys
{
    [Table("F2DB3D92-D765-4A5E-B59B-9BBF06020ADE")]
    public class EmailImplementation : DataObject
    {
        protected EmailImplementation() : base() { }

        private long? _emailImplementationID;
        [Field("53F46BCA-54F5-4EF7-BE6C-57078D718E6C")]
        public long? EmailImplementationID
        {
            get { CheckGet(); return _emailImplementationID; }
            set { CheckSet(); _emailImplementationID = value; }
        }

        private long? _emailTemplateID;
        [Field("EC655B3F-3BFA-4DE4-B4C2-59BD9658D2C9")]
        public long? EmailTemplateID
        {
            get { CheckGet(); return _emailTemplateID; }
            set { CheckSet(); _emailTemplateID = value; }
        }

        private EmailTemplate _emailTemplate = null;
        [Relationship("51E1B44A-82CF-4425-85C7-C63B1F228C16")]
        public EmailTemplate EmailTemplate
        {
            get { CheckGet(); return _emailTemplate; }
        }

        private string _fromName;
        [Field("6260B516-FFC9-4292-B0E1-80D249B16F66", DataSize = 100)]
        public string FromName
        {
            get { CheckGet(); return _fromName; }
            set { CheckSet(); _fromName = value; }
        }

        private string _fromEmail;
        [Field("765561DB-E98F-4C0D-A993-69EB671A0CCA", DataSize = 255)]
        public string FromEmail
        {
            get { CheckGet(); return _fromEmail; }
            set { CheckSet(); _fromEmail = value; }
        }

        private string _to;
        [Field("A4EEB52E-28D7-4385-BDCA-371B033C852E", DataSize = 255)]
        public string To
        {
            get { CheckGet(); return _to; }
            set { CheckSet(); _to = value; }
        }

        private string _subject;
        [Field("F9CDBD45-CD1E-4E8E-8E91-1F6BE43F50C4", DataSize = 50)]
        public string Subject
        {
            get { CheckGet(); return _subject; }
            set { CheckSet(); _subject = value; }
        }

        private string _body;
        [Field("58769C80-204A-4C6E-A629-D6624BF35819", DataSize = 4000)]
        public string Body
        {
            get { CheckGet(); return _body; }
            set { CheckSet(); _body = value; }
        }

        #region Relationships
        #region company
        private List<Company> _companyWireTransferHistories = new List<Company>();
        [RelationshipList("E03E4DFC-C7D6-4932-A148-F57C470EBEE6", nameof(Company.EmailImplementationIDWireTransferHistory))]
        public IReadOnlyCollection<Company> CompanyWireTransferHistories
        {
            get { CheckGet(); return _companyWireTransferHistories; }
        }

        private List<Location> _locationPayableInvoices = new List<Location>();
        [RelationshipList("1EE39ABB-9D43-4585-BF30-76F35A68A22A", nameof(Location.EmailImplementationIDPayableInvoice))]
        public IReadOnlyCollection<Location> LocationPayableInvoices
        {
            get { CheckGet(); return _locationPayableInvoices; }
        }

        private List<Location> _locationReadyForReceipts = new List<Location>();
        [RelationshipList("1EE39ABB-9D43-4585-BF30-76F35A68A22A", nameof(Location.EmailImplementationIDReadyForReceipt))]
        public IReadOnlyCollection<Location> LocationReadyForReceipts
        {
            get { CheckGet(); return _locationReadyForReceipts; }
        }
        #endregion
        #region fleet
        private List<MiscellaneousSettings> _miscellaneousSettingsCarReleased = new List<MiscellaneousSettings>();
        [RelationshipList("7C25ACC6-B943-4B3E-8F13-B711D67FF6D0", nameof(MiscellaneousSettings.EmailImplementationIDCarReleased))]
        public IReadOnlyCollection<MiscellaneousSettings> MiscellaneousSettingsCarReleased
        {
            get { CheckGet(); return _miscellaneousSettingsCarReleased; }
        }

        private List<MiscellaneousSettings> _miscellaneousSettingsLocomotiveReleased = new List<MiscellaneousSettings>();
        [RelationshipList("CB53111E-9B6A-4467-8F6A-49C55F2E1713", nameof(MiscellaneousSettings.EmailImplementationIDLocomotiveReleased))]
        public IReadOnlyCollection<MiscellaneousSettings> MiscellaneousSettingsLocomotiveReleased
        {
            get { CheckGet(); return _miscellaneousSettingsLocomotiveReleased; }
        }

        private List<MiscellaneousSettings> _miscellaneousSettingsLeaseRequestAvailable = new List<MiscellaneousSettings>();
        [RelationshipList("15B4D7C3-5880-4C84-B18A-F7BE90FEC1D3", nameof(MiscellaneousSettings.EmailImplementationIDLeaseRequestAvailable))]
        public IReadOnlyCollection<MiscellaneousSettings> MiscellaneousSettingsLeaseRequestAvailable
        {
            get { CheckGet(); return _miscellaneousSettingsLeaseRequestAvailable; }
        }

        private List<MiscellaneousSettings> _miscellaneousSettingsLeaseBidReceived = new List<MiscellaneousSettings>();
        [RelationshipList("786599AC-D4A6-4351-9EBA-63C5892410FB", nameof(MiscellaneousSettings.EmailImplementationIDLeaseBidReceived))]
        public IReadOnlyCollection<MiscellaneousSettings> MiscellaneousSettingsLeaseBidReceived
        {
            get { CheckGet(); return _miscellaneousSettingsLeaseBidReceived; }
        }
        #endregion
        #region gov
        private List<Government> _governmentWireTransferHistories = new List<Government>();
        [RelationshipList("BC2F8A11-6721-4B27-84D0-0E02F39B6F82", nameof(Government.EmailImplementationIDWireTransferHistory))]
        public IReadOnlyCollection<Government> GovernmentWireTransferHistories
        {
            get { CheckGet(); return _governmentWireTransferHistories; }
        }

        private List<Government> _governmentPayableInvoices = new List<Government>();
        [RelationshipList("A5751F14-0969-46EE-8F4D-F21EA6BAEF63", nameof(Government.EmailImplementationIDPayableInvoice))]
        public IReadOnlyCollection<Government> GovernmentPayableInvoices
        {
            get { CheckGet(); return _governmentPayableInvoices; }
        }

        private List<Government> _governmentReadyForReceipts = new List<Government>();
        [RelationshipList("81C9D097-E4F2-4D76-B5A9-2418782213EA", nameof(Government.EmailImplementationIDReadyForReceipt))]
        public IReadOnlyCollection<Government> GovernmentReadyForReceipts
        {
            get { CheckGet(); return _governmentReadyForReceipts; }
        }
        #endregion
        #endregion

        public bool SendEmail<TModel>(long? primaryKeyOfModel, ITransaction transaction) where TModel : DataObject
        {
            string workingBody = Body;

            HashSet<string> fieldPaths = new HashSet<string>();
            while(workingBody.Contains("{"))
            {
                workingBody = workingBody.Substring(workingBody.IndexOf("{"));
                string fieldPath = workingBody.Substring(1, workingBody.IndexOf("}") - 1);
                fieldPaths.Add(fieldPath);
                workingBody = workingBody.Substring(fieldPath.Length + 2);
            }

            workingBody = Body;
            TModel model = DataObject.GetReadOnlyByPrimaryKey<TModel>(primaryKeyOfModel, transaction, fieldPaths.Select(fp => fp.Contains(":") ? fp.Substring(0, fp.IndexOf(":")) : fp));
            foreach(string fieldPath in fieldPaths)
            {
                string format = "";
                if (fieldPath.Contains(":"))
                {
                    format = fieldPath.Substring(fieldPath.IndexOf(":") + 1);
                }

                object fieldValue = model.GetValue(fieldPath.Contains(":") ? fieldPath.Substring(0, fieldPath.IndexOf(":")) : fieldPath);
                if (fieldValue != null && !string.IsNullOrEmpty(format))
                {
                    if (fieldValue is DateTime dateTime)
                    {
                        try
                        {
                            fieldValue = dateTime.ToString(format);
                        }
                        catch { }
                    }

                    if (fieldValue is decimal decimalValue)
                    {
                        try
                        {
                            fieldValue = decimalValue.ToString(format);
                        }
                        catch { }
                    }
                }

                workingBody = workingBody.Replace($"{{{fieldPath}}}", fieldValue?.ToString());
            }

            OutboundEmail outboundEmail = DataObjectFactory.Create<OutboundEmail>();
            outboundEmail.FromName = FromName;
            outboundEmail.FromEmail = FromEmail;
            outboundEmail.To = To;
            outboundEmail.Subject = Subject;
            outboundEmail.Body = workingBody;
            return outboundEmail.Save(transaction);
        }
    }
}
