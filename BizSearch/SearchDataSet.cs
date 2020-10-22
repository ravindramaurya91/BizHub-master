using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Base;
using BizHub.Service;
using Model;
using CommonUtil;
using System.Diagnostics;

namespace BizSearch {
    public class SearchDataSet {

        #region Fields
        private List<SearchListing> _listings = new List<SearchListing>();
        private Dictionary<Int64, SearchDataSubset> _oidList = new Dictionary<long, SearchDataSubset>();
        private Dictionary<string, SearchDataSubset> _zipList = new Dictionary<string, SearchDataSubset>();
        #endregion (Fields)

        public SearchDataSet() {
            LoadAllListings();
        }
        public SearchDataSet(Int64 tiListingOid) {
            // This constructor loads a single Listing record into the SearchDataSet so we can use the 
            // standard search engine to compare this single listing against all of the saved searches & see if it will be of any 
            // interest to the potential buyers
            LoadSingleListing(tiListingOid);
        }

        #region Load Data
        protected virtual void LoadAllListings() {
            // Load All Listings into data set (Called from first constructor)
            _listings = Base.Database.GetInstance().Fetch<SearchListing>("SELECT * FROM Listing WHERE IsActive = @0", true);
            ProcessListings();
        }
        protected virtual void LoadSingleListing(Int64 tiListingOid) {
            // Load a single Listing into data set (see note in second constructor)
            _listings = Base.Database.GetInstance().Fetch<SearchListing>("SELECT * FROM Listing WHERE Oid = @0", tiListingOid);
            ProcessListings();
        }
        private void ProcessListings() {
            foreach (SearchListing oListing in _listings) {
                oListing.DeconstructData();
            }
            SortRawListngs_Country();
        }

        private void SortRawListngs_Country() {
            foreach (SearchListing oListing in _listings) {
                Debug.WriteLine("Listing Oid = " + oListing.Oid.ToString());
                AddLookupEntry(oListing.lkpCountryOid, oListing);  // Add Country
                AddLookupEntry(oListing.lkpStateOid, oListing);    // Add State
                AddLookupEntry(oListing.lkpCountyOid, oListing);   // Add County
                AddLookupEntry(oListing.lkpCityOid, oListing);     // Add City
                AddZipCodeEntry(oListing.Zip, oListing); // Add ZipCode
            }
        }

        private void AddLookupEntry(Int64? tiLookupOid, SearchListing toListing) {
            SearchDataSubset oSubSet;

            if (tiLookupOid != null ) {
                Int64 iLookupOid = (Int64)tiLookupOid;
                Lookup oLookup = LookupManager.Instance.GetLookupByOid(iLookupOid);
                if (oLookup != null) {
                    if (!_oidList.TryGetValue(iLookupOid, out oSubSet)) {
                        // the key isn't in the dictionary.
                        _oidList.Add(iLookupOid, new SearchDataSubset(oLookup.LookupName, oLookup.Value,  toListing));
                    } else {
                        oSubSet.AddToCollection(toListing);
                    }
                }
            }
        }

        private void AddZipCodeEntry(string tsZipCode, SearchListing toListing) {
            SearchDataSubset oSubSet;

            if (!string.IsNullOrEmpty(tsZipCode)) {
                if (!_zipList.TryGetValue(tsZipCode, out oSubSet)) {
                    // the key isn't in the dictionary.
                    _zipList.Add(tsZipCode, new SearchDataSubset("ZipCode", tsZipCode, toListing));
                } else {
                    oSubSet.AddToCollection(toListing);
                }
            }
        }
        #endregion (Load Data)

        #region Search Methods
        #region FirstPass
        public SearchDataSubset GetSubsetByZipCodes(string tsZipCodes, string tsBusinessCategories) {
            SearchDataSubset oReturn = new SearchDataSubset();
            SearchDataSubset oSubSet;
            //string[] sZipCodeArray = tsZipCodes.Substring(1).Split(',');
            string[] sZipCodeArray = tsZipCodes.Split(',');

            bool bSearchUsesBusinessCategories = (!string.IsNullOrEmpty(tsBusinessCategories));

            foreach (string sZipCode in sZipCodeArray) {
                if (!string.IsNullOrEmpty(sZipCode)) {
                    if (_zipList.TryGetValue(sZipCode, out oSubSet)) {
                        // the key isn't in the dictionary.
                        if (bSearchUsesBusinessCategories) {
                            oReturn.Listings.AddRange(oSubSet.RefineSearchByBusinessCategory(tsBusinessCategories));
                        } else {
                            oReturn.Listings.AddRange(oSubSet.Listings);
                        }
                    }
                }
            }
            return oReturn;
        }
        public SearchDataSubset GetSubsetByLookupOids(string tsLookupOids, string tsBusinessCategories) {
            SearchDataSubset oReturn = new SearchDataSubset();
            SearchDataSubset oSubSet;
            //string[] sLookupOidArray = tsLookupOids.Substring(1).Split(',');
            string[] sLookupOidArray = tsLookupOids.Split(',');

            bool bSearchUsesBusinessCategories = (!string.IsNullOrEmpty(tsBusinessCategories));

            foreach (string sOid in sLookupOidArray) {
                if (!string.IsNullOrEmpty(sOid)) {
                    if (_oidList.TryGetValue(Convert.ToInt64(sOid), out oSubSet)) {
                        // the key isn't in the dictionary.
                        if (bSearchUsesBusinessCategories) {
                            oReturn.Listings.AddRange(oSubSet.RefineSearchByBusinessCategory(tsBusinessCategories));
                        } else {
                            oReturn.Listings.AddRange(oSubSet.Listings);
                        }
                    }
                }
            }
            return oReturn;
        }
        public SearchDataSubset GetSubsetByLookupOid(Int64 tiLookupOid, string tsBusinessCategories) {
            SearchDataSubset oReturn = new SearchDataSubset();
            SearchDataSubset oSubSet;

            bool bSearchUsesBusinessCategories = (!string.IsNullOrEmpty(tsBusinessCategories));

            if (_oidList.TryGetValue(tiLookupOid, out oSubSet)) {
                // the key isn't in the dictionary.
                if (bSearchUsesBusinessCategories) {
                    oReturn.Listings.AddRange(oSubSet.RefineSearchByBusinessCategory(tsBusinessCategories));
                } else {
                    oReturn.Listings.AddRange(oSubSet.Listings);
                }
            }
            return oReturn;
        }
        #endregion (FirstPass)
        #endregion (Search Methods)

        #region Methods
        #endregion (Methods)

        #region Properties
        public List<SearchListing> Listings {
            get { return _listings; }
            set { _listings = value; }
        }
        #endregion (Properties)
    }
}
