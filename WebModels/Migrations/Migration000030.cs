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
        }
    }
}
