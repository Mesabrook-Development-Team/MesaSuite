using API.Common.Attributes;
using API_Company.Attributes;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Utility;
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
            r.RailLocation.Track.Name,
            r.RailLocation.Train.TimeOnDuty,
            r.RailLocation.Train.TrainSymbol.Name,
            r.TrackDestination.Name,
            r.CompanyIDOwner,
            r.CompanyPossessor.Name,
            r.GovernmentPossessor.Name,
            r.RailcarModel.Name,
            r.BillOfLadingCurrent.BillOfLadingID
        });

        [HttpGet]
        public async Task<List<Railcar>> GetOwnedLeasedForCompany()
        {
            Search<Railcar> railcarSearch = new Search<Railcar>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.Or,
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
            Search<Railcar> railcarSearch = new Search<Railcar>(new LongSearchCondition<Railcar>()
            {
                Field = FieldPathUtility.CreateFieldPathsAsList<Railcar>(r => new List<object>() { r.BillOfLadingCurrent.BillOfLadingID }).First(),
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = id
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
    }
}
