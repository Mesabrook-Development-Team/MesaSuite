using System;
using System.Data.SqlClient;
using ClussPro.Base.Data;
using ClussPro.Base.Data.Operand;

namespace ClussPro.SqlServerProvider.ScriptWriters
{
    internal static class SelectableWriter
    {
        public static string WriteSelectable(ISelectable selectable, SqlParameterCollection parameters)
        {
            if (selectable is Table table)
            {
                return WriteTable(table);
            }

            if (selectable is TableAlias tableAlias)
            {
                return WriteTableAlias(tableAlias);
            }

            if (selectable is SubQuery subQuery)
            {
                return WriteSubQuery(subQuery, parameters);
            }

            throw new InvalidCastException("Could not determine ISelectable type for writing");
        }

        private static string WriteTable(Table table)
        {
            string sql = $"[{table.Schema}].[{table.Name}]";

            if (!string.IsNullOrEmpty(table.Alias))
            {
                sql += $" AS {table.Alias}";
            }

            return sql;
        }

        private static string WriteTableAlias(TableAlias tableAlias)
        {
            return $"[{tableAlias.AliasName}]";
        }

        private static string WriteSubQuery(SubQuery subQuery, SqlParameterCollection parameters)
        {
            if (!(subQuery.SelectSubQuery is SelectQuery selectQuery))
            {
                throw new InvalidCastException("Cannot write SQL for ISelectQuery that is not part of the SqlServerProvider");
            }

            string sql = $"({selectQuery.GetSQL(parameters)})";
            if (!string.IsNullOrEmpty(subQuery.Alias))
            {
                sql += $" AS [{subQuery.Alias}]";
            }

            return sql;
        }
    }
}
