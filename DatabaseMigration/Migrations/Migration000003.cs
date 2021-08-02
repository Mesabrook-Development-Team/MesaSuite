using ClussPro.Base.Data;
using ClussPro.Base.Data.Query;

namespace DatabaseMigration.Migrations
{
    public class Migration000003 : IMigration
    {
        public int MigrationNumber => 3;

        public void Execute(ITransaction transaction)
        {
            IAlterTable alterTable = SQLProviderFactory.GetAlterTableQuery();
            alterTable.Schema = "company";
            alterTable.Table = "Company";

            alterTable.AddColumn("EmailDomain", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 80));
        }
    }
}
