using ClussPro.Base.Data;
using ClussPro.Base.Data.Query;

namespace WebModels.Migrations
{
    // Add InvoiceNumberPrefix and NextInvoiceNumber to gov.Government
    public class Migration000014 : IMigration
    {
        public int MigrationNumber => 14;

        public void Execute(ITransaction transaction)
        {
            IAlterTable alterTable = SQLProviderFactory.GetAlterTableQuery();
            alterTable.Schema = "gov";
            alterTable.Table = "Government";
            alterTable.AddColumn("InvoiceNumberPrefix", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 3), transaction);
            alterTable.AddColumn("NextInvoiceNumber", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 8), transaction);
        }
    }
}
