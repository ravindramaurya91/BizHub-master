using System;
using Microsoft.AspNetCore.Components.Web;
using System.Collections.Generic;
using System.Timers;
using Model;

namespace BizHub.Pages.FavoritedListings {
    public partial class PagFavoritedListings {

        #region Fields
        private System.Timers.Timer _Timer;
        private PagFavoritedListingsController _controller = new PagFavoritedListingsController();
        #endregion(Fields)

        #region Constructor
        protected override void OnAfterRender(bool firstRender) {
            if (firstRender) {
                Controller.GetMyFavoritedListings();
                StateHasChanged();
            }
        }
        #endregion (Constructor)

        #region Methods
        public void ListingViewSelection(string tsNewView) {
            if (tsNewView.Equals(Constants.LISTINGS_VIEW_STYLE_TILE)) {
                ListingDisplaySetting = Constants.LISTINGS_VIEW_STYLE_TILE;
            } else {
                ListingDisplaySetting = Constants.LISTINGS_VIEW_STYLE_LIST;
            }
        }

        public void SearchFavorites() {
            Controller.KeywordSearch(SearchString);
        }
        #region Sorting Options
        public void Sort(string tsSortCriteria) {
            Controller.Sort(tsSortCriteria);
        }
        #endregion (Sorting Options)

        #region Filter Handling
        public void CheckForSearchEnter(KeyboardEventArgs e) {
            if (e.Key.Equals("Enter")) {
                SearchFavorites();
            }
        }

        public void ClearSearchString() {
            SearchString = null;
            Controller.ClearWordSearch();
        }
        #endregion (Filter Handling)

        #endregion(Methods)

        #region Properties
        public PagFavoritedListingsController Controller { get => _controller; set => _controller = value; }
        public string SearchString { get; set; }
        public string ListingDisplaySetting { get; set; } = Constants.LISTINGS_VIEW_STYLE_LIST;
        public List<ListingDTO> Listings { get => Controller.Listings; set => Controller.Listings = value; }
        #endregion(Properties)

    }
}