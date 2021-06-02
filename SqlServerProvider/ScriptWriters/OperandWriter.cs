using ClussPro.Base.Data.Operand;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClussPro.SqlServerProvider.ScriptWriters
{
    internal static class OperandWriter
    {
        public static string WriteOperand(IOperand operand, SqlParameterCollection parameters)
        {
            if (operand is Field)
            {
                return WriteField((Field)operand);
            }

            if (operand is Literal)
            {
                return WriteLiteral((Literal)operand, parameters);
            }

            if (operand is CSV)
            {
                return WriteCSV((CSV)operand, parameters);
            }

            if (operand is Case)
            {
                return WriteCase((Case)operand, parameters);
            }

            throw new InvalidCastException("Could not determine IOperand type for writing");
        }

        private static string WriteField(Field field)
        {
            string sql = "";
            if (!string.IsNullOrEmpty(field.TableAlias))
            {
                sql += $"[{field.TableAlias}].";
            }

            sql += $"[{field.FieldName}]";

            return sql;
        }

        private static string WriteLiteral(Literal literal, SqlParameterCollection parameters)
        {
            int paramCount = parameters.Count;
            parameters.AddWithValue(paramCount.ToString(), literal.Value);
            return $"@{paramCount}";
        }

        public static string WriteCSV(CSV csv, SqlParameterCollection parameters)
        {
            StringBuilder builder = new StringBuilder("(");
            bool first = true;
            foreach(object value in csv.Values)
            {
                if (!first)
                {
                    builder.Append(",");
                }
                first = false;

                int paramCount = parameters.Count;
                parameters.AddWithValue(paramCount.ToString(), value);
                builder.Append($"@{paramCount}");
            }

            builder.Append(")");

            return builder.ToString();
        }

        private static string WriteCase(Case caseStatement, SqlParameterCollection parameters)
        {
            StringBuilder builder = new StringBuilder("CASE ");

            foreach(Case.When when in caseStatement.Whens)
            {
                builder.Append("WHEN (");
                builder.Append(ConditionWriter.WriteCondition(when.Condition, parameters));
                builder.Append(") THEN (");
                builder.Append(OperandWriter.WriteOperand(when.Result, parameters));
                builder.Append(") ");
            }

            if (caseStatement.Else != null)
            {
                builder.Append("ELSE (");
                builder.Append(OperandWriter.WriteOperand(caseStatement.Else, parameters));
                builder.Append(") ");
            }

            builder.Append("END");

            return builder.ToString();
        }
    }
}
