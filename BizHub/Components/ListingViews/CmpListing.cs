using System;
using Microsoft.AspNetCore.Components;

using Model;

namespace BizHub.Components.ListingViews {
    public partial class CmpListing {

        #region Methods
        public void ShowContactBrokerModal() {
           ModalsService.ShowContactBrokerModal(ListingDTO.EntityOid, ListingDTO);
        }

        public static MarkupString Sanitize(MarkupString markupString) {
            return new MarkupString(FSHtmlSanitizer.SanitizeInput(markupString.Value));
        }

        public bool IsContactDisabled(Int64 tiOid) {
            if (tiOid == SessionMgr.Instance.User.EntityOid) {
                return true;
            } else {
                return false;
            }
        }

        public void ViewListingDetail() {
            Controller.NavigateToListingDetail(ListingDTO.Oid);
        }

        public void ToggleFavorite() {
            Controller.ToggleListingFavorite(ListingDTO);
        }
        #endregion (Methods)

        #region Properties
        [Parameter] public ICmpListingController Controller { get; set; }
        [Parameter] public ListingDTO ListingDTO { get; set; }
        #endregion (Properties)

    }
}
