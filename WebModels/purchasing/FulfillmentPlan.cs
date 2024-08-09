using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebModels.fleet;

namespace WebModels.purchasing
{
    [Table("7B96D263-EE48-44DB-8754-B0BDE09051C0")]
    public class FulfillmentPlan : DataObject
    {
        protected FulfillmentPlan() : base() { }

        private long? _fulfillmentPlanID;
        [Field("42E4EA64-2594-4C85-82D1-B677409ACDD4")]
        public long? FulfillmentPlanID
        {
            get { CheckGet(); return _fulfillmentPlanID; }
            set { CheckSet(); _fulfillmentPlanID = value; }
        }

        private long? _purchaseOrderLineID;
        [Field("A42DB2D4-0BF8-45EE-8594-96A9CD06AC58")]
        public long? PurchaseOrderLineID
        {
            get { CheckGet(); return _purchaseOrderLineID; }
            set { CheckSet(); _purchaseOrderLineID = value; }
        }

        private PurchaseOrderLine _purchaseOrderLine = null;
        [Relationship("FFAA0FC5-61F1-4C0E-8803-A75B7A5CCFA5")]
        public PurchaseOrderLine PurchaseOrderLine
        {
            get { CheckGet(); return _purchaseOrderLine; }
        }

        private long? _railcarID;
        [Field("09B2BB59-5D64-48D3-92F3-CA8460DFE6BF")]
        public long? RailcarID
        {
            get { CheckGet(); return _railcarID; }
            set { CheckSet(); _railcarID = value; }
        }

        private Railcar _railcar = null;
        [Relationship("A9AAC640-EFAA-456C-84A6-A99ADD8C5A07")]
        public Railcar Railcar
        {
            get { CheckGet(); return _railcar; }
        }

        private long? _leaseRequestID;
        [Field("57AA17B1-9CD1-4029-8E25-67C24B209CCA")]
        public long? LeaseRequestID
        {
            get { CheckGet(); return _leaseRequestID; }
            set { CheckSet(); _leaseRequestID = value; }
        }

        private LeaseRequest _leaseRequest = null;
        [Relationship("C45945A9-A8F7-4694-A252-B4EA0A4A5ABB")]
        public LeaseRequest LeaseRequest
        {
            get { CheckGet(); return _leaseRequest; }
        }

        private long? _trackIDLoading;
        [Field("C12B06F2-4A72-4B21-A5D7-49C831C7296F")]
        public long? TrackIDLoading
        {
            get { CheckGet(); return _trackIDLoading; }
            set { CheckSet(); _trackIDLoading = value; }
        }

        private Track _trackLoading = null;
        [Relationship("A9F75A81-9E4D-4AA4-B3F4-4FF75E9F5A3B", ForeignKeyField = nameof(TrackIDLoading))]
        public Track TrackLoading
        {
            get { CheckGet(); return _trackLoading; }
        }

        private long? _trackIDDestination;
        [Field("E3B16B71-899B-4F92-8C9C-2D6A7E7E9A8F")]
        public long? TrackIDDestination
        {
            get { CheckGet(); return _trackIDDestination; }
            set { CheckSet(); _trackIDDestination = value; }
        }

        private Track _trackDestination = null;
        [Relationship("FF68AB12-AD3C-4CF9-9FB4-71C4F56A7D91", ForeignKeyField = nameof(TrackIDDestination))]
        public Track TrackDestination
        {
            get { CheckGet(); return _trackDestination; }
        }

        private long? _trackIDStrategicDestination;
        [Field("69B99F3D-8E5B-4F69-A4E1-DA4B01736C27")]
        public long? TrackIDStrategicDestination
        {
            get { CheckGet(); return _trackIDStrategicDestination; }
            set { CheckSet(); _trackIDStrategicDestination = value; }
        }

        private Track _trackStrategicDestination = null;
        [Relationship("DD54C7F4-2A4D-493D-AB2C-BE33F5D7B42F", ForeignKeyField = nameof(TrackIDStrategicDestination))]
        public Track TrackStrategicDestination
        {
            get { CheckGet(); return _trackStrategicDestination; }
        }

        private long? _trackIDPostFulfillment;
        [Field("B7CDE312-BC4A-4EBF-8B84-C18B5C3A88DA")]
        public long? TrackIDPostFulfillment
        {
            get { CheckGet(); return _trackIDPostFulfillment; }
            set { CheckSet(); _trackIDPostFulfillment = value; }
        }

        private Track _trackPostFulfillment = null;
        [Relationship("8CB6B826-5E31-4F39-9A45-4587E6A7F47D", ForeignKeyField = nameof(TrackIDPostFulfillment))]
        public Track TrackPostFulfillment
        {
            get { CheckGet(); return _trackPostFulfillment; }
        }

        #region Relationships
        #region purchasing
        private List<FulfillmentPlanRoute> _fulfillmentPlanRoutes = new List<FulfillmentPlanRoute>();
        [RelationshipList("4CCE7ACC-E964-4C7F-9A6C-E2268D47BA87", nameof(FulfillmentPlanRoute.FulfillmentPlanID), AutoDeleteReferences = true)]
        public IReadOnlyCollection<FulfillmentPlanRoute> FulfillmentPlanRoutes
        {
            get { CheckGet(); return _fulfillmentPlanRoutes; }
        }
        #endregion
        #endregion
    }
}
