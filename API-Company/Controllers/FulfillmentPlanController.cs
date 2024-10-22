﻿using API.Common;
using API.Common.Attributes;
using API_Company.Attributes;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Schema;
using ClussPro.ObjectBasedFramework.Utility;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using WebModels.company;
using WebModels.purchasing;

namespace API_Company.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess("company")]
    [LocationAccess(RequiredPermissions = new[] { nameof(LocationEmployee.ManagePurchaseOrders) })]
    public class FulfillmentPlanController : DataObjectController<FulfillmentPlan>
    {
        public override IEnumerable<string> DefaultRetrievedFields => Schema.GetSchemaObject<FulfillmentPlan>().GetFields().Select(f => f.FieldName)
                                                                        .Concat(Schema.GetSchemaObject<FulfillmentPlanRoute>().GetFields().Select(f => $"{nameof(FulfillmentPlan.FulfillmentPlanRoutes)}.{f.FieldName}"))
                                                                        .Concat(FieldPathUtility.CreateFieldPathsAsList<FulfillmentPlan>(fp => new List<object>()
                                                                        {
                                                                            fp.Railcar.RailcarID,
                                                                            fp.Railcar.ReportingMark,
                                                                            fp.Railcar.ReportingNumber,
                                                                            fp.LeaseRequest.LeaseRequestID,
                                                                            fp.LeaseRequest.LeaseBids.First().LeaseBidID,
                                                                            fp.FulfillmentPlanPurchaseOrderLines.First().FulfillmentPlanID,
                                                                            fp.FulfillmentPlanPurchaseOrderLines.First().PurchaseOrderLineID,
                                                                            fp.FulfillmentPlanPurchaseOrderLines.First().PurchaseOrderLine.ItemID,
                                                                            fp.FulfillmentPlanPurchaseOrderLines.First().PurchaseOrderLine.Item.Name,
                                                                            fp.FulfillmentPlanPurchaseOrderLines.First().PurchaseOrderLine.Quantity,
                                                                            fp.FulfillmentPlanPurchaseOrderLines.First().PurchaseOrderLine.ItemDescription,
                                                                            fp.FulfillmentPlanPurchaseOrderLines.First().PurchaseOrderLine.IsService,
                                                                            fp.FulfillmentPlanPurchaseOrderLines.First().PurchaseOrderLine.ServiceDescription,
                                                                            fp.TrackLoading.Name,
                                                                            fp.TrackDestination.Name,
                                                                            fp.TrackStrategicAfterDestination.Name,
                                                                            fp.TrackStrategicAfterLoad.Name,
                                                                            fp.TrackPostFulfillment.Name,
                                                                            fp.FulfillmentPlanRoutes.First().SortOrder,
                                                                            fp.FulfillmentPlanRoutes.First().CompanyFrom.Name,
                                                                            fp.FulfillmentPlanRoutes.First().CompanyTo.Name,
                                                                            fp.FulfillmentPlanRoutes.First().GovernmentFrom.Name,
                                                                            fp.FulfillmentPlanRoutes.First().GovernmentTo.Name
                                                                        }));

        public override ISearchCondition GetBaseSearchCondition()
        {
            return new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.Or,
                new ExistsSearchCondition<FulfillmentPlan>()
                {
                    RelationshipName = nameof(FulfillmentPlan.FulfillmentPlanPurchaseOrderLines),
                    ExistsType = ExistsSearchCondition<FulfillmentPlan>.ExistsTypes.NotExists
                },
                new ExistsSearchCondition<FulfillmentPlan>()
                {
                    RelationshipName = nameof(FulfillmentPlan.FulfillmentPlanPurchaseOrderLines),
                    ExistsType = ExistsSearchCondition<FulfillmentPlan>.ExistsTypes.Exists,
                    Condition = new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.Or,
                        new ExistsSearchCondition<FulfillmentPlanPurchaseOrderLine>()
                        {
                            RelationshipName = FieldPathUtility.CreateFieldPathsAsList<FulfillmentPlanPurchaseOrderLine>(fppol => new List<object>() { fppol.PurchaseOrderLine.PurchaseOrder.LocationOrigin.LocationEmployees }).First(),
                            ExistsType = ExistsSearchCondition<FulfillmentPlanPurchaseOrderLine>.ExistsTypes.Exists,
                            Condition = new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                                new LongSearchCondition<LocationEmployee>()
                                {
                                    Field = FieldPathUtility.CreateFieldPathsAsList<LocationEmployee>(lp => new List<object>() { lp.Employee.UserID }).First(),
                                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                                    Value = SecurityProfile.UserID
                                },
                                new BooleanSearchCondition<LocationEmployee>()
                                {
                                    Field = nameof(LocationEmployee.ManagePurchaseOrders),
                                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                                    Value = true
                                })
                        },
                        new ExistsSearchCondition<FulfillmentPlanPurchaseOrderLine>()
                        {
                            RelationshipName = FieldPathUtility.CreateFieldPathsAsList<FulfillmentPlanPurchaseOrderLine>(fppol => new List<object>() { fppol.PurchaseOrderLine.PurchaseOrder.LocationDestination.LocationEmployees }).First(),
                            ExistsType = ExistsSearchCondition<FulfillmentPlanPurchaseOrderLine>.ExistsTypes.Exists,
                            Condition = new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                                new LongSearchCondition<LocationEmployee>()
                                {
                                    Field = FieldPathUtility.CreateFieldPathsAsList<LocationEmployee>(lp => new List<object>() { lp.Employee.UserID }).First(),
                                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                                    Value = SecurityProfile.UserID
                                },
                                new BooleanSearchCondition<LocationEmployee>()
                                {
                                    Field = nameof(LocationEmployee.ManagePurchaseOrders),
                                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                                    Value = true
                                })
                        })
                    });
        }

        [HttpGet]
        public async Task<List<FulfillmentPlan>> GetByPurchaseOrderID(long? id)
        {
            Search<FulfillmentPlan> fulfillmentPlanSearch = new Search<FulfillmentPlan>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new ExistsSearchCondition<FulfillmentPlan>()
                {
                    RelationshipName = nameof(FulfillmentPlan.FulfillmentPlanPurchaseOrderLines),
                    ExistsType = ExistsSearchCondition<FulfillmentPlan>.ExistsTypes.Exists,
                    Condition = new LongSearchCondition<FulfillmentPlanPurchaseOrderLine>()
                    {
                        Field = FieldPathUtility.CreateFieldPathsAsList<FulfillmentPlanPurchaseOrderLine>(fppol => new List<object>() { fppol.PurchaseOrderLine.PurchaseOrderID }).First(),
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = id
                    }
                },
                GetBaseSearchCondition()));

            return fulfillmentPlanSearch.GetReadOnlyReader(null, await FieldsToRetrieve()).ToList();
        }

        [HttpGet]
        public async Task<FulfillmentPlan> GetByRailcar(long? id)
        {
            Search<FulfillmentPlan> fulfillmentPlanSearch = new Search<FulfillmentPlan>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new ExistsSearchCondition<FulfillmentPlan>()
                {
                    RelationshipName = nameof(FulfillmentPlan.FulfillmentPlanPurchaseOrderLines),
                    ExistsType = ExistsSearchCondition<FulfillmentPlan>.ExistsTypes.Exists,
                    Condition = new LongSearchCondition<FulfillmentPlanPurchaseOrderLine>()
                    {
                        Field = FieldPathUtility.CreateFieldPathsAsList<FulfillmentPlanPurchaseOrderLine>(fppol => new List<object>() { fppol.PurchaseOrderLine.RemainingQuantity }).First(),
                        SearchConditionType = SearchCondition.SearchConditionTypes.Greater,
                        Value = 0
                    }
                },
                new LongSearchCondition<FulfillmentPlan>()
                {
                    Field = nameof(FulfillmentPlan.RailcarID),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = id
                }));

            return fulfillmentPlanSearch.GetReadOnly(null, await FieldsToRetrieve());
        }
    }
}