using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Blazor.BizHub.WasmVideo.SignalRServer.Server.Options;
using Blazor.BizHub.WasmVideo.SignalRServer.Server.Services;

namespace Blazor.BizHub.WasmVideo.SignalRServer.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR(options => options.EnableDetailedErrors = true);
            services.Configure<TwilioSettings>(settings =>
            {
                settings.AccountSid = "AC98412f8c26b4111d7ef5285223996d89"; //TWILIO_ACCOUNT_SID
                settings.ApiSecret = "bdd4ef7699fc6d853b319439d8ef3a26"; //TWILIO_API_SECRET
                settings.ApiKey = "SK2f6290d77dfc0ac0c305e2fb48daed94"; //TWILIO_API_KEY
            });
            services.AddSingleton<TwilioService>();
            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
