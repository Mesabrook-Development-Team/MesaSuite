using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Common;
using API.Common.Attributes;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Utility;
using WebModels.fleet;

namespace API_Fleet.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess(new[] { "gov", "company" })]
    public class LeaseBidController : DataObjectController<LeaseBid>
    {
        protected long? CompanyID
        {
            get
            {
                if (!Request.Headers.TryGetValues("CompanyID", out IEnumerable<string> companyIDs))
                {
                    return -1L;
                }

                return long.TryParse(companyIDs.First(), out long companyID) ? companyID : -1L;
            }
        }
        protected long? GovernmentID
        {
            get
            {
                if (!Request.Headers.TryGetValues("GovernmentID", out IEnumerable<string> governmentIDs))
                {
                    return -1L;
                }

                return long.TryParse(governmentIDs.First(), out long governmentID) ? governmentID : -1L;
            }
        }

        public override IEnumerable<string> DefaultRetrievedFields => FieldPathUtility.CreateFieldPathsAsList<LeaseBid>(lb => new List<object>()
        {
            lb.LeaseBidID,
            lb.LeaseRequestID,
            lb.LocomotiveID,
            lb.Locomotive.LocomotiveID,
            lb.Locomotive.LocomotiveModelID,
            lb.Locomotive.LocomotiveModel.LocomotiveModelID,
            lb.Locomotive.LocomotiveModel.Name,
            lb.Locomotive.CompanyIDOwner,
            lb.Locomotive.CompanyOwner.CompanyID,
            lb.Locomotive.CompanyOwner.Name,
            lb.Locomotive.GovernmentIDOwner,
            lb.Locomotive.GovernmentOwner.GovernmentID,
            lb.Locomotive.GovernmentOwner.Name,
            lb.Locomotive.ReportingMark,
            lb.Locomotive.ReportingNumber,
            lb.RailcarID,
            lb.Railcar.RailcarID,
            lb.Railcar.RailcarModelID,
            lb.Railcar.RailcarModel.RailcarModelID,
            lb.Railcar.RailcarModel.Name,
            lb.Railcar.RailcarModel.Type,
            lb.Railcar.CompanyIDOwner,
            lb.Railcar.CompanyOwner.CompanyID,
            lb.Railcar.CompanyOwner.Name,
            lb.Railcar.GovernmentIDOwner,
            lb.Railcar.GovernmentOwner.GovernmentID,
            lb.Railcar.GovernmentOwner.Name,
            lb.Railcar.ReportingMark,
            lb.Railcar.ReportingNumber,
            lb.LeaseAmount,
            lb.RecurringAmountType,
            lb.RecurringAmount,
            lb.LocationIDRecurringAmountDestination,
            lb.LocationRecurringAmountDestination.LocationID,
            lb.LocationRecurringAmountDestination.Name,
            lb.Terms
        });

        public override bool AllowGetAll => true;
        public override ISearchCondition GetBaseSearchCondition()
        {
            return new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.Or,
                new LongSearchCondition<LeaseBid>()
                {
                    Field = FieldPathUtility.CreateFieldPathsAsList<LeaseBid>(lb => new List<object>() { lb.Railcar.CompanyIDOwner }).First(),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = CompanyID
                },
                new LongSearchCondition<LeaseBid>()
                {
                    Field = FieldPathUtility.CreateFieldPathsAsList<LeaseBid>(lb => new List<object>() { lb.Railcar.GovernmentIDOwner }).First(),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = GovernmentID
                },
                new LongSearchCondition<LeaseBid>()
                {
                    Field = FieldPathUtility.CreateFieldPathsAsList<LeaseBid>(lb => new List<object>() { lb.Locomotive.CompanyIDOwner }).First(),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = CompanyID
                },
                new LongSearchCondition<LeaseBid>()
                {
                    Field = FieldPathUtility.CreateFieldPathsAsList<LeaseBid>(lb => new List<object>() { lb.Locomotive.GovernmentIDOwner }).First(),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = GovernmentID
                },
                new LongSearchCondition<LeaseBid>()
                {
                    Field = FieldPathUtility.CreateFieldPathsAsList<LeaseBid>(lb => new List<object>() { lb.LeaseRequest.CompanyIDRequester }).First(),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = CompanyID
                },
                new LongSearchCondition<LeaseBid>()
                {
                    Field = FieldPathUtility.CreateFieldPathsAsList<LeaseBid>(lb => new List<object>() { lb.LeaseRequest.GovernmentIDRequester }).First(),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = GovernmentID
                });
        }
    }
}