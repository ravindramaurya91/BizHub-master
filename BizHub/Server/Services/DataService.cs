using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Base.Security;
using Model;
using CommonUtil;
using BizHub.Shared;
using BizHub.Server;
using System.Diagnostics;
using BizSearch;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Nancy.Session;

namespace BizHub.Services {
    public class DataService {

        public DataService() {

        }

        #region Business Categories
        public static BaseResponse GetBusinessCategories() {
            BaseResponse oReturn = new BaseResponse();

            try {
                Int64 iDefinitionOid = LookupManager.Instance.GetLookupDefinitionOidByLookupName("BusinessCategory");
                if (iDefinitionOid > 0) {

                }
                // Create a Lookup Jieracrhy in LookupManager



            } catch (Exception ex) {
                oReturn.LoadException(ex);
            }

            return oReturn;
        }
        #endregion (Business Categories)

        #region Cards
        //*********************** 

        public static BaseResponse GetBrokerCardsByStateOids(List<Int64> tiStateOids) {
            BaseResponse oReturn = new BaseResponse();
            List<BrokerCardDTO> oList = new List<BrokerCardDTO>();

            try {
                oReturn.Data = SQL.GetBrokerCardsDTOByServiceAreaOids("State", tiStateOids);
            } catch (Exception ex) {
                oReturn.LoadException(ex);
            }
            return oReturn;
        }

        public static BaseResponse GetBrokerCardsByCountyOids(List<Int64> tiStateOids) {
            BaseResponse oReturn = new BaseResponse();
            List<BrokerCardDTO> oList = new List<BrokerCardDTO>();

            try {
                oReturn.Data = SQL.GetBrokerCardsDTOByServiceAreaOids("County", tiStateOids);
            } catch (Exception ex) {
                oReturn.LoadException(ex);
            }
            return oReturn;
        }

        public static BrokerCardDTO GetBrokerCardByEntityOid(Int64 tiOid) {
            BrokerCardDTO oReturn;
            try {
                oReturn = SQL.GetBrokerCardByEntityOid(tiOid);
            } catch (Exception ex) {
                throw ex;
            }

            return oReturn;
        }

        public static BaseResponse GetPublicProfileCardDTOByOid(Int64 tiEntityOid) {

            BaseResponse oReturn = new BaseResponse();
            IdentityCardDTO oProfileCard;

            try {
                if (tiEntityOid > 0) {
                    oReturn.Data = Base.Database.GetInstance().FirstOrDefault<IdentityCardDTO>(SqlConstants.GET_PROFILE_CARD + "WHERE e.Oid = @0", tiEntityOid);
                }

                if (oReturn.Data == null) {
                    if (tiEntityOid == 0) {
                        throw new Exception("No EntityOid passed to the GetPublicProfileCardDTOByOid() Method.");
                    } else {
                        throw new Exception($"No record found in the Entity Table that matches Oid = [{tiEntityOid}]");
                    }
                }
            } catch (Exception ex) {
                oReturn.LoadException(ex);
            }

            return oReturn;
        }
        #endregion (Cards)

