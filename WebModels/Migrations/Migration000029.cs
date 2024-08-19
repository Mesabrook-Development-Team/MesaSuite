using ClussPro.Base.Data;
using ClussPro.Base.Data.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebModels.Migrations
{
    public class Migration000029 : IMigration
    {
        public int MigrationNumber => 28;

        public void Execute(ITransaction transaction)
        {
            CreatePurchasingTables(transaction);
            CreateFleetTables(transaction);
            UpdateTables(transaction);
        }

        private void CreatePurchasingTables(ITransaction transaction)
        {
            ICreateSchema createSchema = SQLProviderFactory.GetCreateSchemaQuery();
            createSchema.SchemaName = "purchasing";
            createSchema.Execute(transaction);

            ICreateTable createTable = SQLProviderFactory.GetCreateTableQuery();
            createTable.SchemaName = "purchasing";
            createTable.TableName = "PurchaseOrder";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "PurchaseOrderID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "LocationIDOrigin", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "GovernmentIDOrigin", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "LocationIDDestination", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "GovernmentIDDestination", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "PurchaseOrderDate", new FieldSpecification(FieldSpecification.FieldTypes.DateTime2, 7) },
                { "Status", new FieldSpecification(FieldSpecification.FieldTypes.Int) },
                { "Description", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 250) }
            };
            createTable.Execute(transaction);
            IAlterTable alter = SQLProviderFactory.GetAlterTableQuery();
            alter.Schema = "purchasing";
            alter.Table = "PurchaseOrder";
            alter.AddForeignKey("FKPurchaseOrder_Location_LocationIDOrigin", "LocationIDOrigin", "company", "Location", "LocationID", transaction);
            alter.AddForeignKey("FKPurchaseOrder_Location_LocationIDDestination", "LocationIDDestination", "company", "Location", "LocationID", transaction);
            alter.AddForeignKey("FKPurchaseOrder_Government_GovernmentIDOrigin", "GovernmentIDOrigin", "gov", "Government", "GovernmentID", transaction);
            alter.AddForeignKey("FKPurchaseOrder_Government_GovernmentIDDestination", "GovernmentIDDestination", "gov", "Government", "GovernmentID", transaction);

            createTable.TableName = "PurchaseOrderLine";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "PurchaseOrderLineID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "PurchaseOrderID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "IsService", new FieldSpecification(FieldSpecification.FieldTypes.Bit) },
                { "ServiceDescription", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 1000) },
                { "ItemID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "ItemDescription", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 100) },
                { "Quantity", new FieldSpecification(FieldSpecification.FieldTypes.Decimal, 9, 2) },
                { "UnitCost", new FieldSpecification(FieldSpecification.FieldTypes.Decimal, 9, 2) }
            };
            createTable.Execute(transaction);
            alter.Table = "PurchaseOrderLine";
            alter.AddForeignKey("FKPurchaseOrderLine_PurchaseOrder_PurchaseOrderID", "PurchaseOrderID", "purchasing", "PurchaseOrder", "PurchaseOrderID", transaction);
            alter.AddForeignKey("FKPurchaseOrderLine_Item_ItemID", "ItemID", "mesasys", "Item", "ItemID", transaction);

            createTable.TableName = "FulfillmentPlan";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "FulfillmentPlanID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "PurchaseOrderLineID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "RailcarID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "LeaseRequestID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "TrackIDLoading", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "TrackIDDestination", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "TrackIDStrategicDestination", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "TrackIDPostFulfillment", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) }
            };
            createTable.Execute(transaction);

            alter.Table = "FulfillmentPlan";
            alter.AddForeignKey("FKFulfillmentPlan_PurchaseOrderLine_PurchaseOrderLineID", "PurchaseOrderLineID", "purchasing", "PurchaseOrderLine", "PurchaseOrderLineID", transaction);
            alter.AddForeignKey("FKFulfillmentPlan_Railcar_RailcarID", "RailcarID", "fleet", "Railcar", "RailcarID", transaction);
            alter.AddForeignKey("FKFulfillmentPlan_LeaseRequest_LeaseRequestID", "LeaseRequestID", "fleet", "LeaseRequest", "LeaseRequestID", transaction);
            alter.AddForeignKey("FKFulfillmentPlan_Track_TrackIDLoading", "TrackIDLoading", "fleet", "Track", "TrackID", transaction);
            alter.AddForeignKey("FKFulfillmentPlan_Track_TrackIDDestination", "TrackIDDestination", "fleet", "Track", "TrackID", transaction);
            alter.AddForeignKey("FKFulfillmentPlan_Track_TrackIDStrategicDestination", "TrackIDStrategicDestination", "fleet", "Track", "TrackID", transaction);
            alter.AddForeignKey("FKFulfillmentPlan_Track_TrackIDPostFulfillment", "TrackIDPostFulfillment", "fleet", "Track", "TrackID", transaction);

            createTable.TableName = "FulfillmentPlanRoute";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "FulfillmentPlanRouteID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "FulfillmentPlanID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "SortOrder", new FieldSpecification(FieldSpecification.FieldTypes.TinyInt) },
                { "CompanyIDFrom", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "CompanyIDTo", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) }
            };
            createTable.Execute(transaction);

            alter.Table = "FulfillmentPlanRoute";
            alter.AddForeignKey("FKFulfillmentPlanRoute_FulfillmentPlan_FulfillmentPlanID", "FulfillmentPlanID", "purchasing", "FulfillmentPlan", "FulfillmentPlanID", transaction);
            alter.AddForeignKey("FKFulfillmentPlanRoute_Company_CompanyIDFrom", "CompanyIDFrom", "company", "Company", "CompanyID", transaction);
            alter.AddForeignKey("FKFulfillmentPlanRoute_Company_CompanyIDTo", "CompanyIDTo", "company", "Company", "CompanyID", transaction);

            createTable.TableName = "Fulfillment";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "FulfillmentID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "PurchaseOrderLineID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "RailcarID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "FulfillmentTime", new FieldSpecification(FieldSpecification.FieldTypes.DateTime2, 7) },
                { "Quantity", new FieldSpecification(FieldSpecification.FieldTypes.Decimal, 9, 2) },
                { "IsComplete", new FieldSpecification(FieldSpecification.FieldTypes.Bit) { DefaultValue = false } }
            };
        }

        private void CreateFleetTables(ITransaction transaction)
        {
            ICreateTable createTable = SQLProviderFactory.GetCreateTableQuery();
            createTable.SchemaName = "fleet";
            createTable.TableName = "RailcarRoute";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "RailcarRouteID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "RailcarID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "SortOrder", new FieldSpecification(FieldSpecification.FieldTypes.TinyInt) },
                { "CompanyIDFrom", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "CompanyIDTo", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) }
            };
            createTable.Execute(transaction);

            IAlterTable alterTable = SQLProviderFactory.GetAlterTableQuery();
            alterTable.Schema = "fleet";
            alterTable.Table = "RailcarRoute";
            alterTable.AddForeignKey("FKRailcarRoute_Railcar_RailcarID", "RailcarID", "fleet", "Railcar", "RailcarID", transaction);
            alterTable.AddForeignKey("FKRailcarRoute_Company_CompanyIDFrom", "CompanyIDFrom", "company", "Company", "CompanyID", transaction);
            alterTable.AddForeignKey("FKRailcarRoute_Company_CompanyIDTo", "CompanyIDTo", "company", "Company", "CompanyID", transaction);
        }

        private void UpdateTables(ITransaction transaction)
        {
            IAlterTable alterTable = SQLProviderFactory.GetAlterTableQuery();
            alterTable.Schema = "invoicing";
            alterTable.Table = "Invoice";
            alterTable.AddColumn("PurchaseOrderID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt), transaction);
            alterTable.AddForeignKey("FKInvoice_PurchaseOrder_PurchaseOrderID", "PurchaseOrderID", "purchasing", "PurchaseOrder", "PurchaseOrderID", transaction);

            alterTable.Table = "InvoiceLine";
            alterTable.AddColumn("PurchaseOrderLine", new FieldSpecification(FieldSpecification.FieldTypes.BigInt), transaction);
            alterTable.AddForeignKey("FKInvoiceLine_PurchaseOrderLine_PurchaseOrderLineID", "PurchaseOrderLineID", "purchasing", "PurchaseOrderLine", "PurchaseOrderLineID", transaction);

            alterTable.Schema = "company";
            alterTable.Table = "LocationEmployee";
            alterTable.AddColumn("ManagePurchaseOrders", new FieldSpecification(FieldSpecification.FieldTypes.Bit) { DefaultValue = false }, transaction);

            alterTable.Schema = "gov";
            alterTable.Table = "Official";
            alterTable.AddColumn("ManagePurchaseOrders", new FieldSpecification(FieldSpecification.FieldTypes.Bit) { DefaultValue = false }, transaction);
        }
    }
}
