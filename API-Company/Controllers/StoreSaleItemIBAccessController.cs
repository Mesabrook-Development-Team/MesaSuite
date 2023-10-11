using API.Common.Attributes;
using API.Common.Extensions;
using API_Company.App_Code;
using API_Company.Attributes;
using ClussPro.Base.Data;
using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using WebModels.account;
using WebModels.company;

namespace API_Company.Controllers
{
    [MesabrookAuthorization]
    [ImmersibrookAccess]
    [RegisterAccess]
    public class StoreSaleItemIBAccessController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Post(StoreItem[] items)
        {
            RegisterCache.CachedRegister cachedRegister = (RegisterCache.CachedRegister)Request.Properties["CachedRegister"];
            if (cachedRegister == null)
            {
                return new StatusCodeResult(System.Net.HttpStatusCode.Forbidden, this);
            }

            Location location = DataObject.GetReadOnlyByPrimaryKey<Location>(cachedRegister.LocationID, null, FieldPathUtility.CreateFieldPathsAsList<Location>(l => new List<object>()
            {
                l.Name,
                l.Company.Name,
                l.AccountIDStoreRevenue,
                l.LocationGovernments.First().Government.EffectiveSalesTax.Rate,
                l.LocationGovernments.First().Government.EffectiveSalesTax.AccountID
            }));

            if (location?.AccountIDStoreRevenue == null)
            {
                return new BadRequestErrorMessageResult("Store Location Accounting not set up", this);
            }

            StoreSale sale = null;
            using (ITransaction transaction = SQLProviderFactory.GenerateTransaction())
            {
                sale = DataObjectFactory.Create<StoreSale>();
                sale.RegisterID = cachedRegister.RegisterID;
                sale.SaleTime = DateTime.Now;
                
                if (!sale.Save(transaction))
                {
                    return sale.HandleFailedValidation(this);
                }

                decimal totalRevenue = 0;
                Dictionary<string, LocationItem> locationItemsByNameQuantity = new Dictionary<string, LocationItem>();
                foreach(StoreItem storeItem in items)
                {
                    string locationItemLookupKey = string.Format("{0}-{1}", storeItem.Name, storeItem.Amount);
                    if (!locationItemsByNameQuantity.ContainsKey(locationItemLookupKey))
                    {
                        Search<LocationItem> locationItemSearch = new Search<LocationItem>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                            new LongSearchCondition<LocationItem>()
                            {
                                Field = nameof(LocationItem.LocationID),
                                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                                Value = cachedRegister.LocationID
                            },
                            new StringSearchCondition<LocationItem>()
                            {
                                Field = $"{nameof(LocationItem.Item)}.{nameof(WebModels.mesasys.Item.Name)}",
                                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                                Value = storeItem.Name
                            },
                            new IntSearchCondition<LocationItem>()
                            {
                                Field = nameof(LocationItem.Quantity),
                                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                                Value = storeItem.Amount
                            }));

                        LocationItem item = locationItemSearch.GetReadOnly(null, new[] 
                        {
                            nameof(LocationItem.LocationItemID),
                            nameof(LocationItem.BasePrice)
                        });

                        if (item == null)
                        {
                            continue;
                        }

                        locationItemsByNameQuantity.Add(locationItemLookupKey, item);
                    }

                    LocationItem locationItem = locationItemsByNameQuantity[locationItemLookupKey];

                    StoreSaleItem saleItem = DataObjectFactory.Create<StoreSaleItem>();
                    saleItem.StoreSaleID = sale.StoreSaleID;
                    saleItem.LocationItemID = locationItem.LocationItemID;
                    saleItem.RingPrice = locationItem.BasePrice;
                    saleItem.SoldPrice = storeItem.SaleAmount;
                    if (!saleItem.Save(transaction))
                    {
                        return saleItem.HandleFailedValidation(this);
                    }

                    totalRevenue += storeItem.SaleAmount;
                }

                Account revenueAccount = DataObject.GetEditableByPrimaryKey<Account>(location.AccountIDStoreRevenue, transaction, new string[0]);
                if (!revenueAccount.Deposit(totalRevenue, string.Format(Transaction.DescriptionFormats.STORE_SALE, cachedRegister.Name), transaction))
                {
                    return revenueAccount.HandleFailedValidation(this);
                }

                foreach(LocationGovernment locationGovernment in location.LocationGovernments)
                {
                    if (locationGovernment.Government?.EffectiveSalesTax?.AccountID == null ||
                        locationGovernment.Government?.EffectiveSalesTax?.Rate == null)
                    {
                        continue;
                    }

                    decimal taxDeposit = Math.Round((locationGovernment.Government.EffectiveSalesTax.Rate.Value / 100M) * totalRevenue, 2, MidpointRounding.AwayFromZero);
                    Account salesTaxAccount = Account.GetEditableByPrimaryKey<Account>(locationGovernment.Government.EffectiveSalesTax.AccountID, transaction, new string[0]);
                    if (!salesTaxAccount.Deposit(taxDeposit, string.Format(Transaction.DescriptionFormats.TAX_COLLECTED_STORE, $"{location.Company?.Name} ({location.Name})"), transaction))
                    {
                        return salesTaxAccount.HandleFailedValidation(this);
                    }
                }

                transaction.Commit();
            }

            return Created($"StoreSaleID/Get/{sale.StoreSaleID}", sale);
        }

        public class StoreItem
        {
            public string Name { get; set; }
            public int Amount { get; set; }
            public decimal SaleAmount { get; set; }
        }
    }
}
