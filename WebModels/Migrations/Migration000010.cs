using System.Collections.Generic;
using ClussPro.Base.Data;
using ClussPro.Base.Data.Query;

namespace WebModels.Migrations
{
    internal class Migration000010 : IMigration
    {
        public int MigrationNumber => 10;

        public void Execute(ITransaction transaction)
        {
            IAlterTable alterTable = SQLProviderFactory.GetAlterTableQuery();
            alterTable.Schema = "company";
            alterTable.Table = "Employee";
            alterTable.AddColumn("ManageLocations", new FieldSpecification(FieldSpecification.FieldTypes.Bit) { DefaultValue = false });

            alterTable.Schema = "gov";
            alterTable.Table = "Official";
            alterTable.AddColumn("ManageInvoices", new FieldSpecification(FieldSpecification.FieldTypes.Bit) { DefaultValue = false });

            alterTable.Table = "SalesTax";
            alterTable.AddColumn("AccountID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt));
            alterTable.AddForeignKey("FKSalesTax_Account_AccountID", "AccountID", "account", "Account", "AccountID", transaction);

            ICreateTable createTable = SQLProviderFactory.GetCreateTableQuery();
            createTable.SchemaName = "company";
            createTable.TableName = "Location";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "LocationID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "CompanyID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "Name", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 50) },
                { "InvoiceNumberPrefix", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 3) },
                { "NextInvoiceNumber", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 8) }
            };
            createTable.Execute(transaction);
            alterTable.Schema = "company";
            alterTable.Table = "Location";
            alterTable.AddForeignKey("FKLocation_Company_CompanyID", "CompanyID", "company", "Company", "CompanyID", transaction);

            createTable.TableName = "LocationEmployee";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "LocationEmployeeID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "LocationID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "EmployeeID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "ManageInvoices", new FieldSpecification(FieldSpecification.FieldTypes.Bit) { DefaultValue = false } }
            };
            createTable.Execute(transaction);
            alterTable.Table = "LocationEmployee";
            alterTable.AddForeignKey("FKLocationEmployee_Location_LocationID", "LocationID", "company", "Location", "LocationID", transaction);
            alterTable.AddForeignKey("FKLocationEmployee_Employee_EmployeeID", "EmployeeID", "company", "Employee", "EmployeeID", transaction);

            createTable.TableName = "LocationGovernment";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "LocationGovernmentID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "LocationID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "GovernmentID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "PaySalesTax", new FieldSpecification(FieldSpecification.FieldTypes.Bit) { DefaultValue = false } }
            };
            createTable.Execute(transaction);
            alterTable.Table = "LocationGovernment";
            alterTable.AddForeignKey("FKLocationGovernment_Location_LocationID", "LocationID", "company", "Location", "LocationID", transaction);
            alterTable.AddForeignKey("FKLocationGovernment_Government_GovernmentID", "GovernmentID", "gov", "Government", "GovernmentID", transaction);

            ICreateSchema createSchema = SQLProviderFactory.GetCreateSchemaQuery();
            createSchema.SchemaName = "invoicing";
            createSchema.Execute(transaction);

            createTable.SchemaName = "invoicing";
            createTable.TableName = "Invoice";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "InvoiceID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "GovernmentIDFrom", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "LocationIDFrom", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "GovernmentIDTo", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "LocationIDTo", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "InvoiceNumber", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 11) },
                { "Description", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 300) },
                { "DueDate", new FieldSpecification(FieldSpecification.FieldTypes.DateTime2, 7) },
                { "CreationType", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 2) },
                { "Status", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 1) },
                { "AccountIDFrom", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "AccountFromHistorical", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 69) },
                { "AccountIDTo", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "AccountToHistorical", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 69) },
            };
            createTable.Execute(transaction);
            alterTable.Schema = "invoicing";
            alterTable.Table = "Invoice";
            alterTable.AddForeignKey("FKInvoice_Government_GovernmentIDFrom", "GovernmentIDFrom", "gov", "Government", "GovernmentID", transaction);
            alterTable.AddForeignKey("FKInvoice_Government_GovernmentIDTo", "GovernmentIDTo", "gov", "Government", "GovernmentID", transaction);
            alterTable.AddForeignKey("FKInvoice_Location_LocationIDFrom", "LocationIDFrom", "company", "Location", "LocationID", transaction);
            alterTable.AddForeignKey("FKInvoice_Location_LocationIDTo", "LocationIDTo", "company", "Location", "LocationID", transaction);

            createTable.TableName = "InvoiceLine";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "InvoiceLineID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "InvoiceID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "Quantity", new FieldSpecification(FieldSpecification.FieldTypes.Decimal, 9, 2) },
                { "UnitCost", new FieldSpecification(FieldSpecification.FieldTypes.Decimal, 9, 2) },
                { "Total", new FieldSpecification(FieldSpecification.FieldTypes.Decimal, 9, 2) },
                { "Description", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 300) }
            };
            createTable.Execute(transaction);
            alterTable.Table = "InvoiceLine";
            alterTable.AddForeignKey("FKInvoiceLine_Invoice_InvoiceID", "InvoiceID", "invoicing", "Invoice", "InvoiceID", transaction);

            createTable.TableName = "InvoiceSalesTax";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "InvoiceSalesTaxID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "InvoiceID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "Municipality", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 50) },
                { "Rate", new FieldSpecification(FieldSpecification.FieldTypes.Decimal, 5, 2) },
                { "AppliedAmount", new FieldSpecification(FieldSpecification.FieldTypes.Decimal, 9, 2) }
            };
            createTable.Execute(transaction);
            alterTable.Table = "InvoiceSalesTax";
            alterTable.AddForeignKey("FKInvoiceSalesTax_Invoice_InvoiceID", "InvoiceID", "invoicing", "Invoice", "InvoiceID", transaction);
        }
    }
}
