using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Validation.Attributes;
using WebModels.mesasys;

namespace WebModels.company
{
    [Table("E97C6315-06D2-462D-A9F2-FB2971047221")]
    [Unique(new[] { nameof(LocationID), nameof(ItemID), nameof(Quantity) })]
    public class LocationItem : DataObject
    {
        protected LocationItem() : base() { }

        private long? _locationItemID;
        [Field("970E72FC-53CB-481B-B53D-989B78C7C7D7")]
        public long? LocationItemID
        {
            get { CheckGet(); return _locationItemID; }
            set { CheckSet(); _locationItemID = value; }
        }

        private long? _locationID;
        [Field("5F523791-7A97-48C3-B06B-893AB4C748A7")]
        [Required]
        public long? LocationID
        {
            get { CheckGet(); return _locationID; }
            set { CheckSet(); _locationID = value; }
        }

        private Location _location = null;
        [Relationship("3F0496E7-B27F-4F72-AF9F-CCB35622BBFA")]
        public Location Location
        {
            get { CheckGet(); return _location; }
        }

        private long? _itemID;
        [Field("6036A1BD-C039-47EE-A8FD-F9F4797E5CE4")]
        [Required]
        public long? ItemID
        {
            get { CheckGet(); return _itemID; }
            set { CheckSet(); _itemID = value; }
        }

        private Item _item = null;
        [Relationship("1766ED1F-5D49-4073-8A13-9AFE9807CBD2")]
        public Item Item
        {
            get { CheckGet(); return _item; }
        }

        private short? _quantity;
        [Field("9425016B-54DB-495C-8078-A43484FFE39C")]
        [Required]
        public short? Quantity
        {
            get { CheckGet(); return _quantity; }
            set { CheckSet(); _quantity = value; }
        }

        private decimal? _basePrice;
        [Field("36956505-BA15-4EDF-850A-1A179933EE3E", DataSize = 9, DataScale = 2)]
        [Required]
        public decimal? BasePrice
        {
            get { CheckGet(); return _basePrice; }
            set { CheckSet(); _basePrice = value; }
        }

        #region Relationships
        #region company
        private List<StoreSaleItem> _storeSales = new List<StoreSaleItem>();
        [RelationshipList("EB7FD6EA-69A8-4CBC-8D1B-36A92F97991C", nameof(StoreSaleItem.LocationItemID), AutoRemoveReferences = true)]
        public IReadOnlyCollection<StoreSaleItem> StoreSales
        {
            get { CheckGet(); return _storeSales; }
        }

        private List<PromotionLocationItem> _promotionLocationItems = new List<PromotionLocationItem>();
        [RelationshipList("44428622-5CF6-47A0-804F-89871CD57952", nameof(PromotionLocationItem.LocationItemID), AutoRemoveReferences = true)]
        public IReadOnlyCollection<PromotionLocationItem> PromotionLocationItems
        {
            get { CheckGet(); return _promotionLocationItems; }
        }
        #endregion
        #endregion
    }
}
