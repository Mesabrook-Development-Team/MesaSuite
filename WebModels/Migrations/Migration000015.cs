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
                { "LocationIDFrom", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "To", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 103) },
                { "AccountFromHistorical", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 69 ) },
                { "AccountToMasked", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 16) },
                { "Amount", new FieldSpecification(FieldSpecification.FieldTypes.Decimal, 9, 2) }
            };
            createTable.Execute(transaction);

            IAlterTable addPermission = SQLProviderFactory.GetAlterTableQuery();
            addPermission.Schema = "company";
            addPermission.Table = "LocationEmployee";
            addPermission.AddColumn("IssueWireTransfers", new FieldSpecification(FieldSpecification.FieldTypes.Bit) { DefaultValue = false }, transaction);

            addPermission.Schema = "gov";
            addPermission.Table = "Official";
            addPermission.AddColumn("IssueWireTransfers", new FieldSpecification(FieldSpecification.FieldTypes.Bit) { DefaultValue = false }, transaction);
        }
    }
}
