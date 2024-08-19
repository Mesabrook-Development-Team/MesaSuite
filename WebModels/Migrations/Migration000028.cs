using ClussPro.Base.Data;
using ClussPro.Base.Data.Query;

namespace WebModels.Migrations
{
    public class Migration000028 : IMigration
    {
        public int MigrationNumber => 28;

        public void Execute(ITransaction transaction)
        {
            IAlterTable alterTable = SQLProviderFactory.GetAlterTableQuery();
            alterTable.Schema = "security";
            alterTable.Table = "User";
            alterTable.AlterColumn("DiscordID", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 20), transaction);
        }
    }
}