        #region Email
        public static List<EmailTemplate> GetAllEmailTemplatesByEntityOidMaster(List<Int64> tiEntityOid_Master) {
            List<EmailTemplate> oReturn = new List<EmailTemplate>();

            try {
                oReturn = EmailTemplate.Fetch("WHERE EntityOid_Master = @0", tiEntityOid_Master);
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return oReturn;
        }
        #endregion (Email)


        #region Entity
        //*********************** 
        public BaseResponse DoSomethingWithTheEntity() {
            BaseResponse oReturn = new BaseResponse();

            try {

            } catch (Exception ex) {
                oReturn.LoadException(ex);
            }
            return oReturn;
        }



        #endregion (Entity)

        #region Listings
        //*********************** 
        public static BaseResponse GetListingByOid(Int64 tiOid, bool tbThrowErrorOnNull = false) {
            BaseResponse oReturn = new BaseResponse();

            try {
                oReturn.Data = SQL.GetListingByOid(tiOid, tbThrowErrorOnNull);

            } catch (Exception ex) {
                oReturn.LoadException(ex);
            }
            return oReturn;
        }
        
        //*********************** 
        public static BaseResponse GetListingsBySearchCriteria(SearchCriteria toSearchCriteria)
        {
         BaseResponse oReturn = new BaseResponse();
         try {
             // oReturn.Data = DataService.SearchListingsBySearchCriteria(toSearchCriteria);

         } catch (Exception ex) {
             oReturn.LoadException(ex);
         }
         return oReturn;
        }
        
        //*********************** 

        //*********************** 
        public static BaseResponse GetListingsByEntityOid_Master(Int64 tiOid) {
            BaseResponse oReturn = new BaseResponse();

            try {
                oReturn.Data = SQL.GetListingsByEntityOid(tiOid);

            } catch (Exception ex) {
                oReturn.LoadException(ex);
            }
            return oReturn;
        }

        //*********************** 
        public static BaseResponse GetListingDTOByOid(Int64 tiOid) {
            BaseResponse oReturn = new BaseResponse();

            try {
                oReturn.Data = ListingDTO.GetByListingOid(tiOid);

            } catch (Exception ex) {
                oReturn.LoadException(ex);
            }
            return oReturn;
        }

        //*********************** 
        public BaseResponse GetAccountDashboardDTO() {
            BaseResponse oReturn = new BaseResponse();
            AccountDashboardDTO oDTO = new AccountDashboardDTO();

            try {
                //TODO Get logged User Oid. Remove hard code
                List<Listing> AllListings = SQL.GetMyListingsAndMySavedListings(SessionMgr.Instance.User.EntityOid);
                List<SearchCriteria> oCriteria = SQL.GetActiveSearchCriteriaListByEntityOid(SessionMgr.Instance.User.EntityOid);
                //TODO: Call to search server, get a count of new listings for each searchcriteria object
                // Build SavedSearchDetailDTO object per SearchCriteria with the corresponding new listings number

                oDTO.ParseListings(AllListings, 1);
                oReturn.Data = oDTO;
                //Go out and get new list count for each criteria
            } catch (Exception ex) {
                oReturn.LoadException(ex);
            }
            return oReturn;
        }

        //*********************** 
        public static ListingDTO AddUpdateListing(ListingDTO toDTO) {
            toDTO.Save();
            return toDTO;
        }

        public static ListingDTO CompleteAndPublishListing(ListingDTO toDTO) {
            DateTime oNow = DateTime.Now;
            
            toDTO.EntityOid = SessionMgr.Instance.User.EntityOid;
            toDTO.EntityOid_BillingAuthority = SessionMgr.Instance.User.EntityOid_Master;
            toDTO.ListingDate = oNow;
            toDTO.CreatedOn = oNow;
            toDTO.IsPending = false;
            toDTO.IsActive = true;
            toDTO.lkpListingSetupStatusOid = LookupManager.Instance.GetOidByConstantValue("LISTINGSETUPSTATUS->COMPLETE");
            toDTO.Save();
            return toDTO;
        }

        #endregion (Listings)

        #region Login
        //*********************** 
        public BaseResponse Login(LoginRequest toRequest) {
            BaseResponse oReturn = new BaseResponse();

            try {
                //??  Authenticator oAuthenticator = new Authenticator();
                //??  Authenticator.AuthenticateTest(toRequest);

            } catch (Exception ex) {
                oReturn.LoadException(ex);
            }
            return oReturn;
        }


        /*       public BaseResponse Authenticate(LoginRequest toRequest) {
            BaseResponse oReturn = new BaseResponse();

            try {
                oReturn.Success = ProcessLoginRequest(toRequest);
            } catch (Exception ex) {
                oReturn.LoadException(ex);
            }
            return oReturn;
        }*/
        #endregion (Login)

        #region ProfileCardDTO
        public static BaseResponse GetIdentityCardByEntityOid(Int64 tiOid) {
            BaseResponse oReturn = new BaseResponse();

            try {
                oReturn.Data = IdentityCardDTO.GetProfileCardDTOByEntityOid(tiOid);

            } catch (Exception ex) {
                oReturn.LoadException(ex);
            }
            return oReturn;
        }

        public static BaseResponse SaveProfileCardDTO(IdentityCardDTO oDTO) {
            BaseResponse oReturn = new BaseResponse();

            try {
                oReturn.Data = oDTO.Save();

            } catch (Exception ex) {
                oReturn.LoadException(ex);
            }
            return oReturn;
        }
        #endregion (ProfileCardDTO)

        #region Search

        public BaseResponse SaveSearchCriteria(SearchCriteria toCriteria) {
            BaseResponse oReturn = new BaseResponse();

            try {
                toCriteria.Save();
                oReturn.Data = toCriteria;

            } catch (Exception ex) {
                oReturn.LoadException(ex);
            }
            return oReturn;
        }

        public static QueryResponse RunSearch(Int64 tiSearchCriteriaOid) {
            // This method will Lookup the SearchCriteria record, run a search, create a Result Set 
            // and return in in a QueryResponse
            SearchDataSubset oReturn = new SearchDataSubset();
            SearchCriteria oCriteria = SQL.GetSearchCriteriaByOid(tiSearchCriteriaOid, true);
            return RunSearch(oCriteria);
        }
     
        public static QueryResponse RunSearch(SearchCriteria toSearchCriteria) {
            // This method will receive a SearchCriteria record, run a search, create a Result Set 
            // and return in in a QueryResponse
            QueryResponse oReturn = new QueryResponse();

            try {
                // Create a response type to send back to the Client

                // Get a SearchRequest from the SearchManager
                // It is the SearchRequest that will hold the SearchCriteria as well as a pointer 
                // to the pre-loaded Listing data which has been curated by the SearchManager on instantiation.
                // 
                // The SearchRequest object will manage the search itself.

                // GET DEFAULT Data from the SessionMgr.User
                if ((toSearchCriteria.lkpStateOid == null) || (toSearchCriteria.lkpStateOid <= 0)) {
                    if (SessionMgr.Instance.User != null) {
                        toSearchCriteria.lkpStateOid = SessionMgr.Instance.User.lkpStateOid;
                    }
                    // Final double chack - default to CA if we do not have a state - 
                    // TODO Check the default Zip if we need a state
                    // TODO - DO NOT HAVE THE STATE HARD CODED
                    if ((toSearchCriteria.lkpStateOid == null) || (toSearchCriteria.lkpStateOid <= 0)) {
                        toSearchCriteria.lkpStateOid = LookupManager.Instance.GetOidByConstantValue("STATE->CALIFORNIA");
                    }
                }

                SearchRequest oSearchRequest = SearchManager.Instance.GetNewSearchRequest(toSearchCriteria);
                SearchDataSubset oResults = oSearchRequest.Search();


                // Create a ResultSetCache_SearchListing Set to be managed by the ResultCache Manager
                // There is a  difference between a "ResultSet" & a "ResultSetCache_SearchListing"
                // Both hold pages of data to be retirieved but the 'ResultSetCache_SearchListing" is specially designed 
                // for Listing Queries.  Everytime a fetch is made to retieve a new page of results the
                // internal calls will update the metrics on the number of times the listings have been viewed.

                // Here is a Standard resultSet call
                //ResultSet oResultSet = ResultSetCache.Instance.AddNewResultSet(toSearchCriteria.EntityOid, Constants.RESULTSET_LISTING_SEARCH, oResults.Listings);

                // Here is a ResultSetCache_SearchListing call
                if (oResults.Listings.Count == 0) {
                    oReturn.ResultSetId = -1;
                    oReturn.PageCount = 0;
                    oReturn.ItemCount = 0;
                    oReturn.PageNumber = 0; 
                    oReturn.Success = true;
                    oReturn.EntityOid = -1;
                } else {
                    ResultSet oResultCache = ResultSetCache_SearchListing.Instance.AddNewResultSet(toSearchCriteria.EntityOid, Constants.RESULTSET_LISTING_SEARCH, oResults.Listings);
                    //oResultSet2.ItemsPerPage = 25;// default = 20

                    // Get a page worth of data
                    // Each time the data is retieved we will see get the EntityOid of the owner of the search
                    Int64 iEntityOid = -1;
                    oReturn.Data = ResultSetCache_SearchListing.Instance.GetPage(oResultCache.Id, 1, out iEntityOid);
                    oReturn.ResultSetId = oResultCache.Id;
                    oReturn.PageCount = oResultCache.Pages;
                    oReturn.ItemCount = oResultCache.Count;
                    oReturn.PageNumber = 1; oReturn.Success = true;
                    oReturn.EntityOid = iEntityOid;
                }

                toSearchCriteria.LastSearchedDate = DateTime.UtcNow;
                toSearchCriteria.NewListingsSinceLastSearchDate = 0;
                toSearchCriteria.Save();

            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }

            return oReturn;
        }

        public static SearchDataSubset SearchListingsByCriteria(Int64 tiSearchCriteriaOid) {
            // This is a direct call to the search engine.  IOt wioll NOT have a ResultSet to Queue the result Pages
            SearchDataSubset oReturn = new SearchDataSubset();
            SearchCriteria oCriteria = SQL.GetSearchCriteriaByOid(tiSearchCriteriaOid, true);
            return SearchListingsByCriteria(oCriteria);
        }
        public static SearchDataSubset SearchListingsByCriteria(SearchCriteria toCriteria) {
            SearchRequest oSearch = SearchManager.Instance.GetNewSearchRequest();
            oSearch.Criteria = toCriteria;
            SearchDataSubset oReturn = oSearch.Search();
            oSearch.Criteria.LastSearchedDate = DateTime.UtcNow;  // reset the date
            oSearch.Criteria.NewListingsSinceLastSearchDate = 0;  // reset the number of new listings that have enetered the system since the last tiume the search was run.
            oSearch.Criteria.Save();
            return oReturn;
        }
        #endregion (Search)

        #region ListingViewStatsCardDTO
        //public static BaseResponse GetListingViewStatsCardDTOsByEntityOid(Int64 tiEntityOid) {
        //    BaseResponse oReturn = new BaseResponse();
        //    List<ListingViewStatsCardDTO> oDTO = new List<ListingViewStatsCardDTO>();

        //    try {
        //        oDTO = Base.Database.GetInstance().Fetch<ListingViewStatsCardDTO>(SqlConstants.GET_LISTING_VIEW_STATS_CARD_DTO + " WHERE wls.EntityOid = @0", tiEntityOid);
        //        oReturn.Data = oDTO;
                
        //    } catch (Exception ex) {
        //        oReturn.LoadException(ex);
        //    }
        //    return oReturn;
        //}

        #endregion (ListingViewStatsCardDTO)

        #region ZipCode
        //*********************** 
        public static ZipCode VerifyZipCode(string tsZipCode) {
            ZipCode oReturn = null;
            try {
                ZipCode oCode = SQL.GetZipCodeByZip(tsZipCode, false);
                if (oCode != null) {
                    oReturn = oCode;
                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return oReturn;
        }
        #endregion (ZipCode)

        #region SearchCriteriaDisplay
        public static List<SearchCriteriaDisplay> GetSearchCriteriaDisplayListByEntityOid(Int64 tiEntityOid) {
            List<SearchCriteriaDisplay> oDisplay = new List<SearchCriteriaDisplay>();

            List<SearchCriteria> oCriteria = SQL.GetSearchCriteriaListByEntityOid(tiEntityOid);
            if (oCriteria.Count > 0) {
                oDisplay = SearchCriteria.ConvertSearchCriteriaListToDisplayList(oCriteria);
            }
            return oDisplay;
        }

        public static List<SearchCriteriaDisplay> GetMySavedSearches() {
            List<SearchCriteriaDisplay> oDisplay = new List<SearchCriteriaDisplay>();

            List<SearchCriteria> oCriteria = SQL.GetActiveSearchCriteriaListByEntityOid(SessionMgr.Instance.User.EntityOid);
            if (oCriteria.Count > 0) {
                oDisplay = SearchCriteria.ConvertSearchCriteriaListToDisplayList(oCriteria);
            }
            return oDisplay;
        }
        #endregion (SearchCriteriaDisplay)

    }
}
