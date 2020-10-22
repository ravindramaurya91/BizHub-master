
using Generator;
using DatabaseSchemaReader;
using DatabaseSchemaReader.DataSchema;
using System.Diagnostics;
using BlazorInputFile;

public class GenerateModels : IGenerator
{

    public void Generate(GeneratorContext context)
    {
        var output = context.GenerateFile("../Model/Generated/GeneratedModels.cs");
        Debug.WriteLine("");
        Debug.WriteLine("GenerateModels");
        Debug.WriteLine("******************************");
        Debug.WriteLine("Path:  " + output.FullPath);
        Debug.WriteLine("******************************");
        Debug.WriteLine("");
        Debug.WriteLine("");

        GenerateFileHeader(output, "Model");
        DatabaseSchema schema = context.Schema;

        foreach (var table in schema.Tables)
        {

            output.AppendLine("");
            output.AppendLine($"    [Serializable]");
            output.AppendLine($"    [TableName(\"{table.Name}\")]");
            output.AppendLine($"    [PrimaryKey(\"{table.PrimaryKeyColumn.Name}\")]");
            //output.AppendLine($"    [ExplicitColumns]");
            
            output.AppendLine($"    public partial class {table.Name} : Record<{table.Name}>, IModel, IIndexer");
            output.AppendLine("    {");

            foreach (var column in table.Columns)
            {
                output.AppendLine($"        [Column(\"{column.Name}\")]");
                //output.AppendLine($"        public {column.GetTypeDefinition()} {column.NetName} {{ get; set; }}");
                output.AppendLine($"        public {column.GetTypeDefinition()} {column.Name} {{ get; set; }}");
            }
            output.AppendLine(" ");
            output.AppendLine("        //*******   Extension Events and Properties    *****");
            output.AppendLine("        public event EventHandler OnIsExpandedChanged;");
            output.AppendLine("        public event EventHandler OnIsHiddenChanged;");
            output.AppendLine("        private bool _isExpanded = false;");
            output.AppendLine("        private bool _isHidden = false;");
            output.AppendLine("        [Ignore]");
            output.AppendLine("        public bool IsExpanded { get {return _isExpanded;} set {if(_isExpanded != value) {_isExpanded = value;OnIsExpandedChanged?.Invoke(this, null);}}}");
            output.AppendLine("        [Ignore]");
            output.AppendLine("        public bool IsHidden { get {return _isHidden;} set {if(_isHidden != value) {_isHidden = value;OnIsHiddenChanged?.Invoke(this, null);}}}");
            output.AppendLine("        public " + table.Name + " ShallowClone(){ return (" + table.Name+")this.MemberwiseClone();}");
            output.AppendLine("");
            output.AppendLine("        public object Get(string tsPropertyName) {");
            output.AppendLine("            return this[tsPropertyName];");
            output.AppendLine("        }");
            output.AppendLine("");
            output.AppendLine("        public void Set(string tsPropertyName, object value) {");
            output.AppendLine("            this[tsPropertyName] = value;");
            output.AppendLine("        }");
            output.AppendLine("");
            
            CreateIndexers(table, output);
            //CreateAlternativeIndexers(table, output);
            output.AppendLine("    }");
        }
        output.AppendLine("");
        output.AppendLine("}");
        output.WriteToDisk();

    }

    private static string GetFieldName(string tsFieldName) {
        return "_" + tsFieldName.Substring(0, 1).ToLower() + tsFieldName.Substring(1);
    }
    private static void GenerateInterfaceModelQueries(GeneratorContext context) {
        
        var accessFile = context.GenerateFile("../MercadoAPI/Queries/MIRecordMap.cs");
        GenerateFileHeader(accessFile, "MercadoAPI");

        DatabaseSchema schema = context.Schema;

        accessFile.AppendLine("    public partial class MIRecordMap {");

        foreach (var table in schema.Tables) {
            accessFile.AppendLine("        // " + table.Name);
            accessFile.AppendLine("        public const string GET_" + table.Name.ToUpper() + " = @\"SELECT target.* ");
            accessFile.AppendLine("            FROM Product target");
            accessFile.AppendLine("            INNER JOIN InterfaceRecordKeyMap map On map.TargetOid = target.Oid AND map.TargetTableName = '" + table.Name + "' \";");
            accessFile.AppendLine("");
        }

        accessFile.AppendLine("    }");
        accessFile.AppendLine("");
        accessFile.AppendLine("}");
        accessFile.WriteToDisk();
        
    }

