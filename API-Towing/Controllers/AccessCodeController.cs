using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using API.Common;
using API.Common.Attributes;
using API.Common.Extensions;
using ClussPro.Base.Data;
using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using WebModels.tow;

namespace API_Towing.Controllers
{
    public class AccessCodeController : ApiController
    {
        protected long UserID => (Request.Properties["SecurityProfile"] as SecurityProfile)?.UserID ?? 0L;

        [MesabrookAuthorization]
        [ProgramAccess("tow")]
        [HttpGet]
        public string Get()
        {
            Search<AccessCode> accessCodeSearch = new Search<AccessCode>(new LongSearchCondition<AccessCode>()
            {
                Field = nameof(AccessCode.UserID),
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = UserID
            });

            return accessCodeSearch.GetReadOnly(null, new string[] { nameof(AccessCode.Code) })?.Code ?? "[none]";
        }

        [MesabrookAuthorization]
        [ProgramAccess("tow")]
        [HttpPut]
        public IHttpActionResult Cancel()
        {
            Search<AccessCode> accessCodeSearch = new Search<AccessCode>(new LongSearchCondition<AccessCode>()
            {
                Field = nameof(AccessCode.UserID),
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = UserID
            });

            foreach(AccessCode accessCode in accessCodeSearch.GetEditableReader())
            {
                if (!accessCode.Delete())
                {
                    return accessCode.HandleFailedValidation(this);
                }
            }

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Verify([FromBody] string accessCode)
        {
            Search<AccessCode> codeToVerify = new Search<AccessCode>(new StringSearchCondition<AccessCode>()
            {
                Field = nameof(AccessCode.Code),
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = accessCode
            });

            AccessCode foundCode = codeToVerify.GetReadOnly(null, new string[] { nameof(AccessCode.TowTicketID), nameof(AccessCode.UserID) });
            if (foundCode == null)
            {
                return NotFound();
            }

            using (ITransaction transaction = SQLProviderFactory.GenerateTransaction())
            {
                TowTicket ticket = DataObject.GetEditableByPrimaryKey<TowTicket>(foundCode.TowTicketID, transaction, null);
                ticket.UserIDResponding = foundCode.UserID;
                ticket.RespondingTime = DateTime.Now;
                ticket.Status = TowTicket.Statuses.ResponseEnRoute;
                if (!ticket.Save(transaction))
                {
                    return ticket.HandleFailedValidation(this);
                }

                Search<AccessCode> codesToDelete = new Search<AccessCode>(new LongSearchCondition<AccessCode>()
                {
                    Field = "TowTicketID",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = ticket.TowTicketID
                });

                foreach(AccessCode code in codesToDelete.GetEditableReader(transaction))
                {
                    if (!code.Delete(transaction))
                    {
                        return code.HandleFailedValidation(this);
                    }
                }

                transaction.Commit();
            }

            return Ok();
        }
    }
}