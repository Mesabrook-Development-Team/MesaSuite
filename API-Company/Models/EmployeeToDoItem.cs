using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using API.Common;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Schema;
using ClussPro.ObjectBasedFramework.Utility;
using WebModels.company;
using WebModels.invoicing;
using WebModels.purchasing;
using static API_Company.Controllers.EmployeeController;

namespace API_Company.Models
{
    public class EmployeeToDoItem
    {
        public enum Types
        {
            PayableInvoiceWaiting,
            ReceivableInvoiceWaiting,
            PayablePastDueInvoice,
            ReceivablePastDueInvoice,
            PurchaseOrderWaitingApproval,
            QuotationRequestWaiting,
            RailcarAwaitingAction,
            RegisterOffline
        }

        public Types Type { get; set; }
        public string Message { get; set; }
        public long? CompanyID { get; set; }
        public long? LocationID { get; set; }
        public long? SourceID { get; set; }

        public static async Task<List<EmployeeToDoItem>> GetForUserID(long userID)
        {
            Search<Employee> employeeRecordsForUser = new Search<Employee>(new LongSearchCondition<Employee>()
            {
                Field = nameof(Employee.UserID),
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = userID
            });
            List<string> fields = Schema.GetSchemaObject<Employee>().GetFields().Select(f => f.FieldName).Concat(
                                  Schema.GetSchemaObject<LocationEmployee>().GetFields().Select(f => nameof(Employee.LocationEmployees) + "." + f.FieldName)).ToList();

            List<Employee> employeeList = (await Task.Run(() => employeeRecordsForUser.GetReadOnlyReader(null, fields))).ToList();
            List<EmployeeToDoItem> toDoItems = new List<EmployeeToDoItem>();

            // Check Invoices
            if (employeeList.SelectMany(e => e.LocationEmployees).Any(le => le.ManageInvoices))
            {
                Search<Invoice> invoiceSearch = new Search<Invoice>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                    new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.Or,
                        new ExistsSearchCondition<Invoice>()
                        {
                            RelationshipName = FieldPathUtility.CreateFieldPath<Invoice>(i => i.LocationFrom.LocationEmployees),
                            ExistsType = ExistsSearchCondition<Invoice>.ExistsTypes.Exists,
                            Condition = new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                                new LongSearchCondition<LocationEmployee>()
                                {
                                    Field = FieldPathUtility.CreateFieldPath<LocationEmployee>(le => le.Employee.UserID),
                                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                                    Value = userID
                                },
                                new BooleanSearchCondition<LocationEmployee>()
                                {
                                    Field = nameof(LocationEmployee.ManageInventory),
                                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                                    Value = true
                                })
                        },
                        new ExistsSearchCondition<Invoice>()
                        {
                            RelationshipName = FieldPathUtility.CreateFieldPath<Invoice>(i => i.LocationTo.LocationEmployees),
                            ExistsType = ExistsSearchCondition<Invoice>.ExistsTypes.Exists,
                            Condition = new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                                new LongSearchCondition<LocationEmployee>()
                                {
                                    Field = FieldPathUtility.CreateFieldPath<LocationEmployee>(le => le.Employee.UserID),
                                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                                    Value = userID
                                },
                                new BooleanSearchCondition<LocationEmployee>()
                                {
                                    Field = nameof(LocationEmployee.ManageInventory),
                                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                                    Value = true
                                })
                        })));

                List<string> invoiceFields = FieldPathUtility.CreateFieldPathsAsList<Invoice>(i => new object[]
                {
                    i.InvoiceID,
                    i.LocationIDFrom,
                    i.LocationFrom.CompanyID,
                    i.LocationFrom.LocationEmployees.First().Employee.UserID,
                    i.LocationIDTo,
                    i.LocationTo.CompanyID,
                    i.LocationTo.LocationEmployees.First().Employee.UserID,
                    i.Status,
                    i.DueDate
                });

                foreach(Invoice invoice in invoiceSearch.GetReadOnlyReader(null, invoiceFields))
                {
                    switch(invoice.Status)
                    {
                        case Invoice.Statuses.Sent:
                            if (invoice.LocationTo.LocationEmployees.Any(le => le.Employee.UserID == userID))
                            {
                                toDoItems.Add(new EmployeeToDoItem()
                                {
                                    LocationID = invoice.LocationIDTo,
                                    CompanyID = invoice.LocationTo.CompanyID,
                                    SourceID = invoice.InvoiceID,
                                    Message = invoice.DueDate > DateTime.Now ?
                                                $"Invoice {invoice.InvoiceNumber} awaits payment" :
                                                $"Invoice {invoice.InvoiceNumber} is overdue",
                                    Type = invoice.DueDate > DateTime.Now ? Types.PayableInvoiceWaiting : Types.PayablePastDueInvoice
                                });
                            }
                            break;
                        case Invoice.Statuses.ReadyForReceipt:
                            if (invoice.LocationFrom.LocationEmployees.Any(le => le.Employee.UserID == userID))
                            {
                                toDoItems.Add(new EmployeeToDoItem()
                                {
                                    LocationID = invoice.LocationIDFrom,
                                    CompanyID = invoice.LocationFrom.CompanyID,
                                    SourceID = invoice.InvoiceID,
                                    Message = invoice.DueDate > DateTime.Now ?
                                                $"Invoice {invoice.InvoiceNumber} is waiting to be received" :
                                                $"Invoice {invoice.InvoiceNumber} is overdue and is waiting to be received",
                                    Type = invoice.DueDate > DateTime.Now ? Types.ReceivableInvoiceWaiting : Types.ReceivablePastDueInvoice
                                });
                            }
                            break;
                    }
                }
            }

            // Check Purchase Orders
            if (employeeList.SelectMany(e => e.LocationEmployees).Any(le => le.ManagePurchaseOrders))
            {
                Search<PurchaseOrderApproval> approvalSearch = new Search<PurchaseOrderApproval>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                    new ExistsSearchCondition<PurchaseOrderApproval>()
                    {
                        RelationshipName = FieldPathUtility.CreateFieldPath<PurchaseOrderApproval>(poa => poa.CompanyApprover.Employees),
                        ExistsType = ExistsSearchCondition<PurchaseOrderApproval>.ExistsTypes.Exists,
                        Condition = new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                            new LongSearchCondition<Employee>()
                            {
                                Field = nameof(Employee.UserID),
                                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                                Value = userID
                            },
                            new ExistsSearchCondition<Employee>()
                            {
                                RelationshipName = nameof(Employee.LocationEmployees),
                                ExistsType = ExistsSearchCondition<Employee>.ExistsTypes.Exists,
                                Condition = new BooleanSearchCondition<LocationEmployee>()
                                {
                                    Field = nameof(LocationEmployee.ManagePurchaseOrders),
                                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                                    Value = true
                                }
                            })
                    },
                    new IntSearchCondition<PurchaseOrderApproval>()
                    {
                        Field = nameof(PurchaseOrderApproval.ApprovalStatus),
                        SearchConditionType = SearchCondition.SearchConditionTypes.NotEquals,
                        Value = (int)PurchaseOrderApproval.ApprovalStatuses.Pending
                    }));


            }
        }
    }
}