using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using API.Common;
using API.Common.Attributes;
using API.Common.Extensions;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Utility;
using WebModels.fleet;

namespace API_Fleet.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess(new[] { "gov", "company" })]
    public class LeaseContractController : ApiController
    {
        private long? CompanyID
        {
            get
            {
                if (!Request.Headers.Contains("CompanyID"))
                {
                    return null;
                }

                return long.Parse(Request.Headers.GetValues("CompanyID").First());
            }
        }

        private long? GovernmentID
        {
            get
            {
                if (!Request.Headers.Contains("GovernmentID"))
                {
                    return null;
                }

                return long.Parse(Request.Headers.GetValues("GovernmentID").First());
            }
        }

        private static readonly List<string> LeaseContractFields = FieldPathUtility.CreateFieldPathsAsList<LeaseContract>(lc => new List<object>()
        {
            lc.LeaseContractID,
            lc.RailcarID,
            lc.Railcar.RailcarID,
            lc.Railcar.CompanyIDOwner,
            lc.Railcar.CompanyOwner.CompanyID,
            lc.Railcar.CompanyOwner.Name,
            lc.Railcar.GovernmentIDOwner,
            lc.Railcar.GovernmentOwner.GovernmentID,
            lc.Railcar.GovernmentOwner.Name,
            lc.Railcar.ReportingMark,
            lc.Railcar.ReportingNumber,
            lc.LocomotiveID,
            lc.Locomotive.LocomotiveID,
            lc.Locomotive.CompanyIDOwner,
            lc.Locomotive.CompanyOwner.CompanyID,
            lc.Locomotive.CompanyOwner.Name,
            lc.Locomotive.GovernmentIDOwner,
            lc.Locomotive.GovernmentOwner.GovernmentID,
            lc.Locomotive.GovernmentOwner.Name,
            lc.Locomotive.ReportingMark,
            lc.Locomotive.ReportingNumber,
            lc.CompanyIDLessee,
            lc.CompanyLessee.CompanyID,
            lc.CompanyLessee.Name,
            lc.GovernmentIDLessee,
            lc.GovernmentLessee.GovernmentID,
            lc.GovernmentLessee.Name,
            lc.Amount,
            lc.RecurringAmountType,
            lc.RecurringAmount,
            lc.Terms,
            lc.LocationIDRecurringAmountSource,
            lc.LocationIDRecurringAmountDestination,
            lc.LeaseTimeStart,
            lc.LeaseTimeEnd,
            lc.LeaseContractInvoices.First().LeaseContractInvoiceID,
            lc.LeaseContractInvoices.First().LeaseContractID,
            lc.LeaseContractInvoices.First().InvoiceID,
            lc.LeaseContractInvoices.First().Type,
            lc.LeaseContractInvoices.First().IssueTime,
            lc.LeaseContractInvoices.First().Invoice.InvoiceID,
            lc.LeaseContractInvoices.First().Invoice.Amount
        });

        private SearchConditionGroup GetBaseSearchCondition(long? companyID, long? governmentID) => new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.Or,
                new LongSearchCondition<LeaseContract>()
                {
                    Field = "Railcar.CompanyIDOwner",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = companyID ?? -1L
                },
                new LongSearchCondition<LeaseContract>()
                {
                    Field = "Railcar.GovernmentIDOwner",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = governmentID ?? -1L
                },
                new LongSearchCondition<LeaseContract>()
                {
                    Field = "Locomotive.CompanyIDOwner",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = companyID ?? -1L
                },
                new LongSearchCondition<LeaseContract>()
                {
                    Field = "Locomotive.GovernmentIDOwner",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = governmentID ?? -1L
                },
                new LongSearchCondition<LeaseContract>()
                {
                    Field = "CompanyIDLessee",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = companyID ?? -1L
                },
                new LongSearchCondition<LeaseContract>()
                {
                    Field = "GovernmentIDLessee",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = governmentID ?? -1L
                });

        [HttpPut]
        public IHttpActionResult CreateFromLeaseBid(CreateFromLeaseBidParameter parameter)
        {
            LeaseBid bid = DataObject.GetReadOnlyByPrimaryKey<LeaseBid>(parameter.leaseBidID, null, FieldPathUtility.CreateFieldPathsAsList<LeaseBid>(lb => new List<object>()
            {
                lb.LeaseRequest.CompanyIDRequester,
                lb.LeaseRequest.GovernmentIDRequester
            }));

            if (bid == null || bid.LeaseRequest == null)
            {
                return NotFound();
            }

            if ((bid.LeaseRequest.CompanyIDRequester != null && bid.LeaseRequest.CompanyIDRequester != CompanyID) || (bid.LeaseRequest.GovernmentIDRequester != null && bid.LeaseRequest.GovernmentIDRequester != GovernmentID))
            {
                return Unauthorized();
            }

            LeaseContract contract = LeaseContract.CreateContractFromBid(parameter.leaseBidID);
            if (contract == null)
            {
                return InternalServerError();
            }
            else if (contract.Errors.Any())
            {
                return contract.HandleFailedValidation(this);
            }
            else
            {
                return Ok(contract);
            }
        }

        public struct CreateFromLeaseBidParameter
        {
            public long? leaseBidID { get; set; }
        }

        [HttpGet]
        public List<LeaseContract> GetAll()
        {
            Search<LeaseContract> leaseContractSearch = new Search<LeaseContract>(GetBaseSearchCondition(CompanyID, GovernmentID));

            return leaseContractSearch.GetReadOnlyReader(null, LeaseContractFields).ToList();
        }

        [HttpGet]
        public LeaseContract Get(long? id)
        {
            Search<LeaseContract> leaseContractSearch = new Search<LeaseContract>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                GetBaseSearchCondition(CompanyID, GovernmentID),
                new LongSearchCondition<LeaseContract>()
                {
                    Field = nameof(LeaseContract.LeaseContractID),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = id
                }));

            return leaseContractSearch.GetReadOnly(null, LeaseContractFields);
        }

        [HttpPatch]
        public IHttpActionResult Patch(PatchData patchData)
        {
            LeaseContract contract = DataObject.GetEditableByPrimaryKey<LeaseContract>(patchData.PrimaryKey, null, null);
            if (contract == null)
            {
                return NotFound();
            }

            // We only allow patches to the LeaseEndTime
            object newEndTime = patchData.Values.FirstOrDefault(kvp => kvp.Key.Equals(nameof(LeaseContract.LeaseTimeEnd), StringComparison.OrdinalIgnoreCase)).Value;
            try
            {
                if (newEndTime != null)
                {
                    newEndTime = Convert.ChangeType(newEndTime, typeof(DateTime));
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Could not convert LeaseEndTime value");
            }

            contract.LeaseTimeEnd = (DateTime?)newEndTime;
            if (!contract.Save())
            {
                return contract.HandleFailedValidation(this);
            }

            return Ok();
        }
    }
}