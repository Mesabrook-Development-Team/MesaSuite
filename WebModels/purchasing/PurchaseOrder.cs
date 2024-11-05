using ClussPro.Base.Data;
using ClussPro.Base.Data.Query;
using ClussPro.Base.Extensions;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Utility;
using ClussPro.ObjectBasedFramework.Validation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebModels.company;
using WebModels.fleet;
using WebModels.gov;
using WebModels.hMailServer.Validations.Conditions;
using WebModels.invoicing;

namespace WebModels.purchasing
{
    [Table("1D36A22A-14A1-4D70-B413-F5FCAF3C1B87")]
    public class PurchaseOrder : DataObject
    {
        protected PurchaseOrder() : base() { }

        private long? _purchaseOrderID;
        [Field("F9C0C9E3-8F6B-4F6F-8D8F-6F8D8F8D8F8D")]
        public long? PurchaseOrderID
        {
            get { CheckGet(); return _purchaseOrderID; }
            set { CheckGet(); _purchaseOrderID = value; }
        }

        private long? _locationIDOrigin;
        [Field("914E2A3E-D966-47AA-9F0F-281685E0109E")]
        public long? LocationIDOrigin
        {
            get { CheckGet(); return _locationIDOrigin; }
            set { CheckGet(); _locationIDOrigin = value; }
        }

        private Location _locationOrigin = null;
        [Relationship("F8F74C15-F8A7-48F2-9101-202F5B31253E", ForeignKeyField = nameof(LocationIDOrigin))]
        public Location LocationOrigin
        {
            get { CheckGet(); return _locationOrigin; }
        }

        private long? _governmentIDOrigin;
        [Field("8AA90984-AF2D-485B-8BE1-5F446CEF504C")]
        public long? GovernmentIDOrigin
        {
            get { CheckGet(); return _governmentIDOrigin; }
            set { CheckGet(); _governmentIDOrigin = value; }
        }

        private Government _governmentOrigin = null;
        [Relationship("A3512448-6DCC-49B7-83EA-5883696C699B", ForeignKeyField = nameof(GovernmentIDOrigin))]
        public Government GovernmentOrigin
        {
            get { CheckGet(); return _governmentOrigin; }
        }

        private long? _locationIDDestination;
        [Field("55694D3A-8BBA-4F95-9884-45A85D9B8051")]
        public long? LocationIDDestination
        {
            get { CheckGet(); return _locationIDDestination; }
            set { CheckGet(); _locationIDDestination = value; }
        }

        private Location _locationDestination = null;
        [Relationship("BB019C65-99CD-40BA-A9F6-F0283D02FCC3", ForeignKeyField = nameof(LocationIDDestination))]
        public Location LocationDestination
        {
            get { CheckGet(); return _locationDestination; }
        }

        private long? _governmentIDDestination;
        [Field("94970F64-69D2-42AE-BD76-22700EE35591")]
        public long? GovernmentIDDestination
        {
            get { CheckGet(); return _governmentIDDestination; }
            set { CheckGet(); _governmentIDDestination = value; }
        }

        private Government _governmentDestination = null;
        [Relationship("F79988B1-0395-4CB1-BA08-C37AC1B59A8F", ForeignKeyField = nameof(GovernmentIDDestination))]
        public Government GovernmentDestination
        {
            get { CheckGet(); return _governmentDestination; }
        }

        private DateTime? _purchaseOrderDate;
        [Field("5E4FEF5E-887B-4DC8-B1C3-1F9A33ABC4CD", DataSize = 7)]
        public DateTime? PurchaseOrderDate
        {
            get { CheckGet(); return _purchaseOrderDate; }
            set { CheckGet(); _purchaseOrderDate = value; }
        }

        public enum Statuses
        {
            Draft,
            Pending,
            Accepted,
            Rejected,
            InProgress,
            Completed
        }

        private Statuses _status;
        [Field("A50DF475-536B-4219-91C9-62C5729A8DDC")]
        public Statuses Status
        {
            get { CheckGet(); return _status; }
            set { CheckGet(); _status = value; }
        }

