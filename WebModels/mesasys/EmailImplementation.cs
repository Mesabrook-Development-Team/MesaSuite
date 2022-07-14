using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;

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

        private string _from;
        [Field("765561DB-E98F-4C0D-A993-69EB671A0CCA", DataSize = 255)]
        public string From
        {
            get { CheckGet(); return _from; }
            set { CheckSet(); _from = value; }
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
    }
}
