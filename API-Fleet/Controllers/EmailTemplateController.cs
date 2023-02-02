using System.Collections.Generic;
using System.Web.Http;
using API.Common.Attributes;
using ClussPro.ObjectBasedFramework.DataSearch;
using WebModels.mesasys;

namespace API_Company.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess(new[] { "company", "gov" })]
    public class EmailTemplateController : ApiController
    {
        public EmailTemplate GetByName([FromUri]string name)
        {
            Search<EmailTemplate> emailTemplateSearch = new Search<EmailTemplate>(new StringSearchCondition<EmailTemplate>()
            {
                Field = nameof(EmailTemplate.Name),
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = name
            });

            List<string> fields = new List<string>()
            {
                nameof(EmailTemplate.EmailTemplateID),
                nameof(EmailTemplate.Name),
                nameof(EmailTemplate.TemplateSchema),
                nameof(EmailTemplate.TemplateObject),
                nameof(EmailTemplate.Template),
                nameof(EmailTemplate.AllowedFields)
            };
            return emailTemplateSearch.GetReadOnly(null, fields);
        }
    }
}