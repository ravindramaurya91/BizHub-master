
using Generator;
using DatabaseSchemaReader;
using DatabaseSchemaReader.DataSchema;
using System.IO;
using System.Diagnostics;

public class GenerateTables : IGenerator
{

    public void Generate(GeneratorContext context)
    {

        var output = context.GenerateFile("../Model/Generated/GeneratedTables.cs");
        Debug.WriteLine("");
        Debug.WriteLine("GenerateTables");
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
        output.AppendLine("    public static class Tables");
        output.AppendLine("    {");

        DatabaseSchema schema = context.Schema;

        foreach (var table in schema.Tables)
        {
            output.AppendLine($"        public static readonly {table.Name}Metadata {table.Name};");
        }

        output.AppendLine("");
        output.AppendLine("        static Tables()");
        output.AppendLine("        {");

        foreach (var table in schema.Tables)
        {
            output.AppendLine($"            Tables.{table.Name} = new {table.Name}Metadata();");
        }

        output.AppendLine("        }");
        output.AppendLine("");
        output.AppendLine("    }");
        output.AppendLine("");
        output.AppendLine("}");

        output.WriteToDisk();
    }

}
