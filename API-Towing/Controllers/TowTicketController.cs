using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using API.Common;
using API.Common.Attributes;
using API.Common.Extensions;
using API_Towing.Models;
using ClussPro.Base.Data;
using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework;
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

            List<TowTicketViewModel> towTickets = new List<TowTicketViewModel>();
            foreach (TowTicket towTicket in towTicketSearch.GetReadOnlyReader(null, TowTicketViewModel.SEARCH_FIELDS))
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
                nameof(TowTicket.RespondingTime),
                $"{nameof(TowTicket.UserResponding)}.{nameof(WebModels.security.User.Username)}"
            });

            if (inProgressTicket == null)
            {
                return new GetStatusModel() { status = "none" };
            }

            return new GetStatusModel()
            {
                status = inProgressTicket.Status.ToString().ToLower(),
                responsetime = inProgressTicket.RespondingTime,
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

        [HttpPut]
        public IHttpActionResult TowComplete()
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
                    Value = (int)TowTicket.Statuses.ResponseEnRoute
                }));

            TowTicket inProgressTicket = towTicketSearch.GetEditable();
            if (inProgressTicket == null)
            {
                return NotFound();
            }

            using (ITransaction transaction = SQLProviderFactory.GenerateTransaction())
            {
                inProgressTicket.CompletionTime = DateTime.Now;
                inProgressTicket.Status = TowTicket.Statuses.History;
                if (!inProgressTicket.Save(transaction))
                {
                    return inProgressTicket.HandleFailedValidation(this);
                }

                string nextTowTicketNumber;
                while(true)
                {
                    nextTowTicketNumber = new Random().Next(1000, 999999).ToString();
                    Search<TowTicket> duplicateNumberSearch = new Search<TowTicket>(new StringSearchCondition<TowTicket>()
                    {
                        Field = nameof(TowTicket.TicketNumber),
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = nextTowTicketNumber
                    });

                    if (!duplicateNumberSearch.ExecuteExists(transaction))
                    {
                        break;
                    }
                }

                TowTicket rewardTicket = DataObjectFactory.Create<TowTicket>();
                rewardTicket.UserIDIssuedTo = inProgressTicket.UserIDResponding;
                rewardTicket.IssueDate = DateTime.Now;
                rewardTicket.TicketNumber = nextTowTicketNumber;
                rewardTicket.Status = TowTicket.Statuses.New;
                if (!rewardTicket.Save(transaction))
                {
                    return rewardTicket.HandleFailedValidation(this);
                }

                transaction.Commit();
            }

            return Ok();
        }

        [HttpGet]
        public List<TowTicketViewModel> GetTowableTickets()
        {
            Search<TowTicket> towTicketSearch = new Search<TowTicket>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
            new LongSearchCondition<TowTicket>()
            {
                Field = nameof(TowTicket.StatusCode),
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = (int)TowTicket.Statuses.Requested
            },
            new LongSearchCondition<TowTicket>()
            {
                Field = nameof(TowTicket.UserIDIssuedTo),
                SearchConditionType = SearchCondition.SearchConditionTypes.NotEquals,
                Value = UserID
            }));

            List<TowTicketViewModel> returnedResults = new List<TowTicketViewModel>();
            foreach(TowTicket ticket in towTicketSearch.GetReadOnlyReader(null, TowTicketViewModel.SEARCH_FIELDS))
            {
                returnedResults.Add(TowTicketViewModel.CreateFromTowTicket(ticket));
            }

            return returnedResults;
        }

        // TOWING-SIDE ACTIONS
        private static readonly string LETTERS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        [HttpPut]
        public IHttpActionResult StartTow(long? id)
        {
            Search<TowTicket> towTicketSearch = new Search<TowTicket>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new LongSearchCondition<TowTicket>()
                {
                    Field = nameof(TowTicket.TowTicketID),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = id
                },
                new LongSearchCondition<TowTicket>()
                {
                    Field = nameof(TowTicket.UserIDIssuedTo),
                    SearchConditionType = SearchCondition.SearchConditionTypes.NotEquals,
                    Value = UserID
                },
                new LongSearchCondition<TowTicket>()
                {
                    Field = nameof(TowTicket.StatusCode),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = (int)TowTicket.Statuses.Requested
                }));

            TowTicket newTicket = towTicketSearch.GetEditable();
            if (newTicket == null)
            {
                return NotFound();
            }

            using (ITransaction transaction = SQLProviderFactory.GenerateTransaction())
            {
                newTicket.Status = TowTicket.Statuses.ResponseEnRoute;
                newTicket.RespondingTime = DateTime.Now;
                if (!newTicket.Save(transaction))
                {
                    return newTicket.HandleFailedValidation(this);
                }

                string newAccessCode;
                while(true)
                {
                    newAccessCode = "";
                    for(int i = 0; i < 2; i++)
                    {
                        newAccessCode += LETTERS[new Random().Next(0, 26) - 1];
                    }

                    newAccessCode += (new Random().Next(1, 10) - 1).ToString();
                    Search<AccessCode> accessCodeSearch = new Search<AccessCode>(new StringSearchCondition<AccessCode>()
                    {
                        Field = nameof(AccessCode.Code),
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = newAccessCode
                    });

                    if (!accessCodeSearch.ExecuteExists(null))
                    {
                        break;
                    }
                }

                AccessCode accessCode = DataObjectFactory.Create<AccessCode>();
                accessCode.TowTicketID = newTicket.TowTicketID;
                accessCode.UserID = UserID;
                accessCode.Code = newAccessCode;
                if (!accessCode.Save(transaction))
                {
                    return accessCode.HandleFailedValidation(this);
                }

                transaction.Commit();
            }

            return Ok();
        }
    }
}