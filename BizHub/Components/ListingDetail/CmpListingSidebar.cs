using BizHub.Shared;
using Microsoft.AspNetCore.Components;

using Model;
using System;

namespace BizHub.Components.ListingDetail {
    public partial class CmpListingSidebar {

        #region Fields
        private BasePageController _controller = new BasePageController();
        #endregion (Fields)

        #region Methods
        public void ToggleFavorite() {
            ListingDTO.ToggleIsFavorite();
        }

        public void NavigateToListingSetup() {
            Controller.NavigateTo("/Listing-Setup/" + ListingDTO.Oid);
        }
        #endregion(Methods)

        #region Properties
        [Parameter] public ListingDTO ListingDTO { get; set; }
        [Parameter] public bool? ShowButtons { get; set; }
        public BasePageController Controller { get => _controller; set => _controller = value; }
        public Int64 LoggedInUserOid { get { return SessionMgr.Instance.User.EntityOid; } }
        #endregion(Properties)
    }
}