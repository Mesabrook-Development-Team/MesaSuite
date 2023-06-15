using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClussPro.Base.Data;
using ClussPro.Base.Data.Query;

namespace WebModels.Migrations
{
    public class Migration000024 : IMigration
    {
        public int MigrationNumber => 24;

        public void Execute(ITransaction transaction)
        {
            ICreateTable createTable = SQLProviderFactory.GetCreateTableQuery();
            createTable.SchemaName = "gov";
            createTable.TableName = "InterestConfiguration";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "InterestConfigurationID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "RateGovernment", new FieldSpecification(FieldSpecification.FieldTypes.Decimal, 5, 2) },
                { "WealthCapGovernment", new FieldSpecification(FieldSpecification.FieldTypes.Decimal, 9, 2) },
                { "RateLocation", new FieldSpecification(FieldSpecification.FieldTypes.Decimal, 5, 2) },
                { "WealthCapLocation", new FieldSpecification(FieldSpecification.FieldTypes.Decimal, 9, 2) },
                { "NextInterestRun", new FieldSpecification(FieldSpecification.FieldTypes.DateTime2, 7) }
            };
            createTable.Execute(transaction);

            IAlterTable alterTable = SQLProviderFactory.GetAlterTableQuery();
            alterTable.Schema = "gov";
            alterTable.Table = "Government";
            alterTable.AddColumn("CanConfigureInterest", new FieldSpecification(FieldSpecification.FieldTypes.Bit) { DefaultValue = false }, transaction);

            alterTable.Table = "Official";
            alterTable.AddColumn("CanConfigureInterest", new FieldSpecification(FieldSpecification.FieldTypes.Bit) { DefaultValue = false }, transaction);
        }
    }
}
