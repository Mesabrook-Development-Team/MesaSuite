using ClussPro.Base.Data;
using ClussPro.Base.Data.Query;
using System.Collections.Generic;

namespace WebModels.Migrations
{
    /// <summary>
    /// Create mesasys.TermsOfService
    /// </summary>
    public class Migration000025 : IMigration
    {
        public int MigrationNumber => 25;

        public void Execute(ITransaction transaction)
        {
            ICreateTable createTable = SQLProviderFactory.GetCreateTableQuery();
            createTable.SchemaName = "mesasys";
            createTable.TableName = "TermsOfService";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "TermsOfServiceID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "Type", new FieldSpecification(FieldSpecification.FieldTypes.Int) },
                { "Terms", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, -1) }
            };
            createTable.Execute(transaction);
        }
    }
}
