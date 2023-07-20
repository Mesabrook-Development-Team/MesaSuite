using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Validation.Attributes;

namespace WebModels.mesasys
{
    [Table("61B22BC3-5BE8-482F-BF58-E22D84B678C8")]
    [Unique(new[] { nameof(Type) })]
    public class TermsOfService : DataObject
    {
        protected TermsOfService() : base() { }

        private long? _termsOfServiceID;
        [Field("37D80E1C-4E92-4AD4-AC90-46E3925CD514")]
        public long? TermsOfServiceID
        {
            get { CheckGet(); return _termsOfServiceID; }
            set { CheckSet(); _termsOfServiceID = value; }
        }

        public enum Types
        {
            MesabrookServer,
            MesaSuite
        }

        private Types _type;
        [Field("907F9072-B93D-45A7-8D97-FF98BEA481DC")]
        [Required]
        public Types Type
        {
            get { CheckGet(); return _type; }
            set { CheckSet(); _type = value; }
        }

        private string _terms;
        [Field("67965EBB-D7DC-486A-B40C-2A23B5AAF5FF", DataSize = -1)]
        [Required]
        public string Terms
        {
            get { CheckGet(); return _terms; }
            set { CheckSet(); _terms = value; }
        }
    }
}
