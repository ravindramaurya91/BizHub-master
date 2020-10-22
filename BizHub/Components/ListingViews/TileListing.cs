using System;
using Microsoft.AspNetCore.Components;

using Model;

namespace BizHub.Components.ListingViews {
    public partial class TileListing {

        #region Methods
        public void ShowContactBrokerModal() {
            ModalsService.ShowContactBrokerModal(ListingDTO.EntityOid, ListingDTO);
        }

        public void ViewListingDetail() {
            Controller.NavigateToListingDetail(ListingDTO.Oid);
        }

        public void ToggleFavorite() {
            Controller.ToggleListingFavorite(ListingDTO);
        }

        public bool IsContactDisabled(Int64 tiOid) {
            if (tiOid == SessionMgr.Instance.User.EntityOid) {
                return true;
            } else {
                return false;
            }
        }
        #endregion (Methods)

        #region Properties
        [Parameter] public ICmpListingController Controller { get; set; }
        [Parameter] public ListingDTO ListingDTO { get; set; }
        #endregion (Properties)
    }
}
