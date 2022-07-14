using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema;
using ClussPro.ObjectBasedFramework.Schema.Attributes;

namespace WebModels.mesasys
{
    [Table("1F37720E-04B1-4716-BE7F-423276D40C26")]
    public class EmailTemplate : DataObject, ISystemLoaded
    {
        protected EmailTemplate() : base() { }

        private long? _emailTemplateID;
        [Field("5A009460-F08F-4608-91CC-690F6D30EB13")]
        public long? EmailTemplateID
        {
            get { CheckGet(); return _emailTemplateID; }
            set { CheckSet(); _emailTemplateID = value; }
        }

        private Guid? _systemID;
        [Field("F080CF98-BEAB-4FD0-A0EF-253EEA77D8F1")]
        public Guid? SystemID
        {
            get { CheckGet(); return _systemID; }
            set { CheckSet(); _systemID = value; }
        }

        private byte[] _systemHash;
        [Field("45DADF60-9729-4A41-9641-1078A778E866")]
        public byte[] SystemHash
        {
            get { CheckGet(); return _systemHash; }
            set { CheckSet(); _systemHash = value; }
        }

        private string _name;
        [Field("6C9D56A3-186E-473A-AE4D-483DD386AB3F", DataSize = 255, IsSystemLoaded = true)]
        public string Name
        {
            get { CheckGet(); return _name; }
            set { CheckSet(); _name = value; }
        }

        private string _template;
        [Field("3146B64C-FF09-407D-885A-4D503563FFE3", DataSize = 4000, IsSystemLoaded = true)]
        public string Template
        {
            get { CheckGet(); return _template; }
            set { CheckSet(); _template = value; }
        }

        private string _allowedFields;
        [Field("EADD9DE5-2FF3-4255-ACC7-A520BA4DDD9B", DataSize = -1, IsSystemLoaded = true)]
        public string AllowedFields
        {
            get { CheckGet(); return _allowedFields; }
            set { CheckSet(); _allowedFields = value; }
        }

        #region Relationships
        private List<EmailImplementation> _emailImplementations = new List<EmailImplementation>();
        [RelationshipList("5A7A20F8-7301-4AAB-90E3-BCD5697234FA", nameof(EmailImplementation.EmailTemplateID))]
        public IReadOnlyCollection<EmailImplementation> EmailImplementations
        {
            get { CheckGet(); return _emailImplementations; }
        }
        #endregion
    }
}
