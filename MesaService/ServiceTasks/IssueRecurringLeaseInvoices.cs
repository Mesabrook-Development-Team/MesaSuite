using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClussPro.Base.Data;
using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Utility;
using WebModels.company;
using WebModels.fleet;
using WebModels.gov;
using WebModels.invoicing;

namespace MesaService.ServiceTasks
{
    internal class IssueRecurringLeaseInvoices : IServiceTask
    {
        public string Name => "Issue Recurring Lease Invoices";

        DateTime _nextRunTime = DateTime.Now;
        public DateTime NextRunTime => _nextRunTime;

        public bool Run()
        {
            Search<LeaseContract> contractSearch = new Search<LeaseContract>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new IntSearchCondition<LeaseContract>()
                {
                    Field = nameof(LeaseContract.RecurringAmountType),
                    SearchConditionType = SearchCondition.SearchConditionTypes.NotEquals,
                    Value = (int)LeaseBid.RecurringAmountTypes.None
                },
                new DateTimeSearchCondition<LeaseContract>()
                {
                    Field = nameof(LeaseContract.LeaseTimeEnd),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Null
                }));

            List<string> fields = FieldPathUtility.CreateFieldPathsAsList<LeaseContract>(lc => new List<object>()
            {
                lc.LeaseContractID, 
                lc.GovernmentIDLessee,
                lc.RecurringAmountType,
                lc.RecurringAmount,
                lc.LocationIDRecurringAmountSource,
                lc.LocationIDRecurringAmountDestination,

                lc.Railcar.CompanyIDOwner,
                lc.Railcar.GovernmentIDOwner,
                lc.Railcar.ReportingMark,
                lc.Railcar.ReportingNumber,

                lc.Locomotive.CompanyIDOwner,
                lc.Locomotive.GovernmentIDOwner,
                lc.Locomotive.ReportingMark,
                lc.Locomotive.ReportingNumber,

                lc.LeaseContractInvoices.First().IssueTime
            });

            foreach(LeaseContract contract in contractSearch.GetReadOnlyReader(null, fields))
            {
                if (!contract.LeaseContractInvoices?.Any() ?? false)
                {
                    continue;
                }

                LeaseContractInvoice lastIssueTime = contract.LeaseContractInvoices.OrderByDescending(x => x.IssueTime).FirstOrDefault();
                DateTime nextIssueTime;
                switch(contract.RecurringAmountType)
                {
                    case LeaseBid.RecurringAmountTypes.None:
                        continue;
                    case LeaseBid.RecurringAmountTypes.Biweekly:
                        nextIssueTime = lastIssueTime.IssueTime.AddDays(14);
                        break;
                    case LeaseBid.RecurringAmountTypes.Monthly:
                        nextIssueTime = lastIssueTime.IssueTime.AddMonths(1);
                        break;
                    case LeaseBid.RecurringAmountTypes.Quarterly:
                        nextIssueTime = lastIssueTime.IssueTime.AddMonths(3);
                        break;
                    case LeaseBid.RecurringAmountTypes.Daily:
                        nextIssueTime = lastIssueTime.IssueTime.AddDays(1);
                        break;
                    case LeaseBid.RecurringAmountTypes.Weekly:
                        nextIssueTime = lastIssueTime.IssueTime.AddDays(7);
                        break;
                    default: 
                        continue;
                }

                if (nextIssueTime <= DateTime.Now)
                {
                    using (ITransaction transaction = SQLProviderFactory.GenerateTransaction())
                    {
                        Invoice recurringInvoice = DataObjectFactory.Create<Invoice>();
                        recurringInvoice.GovernmentIDFrom = contract.Railcar?.GovernmentIDOwner ?? contract.Locomotive?.GovernmentIDOwner;
                        recurringInvoice.LocationIDFrom = contract.LocationIDRecurringAmountDestination;
                        recurringInvoice.GovernmentIDTo = contract.GovernmentIDLessee;
                        recurringInvoice.LocationIDTo = contract.LocationIDRecurringAmountSource;

                        string invoiceNumber = null;
                        if (recurringInvoice.GovernmentIDFrom != null)
                        {
                            Government government = DataObject.GetReadOnlyByPrimaryKey<Government>(recurringInvoice.GovernmentIDFrom, null, FieldPathUtility.CreateFieldPathsAsList<Government>(g => new List<object>() { g.InvoiceNumberPrefix, g.NextInvoiceNumber }));
                            invoiceNumber = string.Format("{0}{1}", government.InvoiceNumberPrefix, government.NextInvoiceNumber);
                        }
                        else if (recurringInvoice.LocationIDFrom != null)
                        {
                            Location location = DataObject.GetReadOnlyByPrimaryKey<Location>(recurringInvoice.LocationIDFrom, null, FieldPathUtility.CreateFieldPathsAsList<Location>(l => new List<object>() { l.InvoiceNumberPrefix, l.NextInvoiceNumber }));
                            invoiceNumber = string.Format("{0}{1}", location.InvoiceNumberPrefix, location.NextInvoiceNumber);
                        }

                        recurringInvoice.InvoiceNumber = invoiceNumber;
                        recurringInvoice.InvoiceDate = DateTime.Now;
                        recurringInvoice.DueDate = DateTime.Now.AddDays(7);
                        recurringInvoice.Description = "Recurring leasing contract invoice";
                        if (!recurringInvoice.Save(transaction))
                        {
                            return false;
                        }

                        InvoiceLine invoiceLine = DataObjectFactory.Create<InvoiceLine>();
                        invoiceLine.InvoiceID = recurringInvoice.InvoiceID;
                        invoiceLine.Description = "Lease for " + contract.Railcar?.ReportingMark + contract.Railcar?.ReportingNumber + contract.Locomotive?.ReportingMark + contract.Locomotive.ReportingNumber;
                        invoiceLine.Quantity = 1;
                        invoiceLine.UnitCost = contract.RecurringAmount;
                        invoiceLine.Total = contract.RecurringAmount;
                        if (!invoiceLine.Save(transaction))
                        {
                            return false;
                        }

                        recurringInvoice = DataObject.GetEditableByPrimaryKey<Invoice>(recurringInvoice.InvoiceID, transaction, null);
                        recurringInvoice.Status = Invoice.Statuses.Sent;
                        if (!recurringInvoice.Save(transaction, new List<Guid>() { Invoice.ValidationIDs.V_SentStatusValid }))
                        {
                            return false;
                        }

                        LeaseContractInvoice leaseContractInvoice = DataObjectFactory.Create<LeaseContractInvoice>();
                        leaseContractInvoice.LeaseContractID = contract.LeaseContractID;
                        leaseContractInvoice.InvoiceID = recurringInvoice.InvoiceID;
                        leaseContractInvoice.Type = LeaseContractInvoice.Types.Recurring;
                        leaseContractInvoice.IssueTime = DateTime.Now;
                        if (!leaseContractInvoice.Save(transaction))
                        {
                            return false;
                        }

                        transaction.Commit();
                    }
                }
            }

            return true;
        }
    }
}
