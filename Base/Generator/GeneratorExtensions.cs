using System;
using DatabaseSchemaReader;
using DatabaseSchemaReader.CodeGen;
using DatabaseSchemaReader.DataSchema;

namespace Generator
{
    public static class GeneratorExtensions
    {

        public static string GetTypeDefinition(this DatabaseColumn column)
        {
            return column.DataType.NetDataTypeCSharpName + CheckNullable(column);
        }

        public static string FkColumnAlias(this DatabaseColumn column)
        {
            return StripIdentifier(column.Name);
        }

        public static string FkPropertyAlias(this DatabaseColumn column)
        {
            string fkColumnAlias = FkColumnAlias(column);
            return NameFixer.ToPascalCase(fkColumnAlias);
        }

        private static string CheckNullable(DatabaseColumn column)
        {
            string result="";
            string type = column.DataType.NetDataTypeCSharpName;
            if(column.Nullable && 
                ! type.Contains("Byte[]") && 
                ! type.Equals("byte[]") && 
                ! type.Equals("string") &&
                ! type.Equals("Microsoft.SqlServer.Types.SqlGeography") &&
                ! type.Equals("Microsoft.SqlServer.Types.SqlGeometry")
                )
                result="?";
            return result;
        }

        private static string StripIdentifier(string name)
        {
            if (name.EndsWith("_oid", true, null))
            {
                return name.Substring(0, name.Length - 4);
            }
            else if (name.EndsWith("oid", true, null))
            {
                return name.Substring(0, name.Length - 3);
            }
            else if (name.EndsWith("_id", true, null))
            {
                return name.Substring(0, name.Length - 3);
            }
            else if (name.EndsWith("id", true, null))
            {
                return name.Substring(0, name.Length - 2);
            }
            else if (name.Contains("oid_"))
            {
                return string.Join("_", name.Split("oid_"));
            }
            else if (name.Contains("Oid_"))
            {
                return string.Join("_", name.Split("Oid_"));
            }
            else
            {
                return name;
            }
        }

    }
}