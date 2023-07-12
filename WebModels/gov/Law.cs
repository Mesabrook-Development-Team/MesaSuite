using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Validation.Attributes;

namespace WebModels.gov
{
    [Table("784106E7-D8C8-44C5-84A4-67834F266F7D")]
    public class Law : DataObject
    {
        protected Law() : base() { }

        private long? _lawID;
        [Field("1724FBA2-A854-4C8F-98A7-32EC2B3C35D9")]
        public long? LawID
        {
            get { CheckGet(); return _lawID; }
            set { CheckSet(); _lawID = value; }
        }

        private long? _governmentID;
        [Field("DE02428E-C471-4F4C-8F69-50DA35CEDBF8")]
        [Required]
        public long? GovernmentID
        {
            get { CheckGet(); return _governmentID; }
            set { CheckSet(); _governmentID = value; }
        }

        private Government _government = null;
        [Relationship("1BA7D11D-F8DB-452B-9789-68053889D4E4")]
        public Government Government
        {
            get { CheckGet(); return _government; }
        }

        private string _name;
        [Field("2F44ED9E-487B-4D98-B904-F039C601D5F2", DataSize = 30)]
        [Required]
        public string Name
        {
            get { CheckGet(); return _name; }
            set { CheckSet(); _name = value;}
        }

        #region Relationships
        #region gov
        private List<LawSection> _lawSections = new List<LawSection>();
        [RelationshipList("7D52FB1A-434E-404A-BCEA-FE93EABB96E4", nameof(LawSection.LawID))]
        public IReadOnlyCollection<LawSection> LawSections
        {
            get { CheckGet(); return _lawSections; }
        }
        #endregion
        #endregion
    }
}
