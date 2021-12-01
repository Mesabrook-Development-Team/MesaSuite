using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClussPro.Base.Data;
using ClussPro.Base.Data.Query;

namespace WebModels.Migrations
{
    /// <summary>
    /// Create the CrashReport table in the mesasys schema.
    /// </summary>
    public class Migration000005 : IMigration
    {
        public int MigrationNumber => 5;

        public void Execute(ITransaction transaction)
        {
            ICreateTable createTable = SQLProviderFactory.GetCreateTableQuery();
            createTable.SchemaName = "mesasys";
            createTable.TableName = "CrashReport";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "CrashReportID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "Time", new FieldSpecification(FieldSpecification.FieldTypes.DateTime2, 7) },
                { "Program", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 100) },
                { "Exception", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, -1) },
                { "User", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 50) }
            };
            createTable.Execute(transaction);
        }
    }
}
