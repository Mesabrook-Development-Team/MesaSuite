using System.Collections.Generic;
using ClussPro.Base.Data;
using ClussPro.Base.Data.Query;

namespace WebModels.Migrations
{
    /// <summary>
    /// Create the gov.SalesTax table.
    /// Add permission for ManageTaxes on Officials.
    /// </summary>
    internal class Migration000009 : IMigration
    {
        public int MigrationNumber => 9;

        public void Execute(ITransaction transaction)
        {
            ICreateTable table = SQLProviderFactory.GetCreateTableQuery();
            table.SchemaName = "gov";
            table.TableName = "SalesTax";
            table.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "SalesTaxID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "GovernmentID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "EffectiveDate", new FieldSpecification(FieldSpecification.FieldTypes.DateTime2, 7) },
                { "Rate", new FieldSpecification(FieldSpecification.FieldTypes.Decimal, 5, 2) }
            };
            table.Execute(transaction);

            IAlterTable alterTable = SQLProviderFactory.GetAlterTableQuery();
            alterTable.Schema = "gov";
            alterTable.Table = "SalesTax";
            alterTable.AddForeignKey("FKSalesTax_Government_GovernmentID", "GovernmentID", "gov", "Government", "GovernmentID", transaction);

            alterTable.Table = "Official";
            alterTable.AddColumn("ManageTaxes", new FieldSpecification(FieldSpecification.FieldTypes.Bit) { DefaultValue = false }, transaction);
        }
    }
}
