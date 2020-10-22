using System;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using Npgsql;
using DatabaseSchemaReader;
using DatabaseSchemaReader.DataSchema;
using DatabaseSchemaReader.CodeGen;
using System.Collections.Generic;

namespace Generator
{

    public class GeneratorUtility
    {

        public static void Run(GeneratorSettings settings)
        {
            try {
                RegisterDatabaseFactories();

                Console.WriteLine("INFO: Running generator.");
                Console.WriteLine($"DEBUG: Database provider name: '{settings.ProviderName}'");
                Console.WriteLine($"DEBUG: Database connection string: '{settings.ConnectionString}'");

                Console.WriteLine("DEBUG: Attempting to connect to database.");
                var factory = DbProviderFactories.GetFactory(settings.ProviderName);
                using(var connection = factory.CreateConnection()) {
                    connection.ConnectionString = settings.ConnectionString;
                    connection.Open();

                    Console.WriteLine("DEBUG: Connection successful.");


                    Console.WriteLine("DEBUG: Attempting to read database schema.");
                    var reader = new DatabaseReader(connection);

                    foreach(string exclude in settings.GetTablesToExclude()) {
                        reader.Exclusions.TableFilter.FilterExclusions.Add(exclude);
                    }

                    if(settings.SchemaName != null && settings.SchemaName.Length > 0) {
                        reader.Owner = settings.SchemaName;
                    }

                    var schema = reader.ReadAll();

                    Console.WriteLine("DEBUG: Database schema read complete.");

                    PrepareSchemaUtility.Prepare(schema,new GeneratorNamer());

                    var context = new GeneratorContext();
                    context.Settings = settings;
                    context.Schema = schema;

                    var templateInterface = typeof(IGenerator);

                    var types = AppDomain.CurrentDomain.GetAssemblies()
                        .SelectMany(s => s.GetTypes())
                        .Where(type => templateInterface.IsAssignableFrom(type) && !templateInterface.Equals(type));

                    DropExcludedColumns(settings, context);

                    foreach (var type in types) {

                        Console.WriteLine($"DEBUG: Running generator {type.Name}.");

                        var template = (IGenerator)Activator.CreateInstance(type);
                        template.Generate(context);
                    }

                }

                Console.WriteLine("INFO: Generator run complete.");
            } catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        private static void DropExcludedColumns(GeneratorSettings toSettings, GeneratorContext toContext) {
            DatabaseTable oTable;
            DatabaseColumn oColumn;
            List<Tuple<string, string>> oExcludedColumns = toSettings.GetColumnsToExclude();
            if (oExcludedColumns.Count > 0) {
                DatabaseSchema schema = toContext.Schema;

                foreach (Tuple<string, string> oRecord in oExcludedColumns) {
                    oTable = GetTableByName(oRecord.Item1, schema.Tables);
                    if (oTable != null) {
                        oColumn = GetColumnByName(oRecord.Item2, oTable.Columns);
                        if (oColumn != null) {
                            oTable.Columns.Remove(oColumn);
                        }
                    }
                }
            }
        }

        private static DatabaseTable GetTableByName(string tsTableName, List<DatabaseTable> toTables) {
            DatabaseTable oReturn = null;
            foreach(DatabaseTable oTable in toTables) {
                if (oTable.Name.Equals(tsTableName)) {
                    oReturn = oTable;
                    break;
                }
            }
            return oReturn;
        }
        private static DatabaseColumn GetColumnByName(string tsColumnName, List<DatabaseColumn> toColumns) {
            DatabaseColumn oReturn = null;
            foreach (DatabaseColumn oColumn in toColumns) {
                if (oColumn.Name.Equals(tsColumnName)) {
                    oReturn = oColumn;
                    break;
                }
            }
            return oReturn;
        }
        private static void RegisterDatabaseFactories()
        {
            DbProviderFactories.RegisterFactory("Npgsql", NpgsqlFactory.Instance);
            DbProviderFactories.RegisterFactory("Microsoft.Data.SqlClient", Microsoft.Data.SqlClient.SqlClientFactory.Instance);
        }

    }

}