        private string _description;
        [Field("A977CA7B-98F4-4B01-85E0-BBF99106F4CA", DataSize = 250)]
        [Required]
        public string Description
        {
            get { CheckGet(); return _description; }
            set { CheckGet(); _description = value; }
        }

        public enum InvoiceSchedules
        {
            UponShipment,
            UponDelivery,
            Manual
        }

        private InvoiceSchedules _invoiceSchedule = InvoiceSchedules.UponShipment;
        [Field("CCD7C290-82AB-404E-B47B-67937F1EF6E0")]
        public InvoiceSchedules InvoiceSchedule
        {
            get { CheckGet(); return _invoiceSchedule; }
            set { CheckGet(); _invoiceSchedule = value; }
        }

        public async Task<bool> Submit(ITransaction transaction = null)
        {
            ITransaction localTransaction = transaction;

            try
            {
                if (localTransaction == null)
                {
                    localTransaction = SQLProviderFactory.GenerateTransaction();
                }

                if (Status != PurchaseOrder.Statuses.Draft)
                {
                    Errors.Add("Status", "Purchase Order must be in Draft status to be submitted");
                    return false;
                }

                if (!await UpdatePrices(localTransaction))
                {
                    return false;
                }

                Status = PurchaseOrder.Statuses.Pending;
                PurchaseOrderDate = DateTime.Now;
                if (!await Task.Run(() => Save(localTransaction, new List<Guid>() { PurchaseOrder.SaveFlags.V_StatusChange })))
                {
                    return false;
                }

                PurchaseOrderApproval recipientApproval = DataObjectFactory.Create<PurchaseOrderApproval>();
                recipientApproval.PurchaseOrderID = PurchaseOrderID;
                recipientApproval.CompanyIDApprover = LocationDestination?.CompanyID;
                recipientApproval.GovernmentIDApprover = GovernmentIDDestination;
                recipientApproval.ApprovalPurpose = PurchaseOrderApproval.DESTINATION_PURPOSE;
                recipientApproval.ApprovalStatus = PurchaseOrderApproval.ApprovalStatuses.Pending;
                if (!await Task.Run(() => recipientApproval.Save(localTransaction)))
                {
                    Errors.AddRange(recipientApproval.Errors.ToArray());
                    return false;
                }

                Search<FulfillmentPlanRoute> routeSearch = new Search<FulfillmentPlanRoute>(new ExistsSearchCondition<FulfillmentPlanRoute>()
                {
                    RelationshipName = FieldPathUtility.CreateFieldPathsAsList<FulfillmentPlanRoute>(fpr => new List<object>() { fpr.FulfillmentPlan.FulfillmentPlanPurchaseOrderLines }).First(),
                    ExistsType = ExistsSearchCondition<FulfillmentPlanRoute>.ExistsTypes.Exists,
                    Condition = new LongSearchCondition<FulfillmentPlanPurchaseOrderLine>()
                    {
                        Field = FieldPathUtility.CreateFieldPathsAsList<FulfillmentPlanPurchaseOrderLine>(fppol => new List<object>() { fppol.PurchaseOrderLine.PurchaseOrderID }).First(),
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = PurchaseOrderID
                    }
                });

                HashSet<long?> companyIDRoutes = new HashSet<long?>();
                HashSet<long?> governmentIDRoutes = new HashSet<long?>();
                List<string> routeFields = FieldPathUtility.CreateFieldPathsAsList<FulfillmentPlanRoute>(fpr => new List<object>()
                {
                    fpr.CompanyIDFrom,
                    fpr.CompanyIDTo,
                    fpr.GovernmentIDFrom,
                    fpr.GovernmentIDTo
                }).ToList();

                foreach (FulfillmentPlanRoute route in await Task.Run(() => routeSearch.GetReadOnlyReader(localTransaction, routeFields)))
                {
                    companyIDRoutes.AddRange(new[] { route.CompanyIDFrom, route.CompanyIDTo });
                    governmentIDRoutes.AddRange(new[] { route.GovernmentIDFrom, route.GovernmentIDTo });
                }

                companyIDRoutes.RemoveWhere(companyID => companyID == LocationDestination?.CompanyID || companyID == LocationOrigin?.CompanyID || companyID == null);
                governmentIDRoutes.RemoveWhere(governmentID => governmentID == GovernmentIDDestination || governmentID == null);

                foreach (long? companyID in companyIDRoutes)
                {
                    PurchaseOrderApproval companyApproval = DataObjectFactory.Create<PurchaseOrderApproval>();
                    companyApproval.PurchaseOrderID = PurchaseOrderID;
                    companyApproval.CompanyIDApprover = companyID;
                    companyApproval.ApprovalPurpose = PurchaseOrderApproval.ROUTE_PURPOSE;
                    companyApproval.ApprovalStatus = PurchaseOrderApproval.ApprovalStatuses.Pending;
                    if (!await Task.Run(() => companyApproval.Save(localTransaction)))
                    {
                        Errors.AddRange(companyApproval.Errors.ToArray());
                        return false;
                    }
                }

                foreach (long? governmentID in governmentIDRoutes)
                {
                    PurchaseOrderApproval governmentApproval = DataObjectFactory.Create<PurchaseOrderApproval>();
                    governmentApproval.PurchaseOrderID = PurchaseOrderID;
                    governmentApproval.GovernmentIDApprover = governmentID;
                    governmentApproval.ApprovalPurpose = PurchaseOrderApproval.ROUTE_PURPOSE;
                    governmentApproval.ApprovalStatus = PurchaseOrderApproval.ApprovalStatuses.Pending;
                    if (!await Task.Run(() => governmentApproval.Save(localTransaction)))
                    {
                        Errors.AddRange(governmentApproval.Errors.ToArray());
                        return false;
                    }
                }

                if (transaction == null)
                {
                    localTransaction.Commit();
                }

                return true;
            }
            finally
            {
                if (transaction == null && localTransaction != null && localTransaction.IsActive)
                {
                    localTransaction.Rollback();
                }
            }
        }

