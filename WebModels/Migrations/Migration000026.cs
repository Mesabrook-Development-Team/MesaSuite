using System.Collections.Generic;
using ClussPro.Base.Data;
using ClussPro.Base.Data.Query;

namespace WebModels.Migrations
{
    public class Migration000026 : IMigration
    {
        public int MigrationNumber => 25;

        public void Execute(ITransaction transaction)
        {
            ICreateTable table = SQLProviderFactory.GetCreateTableQuery();
            table.SchemaName = "gov";
            table.TableName = "Law";
            table.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "LawID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "GovernmentID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "Name", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 30) },
                { "DisplayOrder", new FieldSpecification(FieldSpecification.FieldTypes.TinyInt) }
            };
            table.Execute(transaction);
            IAlterTable alterTable = SQLProviderFactory.GetAlterTableQuery();
            alterTable.Schema = "gov";
            alterTable.Table = "Law";
            alterTable.AddForeignKey("FKLaw_Government_GovernmentID", "GovernmentID", "gov", "Government", "GovernmentID", transaction);

            table.TableName = "LawSection";
            table.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "LawSectionID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary= true } },
                { "LawID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "Title", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 30) },
                { "Detail", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, -1) },
                { "DisplayOrder", new FieldSpecification(FieldSpecification.FieldTypes.TinyInt) }
            };
            table.Execute(transaction);
            alterTable.Table = "LawSection";
            alterTable.AddForeignKey("FKLawSection_Law_LawID", "LawID", "gov", "Law", "LawID", transaction);

            alterTable.Table = "Official";
            alterTable.AddColumn("ManageLaws", new FieldSpecification(FieldSpecification.FieldTypes.Bit) { DefaultValue = false }, transaction);
        }
    }
}
