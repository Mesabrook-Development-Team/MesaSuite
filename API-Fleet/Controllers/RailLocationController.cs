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
using WebModels.fleet;

namespace API_Fleet.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess(new[] { "gov", "company" })]
    public class RailLocationController : ApiController
    {
        private static List<string> DefaultRetrievedFields => FieldPathUtility.CreateFieldPathsAsList<RailLocation>(rl => new List<object>()
        {
            rl.RailLocationID,
            rl.RailcarID,
            rl.LocomotiveID,
            rl.Position,
            rl.Railcar.RailcarID,
            rl.Railcar.ReportingMark,
            rl.Railcar.ReportingNumber,
            rl.Railcar.RailcarModelID,
            rl.Railcar.RailcarModel.RailcarModelID,
            rl.Railcar.RailcarModel.Name,
            rl.Railcar.CompanyIDPossessor,
            rl.Railcar.CompanyPossessor.CompanyID,
            rl.Railcar.CompanyPossessor.Name,
            rl.Railcar.GovernmentIDPossessor,
            rl.Railcar.GovernmentPossessor.GovernmentID,
            rl.Railcar.GovernmentPossessor.Name,
            rl.Locomotive.LocomotiveID,
            rl.Locomotive.ReportingMark,
            rl.Locomotive.ReportingNumber,
            rl.Locomotive.LocomotiveModelID,
            rl.Locomotive.LocomotiveModel.LocomotiveModelID,
            rl.Locomotive.LocomotiveModel.Name,
            rl.Locomotive.CompanyIDPossessor,
            rl.Locomotive.CompanyPossessor.CompanyID,
            rl.Locomotive.CompanyPossessor.Name,
            rl.Locomotive.GovernmentIDPossessor,
            rl.Locomotive.GovernmentPossessor.GovernmentID,
            rl.Locomotive.GovernmentPossessor.Name
        });

        public List<RailLocation> GetByTrain(long? id)
        {
            Search<RailLocation> railLocationSearch = new Search<RailLocation>();
            if (id != null)
            {
                railLocationSearch.SearchCondition = new LongSearchCondition<RailLocation>()
                {
                    Field = nameof(RailLocation.TrainID),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = id
                };
            }
            else
            {
                railLocationSearch.SearchCondition = new LongSearchCondition<RailLocation>()
                {
                    Field = nameof(RailLocation.TrainID),
                    SearchConditionType = SearchCondition.SearchConditionTypes.NotNull
                };
            }

            return railLocationSearch.GetReadOnlyReader(null, DefaultRetrievedFields).ToList();
        }

        public List<RailLocation> GetByTrack(long? id)
        {
            Search<RailLocation> railLocationSearch = new Search<RailLocation>();
            if (id != null)
            {
                railLocationSearch.SearchCondition = new LongSearchCondition<RailLocation>()
                {
                    Field = nameof(RailLocation.TrackID),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = id
                };
            }
            else
            {
                railLocationSearch.SearchCondition = new LongSearchCondition<RailLocation>()
                {
                    Field = nameof(RailLocation.TrackID),
                    SearchConditionType = SearchCondition.SearchConditionTypes.NotNull
                };
            }

            return railLocationSearch.GetReadOnlyReader(null, DefaultRetrievedFields).ToList();
        }
    }
}