        private async Task<bool> UpdatePrices(ITransaction transaction)
        {
            List<ISearchCondition> quotationSearchConditions = new List<ISearchCondition>();
            if (LocationIDOrigin != null)
            {
                quotationSearchConditions.Add(new ExistsSearchCondition<Quotation>()
                {
                    RelationshipName = FieldPathUtility.CreateFieldPathsAsList<Quotation>(q => new List<object>() { q.CompanyTo.Locations }).First(),
                    ExistsType = ExistsSearchCondition<Quotation>.ExistsTypes.Exists,
                    Condition = new LongSearchCondition<Location>()
                    {
                        Field = nameof(Location.LocationID),
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = LocationIDOrigin
                    }
                });
            }

            if (LocationIDDestination != null)
            {
                quotationSearchConditions.Add(new ExistsSearchCondition<Quotation>()
                {
                    RelationshipName = FieldPathUtility.CreateFieldPathsAsList<Quotation>(q => new List<object>() { q.CompanyFrom.Locations }).First(),
                    ExistsType = ExistsSearchCondition<Quotation>.ExistsTypes.Exists,
                    Condition = new LongSearchCondition<Location>()
                    {
                        Field = nameof(Location.LocationID),
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = LocationIDDestination
                    }
                });
            }

            if (GovernmentIDOrigin != null)
            {
                quotationSearchConditions.Add(new LongSearchCondition<Quotation>()
                {
                    Field = nameof(Quotation.GovernmentIDTo),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = GovernmentIDOrigin
                });
            }

            if (GovernmentIDDestination != null)
            {
                quotationSearchConditions.Add(new LongSearchCondition<Quotation>()
                {
                    Field = nameof(Quotation.GovernmentIDFrom),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = GovernmentIDDestination
                });
            }

            quotationSearchConditions.Add(new DateTimeSearchCondition<Quotation>()
            {
                Field = nameof(Quotation.ExpirationTime),
                SearchConditionType = SearchCondition.SearchConditionTypes.Greater,
                Value = DateTime.Now
            });

            Search<Quotation> quoteSearch = new Search<Quotation>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And, quotationSearchConditions.ToArray()));
            List<Quotation> quotes = quoteSearch.GetEditableReader(transaction, FieldPathUtility.CreateFieldPathsAsList<Quotation>(q => new List<object>()
            {
                q.QuotationItems.First().ItemID,
                q.QuotationItems.First().MinimumQuantity,
                q.QuotationItems.First().UnitCost
            })).ToList();

