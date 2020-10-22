
using Generator;
using DatabaseSchemaReader;
using DatabaseSchemaReader.DataSchema;
using System.Diagnostics;

public class GenerateMetadata : IGenerator
{

    public void Generate(GeneratorContext context)
    {
        var output = context.GenerateFile("../Model/Generated/GeneratedMetadata.cs");
        Debug.WriteLine("");
        Debug.WriteLine("GenerateMetadata");
        Debug.WriteLine("******************************");
        Debug.WriteLine("Path:  " + output.FullPath);
        Debug.WriteLine("******************************");
        Debug.WriteLine("");
        Debug.WriteLine("");

        output.AppendLine("// AUTO GENERATED - DO NOT MODIFY DIRECTLY");
        output.AppendLine("");
        output.AppendLine("using Base;");
        output.AppendLine("using System;");
        output.AppendLine("using SqlKata;");
        output.AppendLine("");
        output.AppendLine($"namespace Model");
        output.AppendLine("{");

        DatabaseSchema schema = context.Schema;

        foreach (var table in schema.Tables)
        {
            output.AppendLine("");
            output.AppendLine($"    public partial class {table.Name}Metadata : Metadata<{table.Name}>");
            output.AppendLine("    {");
            output.AppendLine($"        public override string DbTableName => \"{table.Name}\";");

            foreach (var column in table.Columns)
            {
                if (column.IsPrimaryKey)
                {
                    output.AppendLine($"        public override ColumnInfo {column.Name} => DefineColumn(\"{column.Name}\");");
                }
                else
                {
                    output.AppendLine($"        public ColumnInfo {column.Name} => DefineColumn(\"{column.Name}\");");
                }
            }

            //foreach (var column in table.Columns)
            //{
            //    if (column.IsForeignKey)
            //    {
            //        output.AppendLine($"        public ColumnInfo {column.FkPropertyAlias()} => DefineResultColumn(\"{column.FkColumnAlias()}\");");
            //    }
            //}

            output.AppendLine($"        public {table.Name}Metadata As(string alias) => new {table.Name}Metadata() {{ DbTableAlias = alias }};");

            output.AppendLine("    }");

        }

        output.AppendLine("");
        output.AppendLine("}");

        output.WriteToDisk();
    }

}
