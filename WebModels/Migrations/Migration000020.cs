using ClussPro.Base.Data;
using ClussPro.Base.Data.Query;

namespace WebModels.Migrations
{
    /// <summary>
    /// Remove fleet.CarHandlingRate and fleet.TrainSymbolRate
    /// </summary>
    internal class Migration000020 : IMigration
    {
        public int MigrationNumber => 20;

        public void Execute(ITransaction transaction)
        {
            IDropTable drop = SQLProviderFactory.GetDropTableQuery();
            drop.Schema = "fleet";
            drop.Table = "CarHandlingRate";
            drop.Execute(transaction);

            drop.Table = "TrainSymbolRate";
            drop.Execute(transaction);

            IAlterTable dropFinanceCols = SQLProviderFactory.GetAlterTableQuery();
            dropFinanceCols.Schema = "fleet";
            dropFinanceCols.Table = "MiscellaneousSettings";
            dropFinanceCols.DropConstraint("FKMiscellaneousSettings_Location_LocationIDInvoicePayee", transaction);
            dropFinanceCols.DropColumn("LocationIDInvoicePayee", transaction);
            dropFinanceCols.DropConstraint("FKMiscellaneousSettings_Location_LocationIDInvoicePayor", transaction);
            dropFinanceCols.DropColumn("LocationIDInvoicePayor", transaction);

            dropFinanceCols.Table = "RailcarLocationTransaction";
            dropFinanceCols.DropConstraint("FKRailcarLocationTransaction_Invoice_InvoiceID", transaction); 
            dropFinanceCols.DropConstraint("DF__RailcarLo__WillN__3D491139", transaction);
            dropFinanceCols.DropColumn("InvoiceID", transaction);
            dropFinanceCols.DropColumn("WillNotCharge", transaction);
        }
    }
}
