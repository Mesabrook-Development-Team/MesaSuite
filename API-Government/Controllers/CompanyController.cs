using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using API.Common.Attributes;
using ClussPro.ObjectBasedFramework.DataSearch;
using WebModels.company;

namespace API_Government.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess("gov")]
    public class CompanyController : ApiController
    {
        [HttpGet]
        public List<Company> GetAll()
        {
            Search<Company> companySearch = new Search<Company>();

            string[] fields = new[]
            {
                nameof(Company.CompanyID),
                nameof(Company.Name),
                $"{nameof(Company.Locations)}.{nameof(Location.LocationID)}",
                $"{nameof(Company.Locations)}.{nameof(Location.CompanyID)}",
                $"{nameof(Company.Locations)}.{nameof(Location.Name)}"
            };

            return companySearch.GetReadOnlyReader(null, fields).ToList();
        }
    }
}