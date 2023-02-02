using System.Collections.Generic;
using API.Common;
using API.Common.Attributes;
using ClussPro.ObjectBasedFramework.Utility;
using WebModels.fleet;

namespace API_Fleet.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess(new [] { "gov", "company" })]
    public class LeaseRequestController : DataObjectController<LeaseRequest>
    {
        public override IEnumerable<string> DefaultRetrievedFields => FieldPathUtility.CreateFieldPathsAsList<LeaseRequest>(lr => new List<object>()
        {
            lr.LeaseRequestID,
            lr.CompanyIDRequester,
            lr.CompanyRequester.CompanyID,
            lr.CompanyRequester.Name,
            lr.LocationIDChargeTo,
            lr.LocationChargeTo.LocationID,
            lr.LocationChargeTo.Name,
            lr.GovernmentIDRequester,
            lr.GovernmentRequester.GovernmentID,
            lr.GovernmentRequester.Name,
            lr.LeaseType,
            lr.RailcarType,
            lr.TrackIDDeliveryLocation,
            lr.TrackDeliveryLocation.TrackID,
            lr.TrackDeliveryLocation.Name,
            lr.Purpose,
            lr.BidEndTime
        });

        public override bool AllowGetAll => true;
    }
}