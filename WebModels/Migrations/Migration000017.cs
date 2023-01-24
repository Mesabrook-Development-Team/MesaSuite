using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClussPro.Base.Data;
using ClussPro.Base.Data.Query;

namespace WebModels.Migrations
{
    public class Migration000017 : IMigration
    {
        public int MigrationNumber => 17;

        public void Execute(ITransaction transaction)
        {
            ICreateSchema createSchema = SQLProviderFactory.GetCreateSchemaQuery();
            createSchema.SchemaName = "fleet";
            createSchema.Execute(transaction);

            ICreateTable createTable = SQLProviderFactory.GetCreateTableQuery();
            createTable.SchemaName = "fleet";
            createTable.TableName = "LocomotiveModel";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "LocomotiveModelID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "Name", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 30) },
                { "FuelCapacity", new FieldSpecification(FieldSpecification.FieldTypes.Decimal, 4, 0) },
                { "WaterCapacity", new FieldSpecification(FieldSpecification.FieldTypes.Decimal, 3, 0) },
                { "Length", new FieldSpecification(FieldSpecification.FieldTypes.Decimal, 3, 1) },
                { "IsSteamPowered", new FieldSpecification(FieldSpecification.FieldTypes.Bit) { DefaultValue = false } },
                { "Image", new FieldSpecification(FieldSpecification.FieldTypes.Binary) }
            };
            createTable.Execute(transaction);

            createTable.TableName = "RailcarModel";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "RailcarModelID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "Name", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 30) },
                { "CargoCapacity", new FieldSpecification(FieldSpecification.FieldTypes.Decimal, 4, 0) },
                { "Length", new FieldSpecification(FieldSpecification.FieldTypes.Decimal, 3, 1) },
                { "Type", new FieldSpecification(FieldSpecification.FieldTypes.Int) },
                { "Image", new FieldSpecification(FieldSpecification.FieldTypes.Binary) }
            };
            createTable.Execute(transaction);

