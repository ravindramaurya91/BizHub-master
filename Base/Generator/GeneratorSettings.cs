using System;
using System.Reflection;
using System.IO;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Generator
{
    public class GeneratorSettings
    {
        public string ProviderName {get;set;}
        public string ConnectionString {get;set;}
        public string SchemaName {get;set;}
        public string Namespace {get;set;}
        public string Path {get;set;}
        private List<string> excludedTables;
        private List<Tuple<string, string>> excludedColumns;

        public GeneratorSettings()
        {
            this.excludedTables = new List<string>();
            this.excludedColumns = new List<Tuple<string, string>>();
        }

        public GeneratorSettings(string path) : this()
        {
            var pathToSettings = System.IO.Path.Join(path,"../BizHub/appsettings.Development.json");  // Relative Path from the Generator project to the appsettings.Development.json file
            var appSettings = new ConfigurationBuilder().AddJsonFile(pathToSettings, optional: false).Build();
            var dataSource = appSettings.GetSection("DataSource");
            this.ProviderName = dataSource["ProviderName"];
            this.ConnectionString = dataSource["ConnectionString"];
            this.Namespace = dataSource["GeneratorNamespace"];
            this.SchemaName = dataSource["GeneratorSchema"];
            this.Path = path;
        }

        public void ExcludeTable(string tableName)
        {
            excludedTables.Add(tableName);
        }
        public void ExcludeColumn(string tsTableName, string tsColumnName) {
            excludedColumns.Add(new Tuple<string, string>(tsTableName, tsColumnName));
        }

        public List<string> GetTablesToExclude() => excludedTables;
        public List<Tuple<string,string>> GetColumnsToExclude() => excludedColumns;

    }
}