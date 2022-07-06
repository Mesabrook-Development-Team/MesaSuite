using System.Collections.Generic;
using ClussPro.Base.Data;
using ClussPro.Base.Data.Query;

namespace WebModels.Migrations
{
    /// <summary>
    /// Create the account.WireTransferHistory table. Add IssueWireTransfers to company.LocationEmployee and gov.Official.
    /// </summary>
    public class Migration000015 : IMigration
    {
        public int MigrationNumber => 15;

        public void Execute(ITransaction transaction)
        {
            ICreateTable createTable = SQLProviderFactory.GetCreateTableQuery();
            createTable.SchemaName = "account";
            createTable.TableName = "WireTransferHistory";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "WireTransferHistoryID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "GovernmentIDFrom", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "CompanyIDFrom", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "GovernmentIDTo", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "CompanyIDTo", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "TransferTime", new FieldSpecification(FieldSpecification.FieldTypes.DateTime2, 7) },
                { "AccountFromHistorical", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 69 ) },
                { "AccountFromMasked", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 16) },
                { "AccountToHistorical", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 69 ) },
                { "AccountToMasked", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 16) },
                { "Amount", new FieldSpecification(FieldSpecification.FieldTypes.Decimal, 9, 2) },
                { "Memo", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 100) }
            };
            createTable.Execute(transaction);

            IAlterTable addPermission = SQLProviderFactory.GetAlterTableQuery();
            addPermission.Schema = "company";
            addPermission.Table = "Employee";
            addPermission.AddColumn("IssueWireTransfers", new FieldSpecification(FieldSpecification.FieldTypes.Bit) { DefaultValue = false }, transaction);

            addPermission.Schema = "gov";
            addPermission.Table = "Official";
            addPermission.AddColumn("IssueWireTransfers", new FieldSpecification(FieldSpecification.FieldTypes.Bit) { DefaultValue = false }, transaction);

            IAlterTable addForeignKey = SQLProviderFactory.GetAlterTableQuery();
            addForeignKey.Schema = "account";
            addForeignKey.Table = "WireTransferHistory";
            addForeignKey.AddForeignKey("FKWireTransferHistory_Company_CompanyIDFrom", "CompanyIDFrom", "company", "Company", "CompanyID", transaction);
            addForeignKey.AddForeignKey("FKWireTransferHistory_Company_CompanyIDTo", "CompanyIDTo", "company", "Company", "CompanyID", transaction);
            addForeignKey.AddForeignKey("FKWireTransferHistory_Gov_GovernmentIDFrom", "GovernmentIDFrom", "gov", "Government", "GovernmentID", transaction);
            addForeignKey.AddForeignKey("FKWireTransferHistory_Gov_GovernmentIDTo", "GovernmentIDTo", "gov", "Government", "GovernmentID", transaction);
        }
    }
}
