using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using BizHub.Components.Modals.SaveSearch;
using BizHub.Pages.Listings;
using BizHub.Services;
using BizSearch;
using Blazored.Modal;
using Blazored.Modal.Services;
using CommonUtil;
using Model;

namespace BizHub {
    public class PagListingsController : BasePageController, ICmpListingController {

        #region Enums
        public enum eListingSortOrder { PriceHigh, PriceLow, Newest, Oldest }
        #endregion (Enums)

        #region Events
        public event EventHandler OnListingSortOrderChangedEvent;
        #endregion (Events)

        #region Fields
        private AdvancedSearchController _advancedSearchController;
        private List<object> _listings = new List<object>();
        private QueryResponse _queryResponse = new QueryResponse();
        private eListingSortOrder _listingSortOrder = eListingSortOrder.Newest;
        private bool _isRunSearchButtonDisabled = true;
        private bool _isZipCodeValid = true;
        #endregion(Fields)

        #region Constructor
        public PagListingsController(AdvancedSearchController toAdvancedSearchController) {
            _advancedSearchController = toAdvancedSearchController;
        }
        #endregion(Constructor)

        #region Methods

        #region Events
        public void UnSubscribeFromSearchCriteriaDisplayEvents() {
            SearchCriteriaDisplay.OnTagListChanged -= _OnTagsChanged;
            SearchCriteriaDisplay.OnSearchCriteriaPropertyChanged -= _OnSearchCriteriaPropertyChanged;
        }
        public void SubscribeToSearchCriteriaDisplayEvents() {
            SearchCriteriaDisplay.OnTagListChanged += _OnTagsChanged;
            SearchCriteriaDisplay.OnSearchCriteriaPropertyChanged += _OnSearchCriteriaPropertyChanged;
        }

        private void _OnTagsChanged(object sender, SearchCriteriaChangedEventArgs e) {
            ListingCS.TriggerStateHasChanged();
        }

        private void _OnSearchCriteriaPropertyChanged(object sender, SearchCriteriaChangedEventArgs e) {
            if (e.PropertyName.Equals("ZipCode")) {
                    SearchCriteria_OnZipCodeChanged();
            } else {
                EnableRunSearchButton();
            }
        }
        #endregion (Events)

        #region ICmpListingController Required Methods
        public void NavigateToListingDetail(Int64 tiListingOid) {
            NavigateTo("/ListingDetail/" + tiListingOid);
        }

        public void ToggleListingFavorite(ListingDTO toListingDTO) {
            toListingDTO.ToggleIsFavorite();
        }
        #endregion (ICmpListingController Required Methods)


        public void InitiateNewSearch() {
            // get the ZipCode criteria - they will transfer to the new search
            string sZipCode = SearchCriteriaDisplay.SearchCriteria.ZipCode;
            int iRadius = (SearchCriteriaDisplay.SearchCriteria.SearchRadius != null) ? (int)SearchCriteriaDisplay.SearchCriteria.SearchRadius : Convert.ToInt32(Constants.ZIPCODE_SEARCH_DISTANCES[0].Value);

            SearchCriteriaDisplay.ClearAllTags();
            SearchCriteriaDisplay.SearchCriteria = new SearchCriteria() { ZipCode = sZipCode, SearchRadius = iRadius }; ;
            SearchCriteria_OnZipCodeChanged();
        }

        public void SearchCriteria_OnZipCodeChanged() {
            if (!string.IsNullOrEmpty(SearchCriteriaDisplay.ZipCode) && SearchCriteriaDisplay.ZipCode.Length >= 5) {
                ValidateZipCode();
            } else {
                IsZipCodeValid = false;
                DisableRunSearchButton();
            }
        }

        public void ValidateZipCode() {
            if (string.IsNullOrEmpty(SearchCriteriaDisplay.ZipCode)) {
                IsZipCodeValid = false;
                DisableRunSearchButton();
            } else {
                ZipCode oZipCode = DataService.VerifyZipCode(SearchCriteriaDisplay.ZipCode);
                if (oZipCode != null) {
                    IsZipCodeValid = true;
                    EnableRunSearchButton();
                    //TODO create a method that assigns zipcode metadata
                    //Take the zipcode and stuff the cityoid, stateoid, and countyOid onto the search criteria display object that we have.
                } else {
                    IsZipCodeValid = false;
                    DisableRunSearchButton();
                }
            }
        }

        public void GetNextListings() {
            List<object> oTempList = QueryResponse.GetNext();
            Listings.AddRange(oTempList);
        }

        public void GetAndAssignListings() {
            SearchCriteriaDisplay.SearchCriteria.EntityOid = SessionMgr.Instance.User.EntityOid;
            QueryResponse = DataService.RunSearch(SearchCriteriaDisplay.SearchCriteria);
            Listings = QueryResponse.Data;
            DisableRunSearchButton();
        }

