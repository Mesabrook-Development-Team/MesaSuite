using ClussPro.Base.Data;
using ClussPro.Base.Data.Query;

namespace WebModels.Migrations
{
    /// <summary>
    /// Add EmailDomain to gov.Government
    /// </summary>
    public class Migration000006 : IMigration
    {
        public int MigrationNumber => 6;

        public void Execute(ITransaction transaction)
        {
            IAlterTable alterTable = SQLProviderFactory.GetAlterTableQuery();
            alterTable.Schema = "gov";
            alterTable.Table = "Government";
            alterTable.AddColumn("EmailDomain", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 80), transaction);
        }
    }
}
