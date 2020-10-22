using System;
using Microsoft.AspNetCore.Components;

using Model;

namespace BizHub.Components.MyListings {
    public partial class CmpWhseListingStatGrid {

        #region Methods
        public void NavigateToListing() {
            eNavigateToNewPage.InvokeAsync("/ListingDetail/" + StatCardDTO.ListingOid);
        }

        public void NavigateToContactRequests() {
            eNavigateToNewPage.InvokeAsync("/Contact-Requests/" + StatCardDTO.ListingOid);
        }

        public void NavigateToListingSetup() {
            eNavigateToNewPage.InvokeAsync("/Listing-Setup/" + StatCardDTO.ListingOid);
        }

        public void ToggleExpanded() {
            StatCardDTO.IsExpanded = !StatCardDTO.IsExpanded;
            eToggleExpanded.InvokeAsync(true);
        }
        #endregion (Methods)

        #region Properties
        [Parameter] public ListingViewStatsCardDTO StatCardDTO { get; set; }
        [Parameter] public EventCallback<bool> eToggleExpanded { get; set; }
        [Parameter] public EventCallback<string> eNavigateToNewPage { get; set; }
        #endregion (Properties)
    }
}
