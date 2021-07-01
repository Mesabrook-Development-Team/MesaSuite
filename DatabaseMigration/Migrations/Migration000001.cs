using ClussPro.Base.Data;
using ClussPro.Base.Data.Query;
using System.Collections.Generic;

namespace DatabaseMigration.Migrations
{
    public class Migration000001 : IMigration
    {
        public int MigrationNumber => 1;

        public void Execute(ITransaction transaction)
        {
            IDropTable dropTable = SQLProviderFactory.GetDropTableQuery();
            dropTable.Schema = "security";
            dropTable.Table = "UserPermission";
            dropTable.Execute(transaction);

            dropTable.Table = "Permission";
            dropTable.Execute(transaction);

            ICreateTable createProgramTable = SQLProviderFactory.GetCreateTableQuery();
            createProgramTable.SchemaName = "security";
            createProgramTable.TableName = "Program";
            createProgramTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "ProgramID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "Key", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 50) },
                { "Name", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 100) },
                { "SystemID", new FieldSpecification(FieldSpecification.FieldTypes.UniqueIdentifier) },
                { "SystemHash", new FieldSpecification(FieldSpecification.FieldTypes.Binary) }
            };
            createProgramTable.Execute(transaction);

            ICreateTable createUserProgramTable = SQLProviderFactory.GetCreateTableQuery();
            createUserProgramTable.SchemaName = "security";
            createUserProgramTable.TableName = "UserProgram";
            createUserProgramTable.Columns = new Dictionary<string, FieldSpecification>()
            {
                { "UserProgramID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true } },
                { "UserID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "ProgramID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) }
            };
            createUserProgramTable.Execute(transaction);

            IAlterTable foreignKeyCreator = SQLProviderFactory.GetAlterTableQuery();
            foreignKeyCreator.Schema = "security";
            foreignKeyCreator.Table = "UserProgram";
            foreignKeyCreator.AddForeignKey("FKUserProgram_User_UserID", "UserID", "security", "User", "UserID", transaction);
            foreignKeyCreator.AddForeignKey("FKUserProgram_Program_ProgramID", "ProgramID", "security", "Program", "ProgramID", transaction);
        }
    }
}
