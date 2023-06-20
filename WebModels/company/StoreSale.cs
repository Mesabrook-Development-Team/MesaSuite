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
    [Table("FAF0C51A-ACB1-43D7-ADA2-AD55F9B07679")]
    public class StoreSale : DataObject
    {
        protected StoreSale() : base() { }

        private long? _storeSaleID;
        [Field("361A2BA9-F764-45A3-AF7F-1C678C489549")]
        public long? StoreSaleID
        {
            get { CheckGet(); return _storeSaleID; }
            set { CheckSet(); _storeSaleID = value; }
        }

        private long? _locationItemID;
        [Field("A2614A69-909C-48A9-BCAF-9B2F86CA4C4E")]
        [Required]
        public long? LocationItemID
        {
            get { CheckGet(); return _locationItemID; }
            set { CheckSet(); _locationItemID = value; }
        }

        private LocationItem _locationItem;
        [Relationship("894B85EE-F1FE-44F9-A499-C27DB0F1CC9A")]
        public LocationItem LocationItem
        {
            get { CheckGet(); return _locationItem; }
        }

        private long? _registerID;
        [Field("62AD009F-7C9D-4B4B-854D-0F6D9913261C")]
        [Required]
        public long? RegisterID
        {
            get { CheckGet(); return _registerID; }
            set { CheckSet(); _registerID = value; }
        }

        private Register _register = null;
        [Relationship("4F7F96FA-5219-4917-9028-A4F1600B8269")]
        public Register Register
        {
            get { CheckGet(); return _register; }
        }

        private decimal? _ringPrice;
        [Field("213AE82A-9C9E-47A2-990A-4E53359056EA", DataSize = 9, DataScale = 2)]
        [Required]
        public decimal? RingPrice
        {
            get { CheckGet(); return _ringPrice; }
            set { CheckSet(); _ringPrice = value; }
        }

        private decimal? _soldPrice;
        [Field("C7512844-2765-4A70-AC71-ABBEE9990DD8", DataSize = 9, DataScale = 2)]
        public decimal? SoldPrice
        {
            get { CheckGet(); return _soldPrice; }
            set { CheckSet(); _soldPrice = value; }
        }

        private string _discountReason;
        [Field("10CD78A7-8999-4811-99C5-E587C6479BBC", DataSize = 100)]
        public string DiscountReason
        {
            get { CheckGet(); return _discountReason; }
            set { CheckSet(); _discountReason = value; }
        }
    }
}
