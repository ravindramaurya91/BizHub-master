
using DatabaseSchemaReader;
using DatabaseSchemaReader.DataSchema;

namespace Generator
{

    public class GeneratorContext
    {
        public GeneratorSettings Settings { get; set; }
        public DatabaseSchema Schema { get; set; }
        public string Namespace => Settings.Namespace;

        public GeneratedFile GenerateFile(string relativePath)
        {
            string fullPath = $"{Settings.Path}/{relativePath}";
            return new GeneratedFile(fullPath);
        }

    }

}