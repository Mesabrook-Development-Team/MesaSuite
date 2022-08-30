using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClussPro.Base.Data;
using ClussPro.Base.Data.Query;

namespace WebModels.Migrations
{
    public class Migration000017 : IMigration
    {
        public int MigrationNumber => 17;

        public void Execute(ITransaction transaction)
        {
            ICreateSchema createSchema = SQLProviderFactory.GetCreateSchemaQuery();
            createSchema.SchemaName = "fleet";
            createSchema.Execute(transaction);

            ICreateTable createTable = SQLProviderFactory.GetCreateTableQuery();
            createTable.SchemaName = "fleet";
            createTable.TableName = "LocomotiveModel";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "LocomotiveModelID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "Name", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 30) },
                { "FuelCapacity", new FieldSpecification(FieldSpecification.FieldTypes.Decimal, 4, 0) },
                { "WaterCapacity", new FieldSpecification(FieldSpecification.FieldTypes.Decimal, 3, 0) },
                { "Length", new FieldSpecification(FieldSpecification.FieldTypes.Decimal, 3, 1) },
                { "IsSteamPowered", new FieldSpecification(FieldSpecification.FieldTypes.Bit) { DefaultValue = false } },
                { "Image", new FieldSpecification(FieldSpecification.FieldTypes.Binary) }
            };
            createTable.Execute(transaction);

            createTable.TableName = "RailcarModel";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "RailcarModelID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "Name", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 30) },
                { "CargoCapacity", new FieldSpecification(FieldSpecification.FieldTypes.Decimal, 4, 0) },
                { "Length", new FieldSpecification(FieldSpecification.FieldTypes.Decimal, 3, 1) },
                { "Type", new FieldSpecification(FieldSpecification.FieldTypes.Int) },
                { "Image", new FieldSpecification(FieldSpecification.FieldTypes.Binary) }
            };
            createTable.Execute(transaction);

            createTable.TableName = "Locomotive";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "LocomotiveID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "LocomotiveModelID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "GovernmentIDOwner", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "CompanyIDOwner", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "ReportingMark", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 4) },
                { "ReportingNumber", new FieldSpecification(FieldSpecification.FieldTypes.Int) },
                { "ImageOverride", new FieldSpecification(FieldSpecification.FieldTypes.Binary) }
            };
            createTable.Execute(transaction);
            CreateForeignKey(transaction, createTable, "fleet", "LocomotiveModel");
            CreateForeignKey(transaction, createTable, "gov", "Government");
            CreateForeignKey(transaction, createTable, "company", "Company");

            createTable.TableName = "Railcar";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "RailcarID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "RailcarModelID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "GovernmentIDOwner", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "CompanyIDOwner", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "ReportingMark", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 4) },
                { "ReportingNumber", new FieldSpecification(FieldSpecification.FieldTypes.Int) },
                { "ImageOverride", new FieldSpecification(FieldSpecification.FieldTypes.Binary) }
            };
            createTable.Execute(transaction);
            CreateForeignKey(transaction, createTable, "fleet", "RailcarModel");
            CreateForeignKey(transaction, createTable, "gov", "Government");
            CreateForeignKey(transaction, createTable, "company", "Company");
        }

        private void CreateForeignKey(ITransaction transaction, ICreateTable createTableQuery, string parentSchema, string parentTable)
        {
            string foreignKey = "";
            foreach(KeyValuePair<string, FieldSpecification> kvp in createTableQuery.Columns)
            {
                if (kvp.Key.StartsWith(parentTable + "ID"))
                {
                    foreignKey = kvp.Key;
                    break;
                }
            }

            if (string.IsNullOrEmpty(foreignKey))
            {
                throw new InvalidOperationException("Could not determine foreign key");
            }

            IAlterTable alterTable = SQLProviderFactory.GetAlterTableQuery();
            alterTable.Schema = createTableQuery.SchemaName;
            alterTable.Table = createTableQuery.TableName;
            alterTable.AddForeignKey(
                string.Format("FK{0}_{1}_{2}", createTableQuery.TableName, parentSchema, parentTable),
                foreignKey,
                parentSchema,
                parentTable,
                parentTable + "ID",
                transaction);
        }
    }
}
