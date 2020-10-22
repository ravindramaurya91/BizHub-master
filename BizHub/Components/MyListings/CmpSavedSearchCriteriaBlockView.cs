using Microsoft.AspNetCore.Components;

using Model;

namespace BizHub.Components.MyListings {
    public partial class CmpSavedSearchCriteriaBlockView {

        #region Methods
        protected override void OnInitialized() {
            SavedSearchDisplay.OnIsEmailNotificationChanged += SaveSearch;
        }

        public void DeleteCriteria() {
            eDeleteSearchCriteriaDisplay.InvokeAsync(SavedSearchDisplay);
        }

        public void NavigateToListings() {
            eNavigateToListings.InvokeAsync(SavedSearchDisplay);
        }

        public void SaveSearch(object sender, SearchCriteriaChangedEventArgs e) {
            SavedSearchDisplay.SearchCriteria.Save();
        }
        #endregion (Methods)

        #region Properties
        [Parameter] public SearchCriteriaDisplay SavedSearchDisplay { get; set; }
        [Parameter] public EventCallback<SearchCriteriaDisplay> eDeleteSearchCriteriaDisplay { get; set; }
        [Parameter] public EventCallback<SearchCriteriaDisplay> eNavigateToListings { get; set; }
        #endregion (Properties)

    }
}