    private static void CreateIndexers(DatabaseTable table, GeneratedFile output) {
        #region Create Indexers
        // Create Property Indexers
        output.AppendLine(@"        #region Indexer");
        output.AppendLine("        [Ignore]");
        output.AppendLine(@"        public virtual object this[string tsPropertyName] {");
        output.AppendLine(@"            get {");
        output.AppendLine(@"                object oReturn = null;");
        output.AppendLine(@"                switch(tsPropertyName.ToUpper()){");

        foreach (var column in table.Columns) {
            output.AppendLine($"                    case \"{column.Name.ToUpper()}\":  oReturn = this.{column.Name}; break;");
        }
        output.AppendLine(@"                }");
        output.AppendLine(@"                return oReturn;");
        output.AppendLine(@"            }");
        output.AppendLine(@"");
        output.AppendLine(@"            set {");
        output.AppendLine($"                tsPropertyName = tsPropertyName.ToUpper();");
        output.AppendLine(@"                switch(tsPropertyName){");
        foreach (var column in table.Columns) {
            output.AppendLine($"                case \"{column.Name.ToUpper()}\":  this.{column.Name} = ({column.GetTypeDefinition()})value;  break;");
        }
        output.AppendLine(@"                }");
        output.AppendLine(@"            }");
        output.AppendLine(@"        }");
        output.AppendLine(@"");
        output.AppendLine($"        #endregion (Indexer)");
        #endregion (Create Indexers)
    }

    private static void CreateAlternativeIndexers(DatabaseTable table, GeneratedFile output) {
        output.AppendLine(" ");
        output.AppendLine("        #region Indexer");
        output.AppendLine("        [Ignore]");
        output.AppendLine("        public object this[string tsPropertyName] {");
        output.AppendLine("            get {");
        output.AppendLine("                object oReturn = null;");
        output.AppendLine("                switch (tsPropertyName) {");
        string sDataType;
        foreach (var column in table.Columns) {
            sDataType = column.GetTypeDefinition();
            if (sDataType.Equals("string")) {
                output.AppendLine($"                    case \"{column.Name}\": oReturn = (!String.IsNullOrEmpty({column.Name})) ? ({column.GetTypeDefinition()}){column.Name} : default({column.GetTypeDefinition()}); break;");
            } else {
                if (sDataType.Contains("?")) {
                    output.AppendLine($"                    case \"{column.Name}\": oReturn = (!String.IsNullOrEmpty({column.Name})) ? ({column.GetTypeDefinition()}){column.Name} : default({column.GetTypeDefinition()}); break;");
                } else {
                    output.AppendLine($"                    case \"{column.Name}\": oReturn = ({column.GetTypeDefinition()}){column.Name}; break;");
                }
            }
        }
        output.AppendLine("                }");
        output.AppendLine("                return oReturn;");
        output.AppendLine("            }");
        output.AppendLine("            set {");
        output.AppendLine("                switch (tsPropertyName) {");
        foreach (var column in table.Columns) {
            output.AppendLine($"                case \"{column.Name}\": {column.Name} = ({column.GetTypeDefinition()})value; break;");
        }
        output.AppendLine("                }");
        output.AppendLine("            }");
        output.AppendLine("        }");
        output.AppendLine("        #endregion (Indexer)");
    }

    private static void GenerateFileHeader(GeneratedFile toOutputFile, string tsNamespace) {

        toOutputFile.AppendLine("// AUTO GENERATED - DO NOT MODIFY DIRECTLY");
        toOutputFile.AppendLine("");
        toOutputFile.AppendLine("using Base;");
        toOutputFile.AppendLine("using System;");
        toOutputFile.AppendLine("using System.Collections.Generic;");
        toOutputFile.AppendLine("using PetaPoco;");
        if (!tsNamespace.Equals("Model")) {
            toOutputFile.AppendLine("using Model;");
        }
        toOutputFile.AppendLine("");
        toOutputFile.AppendLine("namespace "+ tsNamespace + " {");
        toOutputFile.AppendLine("");
    }

    private static void CreateInterfaceFile(DatabaseTable table, GeneratedFile output) {
        #region Create Indexers
        // Create Property Indexers
        output.AppendLine(@"        #region Indexer");
        output.AppendLine(@"        public override object this[string tsPropertyName] {");
        output.AppendLine(@"            get {");
        output.AppendLine(@"                object oReturn = null;");
        output.AppendLine(@"                switch(tsPropertyName.ToUpper()){");

        foreach (var column in table.Columns) {
            output.AppendLine($"                    case \"{column.Name.ToUpper()}\":");
            output.AppendLine($"                        oReturn = this.{column.Name};");
            output.AppendLine($"                        break;");
        }
        output.AppendLine(@"                }");
        output.AppendLine(@"                return oReturn;");
        output.AppendLine(@"            }");
        output.AppendLine(@"");
        output.AppendLine(@"            set {");
        output.AppendLine($"                tsPropertyName = tsPropertyName.ToUpper();");
        output.AppendLine(@"                switch(tsPropertyName){");
        foreach (var column in table.Columns) {
            output.AppendLine($"                case \"{column.Name.ToUpper()}\":");
            output.AppendLine($"                    this.{column.Name} = ({column.GetTypeDefinition()})value;");
            output.AppendLine($"                        break;");
        }
        output.AppendLine(@"                }");
        output.AppendLine(@"            }");
        output.AppendLine(@"        }");
        output.AppendLine(@"");
        output.AppendLine($"        #endregion (Indexer)");
        #endregion (Create Indexers)
    }
}
