using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClussPro.Base.Data;
using ClussPro.Base.Data.Operand;
using ClussPro.Base.Data.Query;

namespace WebModels.Migrations
{
    public class Migration000018 : IMigration
    {
        public int MigrationNumber => 18;

        public void Execute(ITransaction transaction)
        {
            ISelectQuery select = SQLProviderFactory.GetSelectQuery();
            select.Table = new Table("company", "Employee");
            select.SelectList = new List<Select>() { new Select() { SelectOperand = (Field)"EmployeeID" } };

            IInsertQuery insert = SQLProviderFactory.GetInsertQuery();
            insert.Table = new Table("fleet", "FleetSecurity");
            foreach (DataRow row in select.Execute(transaction).Rows)
            {
                insert.FieldValueList = new List<FieldValue>()
                {
                    new FieldValue() { FieldName = "EmployeeID", FieldType = FieldSpecification.FieldTypes.BigInt, Value = row["EmployeeID"] }
                };
                insert.Execute<long>(transaction);
            }

            select.Table = new Table("gov", "Official");
            select.SelectList = new List<Select>() { new Select() { SelectOperand = (Field)"OfficialID" } };

            foreach (DataRow row in select.Execute(transaction).Rows)
            {
                insert.FieldValueList = new List<FieldValue>()
                {
                    new FieldValue() { FieldName = "OfficialID", FieldType = FieldSpecification.FieldTypes.BigInt, Value = row["OfficialID"] }
                };
                insert.Execute<long>(transaction);
            }
        }
    }
}
