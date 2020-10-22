using Microsoft.AspNetCore.Components.Routing;
using Microsoft.IdentityModel.Tokens;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BizHub.Shared {
    public partial class MainLayout {

        #region Fields
        private bool _isLoading = false;
        #endregion (Fields)

        protected override void OnInitialized() {
            FSPageTools.Instance.NavManager = _navManager;
            FSPageTools.Instance.ModalService = _modalService;
            FSPageTools.Instance.MainLayout = this;
        }

        #region Methods
        public void SetIsLoading(bool tbValue) {
            _isLoading = tbValue;
            StateHasChanged();
        }
        #endregion (Methods)


    }
}
