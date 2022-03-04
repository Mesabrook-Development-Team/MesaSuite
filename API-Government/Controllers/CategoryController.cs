using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using API.Common;
using API.Common.Attributes;
using API_Government.Attributes;
using ClussPro.ObjectBasedFramework.DataSearch;
using WebModels.account;
using WebModels.gov;

namespace API_Government.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess("gov")]
    [GovernmentAccess(RequiredPermissions = new [] { nameof(Official.ManageAccounts) })]
    public class CategoryController : DataObjectController<Category>
    {
        public override IEnumerable<string> DefaultRetrievedFields => new[]
        {
            nameof(Category.CategoryID),
            nameof(Category.GovernmentID),
            nameof(Category.Name)
        };

        public override bool AllowGetAll => true;

        public override SearchCondition GetBaseSearchCondition()
        {
            long governmentID = long.Parse(Request.Headers.GetValues("GovernmentID").First());
            return new LongSearchCondition<Category>()
            {
                Field = "GovernmentID",
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = governmentID
            };
        }
    }
}