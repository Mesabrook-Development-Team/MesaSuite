using API.Common.Attributes;
using API.Common.Extensions;
using ClussPro.Base.Data;
using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using System.Web.Http;
using System.Web.Http.Cors;
using WebModels.mesasys;

namespace API_System.Controllers
{
    public class TermsOfServiceController : ApiController
    {
#if DEBUG
        [EnableCors("*", "*", "*")]
#else
        [EnableCors("https://mesabrook.com,https://www.mesabrook.com", "*", "*")]
#endif
        [HttpGet]
        public string Get(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }

            IntSearchCondition<TermsOfService> searchCondition;
            switch(id.ToLower())
            {
                case "mesabrook":
                    searchCondition = new IntSearchCondition<TermsOfService>()
                    {
                        Field = nameof(TermsOfService.Type),
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = (int)TermsOfService.Types.MesabrookServer
                    };
                    break;
                case "mesasuite":
                    searchCondition = new IntSearchCondition<TermsOfService>()
                    {
                        Field = nameof(TermsOfService.Type),
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = (int)TermsOfService.Types.MesaSuite
                    };
                    break;
                default:
                    return null;
            }

            Search<TermsOfService> termsSearch = new Search<TermsOfService>(searchCondition);
            return termsSearch.GetReadOnly(null, new[] { nameof(TermsOfService.Terms) })?.Terms;
        }

        [MesabrookAuthorization]
        [ProgramAccess("system")]
        [HttpPost]
        public IHttpActionResult Post(TermsOfService termsOfService)
        {
            if (termsOfService == null)
            {
                return BadRequest("A value is required to post");
            }

            Search<TermsOfService> existingSearch = new Search<TermsOfService>(new IntSearchCondition<TermsOfService>()
            {
                Field = nameof(TermsOfService.Type),
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = (int)termsOfService.Type
            });

            using (ITransaction transaction = SQLProviderFactory.GenerateTransaction())
            {
                TermsOfService terms = existingSearch.GetEditable();
                if (terms != null && !terms.Delete(transaction))
                {
                    return terms.HandleFailedValidation(this);
                }

                TermsOfService newTerms = DataObjectFactory.Create<TermsOfService>();
                newTerms.Type = termsOfService.Type;
                newTerms.Terms = termsOfService.Terms;
                if (!newTerms.Save(transaction))
                {
                    return terms.HandleFailedValidation(this);
                }

                transaction.Commit();
            }

            return Ok();
        }
    }
}
