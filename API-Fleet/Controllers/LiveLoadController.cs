using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using API.Common;
using API.Common.Attributes;
using API.Common.Extensions;
using API_Fleet.Extensions;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Utility;
using WebModels.company;
using WebModels.fleet;
using WebModels.gov;

namespace API_Fleet.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess(new[] { "gov", "company" })]
    public class LiveLoadController : DataObjectController<LiveLoad>
    {
        public override IEnumerable<string> DefaultRetrievedFields => FieldPathUtility.CreateFieldPathsAsList<LiveLoad>(ll => new List<object>()
        {
            ll.LiveLoadID,
            ll.TrainID,
            ll.Code,
            ll.LiveLoadSessions.First().LiveLoadSessionID,
            ll.LiveLoadSessions.First().LiveLoadID,
            ll.LiveLoadSessions.First().UserID,
            ll.LiveLoadSessions.First().User.UserID,
            ll.LiveLoadSessions.First().User.Username,
            ll.LiveLoadSessions.First().CompanyID,
            ll.LiveLoadSessions.First().Company.CompanyID,
            ll.LiveLoadSessions.First().Company.Name,
            ll.LiveLoadSessions.First().GovernmentID,
            ll.LiveLoadSessions.First().Government.GovernmentID,
            ll.LiveLoadSessions.First().Government.Name,
            ll.LiveLoadSessions.First().LastHeartbeat
        });

        public override ISearchCondition GetBaseSearchCondition()
        {
            if (this.CompanyID() != null)
            {
                return new ExistsSearchCondition<LiveLoad>()
                {
                    RelationshipName = FieldPathUtility.CreateFieldPathsAsList<LiveLoad>(ll => new List<object>() { ll.Train.TrainSymbol.CompanyOperator.Employees }).First(),
                    ExistsType = ExistsSearchCondition<LiveLoad>.ExistsTypes.Exists,
                    Condition = new LongSearchCondition<Employee>()
                    {
                        Field = nameof(Employee.UserID),
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = SecurityProfile.UserID
                    }
                };
            }
            else if (this.GovernmentID() != null)
            {
                return new ExistsSearchCondition<LiveLoad>()
                {
                    RelationshipName = FieldPathUtility.CreateFieldPathsAsList<LiveLoad>(ll => new List<object>() { ll.Train.TrainSymbol.GovernmentOperator.Officials }).First(),
                    ExistsType = ExistsSearchCondition<LiveLoad>.ExistsTypes.Exists,
                    Condition = new LongSearchCondition<Official>()
                    {
                        Field = nameof(Official.UserID),
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = SecurityProfile.UserID
                    }
                };
            }
            else
            {
                return new LongSearchCondition<LiveLoad>()
                {
                    Field = nameof(LiveLoad.LiveLoadID),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = -1L
                };
            }
        }

        [HttpGet]
        public async Task<LiveLoad> GetForTrain(long? id)
        {
            Search<LiveLoad> search = new Search<LiveLoad>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new LongSearchCondition<LiveLoad>()
                {
                    Field = nameof(LiveLoad.TrainID),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = id
                },
                GetBaseSearchCondition()));

            return search.GetReadOnly(null, await FieldsToRetrieve());
        }

        private readonly char[] LETTERS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        [HttpPost]
        public async Task<IHttpActionResult> Generate(LiveLoadParam liveLoadParam)
        {
            LiveLoad liveLoad = DataObjectFactory.Create<LiveLoad>();
            liveLoad.TrainID = liveLoadParam.TrainID;

            Random rand = new Random();
            StringBuilder codeBuilder = new StringBuilder();

            for(int i = 0; i < 4; i++)
            {
                if (i < 2)
                {
                    codeBuilder.Append(LETTERS[rand.Next(0, 27)]);
                }
                else
                {
                    codeBuilder.Append(rand.Next(0, 10));
                }
            }

            liveLoad.Code = codeBuilder.ToString();
            if (!liveLoad.Save())
            {
                return liveLoad.HandleFailedValidation(this);
            }

            return Ok(DataObject.GetReadOnlyByPrimaryKey<LiveLoad>(liveLoad.LiveLoadID, null, await FieldsToRetrieve()));
        }

        public struct LiveLoadParam
        {
            public long? TrainID { get; set; }
        }
    }
}