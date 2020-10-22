
using Generator;
using DatabaseSchemaReader;
using DatabaseSchemaReader.DataSchema;
using System.Linq;
using System.Diagnostics;

public class GenerateServices : IGenerator
{

    public void Generate(GeneratorContext context)
    {
        var output = context.GenerateFile("../Model/Generated/GeneratedServices.cs");
        Debug.WriteLine("");
        Debug.WriteLine("GenerateServices");
        Debug.WriteLine("******************************");
        Debug.WriteLine("Path:  " + output.FullPath);
        Debug.WriteLine("******************************");
        Debug.WriteLine("");
        Debug.WriteLine("");

        output.AppendLine("// AUTO GENERATED - DO NOT MODIFY DIRECTLY");
        output.AppendLine("");
        output.AppendLine("using Base;");
        output.AppendLine($"using {context.Namespace};");
        output.AppendLine($"using Model;");
        output.AppendLine("using Microsoft.AspNetCore.Mvc;");
        output.AppendLine("using Microsoft.Extensions.DependencyInjection;");
        output.AppendLine("using SqlKata;");
        output.AppendLine("");
        output.AppendLine($"namespace {context.Namespace}.Service");
        output.AppendLine("{");

        DatabaseSchema schema = context.Schema;

        foreach (var table in schema.Tables)
        {
            output.AppendLine("");
            output.AppendLine($"    public partial class {table.Name}ServiceBase : DefaultService<{table.Name}>");
            output.AppendLine("    {");

            output.AppendLine($"        public override Query CreateResultQuery() ");
            output.AppendLine("        {");
            output.AppendLine($"            Query query = CreateDefaultQuery();");
            //foreach (var column in table.Columns)
            //{
            //    if (column.IsForeignKey)
            //    {
            //        string fkNetName = column.ForeignKeyTable.NetName;
            //        output.AppendLine($"            AddLookupToQuery<{fkNetName}>(query, Tables.{table.Name}.{column.FkPropertyAlias()}, Tables.{table.Name}.{column.Name});");
            //    }
            //}
            output.AppendLine("            return query;");
            output.AppendLine("        }");

            // default lookup implementation
            var lookupNameColumn = GetDefaultLookupNameColumn(table);
            if (lookupNameColumn != null)
            {
                output.AppendLine($"        public override Query CreateLookupQuery()");
                output.AppendLine($"        {{");
                output.AppendLine($"            return Database.CreateQuery()");
                output.AppendLine($"                .Select(Tables.{table.Name}.{table.PrimaryKeyColumn.Name}, Tables.{table.Name}.{lookupNameColumn.Name}.As(\"name\"))");
                output.AppendLine($"                .From(Tables.{table.Name});");
                output.AppendLine($"        }}");
            }

            output.AppendLine("    }");

            output.AppendLine("");
           //  output.AppendLine($"    [HttpService(nameof({table.NetName}))]");
            output.AppendLine($"    public partial class {table.Name}Service : {table.Name}ServiceBase {{}}");

        }

        output.AppendLine("");
        output.AppendLine("}");

        output.WriteToDisk();
    }

    private DatabaseColumn GetDefaultLookupNameColumn(DatabaseTable table)
    {
        string[] possibleMatches = { "name", "value", "summary", "description", "fullname", "full_name", "number" };
        return table.Columns.Where(c => possibleMatches.Contains(c.Name.ToLower())).FirstOrDefault();
    }

}
