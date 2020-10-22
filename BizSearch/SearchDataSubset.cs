using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Linq.Expressions;

using Model;
using System.Linq;

namespace BizSearch {
    public class SearchDataSubset {
        #region Fields
        private List<SearchListing> _listings = new List<SearchListing>();
        private Dictionary<Int64, List<SearchListing>> _categories = new Dictionary<long, List<SearchListing>>();
        #endregion (Fields)

        public SearchDataSubset() {
        }
        
        public SearchDataSubset(string tsContext, string tsValue, SearchListing toListing ) {
            Context = tsContext;
            Value = tsValue;
            AddToCollection(toListing);
        }

        #region Load Data
        public void AddToCollection(SearchListing toListing) {
            _listings.Add(toListing);
            BreakDownListingByBusinessCategory(toListing);
        }

        private void BreakDownListingByBusinessCategory(SearchListing toListing) {
            Int64 iOid;
            List<SearchListing> oCollection;

            if (!String.IsNullOrEmpty(toListing.lkpBusinessCategoryOids)) {
                
                //string[] sOids = toListing.lkpBusinessCategoryOids.Substring(1).Split(',');
                string[] sOids = toListing.lkpBusinessCategoryOids.Split(',');
                foreach (string sOid in sOids) {
                    if (!string.IsNullOrEmpty(sOid)) {
                        iOid = Convert.ToInt64(sOid);
                        if (!_categories.TryGetValue(iOid, out oCollection)) {
                            // the key isn't in the dictionary.
                            _categories.Add(iOid, new List<SearchListing>() { toListing });
                        } else {
                            oCollection.Add(toListing);
                        }
                    }
                }

            }
        }

        //public void LoadEntity2ListingMap_StatMetrics() {
        //    SearchListing oCurrentSearchListing = null;
        //    Int64[] iOidList = GetOidListFromListings();
        //    List<Entity2ListingMap_Stat> oMaps = Entity2ListingMap_Stat.Fetch("WHERE ListingOid IN (@0)", iOidList);

        //    // Assign the ListingMap to each Listing
        //    foreach (Entity2ListingMap_Stat oMap in oMaps) {
        //        oCurrentSearchListing = ModelUtil.GetFromListByOid<SearchListing>(oMap.ListingOid, _listings);
        //        if(oCurrentSearchListing != null) {
        //            oCurrentSearchListing.Metrics = oMap;
        //            break;
        //        }
        //    }
        //}
        private Int64[] GetOidListFromListings() {
            Int64[] oReturn = new long[_listings.Count];
            for(int i = 0; i < _listings.Count; i++) {
                oReturn[i] = _listings[i].Oid;
            }
            return oReturn;
        }
        

        #endregion (Load Data)

        #region Search
        #region First Pass
        public List<SearchListing> RefineSearchByBusinessCategory(string tsBusinessCategories) {
            List<SearchListing> oReturn = new List<SearchListing>();
            //string[] sBusinessCategoryArray = tsBusinessCategories.Substring(1).Split(',');
            string[] sBusinessCategoryArray = tsBusinessCategories.Split(',');
            foreach (string sCategory in sBusinessCategoryArray) {
                if (!string.IsNullOrEmpty(sCategory)) {
                    MergeListings(Convert.ToInt64(sCategory), oReturn);
                }
            }
            return oReturn;
        }
        private void MergeListings(Int64 toBizCatOid, List<SearchListing> oCollection) {
            List<SearchListing> oHitList;

            if (_categories.TryGetValue(toBizCatOid, out oHitList)) {
                // the key isn't in the dictionary.
                foreach(SearchListing oListing in oHitList) {
                    if (!oCollection.Contains(oListing)) {
                        oCollection.Add(oListing);
                    }
                }
            }
        }
        #endregion (First Pass)

        #region Apply Search Filters
        public List<SearchListing> ApplySearchFilters(SearchRequest toRequest) {
            // At this point we are beginning the second phase of narrowing down our result set.
            // We have already created this SearchDataSubset by filtering on some combination of Zip, Citry, County, State, and Business Category
            // Now with the newly created DataSubset we will apply the filters from the SearchRequest object to the Listings in the _listings collection.

            // Compare Number Ranges
            List<SearchListing> oReturn = CompareNumberRanges(toRequest);

            // Compare Strings as well.
            if (toRequest.KeyWords.Words.Count > 0) {
                oReturn = RunKeywordComparison(toRequest, oReturn);
            }
            return oReturn;
        }

        private List<SearchListing> RunKeywordComparison(SearchRequest toRequest, List<SearchListing> toList ) {
            List<SearchListing> oReturn = new List<SearchListing>();
            // Keyword searches differ from the other searches in that they are an "OR" - Any word match qualifies a listing
            foreach (SearchListing oListing in toList) {
                oListing.Words.Hits.Clear();
                foreach (string sWord in toRequest.KeyWords.Words.Keys) {
                    if (oListing.Words.Contains(sWord)){
                        oListing.Words.Hits.Add(sWord);
                    }
                }
                if (oListing.Words.Hits.Count > 0) {
                    // There has bneen at least one Keyword match
                    oReturn.Add(oListing);
                }
            }
            return oReturn;
        }

        private List<SearchListing> CompareNumberRanges(SearchRequest toRequest) {
            List<SearchListing> oReturn = new List<SearchListing>();
            bool bQualifies = true;

            List<Int64> oFavoritedListingOids = new List<long>();
            if (SessionMgr.Instance.User != null) {
                oFavoritedListingOids = SessionMgr.Instance.FavoritedListingOids;
            }

            foreach (SearchListing oListing in _listings) {
                bQualifies = true;
                // Compare Decimal Values
                foreach (DecimalValueSet oValues in toRequest.Decimals) {
                    if (!oValues.IsInRange(oListing.Decimals[oValues.Index])) {
                        bQualifies = false;
                        break;
                    }
                }

                // Compare Integer Values
                if (bQualifies) {
                    foreach (IntegerValueSet oValues in toRequest.Integers) {
                        if (!oValues.IsInRange(oListing.Integers[oValues.Index])) {
                            bQualifies = false;
                            break;
                        }
                    }
                }
                // Compare Boolean Values
                if (bQualifies) {
                    foreach (BooleanValueSet oValues in toRequest.Booleans) {
                        if (!oValues.IsInRange(oListing.Booleans[oValues.Index])) {
                            bQualifies = false;
                            break;
                        }
                    }
                }
                if (bQualifies) {
                    oListing.IsFavorite = (oFavoritedListingOids.Contains(oListing.Oid));
                    oReturn.Add(oListing);
                }
            }
            return oReturn;
        }
        #endregion (Apply Search Filters)
        #endregion (Search)

        #region (Properties)
        public string Context { get; set; }
        public string Value { get; set; }
        public List<SearchListing> Listings { get => _listings; set => _listings = value; }
        public Dictionary<Int64, List<SearchListing>> Categories { get => _categories; set => _categories = value; }
        #endregion (Properties)
    }
}
