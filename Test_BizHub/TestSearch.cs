using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using Base;
using Model;
using BizSearch;
using CommonUtil;
using BizHub.Services;

namespace Test {
    public class TestSearch {
        #region Setup / Tear down
        [SetUp]
        public void InitializeTestHarness() {
            Initialization.BuildServiceProvider();
        }

        [TearDown]
        public void TearDown() {
            // Noithing to do here
        }

        public void TestTemplate() {

            try {

            } catch (ArgumentException ex) {
                Debug.WriteLine(ex);
            }
        }

        #endregion Setup / Tear down

        [Test]
        public void Test_01_StandardSearch() {
            // This test will retrieve a single SeacrhCriteria record and compare it to all active listings to see how many matches there are
            Int64 iSrchCriteriaOid = 3;

            try {
                SearchCriteria oCriteria = SearchCriteria.FirstOrDefault("WHERE Oid = @0", iSrchCriteriaOid);
                SearchRequest oSearch = SearchManager.Instance.GetNewSearchRequest();
                oSearch.Criteria = oCriteria;
                SearchDataSubset oResults = oSearch.Search();
                oSearch.Criteria.LastSearchedDate = DateTime.UtcNow;  // reset the date
                oSearch.Criteria.NewListingsSinceLastSearchDate = 0;  // reset the number of new listings that have enetered the system since the last tiume the search was run.
                oSearch.Criteria.Save();
            } catch(Exception ex) {
                Debug.WriteLine(ex.Message);
            }
        }

        [Test]
        public void Test_02_ReverseSearch() {
            // This test will test what happens when a new Listing is added.
            // In it we will single SeacrhCriteria record and compare it to all active listings to see how many matches there are
            Int64 iListingOid = 2;

            try {
                SingleListingComparer oComparer = new SingleListingComparer(iListingOid);
                oComparer.Run();
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }
        }

        [Test]
        public void Test_03_ResultSetCache() {

            try {
                Int64 iSrchCriteriaOid = 3;

                // Run a search
                SearchCriteria oCriteria = SearchCriteria.FirstOrDefault("WHERE Oid = @0", iSrchCriteriaOid);
                SearchRequest oSearch = SearchManager.Instance.GetNewSearchRequest();
                oSearch.Criteria = oCriteria;
                SearchDataSubset oResults = oSearch.Search();

                // Create a response type to send back to the Client
                QueryResponse response = new QueryResponse();

                // Create a Result Set to be managed by the Result Cahce Manager
                ResultSet oResultSet = ResultSetCache.Instance.AddNewResultSet(oCriteria.EntityOid, Constants.RESULTSET_LISTING_SEARCH, oResults.Listings);
                oResultSet.ItemsPerPage = 25;// default = 20

                Int64 iEntityOid = -1;
                response.Data = ResultSetCache.Instance.GetPage(oResultSet.Id, 1, out iEntityOid);
                response.ResultSetId = oResultSet.Id;
                response.PageCount = oResultSet.Pages;
                response.ItemCount = oResultSet.Count;
                response.PageNumber = 1; response.Success = true;

                Debug.WriteLine("Count = " + oResultSet.Count.ToString());
                Debug.WriteLine("Page Count = " + oResultSet.Pages.ToString());

                ResultSet oResultSet2 = ResultSetCache_SearchListing.Instance.AddNewResultSet(oCriteria.EntityOid, Constants.RESULTSET_LISTING_SEARCH, oResults.Listings);
                oResultSet2.ItemsPerPage = 15;// default = 20

                // Since this is a ResultSetCache_SearchListing.
                // This call will trigger the ListingsStats to be updated by 1 View Count
                Int64 iEntityOid_Placeholder = -1;
                List<object> oList = ResultSetCache_SearchListing.Instance.GetPage(oResultSet2.Id, 1, out iEntityOid_Placeholder);

                Debug.WriteLine("Page Count = " + oResultSet2.Pages.ToString());

            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }
        }
        [Test]
        public void Test_04_RunSearch() {
            // this method will emulate the call to the RunSearch() method which will
            // create a ResultSetCache_SearchListing and return a handle to it through a QueryResponse object

            try {
                // Get a SearchCirteia
                Int64 iSrchCriteriaOid = 3;
                SearchCriteria oCriteria = SearchCriteria.FirstOrDefault("WHERE Oid = @0", iSrchCriteriaOid);

                oCriteria = new SearchCriteria();
                // Run a Search and Get a QueryResponse back
                QueryResponse oResponse = DataService.RunSearch(oCriteria);

                // The default is 20 items per page 

                // Here is the data you get back with the QueryResponse:
                Debug.WriteLine($" The total number of items in the response is {oResponse.ItemCount}");
                Debug.WriteLine($" Your Cache ID is {oResponse.ResultSetId}. It is used to retrieve the subsequent pages on demand");
                Debug.WriteLine($" The total number of pages in your result set is {oResponse.PageCount}");
                Debug.WriteLine($" You are currently on Page {oResponse.PageNumber} of {oResponse.PageCount}");
                Debug.WriteLine($" Your data is stored as a List<object> in the Response.Data Property");
                //
                //
                // To Get Your next page of results you will call 
                if (oResponse.PageNumber < oResponse.PageCount) {
                    Int64 iEntityOid = -1;
                    List<object> oList = ResultSetCache_SearchListing.Instance.GetPage(oResponse.ResultSetId, oResponse.PageNumber +1, out iEntityOid);
                }

            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }
        }

    }
}
