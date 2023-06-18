using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClussPro.Base.Data;

namespace ClussPro.SqlServerProvider.Extensions
{
    public static class FieldSpecificationExtensions
    {
        public static string ToSqlDataType(this FieldSpecification col)
        {
            StringBuilder builder = new StringBuilder();
            switch (col.FieldType)
            {
                case FieldSpecification.FieldTypes.BigInt:
                    builder.Append("BIGINT ");
                    break;
                case FieldSpecification.FieldTypes.NVarChar:
                    builder.Append("NVARCHAR(");

                    if (col.DataSize == -1)
                    {
                        builder.Append("MAX) ");
                    }
                    else
                    {
                        builder.Append($"{col.DataSize}) ");
                    }
                    break;
                case FieldSpecification.FieldTypes.Binary:
                    builder.Append("VARBINARY(");
                    if (col.DataSize == -1)
                    {
                        builder.Append("MAX) ");
                    }
                    else
                    {
                        builder.Append($"{col.DataSize}) ");
                    }
                    break;
                case FieldSpecification.FieldTypes.TinyInt:
                    builder.Append("TINYINT ");
                    break;
                case FieldSpecification.FieldTypes.DateTime2:
                    builder.Append($"DATETIME2({col.DataSize}) ");
                    break;
                case FieldSpecification.FieldTypes.UniqueIdentifier:
                    builder.Append("UNIQUEIDENTIFIER ");
                    break;
                case FieldSpecification.FieldTypes.Bit:
                    builder.Append("BIT ");
                    break;
                case FieldSpecification.FieldTypes.Int:
                    builder.Append("INT ");
                    break;
                case FieldSpecification.FieldTypes.Decimal:
                    builder.Append(string.Format("DECIMAL ({0}, {1}) ", col.DataSize, col.DataScale));
                    break;
                case FieldSpecification.FieldTypes.SmallInt:
                    builder.Append("SMALLINT ");
                    break;
            }

            return builder.ToString();
        }
    }
}
