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
                nameof(TowTicket.TicketNumber),
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
                ticketnumber = inProgressTicket.TicketNumber,
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

            TowTicket inProgressTicket;
            using (ITransaction transaction = SQLProviderFactory.GenerateTransaction())
            {
                inProgressTicket = towTicketSearch.GetEditable(transaction);
                if (inProgressTicket == null)
                {
                    return NotFound();
                }

                inProgressTicket.CoordX = null;
                inProgressTicket.CoordZ = null;
                inProgressTicket.Description = null;
                inProgressTicket.Status = TowTicket.Statuses.New;
                if (!inProgressTicket.Save(transaction))
                {
                    return inProgressTicket.HandleFailedValidation(this);
                }

                Search<AccessCode> accessCodesSearch = new Search<AccessCode>(new LongSearchCondition<AccessCode>()
                {
                    Field = nameof(AccessCode.TowTicketID),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = inProgressTicket.TowTicketID
                });

                foreach (AccessCode accessCode in accessCodesSearch.GetEditableReader())
                {
                    if (!accessCode.Delete(transaction))
                    {
                        return accessCode.HandleFailedValidation(this);
                    }
                }

                transaction.Commit();
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

            string newAccessCode;
            while(true)
            {
                Random rand = new Random();

                newAccessCode = "";
                for(int i = 0; i < 2; i++)
                {
                    newAccessCode += LETTERS[rand.Next(0, 26)];
                }

                newAccessCode += (rand.Next(0, 10)).ToString();
                newAccessCode += (rand.Next(0, 10)).ToString();
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
            if (!accessCode.Save())
            {
                return accessCode.HandleFailedValidation(this);
            }

            return Ok();
        }

        [HttpGet]
        public GetStatusModel GetTowingStatus()
        {
            Search<TowTicket> towingTicketSearch = new Search<TowTicket>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new LongSearchCondition<TowTicket>()
                {
                    Field = nameof(TowTicket.UserIDResponding),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = UserID
                },
                new IntSearchCondition<TowTicket>()
                {
                    Field = nameof(TowTicket.StatusCode),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = (int)TowTicket.Statuses.ResponseEnRoute
                }));

            TowTicket towingTicket = towingTicketSearch.GetReadOnly(null, new string[]
            {
                nameof(TowTicket.TicketNumber),
                nameof(TowTicket.StatusCode),
                $"{nameof(TowTicket.UserResponding)}.{nameof(WebModels.security.User.Username)}",
                nameof(TowTicket.RespondingTime)
            });

            if (towingTicket == null)
            {
                return new GetStatusModel() { status = "none" };
            }

            return new GetStatusModel()
            {
                ticketnumber = towingTicket.TicketNumber,
                status = towingTicket.Status.ToString(),
                responder = towingTicket.UserResponding?.Username ?? string.Empty,
                responsetime = towingTicket.RespondingTime
            };
        }

        [HttpGet]
        public TowTicketViewModel GetByNumber(string id)
        {
            Search<TowTicket> towTicketSearch = new Search<TowTicket>(new StringSearchCondition<TowTicket>()
            {
                Field = nameof(TowTicket.TicketNumber),
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = id
            });

            TowTicket ticket = towTicketSearch.GetReadOnly(null, TowTicketViewModel.SEARCH_FIELDS);
            if (ticket == null)
            {
                return null;
            }

            return TowTicketViewModel.CreateFromTowTicket(ticket);
        }

        [HttpGet]
        public TowTicketViewModel GetByAccessCode(string id)
        {
            Search<TowTicket> towTicketSearch = new Search<TowTicket>(new ExistsSearchCondition<TowTicket>()
            {
                ExistsType = ExistsSearchCondition<TowTicket>.ExistsTypes.Exists,
                RelationshipName = nameof(TowTicket.AccessCodes),
                Condition = new StringSearchCondition<AccessCode>()
                {
                    Field = nameof(AccessCode.Code),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = id
                }
            });

            TowTicket foundTicket = towTicketSearch.GetReadOnly(null, TowTicketViewModel.SEARCH_FIELDS);
            if (foundTicket == null)
            {
                return null;
            }

            return TowTicketViewModel.CreateFromTowTicket(foundTicket);
        }

        // HISTORY ACTIONS
        public List<TowTicketViewModel> GetHistorical()
        {
            Search<TowTicket> towTicketSearch = new Search<TowTicket>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.Or,
                    new LongSearchCondition<TowTicket>()
                    {
                        Field = nameof(TowTicket.UserIDIssuedTo),
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = UserID
                    },
                    new LongSearchCondition<TowTicket>()
                    {
                        Field = nameof(TowTicket.UserIDResponding),
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = UserID
                    }),
                new IntSearchCondition<TowTicket>()
                {
                    Field = nameof(TowTicket.StatusCode),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = (int)TowTicket.Statuses.History
                }));

            List<TowTicketViewModel> viewModels = new List<TowTicketViewModel>();
            foreach(TowTicket ticket in towTicketSearch.GetReadOnlyReader(null, TowTicketViewModel.SEARCH_FIELDS))
            {
                viewModels.Add(TowTicketViewModel.CreateFromTowTicket(ticket));
            }

            return viewModels;
        }
    }
}