            createTable.TableName = "Locomotive";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "LocomotiveID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "LocomotiveModelID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "GovernmentIDOwner", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "CompanyIDOwner", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "GovernmentIDPossessor", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "CompanyIDPossessor", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "ReportingMark", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 4) },
                { "ReportingNumber", new FieldSpecification(FieldSpecification.FieldTypes.Int) },
                { "ImageOverride", new FieldSpecification(FieldSpecification.FieldTypes.Binary) }
            };
            createTable.Execute(transaction);
            CreateForeignKey(transaction, createTable, "fleet", "LocomotiveModel");
            CreateForeignKey(transaction, createTable, "gov", "Government", "GovernmentIDOwner");
            CreateForeignKey(transaction, createTable, "company", "Company", "CompanyIDOwner");
            CreateForeignKey(transaction, createTable, "gov", "Government", "GovernmentIDPossessor");
            CreateForeignKey(transaction, createTable, "company", "Company", "CompanyIDPossessor");

            createTable.TableName = "Railcar";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "RailcarID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "RailcarModelID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "GovernmentIDOwner", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "CompanyIDOwner", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "GovernmentIDPossessor", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "CompanyIDPossessor", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "ReportingMark", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 4) },
                { "ReportingNumber", new FieldSpecification(FieldSpecification.FieldTypes.Int) },
                { "ImageOverride", new FieldSpecification(FieldSpecification.FieldTypes.Binary) },
                { "TrackIDDestination", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "TrackIDStrategic", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) }
            };
            createTable.Execute(transaction);
            CreateForeignKey(transaction, createTable, "fleet", "RailcarModel");
            CreateForeignKey(transaction, createTable, "gov", "Government", "GovernmentIDOwner");
            CreateForeignKey(transaction, createTable, "company", "Company", "CompanyIDOwner");
            CreateForeignKey(transaction, createTable, "gov", "Government", "GovernmentIDPossessor");
            CreateForeignKey(transaction, createTable, "company", "Company", "CompanyIDPossessor");

            createTable.TableName = "LeaseRequest";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "LeaseRequestID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "CompanyIDRequester", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "LocationIDChargeTo", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "GovernmentIDRequester", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "LeaseType", new FieldSpecification(FieldSpecification.FieldTypes.Int) },
                { "RailcarType", new FieldSpecification(FieldSpecification.FieldTypes.Int) },
                { "DeliveryLocation", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 50) },
                { "Purpose", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, -1) },
                { "BidEndTime", new FieldSpecification(FieldSpecification.FieldTypes.DateTime2, 7) }
            };
            createTable.Execute(transaction);
            CreateForeignKey(transaction, createTable, "company", "Company");
            CreateForeignKey(transaction, createTable, "company", "Location");
            CreateForeignKey(transaction, createTable, "gov", "Government");

            createTable.TableName = "LeaseBid";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "LeaseBidID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "LeaseRequestID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "LocomotiveID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "RailcarID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "LeaseAmount", new FieldSpecification(FieldSpecification.FieldTypes.Decimal, 8, 2) },
                { "RecurringAmountType", new FieldSpecification(FieldSpecification.FieldTypes.Int) },
                { "RecurringAmount", new FieldSpecification(FieldSpecification.FieldTypes.Decimal, 8, 2) },
                { "LocationIDInvoiceDestination", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "Terms", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, -1) }
            };
            createTable.Execute(transaction);
            CreateForeignKey(transaction, createTable, "fleet", "LeaseRequest");
            CreateForeignKey(transaction, createTable, "fleet", "Locomotive");
            CreateForeignKey(transaction, createTable, "fleet", "Railcar");
            CreateForeignKey(transaction, createTable, "company", "Location");

            createTable.TableName = "LeaseContract";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "LeaseContractID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "RailcarID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "LocomotiveID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "GovernmentIDLessee", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "CompanyIDLessee", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "Amount", new FieldSpecification(FieldSpecification.FieldTypes.Decimal, 8, 2) },
                { "RecurringAmountType", new FieldSpecification(FieldSpecification.FieldTypes.Int) },
                { "RecurringAmount", new FieldSpecification(FieldSpecification.FieldTypes.Decimal, 8, 2) },
                { "LocationIDRecurringAmountSource", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "LocationIDRecurringAmountDestination", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "Terms", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, -1) },
                { "LeaseTimeStart", new FieldSpecification(FieldSpecification.FieldTypes.DateTime2, 7) },
                { "LeaseTimeEnd", new FieldSpecification(FieldSpecification.FieldTypes.DateTime2, 7) }
            };
            createTable.Execute(transaction);
            CreateForeignKey(transaction, createTable, "fleet", "Railcar");
            CreateForeignKey(transaction, createTable, "fleet", "Locomotive");
            CreateForeignKey(transaction, createTable, "gov", "Government");
            CreateForeignKey(transaction, createTable, "company", "Company");
            CreateForeignKey(transaction, createTable, "company", "Location", "LocationIDRecurringAmountSource");
            CreateForeignKey(transaction, createTable, "company", "Location", "LocationIDRecurringAmountDestination");

            createTable.TableName = "LeaseContractInvoice";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "LeaseContractInvoiceID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "LeaseContractID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "InvoiceID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "Type", new FieldSpecification(FieldSpecification.FieldTypes.Int) },
                { "IssueTime", new FieldSpecification(FieldSpecification.FieldTypes.DateTime2, 7) }
            };
            createTable.Execute(transaction);
            CreateForeignKey(transaction, createTable, "fleet", "LeaseContract");
            CreateForeignKey(transaction, createTable, "invoicing", "Invoice");

            createTable.TableName = "TrainSymbol";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "TrainSymbolID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "CompanyIDOperator", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "GovernmentIDOperator", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "Name", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 15) },
                { "Description", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 200) }
            };
            createTable.Execute(transaction);
            CreateForeignKey(transaction, createTable, "gov", "Government");
            CreateForeignKey(transaction, createTable, "company", "Company");

            createTable.TableName = "TrainSymbolRate";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "TrainSymbolRateID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "TrainSymbolID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "EffectiveTime", new FieldSpecification(FieldSpecification.FieldTypes.DateTime2, 7) },
                { "RatePerCar", new FieldSpecification(FieldSpecification.FieldTypes.Decimal, 9, 2) },
                { "RatePerPartialTrip", new FieldSpecification(FieldSpecification.FieldTypes.Decimal, 9, 2) }
            };
            createTable.Execute(transaction);
            CreateForeignKey(transaction, createTable, "fleet", "TrainSymbol");

            createTable.TableName = "Train";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "TrainID", new FieldSpecification(FieldSpecification.FieldTypes.Bit) { IsPrimary = true } },
                { "TrainSymbolID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "TrainInstructions", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 300) },
                { "Status", new FieldSpecification(FieldSpecification.FieldTypes.Int) }
            };
            createTable.Execute(transaction);
            CreateForeignKey(transaction, createTable, "fleet", "TrainSymbol");

            createTable.TableName = "TrainDutyTransaction";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "TrainDutyTransactionID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "TrainID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "UserIDOperator", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "TimeOnDuty", new FieldSpecification(FieldSpecification.FieldTypes.DateTime2, 7) },
                { "TimeOffDuty", new FieldSpecification(FieldSpecification.FieldTypes.DateTime2, 7) }
            };
            createTable.Execute(transaction);
            CreateForeignKey(transaction, createTable, "fleet", "Train");
            CreateForeignKey(transaction, createTable, "security", "User");

            createTable.TableName = "TrainFuelRecord";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "TrainFuelRecordID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "TrainID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "LocomotiveID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "FuelStart", new FieldSpecification(FieldSpecification.FieldTypes.Decimal, 4, 1) },
                { "FuelEnd", new FieldSpecification(FieldSpecification.FieldTypes.Decimal, 4, 1) }
            };
            createTable.Execute(transaction);
            CreateForeignKey(transaction, createTable, "fleet", "Train");
            CreateForeignKey(transaction, createTable, "fleet", "Locomotive");

            createTable.TableName = "RailDistrict";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "RailDistrictID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "CompanyIDOperator", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "GovenrmentIDOperator", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "Name", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 50) }
            };
            createTable.Execute(transaction);
            CreateForeignKey(transaction, createTable, "gov", "Government");
            CreateForeignKey(transaction, createTable, "company", "Company");

            createTable.TableName = "Track";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "TrackID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "RailDistrictID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "CompanyIDOwner", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "GovernmentIDOwner", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "Name", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 30) },
                { "Length", new FieldSpecification(FieldSpecification.FieldTypes.Decimal, 6, 2) }
            };
            createTable.Execute(transaction);
            CreateForeignKey(transaction, createTable, "fleet", "RailDistrict");
            CreateForeignKey(transaction, createTable, "gov", "Government");
            CreateForeignKey(transaction, createTable, "company", "Company");

            IAlterTable alterTable = SQLProviderFactory.GetAlterTableQuery();
            alterTable.Schema = "fleet";
            alterTable.Table = "Railcar";
            alterTable.AddForeignKey("FKRailcar_Track_TrackIDDestination", "TrackIDDestination", "fleet", "Track", "TrackID", transaction);
            alterTable.AddForeignKey("FKRailcar_Track_TrackIDStrategic", "TrackIDStrategic", "fleet", "Track", "TrackID", transaction);

            createTable.TableName = "RailLocation";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "RailLocationID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "RailcarID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "LocomotiveID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "Position", new FieldSpecification(FieldSpecification.FieldTypes.Int) },
                { "TrackID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "TrainID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) }
            };
            createTable.Execute(transaction);
            CreateForeignKey(transaction, createTable, "fleet", "Railcar");
            CreateForeignKey(transaction, createTable, "fleet", "Locomotive");
            CreateForeignKey(transaction, createTable, "fleet", "Track");
            CreateForeignKey(transaction, createTable, "fleet", "Train");

            createTable.TableName = "RailcarLocationTransaction";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "RailcarLocationTransactionID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "RailcarID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "TrackIDNew", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "TrainIDNew", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "IsPartialTrainTrip", new FieldSpecification(FieldSpecification.FieldTypes.Bit) },
                { "TransactionTime", new FieldSpecification(FieldSpecification.FieldTypes.DateTime2, 7) },
                { "InvoiceID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "WillNotCharge", new FieldSpecification(FieldSpecification.FieldTypes.Bit) { DefaultValue = false } }
            };
            createTable.Execute(transaction);
            CreateForeignKey(transaction, createTable, "fleet", "Railcar");
            CreateForeignKey(transaction, createTable, "fleet", "Track");
            CreateForeignKey(transaction, createTable, "fleet", "Train");
            CreateForeignKey(transaction, createTable, "invoicing", "Invoice");

            createTable.TableName = "CarHandlingRate";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "CarHandlingRateID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) {IsPrimary = true } },
                { "CompanyID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "GovernmentID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "IntraDistrictRate", new FieldSpecification(FieldSpecification.FieldTypes.Decimal, 9, 2) },
                { "InterDistrictRate", new FieldSpecification(FieldSpecification.FieldTypes.Decimal, 9, 2) },
                { "PlacementRate", new FieldSpecification(FieldSpecification.FieldTypes.Decimal, 9, 2) },
                { "EffectiveTime", new FieldSpecification(FieldSpecification.FieldTypes.DateTime2, 7) }
            };
            createTable.Execute(transaction);
            CreateForeignKey(transaction, createTable, "company", "CompanyID");
            CreateForeignKey(transaction, createTable, "gov", "GovernmentID");

            createTable.TableName = "MiscellaneousSettings";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "MiscellaneousSettingsID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "CompanyID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "GovernmentID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "LocationIDInvoicePayee", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "LocationIDInvoicePayor", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "EmailImplementationIDCarReleased", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "EmailImplementationIDLocomotiveReleased", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "EmailImplementationIDLeaseRequestAvailable", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "EmailImplementationIDLeaseBidReceived", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) }
            };
            createTable.Execute(transaction);
            CreateForeignKey(transaction, createTable, "company", "Company");
            CreateForeignKey(transaction, createTable, "gov", "Government");
            CreateForeignKey(transaction, createTable, "company", "Location", "LocationIDInvoicePayee");
            CreateForeignKey(transaction, createTable, "company", "Location", "LocationIDInvoicePayor");
            CreateForeignKey(transaction, createTable, "mesasys", "EmailImplementation", "EmailImplementationIDCarReleased");
            CreateForeignKey(transaction, createTable, "mesasys", "EmailImplementation", "EmailImplementationIDLocomotiveReleased");
            CreateForeignKey(transaction, createTable, "mesasys", "EmailImplementation", "EmailImplementationIDLeaseRequestAvailable");
            CreateForeignKey(transaction, createTable, "mesasys", "EmailImplementation", "EmailImplementationIDLeaseBidReceived");

            createTable.SchemaName = "mesasys";
            createTable.TableName = "ItemNamespace";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "ItemNamespaceID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "Namespace", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 100) },
                { "FriendlyName", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 100) }
            };
            createTable.Execute(transaction);

            createTable.TableName = "Item";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "ItemID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "ItemNamespaceID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "Name", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 100) },
                { "Image", new FieldSpecification(FieldSpecification.FieldTypes.Binary) },
                { "Hash", new FieldSpecification(FieldSpecification.FieldTypes.Binary) }
            };
            createTable.Execute(transaction);
            CreateForeignKey(transaction, createTable, "mesasys", "ItemNamespace");

            createTable.SchemaName = "fleet";
            createTable.TableName = "RailcarLoad";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "RailcarLoadID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "RailcarID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "ItemID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "Quantity", new FieldSpecification(FieldSpecification.FieldTypes.Decimal, 9, 2) }
            };
            createTable.Execute(transaction);
            CreateForeignKey(transaction, createTable, "fleet", "Railcar");
            CreateForeignKey(transaction, createTable, "mesasys", "Item");

            createTable.TableName = "LiveLoad";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "LiveLoadID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "TrainID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "Code", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 4) }
            };
            createTable.Execute(transaction);
            CreateForeignKey(transaction, createTable, "fleet", "Train");

            createTable.TableName = "LiveLoadSession";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "LiveLoadSessionID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "LiveLoadID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "UserID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "CompanyID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "GovernmentID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "LastHeartbeat", new FieldSpecification(FieldSpecification.FieldTypes.DateTime2, 7) }
            };
            createTable.Execute(transaction);
            CreateForeignKey(transaction, createTable, "security", "User");
            CreateForeignKey(transaction, createTable, "company", "Company");
            CreateForeignKey(transaction, createTable, "gov", "Government");

            alterTable.Schema = "invoicing";
            alterTable.Table = "InvoiceLine";
            alterTable.AddColumn("ItemID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt), transaction);
            alterTable.AddForeignKey("FKInvoiceLine_Item_ItemID", "ItemID", "mesasys", "Item", "ItemID", transaction);

            createSchema.SchemaName = "netprint";
            createSchema.Execute(transaction);

            createTable.SchemaName = "netprint";
            createTable.TableName = "Printer";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "PrinterID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "Address", new FieldSpecification(FieldSpecification.FieldTypes.UniqueIdentifier) },
                { "Name", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 50) }
            };
            createTable.Execute(transaction);

            createTable.TableName = "PrintJob";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "PrintJobID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "PrinterID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "DocumentName", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 50) },
                { "Finalized", new FieldSpecification(FieldSpecification.FieldTypes.Bit) { DefaultValue = false } }
            };
            createTable.Execute(transaction);
            CreateForeignKey(transaction, createTable, "netprint", "Printer");

            createTable.TableName = "PrintPage";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "PrintPageID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary= true } },
                { "PrintJobID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "DisplayOrder", new FieldSpecification(FieldSpecification.FieldTypes.TinyInt) }
            };
            createTable.Execute(transaction);
            CreateForeignKey(transaction, createTable, "netprint", "PrintJob");

            createTable.TableName = "PrintLine";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "PrintLineID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "PrintPageID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "DisplayOrder", new FieldSpecification(FieldSpecification.FieldTypes.TinyInt) },
                { "Alignment", new FieldSpecification(FieldSpecification.FieldTypes.Int) },
                { "Text", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 50) }
            };
            createTable.Execute(transaction);
            CreateForeignKey(transaction, createTable, "netprint", "PrintLine");
        }

        private void CreateForeignKey(ITransaction transaction, ICreateTable createTableQuery, string parentSchema, string parentTable, string foreignKey = "")
        {
            if (string.IsNullOrEmpty(foreignKey))
            {
                foreach (KeyValuePair<string, FieldSpecification> kvp in createTableQuery.Columns)
                {
                    if (kvp.Key.StartsWith(parentTable + "ID"))
                    {
                        foreignKey = kvp.Key;
                        break;
                    }
                }
            }

            if (string.IsNullOrEmpty(foreignKey))
            {
                throw new InvalidOperationException("Could not determine foreign key");
            }

            IAlterTable alterTable = SQLProviderFactory.GetAlterTableQuery();
            alterTable.Schema = createTableQuery.SchemaName;
            alterTable.Table = createTableQuery.TableName;
            alterTable.AddForeignKey(
                string.Format("FK{0}_{1}_{2}", createTableQuery.TableName, parentTable, foreignKey),
                foreignKey,
                parentSchema,
                parentTable,
                parentTable + "ID",
                transaction);
        }
    }
}