        public void DisableRunSearchButton() {
            IsRunSearchButtonDisabled = true;
        }

        public void EnableRunSearchButton() {
            if(!string.IsNullOrEmpty(SearchCriteriaDisplay.ZipCode) && IsZipCodeValid) {
                IsRunSearchButtonDisabled = false;
            }
        }

        public async Task<bool> SaveSearch() {
            ModalParameters oParameters = new ModalParameters();
            FSBlazorModalOptions oOptions = new FSBlazorModalOptions();

            if (SearchCriteriaDisplay.Oid != null && SearchCriteriaDisplay.Oid > 0) {
                oParameters.Add("IsSearchExists", true);
            }
            oParameters.Add("SearchName", SearchCriteriaDisplay.Name);

            oOptions.HideCloseButton = false;
            oOptions.HideHeader = true;
            oOptions.Class += " save-search-modal";

            ModalResult SaveSearchModal = await ShowModal(typeof(SaveSearchModal), "", oParameters, oOptions).Result;
            if (!SaveSearchModal.Cancelled) {
                SaveSearchModalResponse oResponse = (SaveSearchModalResponse)SaveSearchModal.Data;
                SearchCriteriaDisplay.Name = oResponse.SearchName;
                if (oResponse.ButtonName.Equals(Constants.BUTTON_SAVE_NEW)) {
                    //Serialize into a new SearchCriteria object to ensure it doesn't override the alrady existing Criteria
                    SearchCriteria oCriteria = GenerateNewSearchCriteria(SearchCriteriaDisplay.SearchCriteria);
                    oCriteria.Save();

                    ReplaceSearchCriteriaDisplay(oCriteria);
                    ShowPopupDialog("Search successfully saved!", "Success");
                } else {
                    SearchCriteriaDisplay.SearchCriteria.EntityOid = SessionMgr.Instance.User.EntityOid;
                    SearchCriteriaDisplay.SearchCriteria.ListingCount = Listings.Count;
                    SearchCriteriaDisplay.SearchCriteria.IsActive = true;
                    SearchCriteriaDisplay.SearchCriteria.Save();
                    ShowPopupDialog("Search successfully saved!", "Success");
                }
                return true;
            } else {
                return false;
            }
        }

        public void ReplaceSearchCriteriaDisplay(SearchCriteria toCriteria) {
            UnSubscribeFromSearchCriteriaDisplayEvents();
            SearchCriteriaDisplay = new SearchCriteriaDisplay(toCriteria);
            SubscribeToSearchCriteriaDisplayEvents();
        }

        public SearchCriteria GenerateNewSearchCriteria(SearchCriteria oCriteria) {
            string jCriteria = JsonSerializer.Serialize<SearchCriteria>(oCriteria);
            int commaIndex = jCriteria.IndexOf(",");
            string newStr = jCriteria.Remove(1, commaIndex);
            return JsonSerializer.Deserialize<SearchCriteria>(newStr);
        }

        public void On_ListingSortOrderChanged() {
            // Get the resultsetID
            // Call to the resultset using the ID and request a resort
            // Pass in the "Comparer" to be used
            // Refresh the Controller's Listings Property
            // throw an OnListingSortOrderChangedEvent 
            OnListingSortOrderChangedEvent?.Invoke(this, null);
        }


        #region Search Tag Management
        public void RemoveTag(DisplayTag toTag) {
            _advancedSearchController.RemoveTag(toTag);
            EnableRunSearchButton();
        }
        #endregion (Search Tag Management)

        #endregion(Methods)

        #region Properties
        public PagListings ListingCS { get; set; }
        public QueryResponse QueryResponse { get => _queryResponse; set => _queryResponse = value; }
        public List<object> Listings { get => _listings; set => _listings = value; }
        public AdvancedSearchController AdvancedSearchController { get => _advancedSearchController; set => _advancedSearchController = value; }
        public SearchCriteriaDisplay SearchCriteriaDisplay { get => _advancedSearchController.SearchCriteriaDisplay; set => _advancedSearchController.SearchCriteriaDisplay = value; }
        public bool IsRunSearchButtonDisabled { get => _isRunSearchButtonDisabled; set => _isRunSearchButtonDisabled = value; }
        public bool IsZipCodeValid { get => _isZipCodeValid; set => _isZipCodeValid = value; }
        public eListingSortOrder ListingSortOrder {
            get { return _listingSortOrder; }
            set {
                if (_listingSortOrder != value) {
                    _listingSortOrder = value;
                    On_ListingSortOrderChanged();
                }
            }
            #endregion(Properties)

        }
    }
}
