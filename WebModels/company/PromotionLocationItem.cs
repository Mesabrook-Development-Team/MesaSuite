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
    [Table("1765E12F-A0C5-4313-A5D4-DED31735A707")]
    [Unique(new[] { nameof(PromotionID), nameof(LocationItemID) })]
    public class PromotionLocationItem : DataObject
    {
        protected PromotionLocationItem() : base() { }

        private long? _promotionLocationItemID;
        [Field("3C66DA27-4874-4FB3-BAF6-44629733644E")]
        public long? PromotionLocationItemID
        {
            get { CheckGet(); return _promotionLocationItemID;}
            set { CheckSet(); _promotionLocationItemID = value; }
        }

        private long? _promotionID;
        [Field("0C010214-F2BF-45EC-8526-FD7BEF3B2E26")]
        [Required]
        public long? PromotionID
        {
            get { CheckGet(); return _promotionID; }
            set { CheckSet(); _promotionID = value; }
        }

        private Promotion _promotion = null;
        [Relationship("990A3D2E-1EA7-45B5-B5FB-D9B60D3AF29A")]
        public Promotion Promotion
        {
            get { CheckGet(); return _promotion; }
        }

        private long? _locationItemID;
        [Field("1725B3B8-6D83-4DEF-878D-D0127C44C790")]
        [Required]
        public long? LocationItemID
        {
            get { CheckGet(); return _locationItemID; }
            set { CheckSet(); _locationItemID = value; }
        }

        private LocationItem _locationItem = null;
        [Relationship("8548C76A-ABE0-4137-894C-EDC7AD1B7364")]
        public LocationItem LocationItem
        {
            get { CheckGet(); return _locationItem; }
        }

        private decimal? _promotionPrice;
        [Field("DA7A0A62-8EA5-4F56-BFC4-C72A65FBD523", DataSize = 9, DataScale = 2)]
        [Required]
        public decimal? PromotionPrice
        {
            get { CheckGet(); return _promotionPrice; }
            set { CheckSet(); _promotionPrice = value; }
        }
    }
}
