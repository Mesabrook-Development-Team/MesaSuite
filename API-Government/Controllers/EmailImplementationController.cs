using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using API.Common;
using API.Common.Attributes;
using API_Government.Attributes;
using ClussPro.ObjectBasedFramework;
using WebModels.mesasys;

namespace API_Government.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess("gov")]
    public class EmailImplementationController : DataObjectController<EmailImplementation>
    {
        public override IEnumerable<string> DefaultRetrievedFields => new string[]
        {
            nameof(EmailImplementation.EmailImplementationID),
            nameof(EmailImplementation.EmailTemplateID),
            nameof(EmailImplementation.FromName),
            nameof(EmailImplementation.FromEmail),
            nameof(EmailImplementation.To),
            nameof(EmailImplementation.Subject),
            nameof(EmailImplementation.Body)
        };

        private long? GovernmentID => long.TryParse(Request.Headers.GetValues("GovernmentID").FirstOrDefault(), out long governmentID) ? (long?)governmentID : null;

        [HttpGet]
        public override async Task<EmailImplementation> Get(long id)
        {
            EmailImplementation emailImplementation = await base.Get(id);
            EmailTemplate template = DataObject.GetReadOnlyByPrimaryKey<EmailTemplate>(emailImplementation.EmailTemplateID, null, new[] { nameof(EmailTemplate.SecurityCheckType) });
            if (!template.SecurityCheck(SecurityProfile.UserID, null, null, GovernmentID))
            {
                return null;
            }

            return emailImplementation;
        }

        [HttpPost]
        public override async Task<IHttpActionResult> Post(EmailImplementation dataObject)
        {
            EmailTemplate emailTemplate = DataObject.GetReadOnlyByPrimaryKey<EmailTemplate>(dataObject.EmailTemplateID, null, new string[] { nameof(EmailTemplate.SecurityCheckType) });
            if (emailTemplate == null || !emailTemplate.SecurityCheck(SecurityProfile.UserID, null, null, GovernmentID))
            {
                return Unauthorized(new AuthenticationHeaderValue[0]);
            }

            return await base.Post(dataObject);
        }

        [HttpPut]
        public override async Task<IHttpActionResult> Put(EmailImplementation dataObject)
        {
            EmailTemplate emailTemplate = DataObject.GetReadOnlyByPrimaryKey<EmailTemplate>(dataObject.EmailTemplateID, null, new string[] { nameof(EmailTemplate.SecurityCheckType) });
            if (emailTemplate == null || !emailTemplate.SecurityCheck(SecurityProfile.UserID, null, null, GovernmentID))
            {
                return Unauthorized(new AuthenticationHeaderValue[0]);
            }

            return await base.Post(dataObject);
        }

        [HttpDelete]
        public override IHttpActionResult Delete(long id)
        {
            EmailImplementation implementation = DataObject.GetReadOnlyByPrimaryKey<EmailImplementation>(id, null, new string[] { $"{nameof(EmailImplementation.EmailTemplate)}.{nameof(EmailTemplate.SecurityCheckType)}" });
            if (implementation == null || !implementation.EmailTemplate.SecurityCheck(SecurityProfile.UserID, null, null, GovernmentID))
            {
                return Unauthorized(new AuthenticationHeaderValue[0]);
            }

            return Delete(id);
        }

        [HttpPatch]
        public override async Task<IHttpActionResult> Patch(PatchData patchData)
        {
            EmailImplementation implementation = DataObject.GetReadOnlyByPrimaryKey<EmailImplementation>(patchData.PrimaryKey, null, new string[] { $"{nameof(EmailImplementation.EmailTemplate)}.{nameof(EmailTemplate.SecurityCheckType)}" });
            if (implementation == null || !implementation.EmailTemplate.SecurityCheck(SecurityProfile.UserID, null, null, GovernmentID))
            {
                return Unauthorized(new AuthenticationHeaderValue[0]);
            }

            return await base.Patch(patchData);
        }
    }
}