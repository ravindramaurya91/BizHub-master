using System;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Base
{


    public static class StartupBaseUtil
    {

        public static void LoadStartupBase(this IServiceCollection services)
        {

            var type = typeof(IStartupBase);

            var types =
                from a in AppDomain.CurrentDomain.GetAssemblies()
                where !a.FullName.StartsWith("Microsoft.") && !a.FullName.StartsWith("System.")
                from t in a.GetTypes()
                where type.IsAssignableFrom(t) && !t.Equals(type)
                select t;
                
            var implementationType = types.First();
            
            IStartupBase startupBase = (IStartupBase)Activator.CreateInstance(implementationType);
            startupBase.AddLookupProviders(services);
            startupBase.AddMetadataTables(services);

        }

    }

    public interface IStartupBase
    {
        void AddLookupProviders(IServiceCollection services);
        void AddMetadataTables(IServiceCollection services);
    }

}