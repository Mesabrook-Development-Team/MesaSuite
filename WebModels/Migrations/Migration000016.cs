using System.Collections.Generic;
using ClussPro.Base.Data;
using ClussPro.Base.Data.Query;

namespace WebModels.Migrations
{
    public class Migration000016 : IMigration
    {
        public int MigrationNumber => 16;

        public void Execute(ITransaction transaction)
        {
            ICreateTable createTable = SQLProviderFactory.GetCreateTableQuery();
            createTable.SchemaName = "mesasys";
            createTable.TableName = "EmailTemplate";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "EmailTemplateID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "SystemID", new FieldSpecification(FieldSpecification.FieldTypes.UniqueIdentifier) },
                { "SystemHash", new FieldSpecification(FieldSpecification.FieldTypes.Binary) },
                { "Name", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 255) },
                { "TemplateSchema", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 30) },
                { "TemplateObject", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 100) },
                { "Template", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 4000) },
                { "AllowedFields", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, -1) },
                { "SecurityCheckType", new FieldSpecification(FieldSpecification.FieldTypes.Int) }
            };
            createTable.Execute(transaction);

            createTable.TableName = "EmailImplementation";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "EmailImplementationID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "EmailTemplateID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "FromName", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 100) },
                { "FromEmail", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 255) },
                { "To", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 255) },
                { "Subject", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 50) },
                { "Body", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 4000) }
            };
            createTable.Execute(transaction);

            createTable.TableName = "OutboundEmail";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "OutboundEmailID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "FromName", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 100) },
                { "FromEmail", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 255) },
                { "To", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 255) },
                { "Subject", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 50) },
                { "Body", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 4000) }
            };
            createTable.Execute(transaction);

            IAlterTable alterTable = SQLProviderFactory.GetAlterTableQuery();
            alterTable.Schema = "mesasys";
            alterTable.Table = "EmailImplementation";
            alterTable.AddForeignKey("FKEmailImplementation_EmailTemplate_EmailTemplateID", "EmailTemplateID", "mesasys", "EmailTemplate", "EmailTemplateID", transaction);

            alterTable.Schema = "company";
            alterTable.Table = "Company";
            alterTable.AddColumn("EmailImplementationIDWireTransferHistory", new FieldSpecification(FieldSpecification.FieldTypes.BigInt), transaction);
            alterTable.AddForeignKey("FKCompany_EmailImplementation_EmailImplementationIDWireTransferHistory", "EmailImplementationIDWireTransferHistory", "mesasys", "EmailImplementation", "EmailImplementationID", transaction);

            alterTable.Table = "Location";
            alterTable.AddColumn("EmailImplementationIDPayableInvoice", new FieldSpecification(FieldSpecification.FieldTypes.BigInt), transaction);
            alterTable.AddForeignKey("FKCompany_EmailImplementation_EmailImplementationIDPayableInvoice", "EmailImplementationIDPayableInvoice", "mesasys", "EmailImplementation", "EmailImplementationID", transaction);
            alterTable.AddColumn("EmailImplementationIDReadyForReceipt", new FieldSpecification(FieldSpecification.FieldTypes.BigInt), transaction);
            alterTable.AddForeignKey("FKCompany_EmailImplementation_EmailImplementationIDReadyForReceipt", "EmailImplementationIDReadyForReceipt", "mesasys", "EmailImplementation", "EmailImplementationID", transaction);
        }
    }
}
