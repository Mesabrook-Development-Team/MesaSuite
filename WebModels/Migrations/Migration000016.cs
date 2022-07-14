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
                { "Template", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 4000) },
                { "AllowedFields", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, -1) }
            };
            createTable.Execute(transaction);

            createTable.TableName = "EmailImplementation";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "EmailImplementationID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "EmailTemplateID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "From", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 255) },
                { "To", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 255) },
                { "Subject", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 50) },
                { "Body", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 4000) }
            };
            createTable.Execute(transaction);

            createTable.TableName = "OutboundEmail";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "OutboundEmailID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "From", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 255) },
                { "To", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 255) },
                { "Subject", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 50) },
                { "Body", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 4000) }
            };
            createTable.Execute(transaction);

            IAlterTable alterTable = SQLProviderFactory.GetAlterTableQuery();
            alterTable.Schema = "mesasys";
            alterTable.Table = "EmailImplementation";
            alterTable.AddForeignKey("FKEmailImplementation_EmailTemplate_EmailTemplateID", "EmailTemplateID", "mesasys", "EmailTemplate", "EmailTemplateID", transaction);
        }
    }
}
