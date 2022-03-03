using API.Common;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using WebModels.dbo;

namespace API_MCSync.Controllers
{
    public class VersionController : DataObjectController<MCSyncVersion>
    {
        public override bool AllowGetAll => true;

        public override IEnumerable<string> DefaultRetrievedFields => Schema.GetSchemaObject<MCSyncVersion>().GetFields().Select(f => f.FieldName);

        [HttpGet]
        public string GetLatest()
        {
            Search<MCSyncVersion> versionSearch = new Search<MCSyncVersion>(new DateTimeSearchCondition<MCSyncVersion>()
            {
                Field = "Valid",
                SearchConditionType = SearchCondition.SearchConditionTypes.LessEquals,
                Value = DateTime.Now
            });
            versionSearch.SearchOrders.AddRange(new SearchOrder[]
            {
                new SearchOrder() { OrderField = "Major", OrderDirection = SearchOrder.OrderDirections.Descending },
                new SearchOrder() { OrderField = "Minor", OrderDirection = SearchOrder.OrderDirections.Descending },
                new SearchOrder() { OrderField = "Revision", OrderDirection = SearchOrder.OrderDirections.Descending },
                new SearchOrder() { OrderField = "Build", OrderDirection = SearchOrder.OrderDirections.Descending },
            });

            MCSyncVersion version = versionSearch.GetReadOnly(null, new string[] { "Major", "Minor", "Revision", "Build" });
            if (version == null)
            {
                return null;
            }

            return string.Format("{0}.{1}.{2}.{3}", version.Major, version.Minor, version.Revision, version.Build);
        }

        [NonAction]
        public async override Task<MCSyncVersion> Get(long id)
        {
            return null;
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            return await GetAll();
        }

        [NonAction]
        public async override Task<IHttpActionResult> Post(MCSyncVersion dataObject)
        {
            return null;
        }

        [NonAction]
        public async override Task<IHttpActionResult> Put(MCSyncVersion dataObject)
        {
            return null;
        }

        [NonAction]
        public override IHttpActionResult Delete(long id)
        {
            return null;
        }
    }
}
