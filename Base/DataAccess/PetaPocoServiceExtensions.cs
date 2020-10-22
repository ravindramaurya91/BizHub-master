using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using PetaPoco;
using PetaPoco.SqlKata;
using SqlKata;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Text;
using PetaPoco.Providers;
using System.Data.Common;

namespace Base
{

    public static class PetaPocoServiceExtensions
    {

        /// <summary>
        /// Makes a scoped (per request) IDatabase instance available for dependency injection.
        /// </summary>
        public static void AddPetaPoco(this IServiceCollection services, IConfiguration config)
        {

            services.AddSingleton<IDatabaseBuildConfiguration>((IServiceProvider prov) => {
                var config = prov.GetService<IConfiguration>();
                var section = config.GetSection("DataSource");
                var connectionString = section.GetValue<string>("ConnectionString");
                return DatabaseConfiguration.Build()
                    .UsingConnectionString(connectionString)
                    .UsingDefaultMapper<ConventionMapper>(m => {
                        m.InflectTableName = (inflector, tn) => inflector.Underscore(tn);
                        m.InflectColumnName = (inflector, cn) => inflector.Underscore(cn);
                    })
                    .UsingProvider<CustomSqlServerDatabaseProvider>();
            });

            services.AddTransient<IDatabase>((IServiceProvider prov) => {
                return prov.GetService<IDatabaseBuildConfiguration>().Create();
            });

            var ds = config.GetSection("DataSource");
            var providerName = ds["ProviderName"];
            if (providerName.Equals("Npgsql"))
            {
                SqlKataExtensions.DefaultCompiler = CompilerType.Postgres;
            }
            else
            {
                SqlKataExtensions.DefaultCompiler = CompilerType.SqlServer;
            }
            
        }

        public class CustomSqlServerDatabaseProvider : SqlServerDatabaseProvider {
            public override DbProviderFactory GetFactory()
            {
                // Need to specify class and assembly of the DbProviderFactory 
                return GetFactory("Microsoft.Data.SqlClient.SqlClientFactory, Microsoft.Data.SqlClient");
            }
        }

        public static List<T> Fetch<T>(this Query query)
        {
            var db = Context.Get<IDatabase>();
            var sql = query.ToSql();
            return db.Fetch<T>(sql);
        }

        public static T FirstOrDefault<T>(this Query query)
        {
            var db = Context.Get<IDatabase>();
            var sql = query.ToSql();
            return db.FirstOrDefault<T>(sql);
        }

        public static Page<T> Page<T>(this Query query, int page, int itemsToPage)
        {
            var db = Context.Get<IDatabase>();
            var sql = query.ToSql();
            return db.Page<T>(page, itemsToPage, sql);
        }

        public static Query LogSql(this Query query, string label = null)
        {
            var log = new StringBuilder();
            var sql = query.ToSql();

            if (label == null)
            {
                log.AppendLine("SQL:");
            }
            else
            {
                log.AppendLine($"SQL ({label}):");
            }

            log.Append("  ");
            log.Append(sql.SQL);
            
            var arguments = sql.Arguments;

            if (arguments.Length > 0)
            {
                log.AppendLine();
                log.Append("Arguments:");
            }

            for (int i = 0; i < arguments.Length; i++)
            {
                log.AppendLine();
                log.Append($"  @{i}: {arguments[0]}");
            }

            var logger = Context.Get<ILogger<Database>>();
            logger.LogDebug(log.ToString());
            return query;
        }

    }

}