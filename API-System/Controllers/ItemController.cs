using API.Common;
using API.Common.Attributes;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WebModels.mesasys;

namespace API_System.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess("system")]
    public class ItemController : DataObjectController<Item>
    {
        public override IEnumerable<string> DefaultRetrievedFields => FieldPathUtility.CreateFieldPathsAsList<Item>(i => new List<object>()
        {
            i.ItemID,
            i.ItemNamespaceID,
            i.ItemNamespace.ItemNamespaceID,
            i.ItemNamespace.Namespace,
            i.ItemNamespace.FriendlyName,
            i.Name,
            i.Image,
            i.Hash
        });

        public override bool AllowGetAll => true;

        [HttpGet]
        public async Task<List<Item>> GetByQuery([FromUri]int t = 50, [FromUri]List<long> ins = null, [FromUri]string q = "")
        {
            Search<Item> itemSearch = new Search<Item>();
            itemSearch.Take = t;

            SearchConditionGroup conditionGroup = new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And);

            if (ins != null && ins.Count > 0)
            {
                conditionGroup.SearchConditions.Add(new LongSearchCondition<Item>()
                {
                    Field = nameof(Item.ItemNamespaceID),
                    SearchConditionType = SearchCondition.SearchConditionTypes.List,
                    List = ins
                });
            }

            if (!string.IsNullOrWhiteSpace(q))
            {
                conditionGroup.SearchConditions.Add(new StringSearchCondition<Item>()
                {
                    Field = nameof(Item.Name),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Like,
                    Value = $"%{q}%"
                });
            }

            itemSearch.SearchCondition = conditionGroup;
            itemSearch.SearchOrders.Add(new SearchOrder()
            {
                OrderField = nameof(Item.Name)
            });

            return itemSearch.GetReadOnlyReader(null, await FieldsToRetrieve()).ToList();
        }
    }
}