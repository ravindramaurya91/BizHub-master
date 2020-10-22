using System;
using System.Collections.Generic;
using SqlKata;

namespace Base
{

    public delegate string GetTableAlias();

    public class ColumnInfo
    {

        private readonly string name;
        private readonly string tableName;
        private readonly string tableAlias;
        private readonly bool isResultColumn;

        public ColumnInfo(string name, string tableName, string tableAlias, bool isResultColumn = false)
        {
            this.name = name;
            this.tableName = tableName;
            this.tableAlias = tableAlias;
            this.isResultColumn = isResultColumn;
        }


        public string As(string alias)
        {
            return $"{Qualified} as {alias}";
        }

        public string As(ColumnInfo alias)
        {
            return $"{Qualified} as {alias.Unqualified}";
        }

        public string Unqualified { get => name; }

        public string UnqualifiedRaw { get => $"[{name}]"; }

        public string Qualified { get => $"{tableAlias}.{name}"; }

        public string QualifiedRaw { get => $"[{tableAlias}].[{name}]"; }

        public bool IsResultColumn { get => isResultColumn; }
        
        public static implicit operator string(ColumnInfo column)
        {
            return column.Qualified;
        }

    }

}