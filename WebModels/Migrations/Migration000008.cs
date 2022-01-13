using ClussPro.Base.Data;
using ClussPro.Base.Data.Query;

namespace WebModels.Migrations
{
    internal class Migration000008 : IMigration
    {
        public int MigrationNumber => 8;

        public void Execute(ITransaction transaction)
        {
            IAlterTable alterTable = SQLProviderFactory.GetAlterTableQuery();
            alterTable.Schema = "gov";
            alterTable.Table = "Government";
            alterTable.AddColumn("CanMintCurrency", new FieldSpecification(FieldSpecification.FieldTypes.Bit) { DefaultValue = false }, transaction);

            alterTable.Table = "Official";
            alterTable.AddColumn("CanMintCurrency", new FieldSpecification(FieldSpecification.FieldTypes.Bit) { DefaultValue = false }, transaction);
        }
    }
}
