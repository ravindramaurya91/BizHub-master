using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using Model;

namespace BizSearch {
    public class SingleListingComparer {
        #region Fields
        private List<SearchCriteria> _criteriaList = null;
        private SearchRequest _searchRequest = null;
        private Int64 _listingOid;
        #endregion (Fields)

        #region Constructor
        public SingleListingComparer(Int64 tiListingOid) {
            _listingOid = tiListingOid;
        }
        #endregion (Constructor)

        public void Run() {
            // Create a new thread to run in;
            Thread oThread = new Thread(() => RunInBackgroundThread()) { };
            oThread.Start();
        }

        public void RunInBackgroundThread() {
            
        // Get a search request from the SearchManager.  By passing a Listing.Oid as a parameter in the request, 
        // we will get a SearchRequest with a single Listing in its Data set (Listing.Data)
        _searchRequest = SearchManager.Instance.GetNewSearchRequest(_listingOid);
            Debug.WriteLine("Running in thread");

            // See This method will run a "Reverse Search."  It will take a single listing record and 
            // Crawl the active SearchCriteria to see if the new Listing is a match for any of the Saved Searches.  If it is, 
            // we will increment the SearchCriteria.NewListingsSinceLastSearchDate counter.
            SearchDataSubset oResult;
            DateTime dtListingCreationDate = _searchRequest.Data.Listings[0].CreatedOn;

            _criteriaList = SearchCriteria.Fetch("Where IsActive = @0", true);
            foreach(SearchCriteria oCriteria in _criteriaList) {
                if ((oCriteria.LastSearchedDate == null) || 
                   ( oCriteria.LastSearchedDate < dtListingCreationDate)) {
                    
                    _searchRequest.Criteria = oCriteria;  // This will cause the new Criteria to be loaded into the SearchRequest object and be prepared for comparison
                    oResult = _searchRequest.Search();

                    if ((oResult != null) && (oResult.Listings != null) && (oResult.Listings.Count > 0)) {
                        // The one listing matched the SearchCriteria filter
                        if (oCriteria.NewListingsSinceLastSearchDate == null) {
                            oCriteria.NewListingsSinceLastSearchDate = 1;
                        } else {
                            oCriteria.NewListingsSinceLastSearchDate = oCriteria.NewListingsSinceLastSearchDate + 1;
                        }
                        oCriteria.Save();
                    }
                }
            }
        }
    }
}
