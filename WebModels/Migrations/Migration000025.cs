using System.Collections.Generic;
using ClussPro.Base.Data;
using ClussPro.Base.Data.Query;

namespace WebModels.Migrations
{
    public class Migration000025 : IMigration
    {
        public int MigrationNumber => 25;

        public void Execute(ITransaction transaction)
        {
            CreateNewTables(transaction);
            UpdateTables(transaction);
        }

        private void CreateNewTables(ITransaction transaction)
        {
            ICreateTable createTable = SQLProviderFactory.GetCreateTableQuery();
            createTable.SchemaName = "company";
            createTable.TableName = "Register";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "RegisterID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "LocationID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "Identifier", new FieldSpecification(FieldSpecification.FieldTypes.UniqueIdentifier) },
                { "Name", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 30) }
            };
            createTable.Execute(transaction);
            CreateForeignKey(createTable, transaction, "company", "Location");

            createTable.TableName = "LocationItem";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "LocationItemID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "LocationID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "ItemID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "Quantity", new FieldSpecification(FieldSpecification.FieldTypes.SmallInt) },
                { "BasePrice", new FieldSpecification(FieldSpecification.FieldTypes.Decimal, 9, 2) }
            };
            createTable.Execute(transaction);
            CreateForeignKey(createTable, transaction, "company", "LocationID");
            CreateForeignKey(createTable, transaction, "mesasys", "Item");

            createTable.TableName = "StoreSale";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "StoreSaleID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "LocationItemID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "RegisterID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "RingPrice", new FieldSpecification(FieldSpecification.FieldTypes.Decimal, 9, 2) },
                { "SoldPrice", new FieldSpecification(FieldSpecification.FieldTypes.Decimal, 9, 2) },
                { "DiscountReason", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 100) }
            };
            createTable.Execute(transaction);
            CreateForeignKey(createTable, transaction, "company", "LocationItem");
            CreateForeignKey(createTable, transaction, "company", "Register");

            createTable.TableName = "Promotion";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "PromotionID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "LocationID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "StartTime", new FieldSpecification(FieldSpecification.FieldTypes.DateTime2, 7) },
                { "EndTime", new FieldSpecification(FieldSpecification.FieldTypes.DateTime2, 7) },
                { "Name", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 50) }
            };
            createTable.Execute(transaction);
            CreateForeignKey(createTable, transaction, "company", "Location");

            createTable.TableName = "PromotionLocationItem";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "PromotionLocationItemID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "PromotionID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "LocationItemID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "PromotionPrice", new FieldSpecification(FieldSpecification.FieldTypes.Decimal, 9, 2) }
            };
            createTable.Execute(transaction);
            CreateForeignKey(createTable, transaction, "company", "Promotion");
            CreateForeignKey(createTable, transaction, "company", "LocationItem");
        }

        private void UpdateTables(ITransaction transaction)
        {
            IAlterTable alterTable = SQLProviderFactory.GetAlterTableQuery();
            alterTable.Schema = "company";
            alterTable.Table = "Employee";
            alterTable.AddColumn("ManagePrices", new FieldSpecification(FieldSpecification.FieldTypes.Bit) { DefaultValue = false });
            alterTable.AddColumn("ManageRegisters", new FieldSpecification(FieldSpecification.FieldTypes.Bit) { DefaultValue = false });
            alterTable.AddColumn("ManageInventory", new FieldSpecification(FieldSpecification.FieldTypes.Bit) { DefaultValue = false });

            alterTable.Schema = "security";
            alterTable.Table = "User";
            alterTable.AddColumn("IsStoreRegister", new FieldSpecification(FieldSpecification.FieldTypes.Bit) { DefaultValue = false });
        }

        private void CreateForeignKey(ICreateTable createTable, ITransaction transaction, string schema, string table)
        {
            IAlterTable alterTable = SQLProviderFactory.GetAlterTableQuery();
            alterTable.Schema = createTable.SchemaName;
            alterTable.Table = createTable.TableName;
            alterTable.AddForeignKey($"FK{createTable.TableName}_{table}_{table}ID", $"{table}ID", schema, table, $"{table}ID", transaction);
        }
    }
}
