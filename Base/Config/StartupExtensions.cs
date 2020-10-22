using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Base
{

    public static class StartupExtensions
    {

        private static string apiName;
        private static string apiVersion;

        public static void AddBaseFramework(this IServiceCollection services, IMvcBuilder mvc, IConfiguration config)
        {
            var apiConfig = config.GetSection("Api");
            apiName = apiConfig["Name"];
            apiVersion = apiConfig["Version"];

            services.AddPetaPoco(config);

            services.LoadStartupBase();
            
            mvc.AddMvcOptions(options => {

                options.Conventions.Add(new HttpServiceRouteConvention());

                // NOTE: disabling 2.2 routing because it does not use the custom IActionSelector registered below to resolve ambiguous actions
                // TODO: determine how to do the same thing as the custom IActionSelector in 2.2 and then reenable this option
                options.EnableEndpointRouting = false; 

            });

            mvc.ConfigureApplicationPartManager(manager => {

                manager.FeatureProviders.Add(new HttpServiceFeatureProvider());

            });

            var oServiceProvider = services.BuildServiceProvider();
            Context.SetServiceProvider(oServiceProvider);
        }

        public static void UseBaseFramework(this IApplicationBuilder app)
        {
        }

    }

}