            Dictionary<QuotationItem, Quotation> quotesByItem = new Dictionary<QuotationItem, Quotation>();
            quotes.ForEach(q => q.QuotationItems.ToList().ForEach(qi => quotesByItem[qi] = q));

            List<LocationItem> locationItems = new List<LocationItem>();
            if (LocationIDDestination != null)
            {
                Search<LocationItem> locationItemSearch = new Search<LocationItem>(new LongSearchCondition<LocationItem>()
                {
                    Field = nameof(LocationItem.LocationID),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = LocationIDDestination
                });
                locationItems = locationItemSearch.GetReadOnlyReader(transaction, FieldPathUtility.CreateFieldPathsAsList<LocationItem>(li => new List<object>()
                {
                    li.ItemID,
                    li.Quantity,
                    li.BasePrice,
                    li.CurrentPromotionLocationItem.PromotionPrice
                })).ToList();
            }

            Search<PurchaseOrderLine> lineSearch = new Search<PurchaseOrderLine>(new LongSearchCondition<PurchaseOrderLine>()
            {
                Field = nameof(PurchaseOrderLine.PurchaseOrderID),
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = PurchaseOrderID
            });

            foreach(PurchaseOrderLine line in await Task.Run(() => lineSearch.GetEditableReader(transaction)))
            {
                if (line.ItemID == null)
                {
                    continue;
                }

                QuotationItem quoteItem = quotesByItem.Keys.Where(qi => qi.ItemID == line.ItemID && qi.MinimumQuantity <= line.Quantity).OrderBy(qi => qi.UnitCost).FirstOrDefault();
                decimal? unitCost = quoteItem?.UnitCost;
                if (unitCost == null)
                {
                    LocationItem relatedItem = locationItems.Where(li => li.ItemID == line.ItemID && li.Quantity == line.Quantity).FirstOrDefault();
                    if (relatedItem == null)
                    {
                        relatedItem = locationItems.Where(li => li.ItemID == line.ItemID && li.Quantity == 1).FirstOrDefault();
                    }

                    if (relatedItem == null)
                    {
                        return false;
                    }

                    unitCost = (relatedItem.CurrentPromotionLocationItem?.PromotionPrice ?? relatedItem.BasePrice) / relatedItem.Quantity;
                }

                line.UnitCost = unitCost.Value;

                if (!await Task.Run(() => line.Save(transaction)))
                {
                    Errors.AddRange(line.Errors.ToArray());
                    return false;
                }
            }

