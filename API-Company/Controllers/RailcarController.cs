﻿using API.Common.Attributes;
using API.Common.Extensions;
using API_Company.Attributes;
using ClussPro.Base.Data;
using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using WebModels.company;
using WebModels.fleet;
using WebModels.purchasing;

namespace API_Company.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess("company")]
    [LocationAccess(RequiredPermissions = new[] { nameof(LocationEmployee.ManagePurchaseOrders) })]
    public class RailcarController : ApiController
    {
        protected long? CompanyID => long.Parse(Request.Headers.GetValues("CompanyID").First());
        protected long? LocationID => long.Parse(Request.Headers.GetValues("LocationID").First());

        private static readonly List<string> fields = FieldPathUtility.CreateFieldPathsAsList<Railcar>(r => new List<object>()
        {
            r.RailcarID,
            r.ReportingMark,
            r.ReportingNumber,
            r.RailLocation.TrackID,
            r.RailLocation.Track.TrackID,
            r.RailLocation.Track.Name,
            r.RailLocation.TrainID,
            r.RailLocation.Train.TimeOnDuty,
            r.RailLocation.Train.TrainSymbol.Name,
            r.RailLocation.Position,
            r.TrackIDDestination,
            r.TrackDestination.TrackID,
            r.TrackDestination.CompanyIDOwner,
            r.TrackDestination.Name,
            r.CompanyIDOwner,
            r.CompanyOwner.Name,
            r.GovernmentIDOwner,
            r.GovernmentOwner.Name,
            r.CompanyPossessor.Name,
            r.GovernmentPossessor.Name,
            r.CompanyLeasedTo.CompanyID,
            r.RailcarModelID,
            r.RailcarModel.Name,
            r.RailcarModel.CargoCapacity,
            r.RailcarLoads.First().RailcarLoadID,
            r.RailcarLoads.First().ItemID,
            r.RailcarLoads.First().Item.ItemID,
            r.RailcarLoads.First().Item.Name,
            r.RailcarLoads.First().Item.Image,
            r.RailcarLoads.First().Quantity,
            r.RailcarLoads.First().PurchaseOrderLineID,
            r.RailcarLoads.First().PurchaseOrderLine.PurchaseOrderLineID,
            r.RailcarLoads.First().PurchaseOrderLine.ItemDescription,
            r.RailcarLoads.First().PurchaseOrderLine.PurchaseOrderID,
            r.RailcarLoads.First().PurchaseOrderLine.ServiceDescription,
            r.RailcarLoads.First().PurchaseOrderLine.IsService,
            r.RailcarLoads.First().PurchaseOrderLine.Quantity,
            r.RailcarLoads.First().PurchaseOrderLine.ItemID,
            r.RailcarLoads.First().PurchaseOrderLine.Item.ItemID,
            r.RailcarLoads.First().PurchaseOrderLine.Item.Name,
            r.RailcarRoutes.First().RailcarRouteID,
            r.RailcarRoutes.First().SortOrder,
            r.RailcarRoutes.First().CompanyIDFrom,
            r.RailcarRoutes.First().CompanyFrom.CompanyID,
            r.RailcarRoutes.First().CompanyFrom.Name,
            r.RailcarRoutes.First().GovernmentIDFrom,
            r.RailcarRoutes.First().GovernmentFrom.GovernmentID,
            r.RailcarRoutes.First().GovernmentFrom.Name,
            r.RailcarRoutes.First().CompanyIDTo,
            r.RailcarRoutes.First().CompanyTo.CompanyID,
            r.RailcarRoutes.First().CompanyTo.Name,
            r.RailcarRoutes.First().GovernmentIDTo,
            r.RailcarRoutes.First().GovernmentTo.GovernmentID,
            r.RailcarRoutes.First().GovernmentTo.Name
        });

        [HttpGet]
        public async Task<List<Railcar>> GetIdleForCompany([FromUri]long? includeCompanyIDShipper = null, [FromUri]long? includeGovernmentIDShipper = null)
        {
            List<ISearchCondition> ownershipConditions = new List<ISearchCondition>()
            {
                new LongSearchCondition<Railcar>()
                {
                    Field = nameof(Railcar.CompanyIDOwner),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = CompanyID
                },
                new LongSearchCondition<Railcar>()
                {
                    Field = FieldPathUtility.CreateFieldPathsAsList<Railcar>(r => new List<object>() { r.CompanyLeasedTo.CompanyID }).First(),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = CompanyID
                }
            };

            if (includeCompanyIDShipper != null)
            {
                ownershipConditions.Add(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                    new LongSearchCondition<Railcar>()
                    {
                        Field = nameof(Railcar.CompanyIDOwner),
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = includeCompanyIDShipper
                    },
                    new LongSearchCondition<Railcar>()
                    {
                        Field = FieldPathUtility.CreateFieldPath<Railcar>(r => r.CompanyLeasedTo.CompanyID),
                        SearchConditionType = SearchCondition.SearchConditionTypes.Null
                    },
                    new LongSearchCondition<Railcar>()
                    {
                        Field = FieldPathUtility.CreateFieldPath<Railcar>(r => r.GovernmentLeasedTo.GovernmentID),
                        SearchConditionType = SearchCondition.SearchConditionTypes.Null
                    }));
            }

            if (includeGovernmentIDShipper != null)
            {
                ownershipConditions.Add(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                    new LongSearchCondition<Railcar>()
                    {
                        Field = nameof(Railcar.GovernmentIDOwner),
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = includeGovernmentIDShipper
                    },
                    new LongSearchCondition<Railcar>()
                    {
                        Field = FieldPathUtility.CreateFieldPath<Railcar>(r => r.CompanyLeasedTo.CompanyID),
                        SearchConditionType = SearchCondition.SearchConditionTypes.Null
                    },
                    new LongSearchCondition<Railcar>()
                    {
                        Field = FieldPathUtility.CreateFieldPath<Railcar>(r => r.GovernmentLeasedTo.GovernmentID),
                        SearchConditionType = SearchCondition.SearchConditionTypes.Null
                    }));
            }

            Search<Railcar> railcarSearch = new Search<Railcar>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.Or, ownershipConditions.ToArray()),
                new ExistsSearchCondition<Railcar>()
                {
                    RelationshipName = nameof(Railcar.FulfillmentPlans),
                    ExistsType = ExistsSearchCondition<Railcar>.ExistsTypes.NotExists,
                    Condition = new ExistsSearchCondition<FulfillmentPlan>()
                    {
                        RelationshipName = nameof(FulfillmentPlan.FulfillmentPlanPurchaseOrderLines),
                        ExistsType = ExistsSearchCondition<FulfillmentPlan>.ExistsTypes.Exists,
                        Condition = new IntSearchCondition<FulfillmentPlanPurchaseOrderLine>()
                        {
                            Field = FieldPathUtility.CreateFieldPath<FulfillmentPlanPurchaseOrderLine>(fppol => fppol.PurchaseOrderLine.PurchaseOrder.Status),
                            SearchConditionType = SearchCondition.SearchConditionTypes.NotEquals,
                            Value = (int)PurchaseOrder.Statuses.Completed
                        }
                    }
                }));

            return await Task.Run(() => railcarSearch.GetReadOnlyReader(null, fields).ToList());
        }

        [HttpGet]
        public async Task<List<Railcar>> GetOnTrack(long? id)
        {
            Search<Railcar> railcarSearch = new Search<Railcar>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new LongSearchCondition<Railcar>()
                {
                    Field = FieldPathUtility.CreateFieldPathsAsList<Railcar>(r => new List<object>() { r.RailLocation.TrackID }).First(),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = id
                },
                new LongSearchCondition<Railcar>()
                {
                    Field = FieldPathUtility.CreateFieldPathsAsList<Railcar>(r => new List<object>() { r.RailLocation.Track.CompanyIDOwner }).First(),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = CompanyID
                }));

            return await Task.Run(() => railcarSearch.GetReadOnlyReader(null, fields).ToList());
        }

        [HttpGet]
        public async Task<List<Railcar>> GetForPurchaseOrderLine(long? id)
        {
            Search<Railcar> railcarSearch = new Search<Railcar>(new ExistsSearchCondition<Railcar>()
            {
                RelationshipName = nameof(Railcar.FulfillmentPlans),
                ExistsType = ExistsSearchCondition<Railcar>.ExistsTypes.Exists,
                Condition = new ExistsSearchCondition<FulfillmentPlan>()
                {
                    RelationshipName = nameof(FulfillmentPlan.FulfillmentPlanPurchaseOrderLines),
                    ExistsType = ExistsSearchCondition<FulfillmentPlan>.ExistsTypes.Exists,
                    Condition = new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                        new LongSearchCondition<FulfillmentPlanPurchaseOrderLine>()
                        {
                            Field = nameof(FulfillmentPlanPurchaseOrderLine.PurchaseOrderLineID),
                            SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                            Value = id
                        },
                        new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.Or,
                            new LongSearchCondition<FulfillmentPlanPurchaseOrderLine>()
                            {
                                Field = FieldPathUtility.CreateFieldPathsAsList<FulfillmentPlanPurchaseOrderLine>(fppol => new List<object>() { fppol.PurchaseOrderLine.PurchaseOrder.LocationIDDestination }).First(),
                                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                                Value = LocationID
                            },
                            new LongSearchCondition<FulfillmentPlanPurchaseOrderLine>()
                            {
                                Field = FieldPathUtility.CreateFieldPathsAsList<FulfillmentPlanPurchaseOrderLine>(fppol => new List<object>() { fppol.PurchaseOrderLine.PurchaseOrder.LocationIDOrigin }).First(),
                                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                                Value = LocationID
                            }))
                }
            });

            return await Task.Run(() => railcarSearch.GetReadOnlyReader(null, fields).ToList());
        }

        [HttpGet]
        [Route("railcar/getbyreportingmark/{reportingMark}")]
        public async Task<Railcar> GetByReportingMark(string reportingMark)
        {
            string formattedReportingMark = reportingMark.Trim().Replace(" ", "").ToUpper();

            string searchReportingMark = "";
            foreach (char character in formattedReportingMark)
            {
                if (char.IsDigit(character))
                {
                    break;
                }

                searchReportingMark += character;
            }

            if (string.IsNullOrEmpty(searchReportingMark) || !int.TryParse(formattedReportingMark.Substring(searchReportingMark.Length), out int searchReportingNumber))
            {
                return null;
            }

            Search<Railcar> railcarSearch = new Search<Railcar>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new StringSearchCondition<Railcar>()
                {
                    Field = nameof(Railcar.ReportingMark),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = searchReportingMark
                },
                new IntSearchCondition<Railcar>()
                {
                    Field = nameof(Railcar.ReportingNumber),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = searchReportingNumber
                }));

            return await Task.Run(() => railcarSearch.GetReadOnly(null, fields));
        }

        [HttpGet]
        public async Task<Railcar> GetByBillOfLading(long? id)
        {
            Search<Railcar> railcarSearch = new Search<Railcar>(new ExistsSearchCondition<Railcar>()
            {
                RelationshipName = nameof(Railcar.BillsOfLading),
                ExistsType = ExistsSearchCondition<Railcar>.ExistsTypes.Exists,
                Condition = new LongSearchCondition<BillOfLading>()
                {
                    Field = nameof(BillOfLading.BillOfLadingID),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = id
                }
            });

            return await Task.Run(() => railcarSearch.GetReadOnly(null, fields));
        }

        [HttpGet]
        public async Task<Railcar> Get(long? id)
        {
            return await Task.Run(() => DataObject.GetReadOnlyByPrimaryKey<Railcar>(id, null, fields));
        }

        [HttpGet]
        public async Task<byte[]> GetImage(long? id)
        {
            Railcar railcar = await Task.Run(() => DataObject.GetReadOnlyByPrimaryKey<Railcar>(id, null, FieldPathUtility.CreateFieldPathsAsList<Railcar>(r => new List<object>() { r.ImageOverrideThumbnail, r.RailcarModel.ImageThumbnail })));
            return railcar?.ImageOverrideThumbnail ?? railcar?.RailcarModel?.ImageThumbnail;
        }

        public struct ReleaseParameter
        {
            public long? RailcarID { get; set; }
            public long? GovernmentIDReleaseTo { get; set; }
            public long? CompanyIDReleaseTo { get; set; }
        }

        [HttpPost]
        public async Task<IHttpActionResult> Release(ReleaseParameter parameter)
        {
            Search<Railcar> railcarSearch = new Search<Railcar>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new LongSearchCondition<Railcar>()
                {
                    Field = nameof(Railcar.RailcarID),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = parameter.RailcarID
                },
                new LongSearchCondition<Railcar>()
                {
                    Field = nameof(Railcar.CompanyIDPossessor),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = CompanyID
                }));

            Railcar railcar = await Task.Run(() => railcarSearch.GetEditable());
            if (railcar == null)
            {
                return NotFound();
            }

            railcar.CompanyIDPossessor = parameter.CompanyIDReleaseTo;
            railcar.GovernmentIDPossessor = parameter.GovernmentIDReleaseTo;

            if (!await Task.Run(() => railcar.Save()))
            {
                return railcar.HandleFailedValidation(this);
            }

            return Ok(await Task.Run(() => DataObject.GetReadOnlyByPrimaryKey<Railcar>(parameter.RailcarID, null, fields)));
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteRailcarLoad(long? id)
        {
            RailcarLoad railcarLoad = await Task.Run(() => DataObject.GetEditableByPrimaryKey<RailcarLoad>(id, null, FieldPathUtility.CreateFieldPathsAsList<RailcarLoad>(rl => new object[]
            {
                rl.Railcar.CompanyIDPossessor,
                rl.Railcar.RailLocation.TrainID,
                rl.Railcar.RailLocation.Train.TrainSymbol.CompanyIDOperator,
                rl.Railcar.RailLocation.Train.TrainSymbol.GovernmentIDOperator,
                rl.Railcar.FulfillmentPlans.First().FulfillmentPlanPurchaseOrderLines.First().PurchaseOrderLineID,
                rl.Railcar.FulfillmentPlans.First().FulfillmentPlanRoutes.First().CompanyIDFrom,
                rl.Railcar.FulfillmentPlans.First().FulfillmentPlanRoutes.First().GovernmentIDFrom,
                rl.Railcar.FulfillmentPlans.First().FulfillmentPlanRoutes.First().SortOrder
            })));

            if (railcarLoad == null)
            {
                return NotFound();
            }

            Railcar railcar = railcarLoad.Railcar;
            bool valid = railcar.CompanyIDPossessor == CompanyID;
            if (!valid && railcar.RailLocation?.TrainID != null)
            {
                FulfillmentPlan currentPlan = railcar.FulfillmentPlans?.FirstOrDefault(fp => (fp.FulfillmentPlanPurchaseOrderLines?.Any(fppol => fppol.PurchaseOrderLineID != null && fppol.PurchaseOrderLineID == railcarLoad.PurchaseOrderLineID)) ?? false);
                FulfillmentPlanRoute firstRoute = currentPlan?.FulfillmentPlanRoutes?.OrderByDescending(fpr => fpr.SortOrder).FirstOrDefault();
                if (firstRoute != null)
                {
                    valid = (firstRoute.GovernmentIDFrom != null && firstRoute.GovernmentIDFrom == railcar.RailLocation.Train.TrainSymbol.GovernmentIDOperator) ||
                            (firstRoute.CompanyIDFrom != null && firstRoute.CompanyIDFrom == railcar.RailLocation.Train.TrainSymbol.CompanyIDOperator);
                }
            }

            if (!valid)
            {
                return NotFound();
            }

            if (!await Task.Run(() => railcarLoad.Delete()))
            {
                return railcarLoad.HandleFailedValidation(this);
            }

            return Ok();
        }

        public struct CompleteReceivingParameter
        {
            public long? RailcarID { get; set; }
        }

        [HttpPost]
        public async Task<IHttpActionResult> CompleteReceiving(CompleteReceivingParameter parameter)
        {
            using (ITransaction transaction = SQLProviderFactory.GenerateTransaction())
            {
                Search<Railcar> railcarSearch = new Search<Railcar>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                    new LongSearchCondition<Railcar>()
                    {
                        Field = nameof(Railcar.RailcarID),
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = parameter.RailcarID
                    },
                    new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.Or,
                        new LongSearchCondition<Railcar>()
                        {
                            Field = FieldPathUtility.CreateFieldPathsAsList<Railcar>(r => new List<object>() { r.RailLocation.Track.CompanyIDOwner }).First(),
                            SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                            Value = CompanyID
                        },
                        new LongSearchCondition<Railcar>()
                        {
                            Field = FieldPathUtility.CreateFieldPath<Railcar>(r => r.RailLocation.TrainID),
                            SearchConditionType = SearchCondition.SearchConditionTypes.NotNull
                        }),
                    new LongSearchCondition<Railcar>()
                    {
                        Field = FieldPathUtility.CreateFieldPathsAsList<Railcar>(r => new List<object>() { r.TrackDestination.CompanyIDOwner }).First(),
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = CompanyID
                    }));

                Railcar railcar = await Task.Run(() => railcarSearch.GetEditable(transaction, FieldPathUtility.CreateFieldPathsAsList<Railcar>(r => new object[]
                {
                    r.RailLocation.TrackID,
                    r.RailLocation.Track.CompanyIDOwner,
                    r.RailLocation.TrainID,
                    r.RailLocation.Train.TrainSymbol.CompanyIDOperator,
                    r.RailLocation.Train.TrainSymbol.GovernmentIDOperator,
                    r.RailcarRoutes.First().SortOrder,
                    r.RailcarRoutes.First().CompanyIDFrom,
                    r.RailcarRoutes.First().GovernmentIDFrom
                })));


                if (railcar == null)
                {
                    return NotFound();
                }

                bool valid = railcar.RailLocation?.Track?.CompanyIDOwner == CompanyID;
                if (!valid)
                {
                    RailcarRoute lastRoute = railcar.RailcarRoutes?.OrderByDescending(r => r.SortOrder).FirstOrDefault();
                    if (lastRoute != null)
                    {
                        valid = (lastRoute.GovernmentIDFrom != null && lastRoute.GovernmentIDFrom == railcar.RailLocation.Train.TrainSymbol.GovernmentIDOperator) ||
                                (lastRoute.CompanyIDFrom != null && lastRoute.CompanyIDFrom == railcar.RailLocation.Train.TrainSymbol.CompanyIDOperator);
                    }
                }

                if (!valid)
                {
                    return NotFound();
                }

                if (!await Task.Run(() => railcar.CompleteReceiving(transaction)))
                {
                    return railcar.HandleFailedValidation(this);
                }

                transaction.Commit();
            }
            return Ok();
        }

        [HttpGet]
        public async Task<List<Railcar>> GetForShippingReceiving()
        {
            Search<Railcar> railcarSearch = new Search<Railcar>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.Or,
                    new ExistsSearchCondition<Railcar>()
                    {
                        RelationshipName = nameof(Railcar.FulfillmentPlans),
                        ExistsType = ExistsSearchCondition<Railcar>.ExistsTypes.Exists,
                        Condition = new ExistsSearchCondition<FulfillmentPlan>()
                        {
                            RelationshipName = nameof(FulfillmentPlan.FulfillmentPlanPurchaseOrderLines),
                            ExistsType = ExistsSearchCondition<FulfillmentPlan>.ExistsTypes.Exists,
                            Condition = new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                                new IntSearchCondition<FulfillmentPlanPurchaseOrderLine>()
                                {
                                    Field = FieldPathUtility.CreateFieldPathsAsList<FulfillmentPlanPurchaseOrderLine>(fppol => new List<object>() { fppol.PurchaseOrderLine.PurchaseOrder.Status }).First(),
                                    SearchConditionType = SearchCondition.SearchConditionTypes.List,
                                    List = new List<int>() { (int)PurchaseOrder.Statuses.Accepted, (int)PurchaseOrder.Statuses.InProgress }
                                },
                                new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.Or,
                                    new LongSearchCondition<FulfillmentPlanPurchaseOrderLine>()
                                    {
                                        Field = FieldPathUtility.CreateFieldPathsAsList<FulfillmentPlanPurchaseOrderLine>(fppol => new List<object>() { fppol.PurchaseOrderLine.PurchaseOrder.LocationIDOrigin} ).First(),
                                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                                        Value = LocationID
                                    },
                                    new LongSearchCondition<FulfillmentPlanPurchaseOrderLine>()
                                    {
                                        Field = FieldPathUtility.CreateFieldPathsAsList<FulfillmentPlanPurchaseOrderLine>(fppol => new List<object>() { fppol.PurchaseOrderLine.PurchaseOrder.LocationIDDestination }).First(),
                                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                                        Value = LocationID
                                    }))
                        }
                    },
                    new ExistsSearchCondition<Railcar>()
                    {
                        RelationshipName = nameof(Railcar.RailcarLoads),
                        ExistsType = ExistsSearchCondition<Railcar>.ExistsTypes.Exists,
                        Condition = new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.Or,
                            new LongSearchCondition<RailcarLoad>()
                            {
                                Field = FieldPathUtility.CreateFieldPathsAsList<RailcarLoad>(rl => new List<object>() { rl.PurchaseOrderLine.PurchaseOrder.LocationIDOrigin }).First(),
                                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                                Value = LocationID
                            },
                            new LongSearchCondition<RailcarLoad>()
                            {
                                Field = FieldPathUtility.CreateFieldPathsAsList<RailcarLoad>(rl => new List<object>() { rl.PurchaseOrderLine.PurchaseOrder.LocationIDDestination }).First(),
                                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                                Value = LocationID
                            })
                    }),
                new LongSearchCondition<Railcar>()
                {
                    Field = FieldPathUtility.CreateFieldPathsAsList<Railcar>(r => new List<object>() { r.RailLocation.Track.CompanyIDOwner }).First(),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = CompanyID
                },
                new LongSearchCondition<Railcar>()
                {
                    Field = nameof(Railcar.CompanyIDPossessor),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = CompanyID
                }));

            return await Task.Run(() => railcarSearch.GetReadOnlyReader(null, fields).ToList());
        }

        [HttpPost]
        public async Task<IHttpActionResult> AddRailcarLoad(RailcarLoad railcarLoad)
        {
            Search<Railcar> railcarSearch = new Search<Railcar>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new LongSearchCondition<Railcar>()
                {
                    Field = nameof(Railcar.RailcarID),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = railcarLoad.RailcarID
                },
                new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.Or,
                    new LongSearchCondition<Railcar>()
                    {
                        Field = nameof(Railcar.CompanyIDPossessor),
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = CompanyID
                    },
                    new LongSearchCondition<Railcar>()
                    {
                        Field = FieldPathUtility.CreateFieldPath<Railcar>(r => r.RailLocation.TrainID),
                        SearchConditionType = SearchCondition.SearchConditionTypes.NotNull
                    })));

            Railcar railcar = await Task.Run(() => railcarSearch.GetReadOnly(null, FieldPathUtility.CreateFieldPathsAsList<Railcar>(r => new object[]
            {
                r.CompanyIDPossessor,
                r.RailLocation.TrainID,
                r.RailLocation.Train.TrainSymbol.CompanyIDOperator,
                r.RailLocation.Train.TrainSymbol.GovernmentIDOperator,
                r.FulfillmentPlans.First().FulfillmentPlanPurchaseOrderLines.First().PurchaseOrderLineID,
                r.FulfillmentPlans.First().FulfillmentPlanRoutes.First().CompanyIDTo,
                r.FulfillmentPlans.First().FulfillmentPlanRoutes.First().GovernmentIDTo,
                r.FulfillmentPlans.First().FulfillmentPlanRoutes.First().SortOrder
            })));

            bool valid = railcar.CompanyIDPossessor == CompanyID;
            if (!valid && railcar.RailLocation?.TrainID != null)
            {
                FulfillmentPlan currentPlan = railcar.FulfillmentPlans?.FirstOrDefault(fp => (fp.FulfillmentPlanPurchaseOrderLines?.Any(fppol => fppol.PurchaseOrderLineID != null && fppol.PurchaseOrderLineID == railcarLoad.PurchaseOrderLineID)) ?? false);
                FulfillmentPlanRoute firstRoute = currentPlan?.FulfillmentPlanRoutes?.OrderBy(fpr => fpr.SortOrder).FirstOrDefault();
                if (firstRoute != null)
                {
                    valid = (firstRoute.GovernmentIDTo != null && firstRoute.GovernmentIDTo == railcar.RailLocation.Train.TrainSymbol.GovernmentIDOperator) ||
                            (firstRoute.CompanyIDTo != null && firstRoute.CompanyIDTo == railcar.RailLocation.Train.TrainSymbol.CompanyIDOperator);
                }
            }

            if (!valid)
            {
                return NotFound();
            }

            if (!await Task.Run(() => railcarLoad.Save()))
            {
                return railcarLoad.HandleFailedValidation(this);
            }

            return Ok();
        }
    }
}
