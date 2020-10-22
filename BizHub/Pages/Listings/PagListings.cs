using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using BizHub.Components.Modals.ListingsSearchByZip;
using BizSearch;

using Model;
using Blazored.Modal.Services;

namespace BizHub.Pages.Listings {
    public partial class PagListings {

        #region Constructor
        protected override void OnAfterRender(bool firstRender) {
            if (firstRender || IsSearchSelected) {
                InitializeData();
            }
        }

        protected override void OnInitialized() {
            #region Documenatation
            // This page is controlled by a PageController (PageListingsController.cs). The PageListingsController uses
            // a child controller (AdvancedSearchController) which is used to govern CmpAdvancedSearch.zazor. 
            // The primary object for the UI in the CmpAdvancedSearch.zazor component is SearchCriteriaDisplay. It is a 
            // wrapper around the SearchCriteria record and produces the list of SearchTags as properties are changed.
            //
            // The AdvancedSearchController is the host to the SearchCriteria Display.
            // Since this class is the first to fire it will construct these relationships in the following sequence:
            //     1) Create the AdvancedSearchController (ASC). (the ASC will create a new SearchCriteriaDisplay as a part of its instantikation)
            //     2) Create a PageListingsController and pass a reference to the ASC as an argument
            //     3) Create the CmpAdvanmcedSearch.razor and pass in the ASC as a paramenter.
            //
            // Now the PageListingsController will be the parent wrapper. It will have access to the ASC which will hold the SearchCriteriaDisplay
            // The CmpAdvancedSearch.zazor component will have access to it through the ASC
            // 
            // The ASC will manage all chages to the SearchCriteri and throw events to interested parties

            #endregion (Documenatation)
            IsLoading = true;
            IsSearchSelected = false;
            IsShowingSearchFilter = true;
            ListingDisplaySetting = Constants.LISTINGS_VIEW_STYLE_LIST;

            AdvancedSearchController oASController = new AdvancedSearchController();
            Controller = new PagListingsController(oASController);
            Controller.ListingCS = this;
        }

        private async void InitializeData() {
            IsLoading = true;
            if (!string.IsNullOrEmpty(SCString)) {
                Controller.UnSubscribeFromSearchCriteriaDisplayEvents();
                SearchCriteriaDisplay = new SearchCriteriaDisplay(SearchCriteria.FromUrl(SCString));
                PageLoad_CriteriaExists();
            } else {
                SearchCriteriaDisplay = new SearchCriteriaDisplay();
                PageLoad_NoCriteriaExists();
            }
        }
        #endregion (Constructor)

        #region Methods

        public void PageLoad_CriteriaExists() {
            Controller.SubscribeToSearchCriteriaDisplayEvents();
            Controller.ValidateZipCode();
            if (IsZipCodeValid) {
                Controller.GetAndAssignListings();
            }
            IsLoading = false;
            IsSearchSelected = false;
            StateHasChanged();
        }

        public async void PageLoad_NoCriteriaExists() {
                string sZip = SessionMgr.Instance.User.Zip;
                if (!string.IsNullOrEmpty(sZip)) {
                    SearchCriteriaDisplay.ZipCode = sZip;
                    SearchSelected();
                } else {
                    ZipCodeSelectModalResponse oResponse = await ShowZipCodeModal();
                    if (oResponse != null) {
                        SearchCriteriaDisplay.SearchRadius = oResponse.SearchRadius;
                        SearchCriteriaDisplay.ZipCode = oResponse.ZipCode;
                        SearchSelected();
                }
            }
        }

        public void FlipFilterShown() {
            IsShowingSearchFilter = !IsShowingSearchFilter;
        }

        public void TriggerStateHasChanged() {
            this.StateHasChanged();
        }

        public void SortBySelected(string tsSortValue) {
            //Controller.On_ListingSortOrderChanged(tsSortValue);
        }

        async Task<ZipCodeSelectModalResponse> ShowZipCodeModal() {
            FSBlazorModalOptions oOptions = new FSBlazorModalOptions();
            oOptions.HideCloseButton = false;
            oOptions.HideHeader = true;
            oOptions.DisableBackgroundCancel = true;
            oOptions.Class += " bizhub-large-modal";
            ModalResult ZipCodeModalResult = await Controller.ShowModal(typeof(CmpListingsSearchByZip), "Begin Your Search", oOptions).Result;
            if (!ZipCodeModalResult.Cancelled) {
                return (ZipCodeSelectModalResponse)ZipCodeModalResult.Data;
            } else {
                return null;
            }
        }

        public void ListingViewSelection(string tsNewView) {
            if (tsNewView.Equals(Constants.LISTINGS_VIEW_STYLE_TILE)) {
                ListingDisplaySetting = Constants.LISTINGS_VIEW_STYLE_TILE;
            } else {
                ListingDisplaySetting = Constants.LISTINGS_VIEW_STYLE_LIST;
            }
        }

        public SearchCriteria CreateDefaultSearchCriteria() {
            //TODO Need to think about hopw we want to create a default for a buyer that is not registered
            SearchCriteria oCriteria = new SearchCriteria();
            return oCriteria;
        }

        public async void SaveSearch() {
            bool bSaved = await Controller.SaveSearch();
            if (bSaved) {
                StateHasChanged();
            }
        }

        public void SearchSelected() {
            IsSearchSelected = true;
            Controller.NavigateToListingsWithPayload(SearchCriteriaDisplay.SearchCriteria);
        }

        public void RemoveTag(DisplayTag toTag) {
            Controller.RemoveTag(toTag);
            StateHasChanged();
        }

        public void InitiateNewSearch() {
            Controller.InitiateNewSearch();
        }
        #endregion (Methods)

        #region Properties
        [Parameter]
        public string SCString { get; set; }

        public QueryResponse QueryResponse { get => Controller.QueryResponse; }
        public PagListingsController Controller { get; set; }
        public SearchCriteriaDisplay SearchCriteriaDisplay { get => Controller.AdvancedSearchController.SearchCriteriaDisplay; set => Controller.AdvancedSearchController.SearchCriteriaDisplay = value; }
        public List<object> Listings { get => Controller.Listings; }
        public string ListingDisplaySetting { get; set; }

        public bool IsRunSearchButtonDisabled { get => Controller.IsRunSearchButtonDisabled; }
        public bool IsZipCodeValid { get => Controller.IsZipCodeValid; }

        public bool IsLoading { get; set; }
        public bool IsSearchSelected { get; set; }
        public bool IsShowingSearchFilter { get; set; }
        #endregion (Properties)
    }




}
