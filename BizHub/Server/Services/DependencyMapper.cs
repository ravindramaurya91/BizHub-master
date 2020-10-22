using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BizHub.Areas.Identity;
using BizHub.Server;
using Model;
using Model.Interfaces;

namespace BizHub.Services {
    public class DependencyMapper {

        public static void InitializeDependencies(ref IServiceCollection services, IConfiguration configuration, Type type) {
            InitializeDataContext(ref services, configuration);
            InitializeAutoMapper(ref services, type);
            MapRepositories(ref services);
            MapServices(ref services);
        }

        static void InitializeDataContext(ref IServiceCollection services, IConfiguration configuration) {
        }
        static void InitializeAutoMapper(ref IServiceCollection services, Type type) {
        }
        static void MapRepositories(ref IServiceCollection services) {
        }

        static void MapServices(ref IServiceCollection services) {
            //services.AddScoped<IUserSession, UserSession>();        // Scoped is a Singleton per user session
            services.AddTransient<DataService>();     // Transient = Get a new instance everytime you call for it
            services.AddScoped<BizHubUser> ();

            //services.AddScoped<SessionMgr>();
            //SessionMgr oMgr = new SessionMgr(services);


        }
    }

}
