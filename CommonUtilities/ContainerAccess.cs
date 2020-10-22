using System;
using System.Collections.Generic;
using System.Text;

namespace CommonUtil {
    public class ContainerAccess {

        #region Private
        private static IServiceProvider _provider;
        #endregion (Private)

        public static void SetServiceProvider(IServiceProvider provider) {
            _provider = provider;
            ContainerAccess._provider = provider;
        }

        public static T Get<T>() {
            return (T)ContainerAccess._provider.GetService(typeof(T));
        }


    }
}
