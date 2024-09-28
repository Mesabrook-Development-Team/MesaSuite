using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Validation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebModels.invoicing;
using WebModels.mesasys;

namespace WebModels.purchasing
{
    [Table("936D032E-72A7-4C29-B9D0-C457BFD4D527")]
    public class PurchaseOrderLine : DataObject
    {
        protected PurchaseOrderLine() : base() { }

        private long? _purchaseOrderLineID;
        [Field("7D676889-2C1F-4BDD-80A9-9CC97521C6D5")]
        public long? PurchaseOrderLineID
        {
            get { CheckGet(); return _purchaseOrderLineID; }
            set { CheckSet(); _purchaseOrderLineID = value; }
        }

        private long? _purchaseOrderID;
        [Field("39242E74-9996-4A8E-BA29-C75EFC36FA20")]
        [Required]
        public long? PurchaseOrderID
        {
            get { CheckGet(); return _purchaseOrderID; }
            set { CheckSet(); _purchaseOrderID = value; }
        }

        private PurchaseOrder _purchaseOrder = null;
        [Relationship("07430E11-BB81-41B6-A756-CFE9D928303E")]
        public PurchaseOrder PurchaseOrder
        {
            get { CheckGet(); return _purchaseOrder; }
        }

        private bool _isService = false;
        [Field("B239F003-4019-4C3D-A328-8366FDD2BB64")]
        public bool IsService
        {
            get { CheckGet(); return _isService; }
            set { CheckSet(); _isService = value; }
        }

        private string _serviceDescription;
        [Field("1049EC62-DA09-4C65-8CC3-EA477C5AEEA7", DataSize = 1000)]
        public string ServiceDescription
        {
            get { CheckGet(); return _serviceDescription; }
            set { CheckSet(); _serviceDescription = value; }
        }

        private long? _itemID;
        [Field("2E738727-BE5D-45EB-A438-9838B249F48C")]
        public long? ItemID
        {
            get { CheckGet(); return _itemID; }
            set { CheckSet(); _itemID = value; }
        }

        private Item _item = null;
        [Relationship("ABBBCBD3-9826-48CE-B668-2731A1D8506A")]
        public Item Item
        {
            get { CheckGet(); return _item; }
        }

        private string _itemDescription;
        [Field("678240C1-A418-40FE-9BBB-F7C1FDE3BA90", DataSize = 100)]
        public string ItemDescription
        {
            get { CheckGet(); return _itemDescription; }
            set { CheckSet(); _itemDescription = value; }
        }

        private decimal? _quantity;
        [Field("AC61E957-22FD-44FE-A186-62BBF26E5056", DataSize = 9, DataScale = 2)]
        public decimal? Quantity
        {
            get { CheckGet(); return _quantity; }
            set { CheckSet(); _quantity = value; }
        }

        private decimal? _unitCost;
        [Field("94FF9953-EB3E-4969-B018-155C04695D1F", DataSize = 9, DataScale = 2)]
        public decimal? UnitCost
        {
            get { CheckGet(); return _unitCost; }
            set { CheckSet(); _unitCost = value; }
        }

        protected override bool PreDelete(ITransaction transaction)
        {
            Search<FulfillmentPlan> fulfillmentPlanSearch = new Search<FulfillmentPlan>(new ExistsSearchCondition<FulfillmentPlan>()
            {
                RelationshipName = nameof(FulfillmentPlan.FulfillmentPlanPurchaseOrderLines),
                ExistsType = ExistsSearchCondition<FulfillmentPlan>.ExistsTypes.Exists,
                Condition = new LongSearchCondition<FulfillmentPlanPurchaseOrderLine>()
                {
                    Field = nameof(FulfillmentPlanPurchaseOrderLine.PurchaseOrderLineID),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = PurchaseOrderLineID
                }
            });

            if (fulfillmentPlanSearch.ExecuteExists(transaction))
            {
                FulfillmentPlan fulfillmentPlan = fulfillmentPlanSearch.GetEditable(transaction);
                if (!fulfillmentPlan.Delete(transaction))
                {
                    Errors.AddRange(fulfillmentPlan.Errors.ToArray());

                    return false;
                }
            }

            return base.PreDelete(transaction);
        }

        #region Relationships
        #region invoicing
        private List<InvoiceLine> _invoiceLines = new List<InvoiceLine>();
        [RelationshipList("26BF469D-EDBA-42D0-96DA-B203D4667AE4", nameof(InvoiceLine.PurchaseOrderLineID))]
        public List<InvoiceLine> InvoiceLines
        {
            get { CheckGet(); return _invoiceLines; }
        }
        #endregion
        #region purchasing
        private List<FulfillmentPlanPurchaseOrderLine> _fulfillmentPlanPurchaseOrderLines = new List<FulfillmentPlanPurchaseOrderLine>();
        [RelationshipList("354F1484-E4B8-44CF-B4BE-7719C19683D5", nameof(FulfillmentPlanPurchaseOrderLine.PurchaseOrderLineID), AutoDeleteReferences = true)]
        public IReadOnlyCollection<FulfillmentPlanPurchaseOrderLine> FulfillmentPlanPurchaseOrderLines
        {
            get { CheckGet(); return _fulfillmentPlanPurchaseOrderLines; }
        }

        private List<Fulfillment> _fulfillments = new List<Fulfillment>();
        [RelationshipList("91C27B49-3DE2-4BC1-B82B-148F84D4BE33", nameof(Fulfillment.PurchaseOrderLineID))]
        public IReadOnlyCollection<Fulfillment> Fulfillments
        {
            get { CheckGet(); return _fulfillments; }
        }
        #endregion
        #endregion
    }
}
