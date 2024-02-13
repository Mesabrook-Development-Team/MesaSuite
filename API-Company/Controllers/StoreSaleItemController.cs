using API.Common.Attributes;
using API_Company.Attributes;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using WebModels.company;

namespace API_Company.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess("company")]
    [LocationAccess(RequiredPermissions = new[] { nameof(LocationEmployee.ManagePrices) })]
    public class StoreSaleItemController : ApiController
    {
        private readonly List<string> fields = FieldPathUtility.CreateFieldPathsAsList<StoreSaleItem>(ssi => new List<object>()
        {
            ssi.StoreSaleItemID,
            ssi.RingPrice,
            ssi.SoldPrice,
            ssi.DiscountReason,
            ssi.StoreSaleID,
            ssi.LocationItemID,
            ssi.LocationItem.Quantity,
            ssi.LocationItem.BasePrice,
            ssi.LocationItem.ItemID,
            ssi.LocationItem.Item.ItemID,
            ssi.LocationItem.Item.Name,
            ssi.LocationItem.Item.IsFluid,
            ssi.StoreSale.StoreSaleID,
            ssi.StoreSale.RegisterID,
            ssi.StoreSale.Register.Name,
            ssi.StoreSale.Register.Location.Name,
            ssi.StoreSale.Register.Location.Company.Name,
            ssi.StoreSale.SaleTime
        });

        [HttpGet]
        public List<StoreSaleItem> Get()
        {
            IEnumerable<KeyValuePair<string, string>> queryValuePairs = Request.GetQueryNameValuePairs();
            Search<StoreSaleItem> storeSaleSearch = new Search<StoreSaleItem>();
            SearchConditionGroup searchCondition = new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And);

            List<long> registerIDs = new List<long>();
            foreach(KeyValuePair<string, string> kvp in queryValuePairs.Where(k => k.Key.Equals("registerid", StringComparison.OrdinalIgnoreCase)))
            {
                if (!long.TryParse(kvp.Value, out long registerID))
                {
                    continue;
                }

                registerIDs.Add(registerID);
            }

            if (registerIDs.Any())
            {
                searchCondition.SearchConditions.Add(new LongSearchCondition<StoreSaleItem>()
                {
                    Field = nameof(StoreSaleItem.StoreSale) + "." + nameof(StoreSale.RegisterID),
                    SearchConditionType = SearchCondition.SearchConditionTypes.List,
                    List = registerIDs
                });
            }

            List<long> itemIDs = new List<long>();
            foreach(KeyValuePair<string, string> kvp in queryValuePairs.Where(k => k.Key.Equals("itemid", StringComparison.OrdinalIgnoreCase)))
            {
                if (!long.TryParse(kvp.Value, out long itemID))
                {
                    continue;
                }

                itemIDs.Add(itemID);
            }

            if (itemIDs.Any())
            {
                searchCondition.SearchConditions.Add(new LongSearchCondition<StoreSaleItem>()
                {
                    Field = nameof(StoreSaleItem.LocationItem) + "." + nameof(LocationItem.ItemID),
                    SearchConditionType = SearchCondition.SearchConditionTypes.List,
                    List = itemIDs
                });
            }

            string startDate = queryValuePairs.Where(kvp => kvp.Key.Equals("startdate", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Value;
            string endDate = queryValuePairs.Where(kvp => kvp.Key.Equals("enddate", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Value;
            if (!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate) && long.TryParse(startDate, out long startTicks) && long.TryParse(endDate, out long endTicks))
            {
                DateTime start = new DateTime(startTicks);
                DateTime end = new DateTime(endTicks);

                searchCondition.SearchConditions.Add(new DateTimeSearchCondition<StoreSaleItem>()
                {
                    Field = nameof(StoreSaleItem.StoreSale) + "." + nameof(StoreSale.SaleTime),
                    SearchConditionType = SearchCondition.SearchConditionTypes.GreaterEquals,
                    Value = start.Date
                });

                searchCondition.SearchConditions.Add(new DateTimeSearchCondition<StoreSaleItem>()
                {
                    Field = nameof(StoreSaleItem.StoreSale) + "." + nameof(StoreSale.SaleTime),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Less,
                    Value = end.Date.AddDays(1).AddSeconds(-1)
                });
            }

            storeSaleSearch.SearchCondition = searchCondition;
            return storeSaleSearch.GetReadOnlyReader(null, fields).ToList();
        }
    }
}
