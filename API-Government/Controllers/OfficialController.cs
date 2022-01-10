using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using API.Common;
using API.Common.Attributes;
using API_Government.Attributes;
using ClussPro.ObjectBasedFramework.DataSearch;
using WebModels.gov;
using WebModels.security;

namespace API_Government.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess("gov")]
    [GovernmentAccess(RequiredPermissions = new string[] { nameof(Official.ManageOfficials) })]
    
    public class OfficialController : DataObjectController<Official>
    {
        public override IEnumerable<string> AllowedFields => new string[]
        {
            nameof(Official.OfficialID),
            nameof(Official.GovernmentID),
            nameof(Official.UserID),
            nameof(Official.ManageOfficials),
            nameof(Official.ManageEmails),
            nameof(Official.ManageAccounts),
            nameof(Official.OfficialName)
        };

        [HttpGet]
        public List<Official> GetAllForGovernment()
        {
            long govID = long.Parse(Request.Headers.GetValues("GovernmentID").First());
            Search<Official> officialSearch = new Search<Official>(new LongSearchCondition<Official>()
            {
                Field = "GovernmentID",
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = govID
            });

            return officialSearch.GetReadOnlyReader(null, AllowedFields).ToList();
        }

        [HttpGet]
        public List<User> Candidates()
        {
            long govID = long.Parse(Request.Headers.GetValues("GovernmentID").First());
            Search<User> userSearch = new Search<User>(new ExistsSearchCondition<User>()
            {
                RelationshipName = "Officials",
                ExistsType = ExistsSearchCondition<User>.ExistsTypes.NotExists,
                Condition = new LongSearchCondition<Official>()
                {
                    Field = "GovernmentID",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = govID
                }
            });

            return userSearch.GetReadOnlyReader(null, new string[] { "UserID", "Username" }).ToList();
        }

        [GovernmentAccess(RequiredPermissions = null)]
        public Official GetForGovernment()
        {
            SecurityProfile securityProfile = (SecurityProfile)Request.Properties["SecurityProfile"];
            long govID = long.Parse(Request.Headers.GetValues("GovernmentID").First());
            Search<Official> officialSeach = new Search<Official>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new LongSearchCondition<Official>()
                {
                    Field = "GovernmentID",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = govID
                },
                new LongSearchCondition<Official>()
                {
                    Field = "UserID",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = securityProfile.UserID
                }));

            return officialSeach.GetReadOnly(null, AllowedFields);
        }
    }
}