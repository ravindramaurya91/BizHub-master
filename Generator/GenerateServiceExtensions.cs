
using Generator;
using DatabaseSchemaReader;
using DatabaseSchemaReader.DataSchema;
using System.Diagnostics;
using System;

public class GenerateServiceExtensions : IGenerator
{

    public void Generate(GeneratorContext context)
    {
        var output = context.GenerateFile("../Model/Generated/GeneratedServiceExtensions.cs");
        Debug.WriteLine("");
        Debug.WriteLine("GenerateServiceExtensions");
        Debug.WriteLine("******************************");
        Debug.WriteLine("Path:  " + output.FullPath);
        Debug.WriteLine("******************************");
        Debug.WriteLine("");
        Debug.WriteLine("");

        output.AppendLine("// AUTO GENERATED - DO NOT MODIFY DIRECTLY");
        output.AppendLine("");
        output.AppendLine($"using Base;");
        output.AppendLine($"using Model;");
        output.AppendLine($"using {context.Namespace}.Service;");
        output.AppendLine("using Microsoft.AspNetCore.Mvc;");
        output.AppendLine("using Microsoft.Extensions.DependencyInjection;");
        output.AppendLine("");
        output.AppendLine($"namespace {context.Namespace}");
        output.AppendLine("{");
        output.AppendLine("");
        output.AppendLine("    public class StartupBase : IStartupBase");
        output.AppendLine("    {");
        output.AppendLine("        public void AddLookupProviders(IServiceCollection services)");
        output.AppendLine("        {");

        DatabaseSchema schema = context.Schema;

        foreach (var table in schema.Tables)
        {
            output.AppendLine($"            services.AddTransient<ILookupProvider<{table.Name}>, {table.Name}Service>();");
        }

        output.AppendLine("        }");

        output.AppendLine("        public void AddMetadataTables(IServiceCollection services)");
        output.AppendLine("        {");

        foreach (var table in schema.Tables)
        {
            output.AppendLine($"            services.AddTransient<IMetadata<{table.Name}>, {table.Name}Metadata>();");
        }

        output.AppendLine("        }");

        output.AppendLine("    }");
        output.AppendLine("");
        output.AppendLine("}");

        try {
            output.WriteToDisk();
        } catch(Exception ex) {
            throw new System.Exception("An Error has occurred attempting to write the GeneratedServiceExtensions to disk:    " + ex.Message);
        }
    }

}
