using ClussPro.Base.Data;
using ClussPro.Base.Data.Query;
using System.Collections.Generic;

namespace WebModels.Migrations
{
    public class Migration000030 : IMigration
    {
        public int MigrationNumber => 30;

        public void Execute(ITransaction transaction)
        {
            ICreateTable createTable = SQLProviderFactory.GetCreateTableQuery();
            createTable.SchemaName = "mesasys";
            createTable.TableName = "BlockAudit";

            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "BlockAuditID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "AuditTime", new FieldSpecification(FieldSpecification.FieldTypes.DateTime2, 7) },
                { "PositionX", new FieldSpecification(FieldSpecification.FieldTypes.Int) },
                { "PositionY", new FieldSpecification(FieldSpecification.FieldTypes.Int) },
                { "PositionZ", new FieldSpecification(FieldSpecification.FieldTypes.Int) },
                { "BlockName", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 100) },
                { "PlayerName", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 50) },
                { "AuditType", new FieldSpecification(FieldSpecification.FieldTypes.Int) }
            };
            createTable.Execute(transaction);

            createTable.TableName = "BlockAuditAlertConfig";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "BlockAuditAlertConfigID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "DiscordIDs", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 300) }
            };
            createTable.Execute(transaction);

            createTable.TableName = "BlockAuditAlertConfigBlock";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "BlockAuditAlertConfigBlockID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "BlockAuditAlertConfigID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "BlockName", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 100) },
                { "AlertPlace", new FieldSpecification(FieldSpecification.FieldTypes.Bit) { DefaultValue = false } },
                { "AlertBreak", new FieldSpecification(FieldSpecification.FieldTypes.Bit) { DefaultValue = false } },
                { "AlertUse", new FieldSpecification(FieldSpecification.FieldTypes.Bit) { DefaultValue = false } }
            };
            createTable.Execute(transaction);
            IAlterTable alterTable = SQLProviderFactory.GetAlterTableQuery();
            alterTable.Schema = "mesasys";
            alterTable.Table = "BlockAuditAlertConfigBlock";
            alterTable.AddForeignKey("FKBlockAuditAlertConfigBlock_BlockAuditAlertConfig_BlockAuditAlertConfigID", "BlockAuditAlertConfigID", "mesasys", "BlockAuditAlertConfig", "BlockAuditAlertConfigID", transaction);

            createTable.TableName = "BlockAuditAlert";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "BlockAuditAlertID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "BlockAuditID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "IsAcknowledged", new FieldSpecification(FieldSpecification.FieldTypes.Bit) { DefaultValue = false } }
            };
            createTable.Execute(transaction);
            alterTable.Table = "BlockAuditAlert";
            alterTable.AddForeignKey("FKBlockAuditAlert_BlockAudit_BlockAuditID", "BlockAuditID", "mesasys", "BlockAudit", "BlockAuditID", transaction);
        }
    }
}
