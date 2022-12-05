using API.Common;
using API.Common.Attributes;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebModels.fleet;

namespace API_Fleet.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess(new[] { "gov", "company" })]
    public class RailLocationController : DataObjectController<RailLocation>
    {
        public override IEnumerable<string> DefaultRetrievedFields => FieldPathUtility.CreateFieldPathsAsList<RailLocation>(rl => new List<object>()
        {
            rl.RailLocationID,
            rl.RailcarID,
            rl.Position,
            rl.Railcar.RailcarID,
            rl.Railcar.ReportingMark,
            rl.Railcar.ReportingNumber,
            rl.Locomotive.LocomotiveID,
            rl.Locomotive.ReportingMark,
            rl.Locomotive.ReportingNumber
        });

        public async Task<List<RailLocation>> GetByTrain(long? id)
        {
            Search<RailLocation> railLocationSearch = new Search<RailLocation>(new LongSearchCondition<RailLocation>()
            {
                Field = nameof(RailLocation.TrainID),
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = id
            });

            return railLocationSearch.GetReadOnlyReader(null, await FieldsToRetrieve()).ToList();
        }
    }
}