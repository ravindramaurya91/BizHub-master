using System.Collections.Generic;

using Model;

namespace BizHub.Pages.SavedSearches {
    public partial class PagSavedSearches {

        #region Fields
        private PagSavedSearchesController _controller = new PagSavedSearchesController();
        #endregion(Fields)

        #region Constructor
        protected override void OnAfterRender(bool firstRender) {
            if (firstRender) {
                Controller.GetMySavedSearches();
                IsLoading = false;
                StateHasChanged();
            }
        }
        #endregion(Constructor)

        #region Methods
        public async void DeleteSavedSearch(SearchCriteriaDisplay toDisplay) {
           bool bResponse = await Controller.ConfirmDeleteSearch(toDisplay);
            if(bResponse == true) {
                Controller.DeleteSearch(toDisplay);
                SavedSearches.Remove(toDisplay);
                StateHasChanged();
            }
        }

        public void NavToSavedSearch(SearchCriteriaDisplay toDisplay) {
            Controller.NavigateToListingsWithPayload(toDisplay.SearchCriteria);
        }
        #endregion(Methods)

        #region Properties
        public PagSavedSearchesController Controller { get => _controller; set => _controller = value; }
        public List<SearchCriteriaDisplay> SavedSearches { get => Controller.SavedSearches; }
        public bool IsLoading { get; set; } = true;
        #endregion(Properties)
    }
}