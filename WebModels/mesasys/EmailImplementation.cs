using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using WebModels.company;
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
            TModel model = DataObject.GetReadOnlyByPrimaryKey<TModel>(primaryKeyOfModel, transaction, fieldPaths);
            foreach(string fieldPath in fieldPaths)
            {
                workingBody = workingBody.Replace($"{{{fieldPath}}}", model.GetValue(fieldPath)?.ToString());
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
