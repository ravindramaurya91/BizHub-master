using System;
using System.Runtime.InteropServices;

using Model;

namespace BizSearch {
    public class SearchManager {

        #region Event
        public event EventHandler OnSearchDataChanged;
        #endregion (Event)

        #region Fields
        private static volatile SearchManager _searchManager = null;
        private SearchDataSet _dataSet = null;
        private static object _syncRoot = new Object(); //for multi thread protection
        #endregion (Fields)

        #region Constructor
        static SearchManager() {

        }


        private static SearchManager GetSearchManager() {
            // Return an object reference to GlobalUtilities
            if (_searchManager == null) {
                lock (_syncRoot) {
                    _searchManager = new SearchManager();
                    _searchManager.LoadSearchData();

                }
            }
            return _searchManager;
        }
        public void LoadSearchData() {
            _dataSet = new SearchDataSet();
        }
        #endregion (Constructor)

        #region Methods

        #region Events
        protected virtual void On_SearchDataChanged() {
            OnSearchDataChanged?.Invoke(_dataSet, new EventArgs());
        }
        #endregion (Events)

        public SearchRequest GetNewSearchRequest() {
            // This will return an empty Search Request.  A SearchCriteria needs to be added to it 
            // (by Property) SearchRequest.Criteria = (MySearchCriteria)
            // before running a Search. If you try to run a Search without providing a SearchCriteria, 
            // the SearchEngine will throw an error message.
            return GetNewSearchRequest(null);
        }
        public SearchRequest GetNewSearchRequest(SearchCriteria toCriteria) {
            // This will return a SearchRequest object fully primed and ready to run
            SearchRequest oReturn = new SearchRequest();
            oReturn.Criteria = toCriteria;
            oReturn.Data = _dataSet;
            return oReturn;
        }
        public SearchRequest GetNewSearchRequest(Int64 tiListingOid) {
            // This will return a SearchRequest object with a Single listing in it's data set
            SearchRequest oReturn = new SearchRequest();
            oReturn.Criteria = null;
            oReturn.Data = new SearchDataSet(tiListingOid);
            return oReturn;
        }
        public void RefreshSearchData() {
            _dataSet = new SearchDataSet();
        }

        #endregion (Methods)

        #region Properties
        public static SearchManager Instance {
            get {
                if (_searchManager == null) {
                    _searchManager = GetSearchManager();
                }
                return _searchManager;
            }
        }
        #endregion (Properties)
    }
}
