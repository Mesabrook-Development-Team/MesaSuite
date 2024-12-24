using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using API.Common;
using ClussPro.Base.Extensions;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Schema;
using ClussPro.ObjectBasedFramework.Utility;
using WebModels.company;
using WebModels.fleet;
using WebModels.invoicing;
using WebModels.purchasing;
using static API_Company.Controllers.EmployeeController;

namespace API_Company.Models
{
    public class EmployeeToDoItem
    {
        public enum Types
        {
            PayableInvoiceWaiting = 0,
            ReceivableInvoiceWaiting,
            PayablePastDueInvoice,
            ReceivablePastDueInvoice,
            PurchaseOrderWaitingApproval,
            QuotationRequestWaiting,
            RailcarAwaitingAction,
            RegisterOffline,
            OpenPurchaseOrders
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
                                  Schema.GetSchemaObject<LocationEmployee>().GetFields().Select(f => nameof(Employee.LocationEmployees) + "." + f.FieldName)).Concat(
                                  Schema.GetSchemaObject<FleetSecurity>().GetFields().Select(f => nameof(Employee.FleetSecurity) + "." + f.FieldName)).ToList();

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
                                    Field = nameof(LocationEmployee.ManageInvoices),
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
                                    Field = nameof(LocationEmployee.ManageInvoices),
                                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                                    Value = true
                                })
                        }),
                    new IntSearchCondition<Invoice>()
                    {
                        Field = nameof(Invoice.Status),
                        SearchConditionType = SearchCondition.SearchConditionTypes.NotEquals,
                        Value = (int)Invoice.Statuses.Complete
                    }));

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
                    i.DueDate,
                    i.InvoiceNumber
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
                                                $"Payable Invoice {invoice.InvoiceNumber} awaits payment" :
                                                $"Payable Invoice {invoice.InvoiceNumber} is overdue",
                                    Type = invoice.DueDate > DateTime.Now ? Types.PayableInvoiceWaiting : Types.PayablePastDueInvoice
                                });
                            }
                            else if (invoice.LocationFrom.LocationEmployees.Any(le => le.Employee.UserID == userID) && invoice.DueDate < DateTime.Now)
                            {
                                toDoItems.Add(new EmployeeToDoItem()
                                {
                                    LocationID = invoice.LocationIDFrom,
                                    CompanyID = invoice.LocationFrom.CompanyID,
                                    SourceID = invoice.InvoiceID,
                                    Message = $"Receivable Invoice {invoice.InvoiceNumber} is overdue",
                                    Type = Types.ReceivablePastDueInvoice
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
                                                $"Receivable Invoice {invoice.InvoiceNumber} is waiting to be received" :
                                                $"Receivable Invoice {invoice.InvoiceNumber} is overdue and is waiting to be received",
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
                SearchConditionGroup employeeExistsForManagePOsCondition = new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
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
                            });

                SearchConditionGroup locationEmployeeExistsForManagePOsCondition = new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                    new LongSearchCondition<LocationEmployee>()
                    {
                        Field = FieldPathUtility.CreateFieldPath<LocationEmployee>(le => le.Employee.UserID),
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = userID
                    },
                    new BooleanSearchCondition<LocationEmployee>()
                    {
                        Field = nameof(LocationEmployee.ManagePurchaseOrders),
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = true
                    });
                

                // Purchase Order Approvals
                Search<PurchaseOrderApproval> approvalSearch = new Search<PurchaseOrderApproval>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                    new ExistsSearchCondition<PurchaseOrderApproval>()
                    {
                        RelationshipName = FieldPathUtility.CreateFieldPath<PurchaseOrderApproval>(poa => poa.CompanyApprover.Employees),
                        ExistsType = ExistsSearchCondition<PurchaseOrderApproval>.ExistsTypes.Exists,
                        Condition = employeeExistsForManagePOsCondition
                    },
                    new IntSearchCondition<PurchaseOrderApproval>()
                    {
                        Field = nameof(PurchaseOrderApproval.ApprovalStatus),
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = (int)PurchaseOrderApproval.ApprovalStatuses.Pending
                    }));

                List<string> approvalFields = FieldPathUtility.CreateFieldPathsAsList<PurchaseOrderApproval>(poa => new object[]
                {
                    poa.CompanyIDApprover,
                    poa.PurchaseOrderID
                });

                foreach(PurchaseOrderApproval approval in approvalSearch.GetReadOnlyReader(null, approvalFields))
                {
                    toDoItems.Add(new EmployeeToDoItem()
                    {
                        CompanyID = approval.CompanyIDApprover,
                        SourceID = approval.PurchaseOrderID,
                        Type = Types.PurchaseOrderWaitingApproval,
                        Message = $"Purchase Order {approval.PurchaseOrderID} is waiting for your approval"
                    });
                }

                // Purchase Orders
                Search<PurchaseOrder> purchaseOrderSearch = new Search<PurchaseOrder>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                    new ExistsSearchCondition<PurchaseOrder>()
                    {
                        RelationshipName = FieldPathUtility.CreateFieldPath<PurchaseOrder>(po => po.LocationDestination.LocationEmployees),
                        ExistsType = ExistsSearchCondition<PurchaseOrder>.ExistsTypes.Exists,
                        Condition = locationEmployeeExistsForManagePOsCondition
                    },
                    new IntSearchCondition<PurchaseOrder>()
                    {
                        Field = nameof(PurchaseOrder.Status),
                        SearchConditionType = SearchCondition.SearchConditionTypes.List,
                        List = new List<int>() { (int)PurchaseOrder.Statuses.Accepted, (int)PurchaseOrder.Statuses.InProgress }
                    }));

                Dictionary<long?, int> purchaseOrdersByLocation = new Dictionary<long?, int>();
                foreach(PurchaseOrder purchaseOrder in purchaseOrderSearch.GetReadOnlyReader(null, FieldPathUtility.CreateFieldPathsAsList<PurchaseOrder>(po => new object[] { po.LocationIDDestination })))
                {
                    purchaseOrdersByLocation.GetOrSet(purchaseOrder.LocationIDDestination, () => 0);
                    purchaseOrdersByLocation[purchaseOrder.LocationIDDestination]++;
                }

                foreach(KeyValuePair<long?, int> countByLocationID in purchaseOrdersByLocation)
                {
                    toDoItems.Add(new EmployeeToDoItem()
                    {
                        CompanyID = employeeList.Where(e => e.LocationEmployees.Any(l => l.LocationID == countByLocationID.Key)).First().CompanyID,
                        LocationID = countByLocationID.Key,
                        Type = Types.OpenPurchaseOrders,
                        Message = $"You have {countByLocationID.Value} open Purchase Order(s)"
                    });
                }

                // Quotation Requests
                Search<QuotationRequest> quotationRequestSearch = new Search<QuotationRequest>(
                    new ExistsSearchCondition<QuotationRequest>()
                    {
                        RelationshipName = FieldPathUtility.CreateFieldPath<QuotationRequest>(qr => qr.CompanyTo.Employees),
                        ExistsType = ExistsSearchCondition<QuotationRequest>.ExistsTypes.Exists,
                        Condition = employeeExistsForManagePOsCondition
                    });

                List<string> quotationRequestFields = FieldPathUtility.CreateFieldPathsAsList<QuotationRequest>(qr => new object[]
                {
                    qr.QuotationRequestID,
                    qr.CompanyIDTo,
                    qr.CompanyFrom.Name,
                    qr.GovernmentFrom.Name,
                    qr.QuotationRequestItems.First().QuotationRequestItemID
                });

                foreach(QuotationRequest quotationRequest in quotationRequestSearch.GetReadOnlyReader(null, quotationRequestFields))
                {
                    toDoItems.Add(new EmployeeToDoItem()
                    {
                        CompanyID = quotationRequest.CompanyIDTo,
                        SourceID = quotationRequest.QuotationRequestID,
                        Type = Types.QuotationRequestWaiting,
                        Message = $"Quotation Request from {quotationRequest.CompanyFrom?.Name}{quotationRequest.GovernmentFrom.Name} for {quotationRequest.QuotationRequestItems?.Count ?? 0} item(s) is awaiting response"
                    });
                }

                // Railcars that need attention
                Search<Railcar> railcarSearch = new Search<Railcar>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.Or,
                    new ExistsSearchCondition<Railcar>()
                    {
                        RelationshipName = nameof(Railcar.FulfillmentPlans),
                        ExistsType = ExistsSearchCondition<Railcar>.ExistsTypes.Exists,
                        Condition = new ExistsSearchCondition<FulfillmentPlan>()
                        {
                            RelationshipName = nameof(FulfillmentPlan.FulfillmentPlanPurchaseOrderLines),
                            ExistsType = ExistsSearchCondition<FulfillmentPlan>.ExistsTypes.Exists,
                            Condition = new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                                new IntSearchCondition<FulfillmentPlanPurchaseOrderLine>()
                                {
                                    Field = FieldPathUtility.CreateFieldPathsAsList<FulfillmentPlanPurchaseOrderLine>(fppol => new List<object>() { fppol.PurchaseOrderLine.PurchaseOrder.Status }).First(),
                                    SearchConditionType = SearchCondition.SearchConditionTypes.List,
                                    List = new List<int>() { (int)PurchaseOrder.Statuses.Accepted, (int)PurchaseOrder.Statuses.InProgress }
                                },
                                new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.Or,
                                    new ExistsSearchCondition<FulfillmentPlanPurchaseOrderLine>()
                                    {
                                        RelationshipName = FieldPathUtility.CreateFieldPathsAsList<FulfillmentPlanPurchaseOrderLine>(fppol => new List<object>() { fppol.PurchaseOrderLine.PurchaseOrder.LocationOrigin.LocationEmployees }).First(),
                                        ExistsType = ExistsSearchCondition<FulfillmentPlanPurchaseOrderLine>.ExistsTypes.Exists,
                                        Condition = locationEmployeeExistsForManagePOsCondition
                                    },
                                    new ExistsSearchCondition<FulfillmentPlanPurchaseOrderLine>()
                                    {
                                        RelationshipName = FieldPathUtility.CreateFieldPathsAsList<FulfillmentPlanPurchaseOrderLine>(fppol => new List<object>() { fppol.PurchaseOrderLine.PurchaseOrder.LocationDestination.LocationEmployees }).First(),
                                        ExistsType = ExistsSearchCondition<FulfillmentPlanPurchaseOrderLine>.ExistsTypes.Exists,
                                        Condition = locationEmployeeExistsForManagePOsCondition
                                    }))
                        }
                    },
                    new ExistsSearchCondition<Railcar>()
                    {
                        RelationshipName = nameof(Railcar.RailcarLoads),
                        ExistsType = ExistsSearchCondition<Railcar>.ExistsTypes.Exists,
                        Condition = new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.Or,
                            new ExistsSearchCondition<RailcarLoad>()
                            {
                                RelationshipName = FieldPathUtility.CreateFieldPathsAsList<RailcarLoad>(rl => new List<object>() { rl.PurchaseOrderLine.PurchaseOrder.LocationOrigin.LocationEmployees }).First(),
                                ExistsType = ExistsSearchCondition<RailcarLoad>.ExistsTypes.Exists,
                                Condition = locationEmployeeExistsForManagePOsCondition
                            },
                            new ExistsSearchCondition<RailcarLoad>()
                            {
                                RelationshipName = FieldPathUtility.CreateFieldPathsAsList<RailcarLoad>(rl => new List<object>() { rl.PurchaseOrderLine.PurchaseOrder.LocationDestination.LocationEmployees }).First(),
                                ExistsType = ExistsSearchCondition<RailcarLoad>.ExistsTypes.Exists,
                                Condition = locationEmployeeExistsForManagePOsCondition
                            })
                    }),
                new ExistsSearchCondition<Railcar>()
                {
                    RelationshipName = FieldPathUtility.CreateFieldPathsAsList<Railcar>(r => new List<object>() { r.RailLocation.Track.CompanyOwner.Employees }).First(),
                    ExistsType = ExistsSearchCondition<Railcar>.ExistsTypes.Exists,
                    Condition = employeeExistsForManagePOsCondition
                },
                new ExistsSearchCondition<Railcar>()
                {
                    RelationshipName = FieldPathUtility.CreateFieldPath<Railcar>(r => r.CompanyPossessor.Employees),
                    ExistsType = ExistsSearchCondition<Railcar>.ExistsTypes.Exists,
                    Condition = employeeExistsForManagePOsCondition
                }));

                List<string> railcarFields = FieldPathUtility.CreateFieldPathsAsList<Railcar>(r => new object[]
                {
                    r.FulfillmentPlans.First().FulfillmentPlanPurchaseOrderLines.First().PurchaseOrderLine.PurchaseOrder.LocationIDDestination,
                    r.FulfillmentPlans.First().FulfillmentPlanPurchaseOrderLines.First().PurchaseOrderLine.PurchaseOrder.LocationDestination.CompanyID,
                    r.FulfillmentPlans.First().FulfillmentPlanPurchaseOrderLines.First().PurchaseOrderLine.PurchaseOrder.LocationIDOrigin,
                    r.FulfillmentPlans.First().FulfillmentPlanPurchaseOrderLines.First().PurchaseOrderLine.PurchaseOrder.LocationOrigin.CompanyID,
                    r.FulfillmentPlans.First().FulfillmentPlanPurchaseOrderLines.First().PurchaseOrderLine.PurchaseOrder.Status,
                    r.RailcarLoads.First().PurchaseOrderLine.PurchaseOrder.LocationIDDestination,
                    r.RailcarLoads.First().PurchaseOrderLine.PurchaseOrder.LocationDestination.CompanyID,
                    r.RailcarLoads.First().PurchaseOrderLine.PurchaseOrder.LocationIDOrigin,
                    r.RailcarLoads.First().PurchaseOrderLine.PurchaseOrder.LocationOrigin.CompanyID,
                    r.CompanyIDPossessor
                });

                List<Railcar> railcars = railcarSearch.GetReadOnlyReader(null, railcarFields).ToList();
                Dictionary<long?, int> railcarCountByLocationID = new Dictionary<long?, int>();
                foreach(Railcar railcar in railcars)
                {
                    PurchaseOrder openPurchaseOrderForRailcar = railcar.FulfillmentPlans?.Select(fp => fp.FulfillmentPlanPurchaseOrderLines?.FirstOrDefault(fppol => fppol.PurchaseOrderLine?.PurchaseOrder?.Status == PurchaseOrder.Statuses.InProgress || fppol.PurchaseOrderLine?.PurchaseOrder?.Status == PurchaseOrder.Statuses.Accepted)?.PurchaseOrderLine.PurchaseOrder).FirstOrDefault();
                    if (openPurchaseOrderForRailcar == null || !employeeList.Any(e => e.LocationEmployees.Any(le => le.ManagePurchaseOrders && (le.LocationID == openPurchaseOrderForRailcar.LocationIDOrigin || le.LocationID == openPurchaseOrderForRailcar.LocationIDDestination))))
                    {
                        openPurchaseOrderForRailcar = railcar.RailcarLoads?.FirstOrDefault(rl => employeeList.Any(e => e.LocationEmployees.Any(el => el.ManagePurchaseOrders && (el.LocationID == rl.PurchaseOrderLine?.PurchaseOrder?.LocationIDDestination || el.LocationID == rl.PurchaseOrderLine?.PurchaseOrder?.LocationIDOrigin))))?.PurchaseOrderLine?.PurchaseOrder;
                    }

                    if (openPurchaseOrderForRailcar == null || railcar.CompanyIDPossessor == null)
                    {
                        continue;
                    }

                    long? locationID = openPurchaseOrderForRailcar.LocationOrigin.CompanyID == railcar.CompanyIDPossessor ? openPurchaseOrderForRailcar.LocationIDOrigin : openPurchaseOrderForRailcar.LocationIDDestination;
                    if (!employeeList.FirstOrDefault(e => e.CompanyID == railcar.CompanyIDPossessor)?.LocationEmployees.Any(le => le.LocationID == locationID && le.ManagePurchaseOrders) ?? false)
                    {
                        continue;
                    }

                    railcarCountByLocationID.GetOrSet(locationID, () => 0);
                    railcarCountByLocationID[locationID]++;
                }

                foreach (KeyValuePair<long?, int> countByLocationID in railcarCountByLocationID)
                {
                    if (countByLocationID.Value <= 0)
                    {
                        continue;
                    }

                    toDoItems.Add(new EmployeeToDoItem()
                    {
                        CompanyID = employeeList.Where(e => e.LocationEmployees.Any(le => le.LocationID == countByLocationID.Key)).FirstOrDefault().CompanyID,
                        LocationID = countByLocationID.Key,
                        Type = Types.RailcarAwaitingAction,
                        Message = $"You have {countByLocationID.Value} railcar(s) on your property awaiting action"
                    });
                }
            }

            // Check registers
            if (employeeList.Any(e => e.LocationEmployees.Any(el => el.ManageRegisters)))
            {
                Search<Register> registerSearch = new Search<Register>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                    new IntSearchCondition<Register>()
                    {
                        Field = FieldPathUtility.CreateFieldPath<Register>(r => r.CurrentStatus.Status),
                        SearchConditionType = SearchCondition.SearchConditionTypes.NotEquals,
                        Value = (int)RegisterStatus.Statuses.Online
                    },
                    new ExistsSearchCondition<Register>()
                    {
                        RelationshipName = FieldPathUtility.CreateFieldPath<Register>(r => r.Location.LocationEmployees),
                        ExistsType = ExistsSearchCondition<Register>.ExistsTypes.Exists,
                        Condition = new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                            new LongSearchCondition<LocationEmployee>()
                            {
                                Field = FieldPathUtility.CreateFieldPath<LocationEmployee>(le => le.Employee.UserID),
                                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                                Value = userID
                            },
                            new BooleanSearchCondition<LocationEmployee>()
                            {
                                Field = nameof(LocationEmployee.ManageRegisters),
                                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                                Value = true
                            })
                    }));

                foreach(Register register in registerSearch.GetReadOnlyReader(null, new[] { nameof(Register.RegisterID), nameof(Register.LocationID), nameof(Register.Location) + "." + nameof(Location.CompanyID), nameof(Register.Name)}))
                {
                    toDoItems.Add(new EmployeeToDoItem()
                    {
                        CompanyID = register.Location.CompanyID,
                        LocationID = register.LocationID,
                        SourceID = register.RegisterID,
                        Type = Types.RegisterOffline,
                        Message = $"Register {register.Name} is reporting offline"
                    });
                }
            }

            return toDoItems;
        }
    }
}