using System;
using Microsoft.AspNetCore.Components;
using Blazored.Modal.Services;

namespace BizHub.Shared {
    public class FSPageTools {

        #region Fields
        private static volatile FSPageTools _instance = null;
        #endregion (Fields)

        #region Properties
        public static FSPageTools Instance {
            get {
                if (_instance == null) {
                    _instance = new FSPageTools();
                }
                return _instance;
            }
        }

        public MainLayout MainLayout { get; set; }
        public NavigationManager NavManager { get; set; }
        public IModalService ModalService { get; set; }
        #endregion (Properties)
    }
}
