using System;
using CommonUtil;

namespace Base
{
    public class Context
    {

        private static IServiceProvider provider;

        public static void SetServiceProvider(IServiceProvider provider)
        {
            Context.provider = provider;
            CommonUtil.ContainerAccess.SetServiceProvider(provider);
        }
        
        public static T Get<T>()
        {
            return (T) provider.GetService(typeof(T));
        }

    }
}