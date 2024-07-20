using ClussPro.Base.Data;
using ClussPro.Base.Data.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebModels.Migrations
{
    public class Migration000029 : IMigration
    {
        public int MigrationNumber => 29;

        public void Execute(ITransaction transaction)
        {
            DropConstraintsAndColumns(transaction);
            DropEmailTables(transaction);
        }

        private static void DropEmailTables(ITransaction transaction)
        {
            IDropTable dropTable = SQLProviderFactory.GetDropTableQuery();
            dropTable.Schema = "mesasys";
            dropTable.Table = "EmailImplementation";
            dropTable.Execute(transaction);

            dropTable.Table = "EmailTemplate";
            dropTable.Execute(transaction);
        }

        private void DropConstraintsAndColumns(ITransaction transaction)
        {
            IAlterTable alterTable = SQLProviderFactory.GetAlterTableQuery();
            alterTable.Schema = "company";
            alterTable.Table = "Company";
            alterTable.DropConstraint("FKCompany_EmailImplementation_EmailImplementationIDWireTransferHistory", transaction);
            alterTable.DropColumn("EmailImplementationIDWireTransferHistory", transaction);

            alterTable.Table = "Location";
            alterTable.DropConstraint("FKLocation_EmailImplementation_EmailImplementationIDRegisterOffline", transaction);
            alterTable.DropColumn("EmailImplementationIDRegisterOffline", transaction);
            alterTable.DropConstraint("FKLocation_EmailImplementation_EmailImplementationIDPayableInvoice", transaction);
            alterTable.DropColumn("EmailImplementationIDPayableInvoice", transaction);
            alterTable.DropConstraint("FKLocation_EmailImplementation_EmailImplementationIDReadyForReceipt", transaction);
            alterTable.DropColumn("EmailImplementationIDReadyForReceipt", transaction);

            alterTable.Schema = "gov";
            alterTable.Table = "Government";
            alterTable.DropConstraint("FKGovernment_EmailImplementation_EmailImplementationIDPayableInvoice", transaction);
            alterTable.DropColumn("EmailImplementationIDPayableInvoice", transaction);
            alterTable.DropConstraint("FKGovernment_EmailImplementation_EmailImplementationIDReadyForReceipt", transaction);
            alterTable.DropColumn("EmailImplementationIDReadyForReceipt", transaction);
            alterTable.DropConstraint("FKGovernment_EmailImplementation_EmailImplementationIDWireTransferHistory", transaction);
            alterTable.DropColumn("EmailImplementationIDWireTransferHistory", transaction);

            alterTable.Schema = "fleet";
            alterTable.Table = "MiscellaneousSettings";
            alterTable.DropConstraint("FKMiscellaneousSettings_EmailImplementation_EmailImplementationIDCarReleased", transaction);
            alterTable.DropColumn("EmailImplementationIDCarReleased", transaction);
            alterTable.DropConstraint("FKMiscellaneousSettings_EmailImplementation_EmailImplementationIDLeaseBidReceived", transaction);
            alterTable.DropColumn("EmailImplementationIDLeaseBidReceived", transaction);
            alterTable.DropConstraint("FKMiscellaneousSettings_EmailImplementation_EmailImplementationIDLeaseRequestAvailable", transaction);
            alterTable.DropColumn("EmailImplementationIDLeaseRequestAvailable", transaction);
            alterTable.DropConstraint("FKMiscellaneousSettings_EmailImplementation_EmailImplementationIDLocomotiveReleased", transaction);
            alterTable.DropColumn("EmailImplementationIDLocomotiveReleased", transaction);
        }
    }
}
