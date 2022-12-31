using API.Common.Attributes;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebModels.mesasys;

namespace API_Government.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess("gov")]
    public class ItemController : ApiController
    {
        private static readonly List<string> FieldsToRetrieve = FieldPathUtility.CreateFieldPathsAsList<Item>(i => new List<object>()
        {
            i.ItemID,
            i.ItemNamespaceID,
            i.ItemNamespace.ItemNamespaceID,
            i.ItemNamespace.Namespace,
            i.ItemNamespace.FriendlyName,
            i.Name,
            i.Image
        });

        [HttpGet]
        public Item Get(long? id)
        {
            return DataObject.GetReadOnlyByPrimaryKey<Item>(id, null, FieldsToRetrieve);
        }

        [HttpGet]
        public List<Item> GetByQuery([FromUri]string q = "", [FromUri]int t = 50)
        {
            Search<Item> itemSearch = new Search<Item>();
            itemSearch.Take = t;
            itemSearch.SearchOrders = new List<SearchOrder>()
            {
                new SearchOrder()
                {
                    OrderField = nameof(Item.Name)
                }
            };

            if (!string.IsNullOrWhiteSpace(q))
            {
                itemSearch.SearchCondition = new StringSearchCondition<Item>()
                {
                    Field = nameof(Item.Name),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Like,
                    Value = $"%{q}%"
                };
            }

            return itemSearch.GetReadOnlyReader(null, FieldsToRetrieve).ToList();
        }
    }
}