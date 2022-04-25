using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using API.Common;
using API.Common.Attributes;
using API.Common.Extensions;
using API_Towing.Models;
using ClussPro.ObjectBasedFramework.DataSearch;
using WebModels.tow;

namespace API_Towing.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess("tow")]
    public class TowTicketController : ApiController
    {
        protected long UserID => ((SecurityProfile)Request.Properties["SecurityProfile"]).UserID;

        [HttpGet]
        public List<TowTicketViewModel> GetMyTickets()
        {
            Search<TowTicket> towTicketSearch = new Search<TowTicket>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new LongSearchCondition<TowTicket>()
                {
                    Field = nameof(TowTicket.UserIDIssuedTo),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = UserID
                },
                new IntSearchCondition<TowTicket>()
                {
                    Field = nameof(TowTicket.StatusCode),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = (int)TowTicket.Statuses.New
                }));

            string[] fields = new string[]
            {
                nameof(TowTicket.TowTicketID),
                $"{nameof(TowTicket.UserIssuedTo)}.{nameof(WebModels.security.User.Username)}",
                nameof(TowTicket.PhoneNumber),
                nameof(TowTicket.TicketNumber),
                nameof(TowTicket.IssueDate),
                nameof(TowTicket.CoordX),
                nameof(TowTicket.CoordZ),
                nameof(TowTicket.Description),
                $"{nameof(TowTicket.UserResponding)}.{nameof(WebModels.security.User.Username)}",
                nameof(TowTicket.StatusCode)
            };

            List<TowTicketViewModel> towTickets = new List<TowTicketViewModel>();
            foreach (TowTicket towTicket in towTicketSearch.GetReadOnlyReader(null, fields))
            {
                towTickets.Add(TowTicketViewModel.CreateFromTowTicket(towTicket));
            }

            return towTickets;
        }

        private static readonly HashSet<string> _requestTowFields = new HashSet<string>()
        {
            nameof(TowTicket.PhoneNumber),
            nameof(TowTicket.CoordX),
            nameof(TowTicket.CoordZ),
            nameof(TowTicket.Description)
        };

        [HttpPatch]
        public IHttpActionResult RequestTow(PatchData patchData)
        {
            

            Search<TowTicket> towTicketSearch = new Search<TowTicket>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new LongSearchCondition<TowTicket>()
                {
                    Field = nameof(TowTicket.TowTicketID),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = patchData.PrimaryKey
                },
                new LongSearchCondition<TowTicket>()
                {
                    Field = nameof(TowTicket.UserIDIssuedTo),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = UserID
                }));

            TowTicket towTicket = towTicketSearch.GetEditable();
            if (towTicket == null)
            {
                return NotFound();
            }

            towTicket.PatchData(patchData.Method, patchData.Values.Where(kvp => _requestTowFields.Contains(kvp.Key)).ToDictionary(kvp => kvp.Key, kvp => kvp.Value));
            towTicket.Status = TowTicket.Statuses.Requested;
            if (!towTicket.Save())
            {
                return towTicket.HandleFailedValidation(this);
            }

            return Ok();
        }

        [HttpGet]
        public GetStatusModel GetCurrentTicketStatus()
        {
            Search<TowTicket> towTicketSearch = new Search<TowTicket>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new LongSearchCondition<TowTicket>()
                {
                    Field = nameof(TowTicket.UserIDIssuedTo),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = UserID
                },
                new IntSearchCondition<TowTicket>()
                {
                    Field = nameof(TowTicket.StatusCode),
                    SearchConditionType = SearchCondition.SearchConditionTypes.List,
                    List = new List<int>()
                    {
                        (int)TowTicket.Statuses.Requested,
                        (int)TowTicket.Statuses.ResponseEnRoute
                    }
                }));

            TowTicket inProgressTicket = towTicketSearch.GetReadOnly(null, new string[]
            {
                nameof(TowTicket.StatusCode),
                $"{nameof(TowTicket.UserResponding)}.{nameof(WebModels.security.User.Username)}"
            });

            if (inProgressTicket == null)
            {
                return new GetStatusModel() { status = "none" };
            }

            return new GetStatusModel()
            {
                status = inProgressTicket.Status.ToString().ToLower(),
                responder = inProgressTicket.UserResponding?.Username
            };
        }

        [HttpPut]
        public IHttpActionResult CancelTowRequest()
        {
            Search<TowTicket> towTicketSearch = new Search<TowTicket>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new LongSearchCondition<TowTicket>()
                {
                    Field = nameof(TowTicket.UserIDIssuedTo),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = UserID
                },
                new IntSearchCondition<TowTicket>()
                {
                    Field = nameof(TowTicket.StatusCode),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = (int)TowTicket.Statuses.Requested
                }));

            TowTicket inProgressTicket = towTicketSearch.GetEditable();
            if (inProgressTicket == null)
            {
                return NotFound();
            }

            inProgressTicket.CoordX = null;
            inProgressTicket.CoordZ = null;
            inProgressTicket.Description = null;
            inProgressTicket.Status = TowTicket.Statuses.New;
            if (!inProgressTicket.Save())
            {
                return inProgressTicket.HandleFailedValidation(this);
            }

            return Ok(inProgressTicket);
        }
    }
}