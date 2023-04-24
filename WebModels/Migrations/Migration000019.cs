using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClussPro.Base.Data;
using ClussPro.Base.Data.Conditions;
using ClussPro.Base.Data.Operand;
using ClussPro.Base.Data.Query;

namespace WebModels.Migrations
{
    public class Migration000019 : IMigration
    {
        public int MigrationNumber => 19;

        public void Execute(ITransaction transaction)
        {
            AddAndPopulateThumbnailColumn("LocomotiveModel", transaction);
            AddAndPopulateThumbnailColumn("RailcarModel", transaction);
            AddAndPopulateThumbnailColumn("Locomotive", transaction, true);
            AddAndPopulateThumbnailColumn("Railcar", transaction, true);
        }

        private void AddAndPopulateThumbnailColumn(string table, ITransaction transaction, bool isOverride = false)
        {
            IAlterTable alterTable = SQLProviderFactory.GetAlterTableQuery();
            alterTable.Schema = "fleet";
            alterTable.Table = table;
            string originalColumn = isOverride ? "ImageOverride" : "Image";
            string newColumn = isOverride ? "ImageOverrideThumbnail" : "ImageThumbnail";
            alterTable.AddColumn(newColumn, new FieldSpecification(FieldSpecification.FieldTypes.Binary), transaction);

            ISelectQuery selectQuery = SQLProviderFactory.GetSelectQuery();
            selectQuery.SelectList = new List<Select>() 
            { 
                new Select() { SelectOperand = (Field)originalColumn },
                new Select() { SelectOperand = (Field)$"{table}ID" }
            };
            selectQuery.Table = new Table("fleet", table);
            selectQuery.WhereCondition = new ConditionGroup()
            {
                ConditionGroupType = ConditionGroup.ConditionGroupTypes.And,
                Conditions = new List<ICondition>()
                {
                    new Condition()
                    {
                        Left = (Field)originalColumn,
                        ConditionType = Condition.ConditionTypes.NotNull
                    },
                    new Condition()
                    {
                        Left = (Field)newColumn,
                        ConditionType = Condition.ConditionTypes.Null
                    }
                }
            };

            DataTable dataTable = selectQuery.Execute(transaction);
            foreach(DataRow row in dataTable.Rows)
            {
                byte[] image = row[originalColumn] as byte[];
                long? primaryKey = row[$"{table}ID"] as long?;
                if (image == null || primaryKey == null)
                {
                    continue;
                }

                using (Stream stream = new MemoryStream(image))
                using (Image pic = Image.FromStream(stream))
                {
                    int height = (int)(pic.Height * (64D / pic.Width));
                    using (Image thumbnail = pic.GetThumbnailImage(64, height, () => false, IntPtr.Zero))
                    using (MemoryStream saveStream = new MemoryStream())
                    {
                        thumbnail.Save(saveStream, ImageFormat.Png);
                        saveStream.Position = 0;

                        byte[] thumbnailBytes = new byte[saveStream.Length];
                        saveStream.Read(thumbnailBytes, 0, thumbnailBytes.Length);

                        IUpdateQuery updateRecord = SQLProviderFactory.GetUpdateQuery();
                        updateRecord.Table = new Table("fleet", table);
                        updateRecord.FieldValueList = new List<FieldValue>()
                        {
                            new FieldValue() { FieldName = newColumn, Value = thumbnailBytes, FieldType = FieldSpecification.FieldTypes.Binary }
                        };
                        updateRecord.Condition = new Condition()
                        {
                            Left = (Field)$"{table}ID",
                            ConditionType = Condition.ConditionTypes.Equal,
                            Right = new Literal(primaryKey)
                        };
                        updateRecord.Execute(transaction);
                    }
                }
            }
        }
    }
}
