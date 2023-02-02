using API.Common;
using API.Common.Attributes;
using API_Fleet.Extensions;
using ClussPro.ObjectBasedFramework;
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
    public class CarHandlingRateController : DataObjectController<CarHandlingRate>
    {
        public override IEnumerable<string> DefaultRetrievedFields => FieldPathUtility.CreateFieldPathsAsList<CarHandlingRate>(chr => new List<object>()
        {
            chr.CarHandlingRateID,
            chr.CompanyID,
            chr.Company.CompanyID,
            chr.Company.Name,
            chr.GovernmentID,
            chr.Government.GovernmentID,
            chr.Government.Name,
            chr.EffectiveTime,
            chr.IntraDistrictRate,
            chr.InterDistrictRate,
            chr.PlacementRate
        });

        public CarHandlingRateController() : base()
        {
            PostSecurityCheck += EditSecurityCheck;
            PutSecurityCheck += EditSecurityCheck;
            DeleteSecurityCheck += EditSecurityCheck;
            PatchSecurityCheck += EditSecurityCheck;
        }

        private void EditSecurityCheck(object sender, SecurityCheckEventArgs e)
        {
            CarHandlingRate carHandlingRate = DataObject.GetReadOnlyByPrimaryKey<CarHandlingRate>(e.ObjectID, e.Transaction, FieldPathUtility.CreateFieldPathsAsList<CarHandlingRate>(chr => new List<object>()
            {
                chr.CompanyID,
                chr.GovernmentID
            }));

            e.IsValid &= carHandlingRate.CompanyID == this.CompanyID() && carHandlingRate.GovernmentID == this.GovernmentID();
        }

        [HttpGet]
        public async Task<List<CarHandlingRate>> GetByCompanyID(long? id)
        {
            Search<CarHandlingRate> handlingRateSearch = new Search<CarHandlingRate>(new LongSearchCondition<CarHandlingRate>()
            {
                Field = nameof(CarHandlingRate.CompanyID),
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = id
            });

            return handlingRateSearch.GetReadOnlyReader(null, await FieldsToRetrieve()).ToList();
        }

        [HttpGet]
        public async Task<List<CarHandlingRate>> GetByGovernmentID(long? id)
        {
            Search<CarHandlingRate> handlingRateSearch = new Search<CarHandlingRate>(new LongSearchCondition<CarHandlingRate>()
            {
                Field = nameof(CarHandlingRate.GovernmentID),
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = id
            });

            return handlingRateSearch.GetReadOnlyReader(null, await FieldsToRetrieve()).ToList();
        }
    }
}