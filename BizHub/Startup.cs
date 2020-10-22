using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

using Base;
using Base.Security;
using BizHub.Services;
using Blazored.Modal;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using BizHub.Areas.Identity;
using Microsoft.Extensions.Options;

using Syncfusion.Blazor;
using BizHub.FSLibrary.Messaging;
using System.Net.Http;
using System.Net;
using Model;
using Model.Interfaces;
using BizHub.Shared;
using Microsoft.Extensions.FileProviders;

namespace BizHub {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) {

            services.AddDefaultIdentity<BizHubUser>(options => {
                options.SignIn.RequireConfirmedAccount = true;
                options.User.RequireUniqueEmail = true;
            }).AddRoles<BizHubRole>()
              .AddEntityFrameworkStores<BizHubIdentityDbContext>()
              .AddClaimsPrincipalFactory<BizHubUserClaimsPrincipalFactory>()
              .AddUserManager<BizHubUserManager>(); 


            services.AddDbContext<BizHubIdentityDbContext>(cfg => {
                cfg.UseSqlServer(Configuration.GetConnectionString("AuthenticationDB"));
            }) ;

            services.AddHttpContextAccessor();
            services.AddRazorPages();
            services.AddServerSideBlazor(o => o.DetailedErrors = true);
            services.AddBlazoredModal();

            // Syncfusion support 
            services.AddSyncfusionBlazor();

            //var mvc = services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            var mvc = services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
                //mvc.AddNewtonsoftJson();
            

            // Load app specific dependencies
            DependencyMapper.InitializeDependencies(ref services, Configuration, typeof(Startup));


            //services.AddSingleton<IDummyData, DummyData>();        // Singleton = a single instance shared by all users and sessions
            //services.AddScoped<IDummyData, DummyData>();           // Scoped is a Singleton per user session
            //services.AddTransient<IDummyData, DummyData>();          // Transient = Get a new instance everytime you call for it
            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<BizHubUser>>();
            services.AddScoped<SessionMgr>();
            services.AddScoped<FSPageTools>();
            //services.AddSingleton<Microsoft.Extensions.Logging.ILogger, Logger>();

            #region HTTP Clients
            // IHttpClientFactory
            //https://www.talkingdotnet.com/3-ways-to-use-httpclientfactory-in-asp-net-core-2-1/
            services.AddHttpClient();

            #region Sydney
            // register a Sydney named client
            services.AddHttpClient("Sydney", c => {
                c.BaseAddress = new Uri("https://sydney.tworld.com/index.php/api2/");
                c.DefaultRequestHeaders.Add("Authorization", "Basic ZHZpbGxhcjpVQkV6T2J3dzhaZGJPNXM2WUtnM1JRS2JTZEc5eE1iWQ");
            });
            #endregion (Sydney)

            #region Service Hub
            // register a Typed Client
            HttpClientHandler oHandler = new HttpClientHandler();
            string sIpAddress = "http://localhost";

            var section = Configuration.GetSection("RunTimeParameters");
            if (!section.GetValue<string>("RunLocal").Equals("YES")) {
                sIpAddress = section.GetValue<string>("ServiceHubBaseIP");
            }

            string sPortNumber = section.GetValue<string>("ServiceHubPort");
            string sUriString = sIpAddress + ":" + sPortNumber + "/api/";
           
            oHandler.ServerCertificateCustomValidationCallback += (sender, certificate, chain, errors) => { return true; };
            services.AddHttpClient("ServiceHub", c => {
                c.BaseAddress = new Uri(sUriString);
                c.DefaultRequestHeaders.Add("Accept", "application/json");
            }).ConfigurePrimaryHttpMessageHandler(() => oHandler);
            #endregion (Service Hub)

            #endregion (HTTP Clients)

            StartupExtensions.AddBaseFramework(services, mvc, Configuration);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {

            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();


            app.UseEndpoints(endpoints => {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapHub<Server.Messaging.Hubs.ChatHub>(ChatClient.HUBURL);
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });

            ContentRootPath = env.ContentRootPath;
            WebRootPath = env.WebRootPath;
            WebRootFileProvider = env.WebRootFileProvider;
        }


        #region Properties
        public static string ContentRootPath { get; set; } = string.Empty;
        public static string WebRootPath { get; set; } = string.Empty;
        public static IFileProvider WebRootFileProvider { get; set; }

        #endregion (Properties)

    }
}
