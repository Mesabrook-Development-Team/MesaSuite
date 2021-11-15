using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Common;
using API.Common.Attributes;
using API_Company.Attributes;
using ClussPro.ObjectBasedFramework.DataSearch;
using WebModels.account;
using WebModels.company;

namespace API_Company.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess("company")]
    [CompanyAccess(RequiredPermissions = new string[] { nameof(Employee.ManageAccounts) })]
    public class CategoryController : DataObjectController<Category>
    {
        public override IEnumerable<string> AllowedFields => new string[]
        {
            nameof(Category.CategoryID),
            nameof(Category.CompanyID),
            nameof(Category.Name),
            nameof(Category.AccountCount)
        };

        public List<Category> GetForCompany()
        {
            long companyID = long.Parse(Request.Headers.GetValues("CompanyID").First());
            Search<Category> categorySearch = new Search<Category>(new LongSearchCondition<Category>()
            {
                Field = "CompanyID",
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = companyID
            });

            return categorySearch.GetReadOnlyReader(null, AllowedFields).ToList();
        }
    }
}