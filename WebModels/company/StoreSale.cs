using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Validation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebModels.company
{
    [Table("C5D1C4D1-B01E-43DD-94C6-DF38D1CBF208")]
    public class StoreSale : DataObject
    {
        protected StoreSale() : base() { }

        private long? _storeSaleID;
        [Field("BEBB36B7-2298-4491-93B6-B480B8618BEE")]
        public long? StoreSaleID
        {
            get { CheckGet(); return _storeSaleID; }
            set { CheckSet(); _storeSaleID = value; }
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

        private DateTime? _saleTime;
        [Field("82A73C60-9E6E-4749-975D-FA98E80EFFBF", DataSize = 7)]
        public DateTime? SaleTime
        {
            get { CheckGet(); return _saleTime; }
            set { CheckSet(); _saleTime = value; }
        }

        #region Relationships
        #region company
        private List<StoreSaleItem> _storeSaleItems = new List<StoreSaleItem>();
        [RelationshipList("8190A96E-D58A-4A5E-8A62-F3520CA6999C", nameof(StoreSaleItem.StoreSaleID))]
        public IReadOnlyCollection<StoreSaleItem> StoreSaleItems
        {
            get { CheckGet(); return _storeSaleItems; }
        }
        #endregion
        #endregion
    }
}
