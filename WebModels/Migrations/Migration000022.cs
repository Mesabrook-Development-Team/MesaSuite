using System;
using System.Collections.Generic;
using ClussPro.Base.Data;
using ClussPro.Base.Data.Query;

namespace WebModels.Migrations
{
    public class Migration000022 : IMigration
    {
        public int MigrationNumber => 22;

        public void Execute(ITransaction transaction)
        {
            IUpdateQuery updateQuery = SQLProviderFactory.GetUpdateQuery();
            updateQuery.Table = new Table("security", "User");
            updateQuery.FieldValueList = new List<FieldValue>()
            {
                new FieldValue() { FieldName = "LastActivity", FieldType = FieldSpecification.FieldTypes.DateTime2, Value = DateTime.Now }
            };
            updateQuery.Execute(transaction);

            updateQuery.Table = new Table("auth", "Client");
            updateQuery.FieldValueList = new List<FieldValue>()
            {
                new FieldValue() { FieldName = "Type", FieldType = FieldSpecification.FieldTypes.Int, Value = 0 }
            };
            updateQuery.Execute(transaction);
        }
    }
}
