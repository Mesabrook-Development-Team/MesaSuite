using System;
using ClussPro.Base.Data;

namespace ClussPro.SqlServerProvider.ScriptWriters
{
    internal static class SelectableWriter
    {
        public static string WriteSelectable(ISelectable selectable)
        {
            if (selectable is Table table)
            {
                return WriteTable(table);
            }

            if (selectable is TableAlias tableAlias)
            {
                return WriteTableAlias(tableAlias);
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
    }
}
