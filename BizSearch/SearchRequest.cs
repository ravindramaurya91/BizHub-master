using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using CommonUtil;
using Model;

namespace BizSearch {
    public class SearchRequest {
        #region Fields
        private SearchDataSubset _results = null;
        private SearchCriteria _criteria = null;
        private List<DecimalValueSet> _decimals = new List<DecimalValueSet>();
        private List<IntegerValueSet> _integers = new List<IntegerValueSet>();
        private List<BooleanValueSet> _booleans = new List<BooleanValueSet>();
        private StringValueSet _keyWords = new StringValueSet();


        #endregion (Fields)

        #region Methods

        #region Setup
        private void On_CriteriaChanged() {
            if (Criteria != null) {
                _decimals.Clear();
                _integers.Clear();
                _booleans.Clear();

                #region Notation
                // The SearchListing has and array of Decimals for decimal numbers like [Gross Revenue], [Listing Price], etc. as well as
                // an Integer Array for [Number of Employees], [Total Square Footage], etc, and a Boolean array for yes/no values like
                // [Is a Home Business], [IsSbaPreApproved].  These arrays have a fixed position for each of these values. The index for 
                // the fixed position is in SrchConstants. 
                //
                // When a search uses one of these targets in the search criteria we will store that request in this SearchRequest class
                // within the appropriate _decimals, _integers, or _booleans fields.  These fields are of type DecimalValueSet, IntegerValueSet, 
                // or BooleanValueSet respectively. 
                //
                // So, at run time the SearchListing will have a fixed number in its arrays everytime.  Each row in the Array may or may not have a value 
                // in it (based on whether the Listing has values enetered into each of the target values.  Even if the Listing does not have a value
                // the SearchListing will hold a spot in its array for each value at a fixed position.
                //
                // By contrast, this SearchRequest will only store a value in its list of criterias if the searcher has enetered a specific value to
                // be used as a filter in the search.  When we store a search element, we also store the target position for that element in the SearchListing.
                // We do this by anchoring everything to the SrchConstants values for each element.
                // 
                // When the search runs we will go through the list of criteria in the SearchRequest and compare across to the fixed position in the corrisponding arrays 
                // stored on the SearchListing. 
                // 
                // AS SOON AS a criteria does not match - we stop comparing and proceede to the next listing for comparison
                //
                // *****  KEY WORDS   ****
                // Key words are loaded at start up for each listing into the [Words] collection of the SearchListing.  These are stored one word at a time in a Dictionary with the word as a Key
                // An array of key words is stored in the SearchRequest as well (from the Search Criteria Record)  We will itterate these words to see if there are
                // any hits in the SearchListing.
                #endregion (Notation)

                // Decimals
                LoadValueSet("Price", Criteria.ListingPrice_From, Criteria.ListingPrice_To, SrchConstants.DListingPriceIndex);
                LoadValueSet("EBITDA",Criteria.EBITDA_From, Criteria.EBITDA_To, SrchConstants.DEBITDAIndex);
                LoadValueSet("Revenue", Criteria.GrossRevenue_From, Criteria.GrossRevenue_To, SrchConstants.DGrossRevenueIndex);
                LoadValueSet("Cash Flow", Criteria.CashFlow_From, Criteria.CashFlow_To, SrchConstants.DCashFlowIndex);
                LoadValueSet("Down Payment", Criteria.MinimumDownPayment_From, Criteria.MinimumDownPayment_To, SrchConstants.DMinimumDownPaymentIndex);
                //LoadValueSet("EBITDA", Criteria.MinimumDownPayment_From, Criteria.MinimumDownPayment_To, SrchConstants.DMinimumDownPaymentIndex);

                // Integers
                LoadValueSet("Sq Ft", Criteria.TotalSqFt_From, Criteria.TotalSqFt_To, SrchConstants.ITotalSqFtIndex);
                LoadValueSet("EE Count", Criteria.EmployeeCount_From, Criteria.EmployeeCount_To, SrchConstants.IEmployeeCountIndex);
                //LoadValueSet("Price", Criteria.EmployeeCount_From, Criteria.EmployeeCount_To, SrchConstants.IEmployeeCountIndex);

                // Booleans
                LoadValueSet("Absentee", Criteria.IsAbsenteeOwner, SrchConstants.BAbsenteeOwnerIndex);
                LoadValueSet("HomeBased", Criteria.IsHomeBased, SrchConstants.BHomeBasedIndex);
                LoadValueSet("Relocatable", Criteria.IsRelocatable, SrchConstants.BRelocatableIndex);
                LoadValueSet("Franchise", Criteria.IsFranchise, SrchConstants.BFranchiseIndex);
                LoadValueSet("SellerFinanced", Criteria.IsSellerFinanace, SrchConstants.BSellerFinanaceIndex);
                LoadValueSet("SBA PreApprove", Criteria.IsSbaPreApproved, SrchConstants.BSbaPreApprovedIndex);
           
                // Strings
                if (!string.IsNullOrEmpty(Criteria.Keywords)) { _keyWords.AddWords(Criteria.Keywords); }
            }
        }

