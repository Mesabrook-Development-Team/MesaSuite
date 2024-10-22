using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using WebModels.company;
using WebModels.mesasys;

namespace API_Company.Controllers
{
    public class PriceCheckController : ApiController
    {
        [HttpGet]
        public List<Location> GetLocations()
        {
            Search<Location> locationSearch = new Search<Location>(new ExistsSearchCondition<Location>()
            {
                RelationshipName = nameof(Location.LocationItems),
                ExistsType = ExistsSearchCondition<Location>.ExistsTypes.Exists
            });

            return locationSearch.GetReadOnlyReader(null, FieldPathUtility.CreateFieldPathsAsList<Location>(l => new List<object>()
            {
                l.LocationID,
                l.Name,
                l.Company.Name
            })).ToList();
        }

        [HttpGet]
        public List<LocationItem> GetItems([FromUri]long? locationID)
        {
            Search<LocationItem> locationItemSearch = new Search<LocationItem>(new LongSearchCondition<LocationItem>()
            {
                Field = nameof(LocationItem.LocationID),
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = locationID
            });

            return locationItemSearch.GetReadOnlyReader(null, FieldPathUtility.CreateFieldPathsAsList<LocationItem>(l => new List<object>()
            {
                l.LocationItemID,
                l.Item.Name,
                l.Item.ItemNamespace.Namespace,
                l.Item.IsFluid,
                l.BasePrice,
                l.Quantity,
                l.CurrentPromotionLocationItem.PromotionPrice
            })).ToList();
        }

        [HttpGet]
        public LocationItem GetItem([FromUri] long? locationID, [FromUri]string itemName, [FromUri]short? quantity)
        {
            Search<LocationItem> locationItemSearch = new Search<LocationItem>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new StringSearchCondition<LocationItem>()
                {
                    Field = $"{nameof(LocationItem.Item)}.{nameof(Item.Name)}",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = itemName
                },
                new LongSearchCondition<LocationItem>()
                {
                    Field = nameof(LocationItem.LocationID),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = locationID
                },
                new ShortSearchCondition<LocationItem>()
                {
                    Field = nameof(LocationItem.Quantity),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = quantity
                }));

            return locationItemSearch.GetReadOnly(null, FieldPathUtility.CreateFieldPathsAsList<LocationItem>(l => new List<object>()
            {
                l.LocationItemID,
                l.Item.Name,
                l.Item.ItemNamespace.Namespace,
                l.Item.IsFluid,
                l.BasePrice,
                l.Quantity,
                l.CurrentPromotionLocationItem.PromotionPrice
            }));
        }

        [HttpGet]
        public LocationItem GetItem([FromUri]long? locationID, [FromUri]long? itemID, [FromUri]short? quantity)
        {
            Search<LocationItem> locationItemSearch = new Search<LocationItem>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new LongSearchCondition<LocationItem>()
                {
                    Field = nameof(LocationItem.ItemID),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = itemID
                },
                new LongSearchCondition<LocationItem>()
                {
                    Field = nameof(LocationItem.LocationID),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = locationID
                },
                new ShortSearchCondition<LocationItem>()
                {
                    Field = nameof(LocationItem.Quantity),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = quantity
                }));

            return locationItemSearch.GetReadOnly(null, FieldPathUtility.CreateFieldPathsAsList<LocationItem>(l => new List<object>()
            {
                l.LocationItemID,
                l.Item.Name,
                l.Item.ItemNamespace.Namespace,
                l.Item.IsFluid,
                l.BasePrice,
                l.Quantity,
                l.CurrentPromotionLocationItem.PromotionPrice
            }));
        }

        [HttpGet]
        public List<LocationItem> FindItem([FromUri] string itemName, [FromUri] short? quantity)
        {
            SearchConditionGroup searchCondition = new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new StringSearchCondition<LocationItem>()
                {
                    Field = $"{nameof(LocationItem.Item)}.{nameof(Item.Name)}",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = itemName
                });

            if (quantity != null)
            {
                searchCondition.SearchConditions.Add(new ShortSearchCondition<LocationItem>()
                {
                    Field = nameof(LocationItem.Quantity),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = quantity
                });
            }

            Search<LocationItem> locationItemSearch = new Search<LocationItem>(searchCondition);
            return locationItemSearch.GetReadOnlyReader(null, FieldPathUtility.CreateFieldPathsAsList<LocationItem>(l => new List<object>()
            {
                l.LocationItemID,
                l.Item.Name,
                l.Item.ItemNamespace.Namespace,
                l.Item.IsFluid,
                l.BasePrice,
                l.Quantity,
                l.CurrentPromotionLocationItem.PromotionPrice
            })).ToList();
        }
    }
}
