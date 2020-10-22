using System;
using Microsoft.AspNetCore.Components;

using Model;

namespace BizHub.Pages.ListingDetail {
    public partial class PagListingDetail {

        #region Fields
        private Int64 _oid;
        private PagListingDetailController _controller = new PagListingDetailController();
        #endregion (Fields)

        #region Methods
        public void InitializeData() {
            if (Oid != null && Oid > 0) {
                Controller.GetBusinessListing(Oid);
                Controller.GetBrokerCardDTO();
                //Controller.GetSimilarListings();
                StateHasChanged();
            } else {
                Controller.ShowPopupDialog("Must access page with a valid Listing Id", "Error");
            }
        }
        #endregion(Methods)

        #region Properties
        [Parameter]
        public Int64 Oid {
            get { return _oid; }
            set { _oid = value; InitializeData(); }
        }
        PagListingDetailController Controller { get => _controller; set => _controller = value; }
        public ListingDTO ListingDTO { get => Controller.ListingDTO; set => Controller.ListingDTO = value; }
        public BrokerCardDTO BrokerCard { get => Controller.BrokerCard; set => Controller.BrokerCard = value; }

        #endregion (Properties)

    }
}