        #region Load Decimal/Integre/Boolean Values
        // Decimals
        private void LoadValueSet(string tsName, decimal? tiValue1, decimal? tiValue2, int tiIndex) {
            if ((tiValue1 != null) || (tiValue2 != null)) {
                DecimalValueSet oValueSet = new DecimalValueSet() { Name = tsName, Index = tiIndex, Low = decimal.Zero, High = decimal.MaxValue };
                if (tiValue1 != null) {
                    oValueSet.Low = (decimal)tiValue1;
                }
                if (tiValue2 != null) {
                    oValueSet.High = (decimal)tiValue2;
                }
                _decimals.Add(oValueSet);
            }
        }
        // Integers
        private void LoadValueSet(string tsName, int? tiValue1, int? tiValue2, int tiIndex) {
            if ((tiValue1 != null) || (tiValue2 != null)) {
                IntegerValueSet oValueSet = new IntegerValueSet() { Name = tsName, Index = tiIndex, Low = 0, High = int.MaxValue };
                if (tiValue1 != null) {
                    oValueSet.Low = (int)tiValue1;
                }
                if (tiValue2 != null) {
                    oValueSet.High = (int)tiValue2;
                }
                _integers.Add(oValueSet);
            }
        }
        // Booleans
        private void LoadValueSet(string tsName, bool? tiValue1, int tiIndex) {
            if ((tiValue1 != null) && ((bool)tiValue1)) {
                _booleans.Add(new BooleanValueSet() { Name = tsName, Index = tiIndex, Value = true });
            }
        }

        #endregion (Load Decimal/Integre/Boolean Values)

        #endregion (Setup)

        #region Search
        public SearchDataSubset Search() {
            if (Criteria == null) {
                throw new Exception("There is no SearchCriteria given to the search engine.  Search will be halted");
            }

            // Pas the Search Criteria off to the ServiceHub to be archived for later analysis
            QueableMessage oMsg = new QueableMessage() { MessageType = Constants.QUE_MESSAGE_TYPE_SEARCH_REQUEST, Data = _criteria, TargetTable = "SearchCriteria", TargetOid = _criteria.Oid };
            SessionMgr.Instance.PostToServiceHub(oMsg); // DO NOT AWAIT - We want this to be a background process and do not want to slow down the search();

            _results = null;

            // Phase I search narrows the listings in the following order (Zip, City, County, State, Country) - Then filyters by Business Categories
            _results = FirstPassSubSet();

            // If there are listings after Phase I we then go to phase II which is filtering by Numerics (Price, Revenues, etc.) booleans (IsHomeBusiness, Is SellerFinanced, etc.) then by KeyWord Searches
            if (_results.Listings.Count > 0) {
                _results.Listings = _results.ApplySearchFilters(this);
            }

            //if (_results.Listings.Count > 0) {
            //    _results.LoadEntity2ListingMap_StatMetrics();
            //}

            return _results;
        }

        #region First Pass (Country / State/ County/ City/ Zip / Business Categories)
        private SearchDataSubset FirstPassSubSet() {
            // This is the first pass in the search engine.  
            // In it we will look for an opportunity to narrow the size of the collection we have to navigate
            // We will start with the narrowest criteria (ZipCode), then step back through City->County->State-> and Country until we have a subset
            SearchDataSubset oReturn = null;

            if (!string.IsNullOrEmpty(Criteria.ZipCodes)) {
                // The search has zip codes.  This will be the narrowest first pass opportunity
                oReturn = Data.GetSubsetByZipCodes(Criteria.ZipCodes, Criteria.lkpBusinessCategoryOids);
            } else if (!string.IsNullOrEmpty(Criteria.lkpCityOids)) {
                oReturn = Data.GetSubsetByLookupOids(Criteria.lkpCityOids, Criteria.lkpBusinessCategoryOids);
            } else if (!string.IsNullOrEmpty(Criteria.lkpCountyOids)) {
                oReturn = Data.GetSubsetByLookupOids(Criteria.lkpCountyOids, Criteria.lkpBusinessCategoryOids);
            } else if (Criteria.lkpStateOid > 0) {
                oReturn = Data.GetSubsetByLookupOid(Criteria.lkpStateOid, Criteria.lkpBusinessCategoryOids);
            } else {
                throw new Exception("An attempt was made to generate a search with no Geographic Criteria. Must at least select a state in which to search");
            }

            return oReturn;
        }
        #endregion (First Pass (Country / State/ County/ City/ Zip / Business Categories))

        #endregion (Search)

        #endregion (Methods)

        #region Properties
        public Int64 EntityOid { get; set; }
        public SearchDataSet Data { get; set; }
        public SearchCriteria Criteria {
            get { return _criteria; }
            set { 
                _criteria = value;
                On_CriteriaChanged();
            }
        }
        public List<DecimalValueSet> Decimals { get => _decimals; }
        public List<IntegerValueSet> Integers { get =>_integers; }
        public List<BooleanValueSet> Booleans { get =>_booleans; }
        public StringValueSet KeyWords { get => _keyWords; }
        public SearchDataSubset Results { get => _results; }
        #endregion (Properties)
    }
}
