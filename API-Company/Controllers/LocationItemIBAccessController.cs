﻿using API.Common.Attributes;
using API_Company.Attributes;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Utility;
using System.Collections.Generic;
using System.Web.Http;
using WebModels.company;
using WebModels.mesasys;

namespace API_Company.Controllers
{
    [MesabrookAuthorization]
    [ImmersibrookAccess]
    public class LocationItemIBAccessController : ApiController
    {
        private static readonly List<string> FIELDS = FieldPathUtility.CreateFieldPathsAsList<LocationItem>(li => new List<object>()
        {
            li.LocationItemID,
            li.LocationID,
            li.ItemID,
            li.Quantity,
            li.BasePrice,
            li.Item.ItemID,
            li.Item.Name,
            li.Item.IsFluid,
            li.CurrentPromotionLocationItem.PromotionLocationItemID,
            li.CurrentPromotionLocationItem.PromotionPrice
        });

        [HttpGet]
        public IHttpActionResult Get(long? locationID, string name, short? quantity)
        {
            if (locationID == null || string.IsNullOrEmpty(name) || quantity == null)
            {
                return BadRequest();
            }

            Item itemLookup = new Search<Item>(new StringSearchCondition<Item>()
            {
                Field = nameof(Item.Name),
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = name
            }).GetReadOnly(null, new[] { nameof(Item.IsFluid) });

            SearchConditionGroup searchConditionGroup = new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new LongSearchCondition<LocationItem>()
                {
                    Field = nameof(LocationItem.LocationID),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = locationID
                },
                new StringSearchCondition<LocationItem>()
                {
                    Field = $"{nameof(LocationItem.Item)}.{nameof(Item.Name)}",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = name
                });

            if (!(itemLookup?.IsFluid ?? false))
            {
                searchConditionGroup.SearchConditions.Add(
                new ShortSearchCondition<LocationItem>()
                {
                    Field = nameof(LocationItem.Quantity),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = quantity
                });
            }

            Search<LocationItem> locationItemSearch = new Search<LocationItem>(searchConditionGroup);

            LocationItem item = locationItemSearch.GetReadOnly(null, FIELDS);
            return item == null ? (IHttpActionResult)NotFound() : Ok(item);
        }
    }
}