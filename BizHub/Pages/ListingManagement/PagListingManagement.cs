using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BizHub.Pages.ListingManagement {
    public partial class PagListingManagement {

        #region Fields
        private PagListingManagementController _controller = new PagListingManagementController();
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
            _controller.NavManager.NavigateTo("/Listing-Management/" + menuNumber);
        }
        #endregion(Methods)

        #region Properties
        [Parameter] public long CurrentMenu { get; set; }
        public PagListingManagementController Controller { get => _controller; }
        #endregion(Properties)
    }
}
