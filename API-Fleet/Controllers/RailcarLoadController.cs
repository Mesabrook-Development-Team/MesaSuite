using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using API.Common;
using API.Common.Attributes;
using API.Common.Extensions;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Utility;
using WebModels.fleet;

namespace API_Fleet.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess(new [] { "company", "gov" })]
    public class RailcarLoadController : DataObjectController<RailcarLoad>
    {
        public override IEnumerable<string> DefaultRetrievedFields => FieldPathUtility.CreateFieldPathsAsList<RailcarLoad>(rl => new List<object>()
        {
            rl.RailcarLoadID,
            rl.RailcarID,
            rl.ItemID,
            rl.Item.ItemID,
            rl.Item.Name,
            rl.Item.Image,
            rl.Quantity
        });

        [HttpGet]
        public async Task<List<RailcarLoad>> GetByRailcarID(long? id)
        {
            Search<RailcarLoad> railcarLoadSearch = new Search<RailcarLoad>(new LongSearchCondition<RailcarLoad>()
            {
                Field = nameof(RailcarLoad.RailcarID),
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = id
            });

            return railcarLoadSearch.GetReadOnlyReader(null, await FieldsToRetrieve()).ToList();
        }

        [HttpDelete]
        public IHttpActionResult DeleteForRailcar(long? id)
        {
            Search<RailcarLoad> loadSearch = new Search<RailcarLoad>(new LongSearchCondition<RailcarLoad>()
            {
                Field = nameof(RailcarLoad.RailcarID),
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = id
            });

            foreach(RailcarLoad load in loadSearch.GetEditableReader())
            {
                if (!load.Delete())
                {
                    return load.HandleFailedValidation(this);
                }
            }

            return Ok();
        }
    }
}