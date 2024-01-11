using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Validation.Attributes;

namespace WebModels.company
{
    [Table("64E78224-E28F-4A8F-B4F0-CE07AFD5C31F")]
    public class Promotion : DataObject
    {
        protected Promotion() : base() { }

        private long? _promotionID;
        [Field("5B571237-D24C-4434-97DC-15900F8A64E3")]
        public long? PromotionID
        {
            get { CheckGet(); return _promotionID; }
            set { CheckSet(); _promotionID = value; }
        }

        private long? _locationID;
        [Field("91018B1A-B4C0-4278-8868-D664F9D04335")]
        [Required]
        public long? LocationID
        {
            get { CheckGet(); return _locationID; }
            set { CheckSet(); _locationID = value; }
        }

        private Location _location = null;
        [Relationship("873C6C8F-6851-4525-91C2-21B46491D213")]
        public Location Location
        {
            get { CheckGet(); return _location; }
        }

        private DateTime? _startTime;
        [Field("4171EAFE-2B4F-46DB-9FB8-9FE2CEE69D8A", DataSize = 7)]
        [Required]
        public DateTime? StartTime
        {
            get { CheckGet(); return _startTime; }
            set { CheckSet(); _startTime = value; }
        }

        private DateTime? _endTime;
        [Field("0A104D6F-A036-4449-BB72-6F10BBD5C19D", DataSize = 7)]
        [Required]
        public DateTime? EndTime
        {
            get { CheckGet(); return _endTime; }
            set { CheckSet(); _endTime = value; }
        }

        private string _name;
        [Field("BCFA3EC4-89A7-4781-B7DA-E0779CFDAD6C", DataSize = 50)]
        [Required]
        public string Name
        {
            get { CheckGet(); return _name; }
            set { CheckSet(); _name = value; }
        }

        #region Relationships
        #region company
        private List<PromotionLocationItem> _promotionLocationItems = new List<PromotionLocationItem>();
        [RelationshipList("AABCC2DF-0EEF-4773-AEAD-E3653AE55DCE", nameof(PromotionLocationItem.PromotionID), AutoDeleteReferences = true)]
        public IReadOnlyCollection<PromotionLocationItem> PromotionLocationItems
        {
            get { CheckGet(); return _promotionLocationItems; }
        }
        #endregion
        #endregion
    }
}
