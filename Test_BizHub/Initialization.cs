using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

using Base;
using PetaPoco;
using BizHub;
using CommonUtil;
using System.Net.Http;

namespace Test {

    public class Initialization {

        public static IServiceProvider BuildServiceProvider()
        {
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
            services.AddHttpClient();
            // register a named client
            services.AddHttpClient("Sydney", c => {
                c.BaseAddress = new Uri("https://sydney.tworld.com/index.php/api2/");
                c.DefaultRequestHeaders.Add("Authorization", "Basic ZHZpbGxhcjpVQkV6T2J3dzhaZGJPNXM2WUtnM1JRS2JTZEc5eE1iWQ");
            });
            // Register a Typed Client
            //services.AddHttpClient<Model.Interfaces.Sydney.SydneyClient>();

            // register a Named Client
            HttpClientHandler oHandler = new HttpClientHandler();
            oHandler.ServerCertificateCustomValidationCallback += (sender, certificate, chain, errors) => { return true; };
            services.AddHttpClient("ServiceHub", c => {
                c.BaseAddress = new Uri("https://35.166.20.52:44300/api/");
                c.DefaultRequestHeaders.Add("Accept", "application/json");
            }).ConfigurePrimaryHttpMessageHandler(() => oHandler);

            // build service provider
            var serviceProvider = services.BuildServiceProvider();
            Context.SetServiceProvider(serviceProvider);
            //ContainerAccess.SetServiceProvider(serviceProvider);
            return serviceProvider;
        }

    }

}