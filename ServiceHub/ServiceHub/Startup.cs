using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Base;
using Model.Interfaces;

namespace ServiceHub {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddControllers();
            var mvc = services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            // IHttpClientFactory
            // https://www.talkingdotnet.com/3-ways-to-use-httpclientfactory-in-asp-net-core-2-1/
            services.AddHttpClient();
            // register a named client
            services.AddHttpClient("Sydney", c => {
                c.BaseAddress = new Uri("https://sydney.tworld.com/index.php/api2/");
                c.DefaultRequestHeaders.Add("Authorization", "Basic ZHZpbGxhcjpVQkV6T2J3dzhaZGJPNXM2WUtnM1JRS2JTZEc5eE1iWQ");
            });

            StartupExtensions.AddBaseFramework(services, mvc, Configuration);
            services.AddSingleton<ITwilioSMSRepository>(sp => new TwilioSMSRepository(Configuration.GetSection("twilio:accountsid").Value, Configuration.GetSection("Twilio:authtoken").Value, Configuration.GetSection("Twilio:messageserviceid").Value, Configuration.GetSection("ConnectionStrings:bizhub").Value));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseRouting();

            //app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