            return true;
        }

        public async Task<bool> WithdrawSubmission(ITransaction transaction = null)
        {
            ITransaction localTransaction = transaction;

            try
            {
                if (localTransaction == null)
                {
                    localTransaction = SQLProviderFactory.GenerateTransaction();
                }

                if (Status != PurchaseOrder.Statuses.Pending && Status != PurchaseOrder.Statuses.Rejected)
                {
                    Errors.Add("Status", "Purchase order must be pending or rejected to withdraw submission");
                    return false;
                }

                Status = PurchaseOrder.Statuses.Draft;
                PurchaseOrderDate = null;
                if (!await Task.Run(() => Save(localTransaction, new List<Guid>() { PurchaseOrder.SaveFlags.V_StatusChange })))
                {
                    return false;
                }

                Search<PurchaseOrderApproval> approvalSearch = new Search<PurchaseOrderApproval>(new LongSearchCondition<PurchaseOrder>()
                {
                    Field = nameof(PurchaseOrderApproval.PurchaseOrderID),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = PurchaseOrderID
                });

                foreach (PurchaseOrderApproval approval in await Task.Run(() => approvalSearch.GetEditableReader(localTransaction)))
                {
                    if (!await Task.Run(() => approval.Delete(localTransaction)))
                    {
                        Errors.AddRange(approval.Errors.ToArray());
                        return false;
                    }
                }

                if (transaction == null)
                {
                    localTransaction.Commit();
                }

                return true;
            }
            finally
            {
                if (transaction == null && localTransaction != null && localTransaction.IsActive)
                {
                    localTransaction.Rollback();
                }
            }
        }

        public async Task<bool> ApprovalSubmitted(ITransaction transaction = null)
        {
            ITransaction localTransaction = transaction;

            try
            {
                if (localTransaction == null)
                {
                    localTransaction = SQLProviderFactory.GenerateTransaction();
                }

                PurchaseOrder purchaseOrderForApprovalLookup = DataObject.GetReadOnlyByPrimaryKey<PurchaseOrder>(PurchaseOrderID, localTransaction, FieldPathUtility.CreateFieldPathsAsList<PurchaseOrder>(po => new List<object>()
                {
                    po.PurchaseOrderLines.First().IsService,
                    po.PurchaseOrderLines.First().ItemID,
                    po.PurchaseOrderLines.First().Quantity,
                    po.PurchaseOrderLines.First().FulfillmentPlanPurchaseOrderLines.First().FulfillmentPlan.LeaseRequestID,
                    po.PurchaseOrderLines.First().FulfillmentPlanPurchaseOrderLines.First().FulfillmentPlan.RailcarID,
                    po.PurchaseOrderLines.First().FulfillmentPlanPurchaseOrderLines.First().FulfillmentPlan.TrackIDLoading,
                    po.PurchaseOrderLines.First().FulfillmentPlanPurchaseOrderLines.First().FulfillmentPlan.FulfillmentPlanRoutes.First().CompanyIDFrom,
                    po.PurchaseOrderLines.First().FulfillmentPlanPurchaseOrderLines.First().FulfillmentPlan.FulfillmentPlanRoutes.First().CompanyIDTo,
                    po.PurchaseOrderLines.First().FulfillmentPlanPurchaseOrderLines.First().FulfillmentPlan.FulfillmentPlanRoutes.First().GovernmentIDFrom,
                    po.PurchaseOrderLines.First().FulfillmentPlanPurchaseOrderLines.First().FulfillmentPlan.FulfillmentPlanRoutes.First().GovernmentIDTo,
                    po.PurchaseOrderApprovals.First().ApprovalStatus
                }));

                bool hasRejections = purchaseOrderForApprovalLookup.PurchaseOrderApprovals?.Any(poa => poa.ApprovalStatus == PurchaseOrderApproval.ApprovalStatuses.Rejected) ?? false;
                bool hasNoRailcars = purchaseOrderForApprovalLookup.PurchaseOrderLines?.Any(pl => pl.FulfillmentPlanPurchaseOrderLines?.Any(fppol => fppol.FulfillmentPlan?.RailcarID == null && fppol.FulfillmentPlan?.LeaseRequestID == null) ?? false) ?? false;
                bool hasAnyPending = purchaseOrderForApprovalLookup.PurchaseOrderApprovals?.Any(poa => poa.ApprovalStatus == PurchaseOrderApproval.ApprovalStatuses.Pending) ?? false;

                if (!hasRejections && !hasNoRailcars && !hasAnyPending)
                {
                    Status = Statuses.Accepted;
                    if (!await Task.Run(() => Save(localTransaction, new List<Guid>() { PurchaseOrder.SaveFlags.V_StatusChange })))
                    {
                        return false;
                    }

                    // Update all railcars per fulfillment plans
                    foreach(FulfillmentPlan fulfillmentPlan in purchaseOrderForApprovalLookup.PurchaseOrderLines.SelectMany(pol => pol.FulfillmentPlanPurchaseOrderLines).Select(fppol => fppol.FulfillmentPlan))
                    {
                        // Update destination
                        Railcar railcar = DataObject.GetEditableByPrimaryKey<Railcar>(fulfillmentPlan.RailcarID, localTransaction, null);
                        railcar.TrackIDDestination = fulfillmentPlan.TrackIDLoading;
                        if (!await Task.Run(() => railcar.Save(localTransaction)))
                        {
                            Errors.AddRange(railcar.Errors.ToArray());
                            return false;
                        }

                        // Clear out existing routes
                        Search<RailcarRoute> deleteSearch = new Search<RailcarRoute>(new LongSearchCondition<RailcarRoute>()
                        {
                            Field = nameof(RailcarRoute.RailcarID),
                            SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                            Value = railcar.RailcarID
                        });
                        foreach(RailcarRoute railcarRoute in await Task.Run(() => deleteSearch.GetEditableReader(localTransaction)))
                        {
                            if (!await Task.Run(() => railcarRoute.Delete(localTransaction)))
                            {
                                Errors.AddRange(railcarRoute.Errors.ToArray());
                                return false;
                            }
                        }

                        // Routes will be created after product is picked up
                    }

                    // Expire any quotes that were used
                    List<ISearchCondition> quotationSearchConditions = new List<ISearchCondition>()
                    {
                        new DateTimeSearchCondition<Quotation>()
                        {
                            Field = nameof(Quotation.ExpirationTime),
                            SearchConditionType = SearchCondition.SearchConditionTypes.GreaterEquals,
                            Value = PurchaseOrderDate.Value
                        },
                        new BooleanSearchCondition<Quotation>()
                        {
                            Field = nameof(Quotation.IsRepeatable),
                            SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                            Value = false
                        },
                        new ExistsSearchCondition<Quotation>()
                        {
                            RelationshipName = nameof(Quotation.QuotationItems),
                            ExistsType = ExistsSearchCondition<Quotation>.ExistsTypes.Exists,
                            Condition = new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                                new LongSearchCondition<QuotationItem>()
                                {
                                    Field = nameof(QuotationItem.ItemID),
                                    SearchConditionType = SearchCondition.SearchConditionTypes.List,
                                    List = purchaseOrderForApprovalLookup.PurchaseOrderLines.Where(pol => !pol.IsService && pol.ItemID != null).Select(pol => pol.ItemID.Value).ToList()
                                })
                        }
                    };

                    if (LocationIDOrigin != null)
                    {
                        quotationSearchConditions.Add(new ExistsSearchCondition<Quotation>()
                        {
                            RelationshipName = FieldPathUtility.CreateFieldPathsAsList<Quotation>(q => new List<object>() { q.CompanyTo.Locations }).First(),
                            ExistsType = ExistsSearchCondition<Quotation>.ExistsTypes.Exists,
                            Condition = new LongSearchCondition<Location>()
                            {
                                Field = nameof(Location.LocationID),
                                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                                Value = LocationIDOrigin
                            }
                        });
                    }

                    if (LocationIDDestination != null)
                    {
                        quotationSearchConditions.Add(new ExistsSearchCondition<Quotation>()
                        {
                            RelationshipName = FieldPathUtility.CreateFieldPathsAsList<Quotation>(q => new List<object>() { q.CompanyFrom.Locations }).First(),
                            ExistsType = ExistsSearchCondition<Quotation>.ExistsTypes.Exists,
                            Condition = new LongSearchCondition<Location>()
                            {
                                Field = nameof(Location.LocationID),
                                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                                Value = LocationIDDestination
                            }
                        });
                    }

                    if (GovernmentIDOrigin != null)
                    {
                        quotationSearchConditions.Add(new LongSearchCondition<Quotation>()
                        {
                            Field = nameof(Quotation.GovernmentIDTo),
                            SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                            Value = GovernmentIDOrigin
                        });
                    }

                    if (GovernmentIDDestination != null)
                    {
                        quotationSearchConditions.Add(new LongSearchCondition<Quotation>()
                        {
                            Field = nameof(Quotation.GovernmentIDFrom),
                            SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                            Value = GovernmentIDDestination
                        });
                    }

                    Search<Quotation> quotationSearch = new Search<Quotation>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And, quotationSearchConditions.ToArray()));
                    List<Quotation> quotations = await Task.Run(() => quotationSearch.GetEditableReader(localTransaction, FieldPathUtility.CreateFieldPathsAsList<Quotation>(q => new List<object>()
                    {
                        q.QuotationItems.First().ItemID,
                        q.QuotationItems.First().UnitCost,
                        q.QuotationItems.First().MinimumQuantity
                    })).ToList());
                    Dictionary<QuotationItem, Quotation> quotationsByLine = new Dictionary<QuotationItem, Quotation>();
                    Dictionary<long?, List<QuotationItem>> quotationItemsByItemID = new Dictionary<long?, List<QuotationItem>>();

                    quotations.ForEach(q => q.QuotationItems.ToList().ForEach(qi => quotationsByLine.Add(qi, q)));
                    quotationsByLine.Keys.ToList().ForEach(qi => quotationItemsByItemID.GetOrSet(qi.ItemID, () => new List<QuotationItem>()).Add(qi));

                    foreach(PurchaseOrderLine line in purchaseOrderForApprovalLookup.PurchaseOrderLines)
                    {
                        if (line.IsService || line.ItemID == null)
                        {
                            continue;
                        }

                        QuotationItem item = quotationItemsByItemID.GetOrDefault(line.ItemID)?.Where(qi => qi.MinimumQuantity <= line.Quantity).OrderByDescending(qi => qi.UnitCost).FirstOrDefault();
                        if (item == null || !quotations.Any(q => q.QuotationItems.Contains(item)))
                        {
                            continue;
                        }

                        Quotation quotation = quotationsByLine[item];
                        quotation.ExpirationTime = DateTime.Now;
                        if (!await Task.Run(() => quotation.Save(localTransaction)))
                        {
                            Errors.AddRange(quotation.Errors.ToArray());
                            return false;
                        }

                        quotations.Remove(quotation);
                    }
                }

                if (transaction == null)
                {
                    localTransaction.Commit();
                }

                return true;
            }
            finally
            {
                if (transaction == null && localTransaction != null && localTransaction.IsActive)
                {
                    localTransaction.Rollback();
                }
            }
        }

        #region Relationships
        #region invoicing
        private List<Invoice> _invoices = new List<Invoice>();
        [RelationshipList("B9866DDC-19F1-42F8-8905-E80C8CC8CEA1", nameof(Invoice.PurchaseOrderID))]
        public IReadOnlyCollection<Invoice> Invoices
        {
            get { CheckGet(); return _invoices; }
        }
        #endregion
        #region purchasing
        private List<PurchaseOrderLine> _purchaseOrderLines = new List<PurchaseOrderLine>();
        [RelationshipList("F890FC5F-207A-43FC-B8A1-A42DF5288D5F", nameof(PurchaseOrderLine.PurchaseOrderID), AutoDeleteReferences = true)]
        public IReadOnlyCollection<PurchaseOrderLine> PurchaseOrderLines
        {
            get { CheckGet(); return _purchaseOrderLines; }
        }

        private List<PurchaseOrderApproval> _purchaseOrderApprovals = new List<PurchaseOrderApproval>();
        [RelationshipList("CC393106-CC25-462B-A23C-36DF998E49F7", nameof(PurchaseOrderApproval.PurchaseOrderID), AutoDeleteReferences = true)]
        public IReadOnlyCollection<PurchaseOrderApproval> PurchaseOrderApprovals
        {
            get { CheckGet(); return _purchaseOrderApprovals; }
        }

        private List<BillOfLading> _billsOfLading = new List<BillOfLading>();
        [RelationshipList("8E46EC76-0E2E-4E8F-900F-836FC6C8BBC0", nameof(BillOfLading.BillOfLadingID))]
        public IReadOnlyCollection<BillOfLading> BillsOfLading
        {
            get { CheckGet(); return _billsOfLading; }
        }

        private List<PurchaseOrderTemplate> _purchaseOrderTemplates = new List<PurchaseOrderTemplate>();
        [RelationshipList("345649FE-612C-44C7-9875-9004D2420C75", nameof(PurchaseOrderTemplate.PurchaseOrderID), AutoDeleteReferences = true)]
        public IReadOnlyCollection<PurchaseOrderTemplate> PurchaseOrderTemplates
        {
            get { CheckGet(); return _purchaseOrderTemplates; }
        }
        #endregion
        #endregion

        public static class SaveFlags
        {
            public static readonly Guid V_StatusChange = new Guid("5456CAE0-A7C9-43E1-842F-0CE3292710D3");
        }
    }
}
