using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

using Base;
using CommonUtil;
using PetaPoco;
using BizHub;

namespace TestUtilities {
    public class Initialization {

        public static IServiceProvider BuildServiceProvider() {
            var startupType = typeof(BizHub.StartupBase);

            // load configuration
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(TestContext.CurrentContext.TestDirectory + "/../../../../BizHub")
                .AddJsonFile("appsettings.Development.json", optional: false)
                .Build();

            // configure database and base services
            var services = new ServiceCollection();
            services.AddSingleton(typeof(IConfiguration), config);
            services.AddPetaPoco(config);
            services.LoadStartupBase();
            // Add Http Client Factory
            services.AddHttpClient("Sydney", c => {
                c.DefaultRequestHeaders.Add("Authorization", "Basic ZHZpbGxhcjpVQkV6T2J3dzhaZGJPNXM2WUtnM1JRS2JTZEc5eE1iWQ");
                c.BaseAddress = new Uri("https://sydney.tworld.com/index.php/api2/");
            });

            // build service provider
            var serviceProvider = services.BuildServiceProvider();
            Context.SetServiceProvider(serviceProvider);
            ContainerAccess.SetServiceProvider(serviceProvider);

            return serviceProvider;
        }
    }
}
