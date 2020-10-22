using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BizHub.Pages.Admin {
    public partial class PagAdmin {

        #region Fields
        private PagAdminController _controller = new PagAdminController();
        #endregion (Fields)

        #region Methods
        protected override void OnAfterRender(bool firstRender) {
            if (firstRender) {
                if (CurrentMenu <= 0 || CurrentMenu == null) {
                    SelectMenuItem(1);
                }
            }
        }
        public void SelectMenuItem(int menuNumber) {
            _controller.NavManager.NavigateTo("/Admin-Setup/" + menuNumber);
        }
        #endregion(Methods)

        #region Properties
        [Parameter] public long CurrentMenu { get; set; }
        public PagAdminController Controller { get => _controller; }
        #endregion(Properties)
    }
}
