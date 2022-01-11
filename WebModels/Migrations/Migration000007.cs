using ClussPro.Base.Data;
using ClussPro.Base.Data.Query;

namespace WebModels.Migrations
{
    internal class Migration000007 : IMigration
    {
        public int MigrationNumber => 7;

        public void Execute(ITransaction transaction)
        {
            IAlterTable alterTable = SQLProviderFactory.GetAlterTableQuery();
            alterTable.Schema = "gov";
            alterTable.Table = "Official";
            alterTable.AddColumn("ManageAccounts", new FieldSpecification(FieldSpecification.FieldTypes.Bit) { DefaultValue = false }, transaction);

            alterTable.Schema = "account";
            alterTable.Table = "Account";
            alterTable.AddColumn("GovernmentID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt), transaction);
            alterTable.AddForeignKey("FKAccount_Government_GovernmentID", "GovernmentID", "gov", "Government", "GovernmentID", transaction);

            alterTable.Table = "Category";
            alterTable.AddColumn("GovernmentID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt), transaction);
            alterTable.AddForeignKey("FKCategory_Government_GovernmentID", "GovernmentID", "gov", "Government", "GovernmentID", transaction);
        }
    }
}
