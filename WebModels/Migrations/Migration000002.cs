using ClussPro.Base.Data;
using ClussPro.Base.Data.Query;
using System.Collections.Generic;

namespace WebModels.Migrations
{
    /// <summary>
    /// Create company and gov schemas.
    /// Create gov.Government and gov.Official tables.
    /// Create company.Company and company.Employee tables.
    /// </summary>
    public class Migration000002 : IMigration
    {
        public int MigrationNumber => 2;

        public void Execute(ITransaction transaction)
        {
            // Create Schemas
            ICreateSchema createSchema = SQLProviderFactory.GetCreateSchemaQuery();
            createSchema.SchemaName = "company";
            createSchema.Execute(transaction);

            createSchema.SchemaName = "gov";
            createSchema.Execute(transaction);

            // Create Tables
            ICreateTable createTable = SQLProviderFactory.GetCreateTableQuery();
            createTable.SchemaName = "gov";
            createTable.TableName = "Government";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "GovernmentID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "Name", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 50) }
            };
            createTable.Execute(transaction);

            createTable.TableName = "Official";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "OfficialID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "GovernmentID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "UserID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "ManageEmails", new FieldSpecification(FieldSpecification.FieldTypes.Bit) { DefaultValue = false } },
                { "ManageOfficials", new FieldSpecification(FieldSpecification.FieldTypes.Bit) { DefaultValue = false } }
            };
            createTable.Execute(transaction);

            createTable.SchemaName = "company";
            createTable.TableName = "Company";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "CompanyID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "Name", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 50) }
            };
            createTable.Execute(transaction);

            createTable.TableName = "Employee";
            createTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "EmployeeID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "CompanyID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "UserID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "ManageEmails", new FieldSpecification(FieldSpecification.FieldTypes.Bit) { DefaultValue = false } },
                { "ManageEmployees", new FieldSpecification(FieldSpecification.FieldTypes.Bit) { DefaultValue = false } }
            };
            createTable.Execute(transaction);

            // Foreign Keys
            IAlterTable alterTable = SQLProviderFactory.GetAlterTableQuery();
            alterTable.Schema = "gov";
            alterTable.Table = "Official";
            alterTable.AddForeignKey("FKOfficial_Government_GovernmentID", "GovernmentID", "gov", "Government", "GovernmentID", transaction);
            alterTable.AddForeignKey("FKOfficial_User_UserID", "UserID", "security", "User", "UserID", transaction);

            alterTable.Schema = "company";
            alterTable.Table = "Employee";
            alterTable.AddForeignKey("FKEmployee_Company_CompanyID", "CompanyID", "company", "Company", "CompanyID", transaction);
            alterTable.AddForeignKey("FKEmployee_User_UserID", "UserID", "security", "User", "UserID", transaction);
        }
    }
}
