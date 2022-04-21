using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClussPro.Base.Data;
using ClussPro.Base.Data.Query;

namespace WebModels.Migrations
{
    /// <summary>
    /// Create the `tow` schema
    /// Create the `tow.TowTicket` table
    /// </summary>
    public class Migration000011 : IMigration
    {
        public int MigrationNumber => 11;

        public void Execute(ITransaction transaction)
        {
            ICreateSchema createSchema = SQLProviderFactory.GetCreateSchemaQuery();
            createSchema.SchemaName = "tow";
            createSchema.Execute(transaction);

            ICreateTable createTable = SQLProviderFactory.GetCreateTableQuery();
            createTable.SchemaName = "tow";
            createTable.TableName = "TowTicket";
            createTable.Columns = new Dictionary<string, FieldSpecification>(){
                { "TowTicketID", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) { IsPrimary = true  } },
                { "UserIDIssuedTo", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "CoordX", new FieldSpecification(FieldSpecification.FieldTypes.Int) },
                { "CoordZ", new FieldSpecification(FieldSpecification.FieldTypes.Int) },
                { "Description", new FieldSpecification(FieldSpecification.FieldTypes.NVarChar, 500) },
                { "UserIDResponding", new FieldSpecification(FieldSpecification.FieldTypes.BigInt) },
                { "StatusCode", new FieldSpecification(FieldSpecification.FieldTypes.Int) }
            };
            createTable.Execute(transaction);

            IAlterTable alterTable = SQLProviderFactory.GetAlterTableQuery();
            alterTable.Schema = "tow";
            alterTable.Table = "TowTicket";
            alterTable.AddForeignKey("FKTowTicket_UserIDIssuedTo_User_UserID", "UserIDIssuedTo", "security", "User", "UserID", transaction);
            alterTable.AddForeignKey("FKTowTicket_UseriDResponding_User_UserID", "UserIDResponding", "security", "User", "UserID", transaction);
        }
    }
}
