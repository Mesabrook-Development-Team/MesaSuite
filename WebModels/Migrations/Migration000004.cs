using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClussPro.Base.Data;
using ClussPro.Base.Data.Query;

namespace WebModels.Migrations
{

    public class Migration000004 : IMigration
    {
        public int MigrationNumber => 4;

        public void Execute(ITransaction transaction)
        {
            ICreateSchema createSchema = SQLProviderFactory.GetCreateSchemaQuery();
            createSchema.SchemaName = "account";
            createSchema.Execute(transaction);

            ICreateTable createTable = SQLProviderFactory.GetCreateTableQuery();
            createTable.SchemaName = "account";
            createTable.TableName = "Account";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "AccountID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "CompanyID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "CategoryID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "AccountNumber", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 16) },
                { "Balance", new FieldSpecification(FieldSpecification.FieldTypes.Decimal, 11, 2) }
            };
            createTable.Execute(transaction);

            createTable.TableName = "AccountClearance";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "AccountClearanceID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "AccountID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "UserID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) }
            };
            createTable.Execute(transaction);

            createTable.TableName = "Category";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "CategoryID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "Name", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 30) }
            };
            createTable.Execute(transaction);

            IAlterTable alterTable = SQLProviderFactory.GetAlterTableQuery();
            alterTable.Schema = "account";
            alterTable.Table = "Account";
            alterTable.AddForeignKey("FKAccount_Company_CompanyID", "CompanyID", "company", "Company", "CompanyID", transaction);
            alterTable.AddForeignKey("FKAccount_Category_CategoryID", "CategoryID", "account", "Category", "CategoryID", transaction);

            alterTable.Table = "AccountClearance";
            alterTable.AddForeignKey("FKAccountClearance_Account_AccountID", "AccountID", "account", "Account", "AccountID", transaction);
            alterTable.AddForeignKey("FKAccountClearance_User_UserID", "UserID", "security", "User", "UserID", transaction);

            alterTable.Schema = "company";
            alterTable.Table = "Employee";
            alterTable.AddColumn("ManageAccounts", new FieldSpecification(FieldSpecification.FieldTypes.Bit) { DefaultValue = false }, transaction);
        }
    }
}
