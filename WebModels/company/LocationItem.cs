using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClussPro.Base.Data;
using ClussPro.Base.Data.Conditions;
using ClussPro.Base.Data.Operand;
using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema;
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

        private PromotionLocationItem _currentPromotionLocationItem = null;
        [Relationship("63123D3C-4FC2-4EFB-B8F0-0F79181F4572", HasForeignKey = false)]
        public PromotionLocationItem CurrentPromotionLocationItem
        {
            get { CheckGet(); return _currentPromotionLocationItem; }
        }

        public override ICondition GetRelationshipCondition(Relationship relationship, string myAlias, string otherAlias)
        {
            switch(relationship.RelationshipName)
            {
                case nameof(CurrentPromotionLocationItem):
                    return CurrentPromotionLocationItemRelationshipCondition(myAlias, otherAlias);
                default:
                    return base.GetRelationshipCondition(relationship, myAlias, otherAlias);
            }
        }

        private ICondition CurrentPromotionLocationItemRelationshipCondition(string myAlias, string otherAlias)
        {
            ISelectQuery promotionLocationItemQuery = SQLProviderFactory.GetSelectQuery();
            promotionLocationItemQuery.SelectList = new List<Select>() { new Select() { SelectOperand = (ClussPro.Base.Data.Operand.Field)nameof(PromotionLocationItem.PromotionLocationItemID) } };
            promotionLocationItemQuery.Table = new Table("company", "PromotionLocationItem", "currentPLI");
            promotionLocationItemQuery.JoinList = new List<Join>()
            {
                new Join()
                {
                    JoinType = Join.JoinTypes.Inner,
                    Table = new Table("company", "Promotion", "currentP"),
                    Condition = new Condition()
                    {
                        Left = (ClussPro.Base.Data.Operand.Field)$"currentP.{nameof(Promotion.PromotionID)}",
                        ConditionType = Condition.ConditionTypes.Equal,
                        Right = (ClussPro.Base.Data.Operand.Field)$"currentPLI.{nameof(PromotionLocationItem.PromotionID)}"
                    }
                }
            };
            promotionLocationItemQuery.WhereCondition = new ConditionGroup()
            {
                ConditionGroupType = ConditionGroup.ConditionGroupTypes.And,
                Conditions = new List<ICondition>()
                {
                    new Condition()
                    {
                        Left = (ClussPro.Base.Data.Operand.Field)$"currentPLI.{nameof(PromotionLocationItem.LocationItemID)}",
                        ConditionType = Condition.ConditionTypes.Equal,
                        Right = (ClussPro.Base.Data.Operand.Field)$"{myAlias}.{nameof(LocationItemID)}"
                    },
                    new Condition()
                    {
                        Left = (ClussPro.Base.Data.Operand.Field)$"currentP.{nameof(Promotion.StartTime)}",
                        ConditionType = Condition.ConditionTypes.LessEqual,
                        Right = new Literal(DateTime.Now)
                    },
                    new Condition()
                    {
                        Left = (ClussPro.Base.Data.Operand.Field)$"currentP.{nameof(Promotion.EndTime)}",
                        ConditionType = Condition.ConditionTypes.GreaterEqual,
                        Right = new Literal(DateTime.Now)
                    }
                }
            };
            promotionLocationItemQuery.OrderByList = new List<Order>()
            {
                new Order()
                {
                    Field = (ClussPro.Base.Data.Operand.Field)$"currentP.{nameof(Promotion.StartTime)}",
                    OrderDirection = Order.OrderDirections.Descending
                }
            };
            promotionLocationItemQuery.PageSize = 1;

            return new Condition()
            {
                Left = (ClussPro.Base.Data.Operand.Field)$"{otherAlias}.{nameof(PromotionLocationItem.PromotionLocationItemID)}",
                ConditionType = Condition.ConditionTypes.Equal,
                Right = new SubQuery(promotionLocationItemQuery)
            };
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
