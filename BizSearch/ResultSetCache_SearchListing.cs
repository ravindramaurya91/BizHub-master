using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading;

using Base;
using CommonUtil;
using Microsoft.Extensions.Configuration;
using Model;
using PetaPoco;

namespace BizSearch {
    public class ResultSetCache_SearchListing : IResultSetCache {
        private static volatile ResultSetCache_SearchListing _instance = null;
        private static object _syncRoot = new Object(); //for multi thread protection
        private ResultSetCache _cache;

        #region Constructor 
        static ResultSetCache_SearchListing() {
        }
        public void On_CacheStartup() {
            // This method is fired on first loading of the Cache .
            // Place any actions here you want to initialize the object
            _cache = ResultSetCache.Instance;
        }
        #endregion (Constructor)

        #region Interface Pass Throughs
        public ResultSet AddNewResultSet(long tiEntityOid, int tiResultSetType, IList toData) { return _cache.AddNewResultSet(tiEntityOid, tiResultSetType, toData); }
        public ResultSet AddNewResultSet(long tiEntityOid, int tiResultSetType, IList toData, int tiItemsPerPage) { return _cache.AddNewResultSet(tiEntityOid, tiResultSetType, toData, tiItemsPerPage); }
        public void RemoveResultSet(int tiResultSetId) { _cache.RemoveResultSet(tiResultSetId); }
        public void SetItemsPerPage(int tiResultSetId, int tiItemsPerPage) {_cache.SetItemsPerPage(tiResultSetId, tiItemsPerPage);}
        #endregion (Interface Pass Throughs)

        public List<object> GetPage(int tiResultSetId, int tiPageNumber, out Int64 tiEntityOid) {
            tiEntityOid = -1;
            List<object> oReturn = _cache.GetPage(tiResultSetId, tiPageNumber, out tiEntityOid);

            // EveryTime a User makes a call to the GetPage method we will 
            // Start a background thread to increment the View Count on each 
            // Listing return in the page
            // 
            // NOTE: You cannot pass a parameter that is tied up in an "out" to another thread.
            // We will capture the tiEntityOid parameter into a variable for passing
            Int64 iEntityOid = tiEntityOid;
            //Thread oThread = new Thread(() => UpdateViewCount(iEntityOid, oReturn)) { };
            //oThread.Start();
            UpdateViewCount(iEntityOid, oReturn);
            return oReturn;
        }
        
        public void UpdateViewCount(Int64 tiEntityOid, List<object> toList) {
            IConfiguration oConfig = CommonUtil.ContainerAccess.Get<IConfiguration>();
            bool bServiceHubIsOn = oConfig.GetValue<string>("RunTimeParameters:ServiceHub").ToUpper().Equals("ON");
            bool bProcessDirectlyToTheDB = !bServiceHubIsOn;
            if (bServiceHubIsOn) {
                try {
                    TransmitViewCountsToServiceHubForProcessing(tiEntityOid, toList);
                } catch (Exception ex) {
                    // logg the error - then process the data directly to the DB
                    bProcessDirectlyToTheDB = true;
                }
            }

            if (bProcessDirectlyToTheDB) { 
                foreach (object oListing in toList) {
                    // Pass the Listing on and cast it from object to SearchListing
                    ListingStatCapture.UpdateListingStatViewCount(tiEntityOid, (SearchListing)oListing);
                }
            }
        }
        private async void TransmitViewCountsToServiceHubForProcessing(Int64 tiEntityOid, List<object> toList) {
                
            QueableMessage oMsg = new QueableMessage(Constants.QUE_MESSAGE_TYPE_VIEW, toList, "Entity", tiEntityOid);
            SessionMgr.Instance.PostToServiceHub(oMsg);

            //string json = await oMsg.ToJsonAsync();
            //var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            //IHttpClientFactory oHttpClientFactory = CommonUtil.ContainerAccess.Get<IHttpClientFactory>();
            //HttpClient oServiceHubClient = oHttpClientFactory.CreateClient("ServiceHub");

            //HttpResponseMessage oResponse = await oServiceHubClient.PostAsync("queue/PublishToQueue", httpContent);
            //oResponse.EnsureSuccessStatusCode();
            //string oResponseBody = await oResponse.Content.ReadAsStringAsync();
            //Debug.WriteLine(oResponseBody);

        }

        
        #region Properties
        public static ResultSetCache_SearchListing Instance {
            get {
                if (_instance == null) {
                    lock (_syncRoot) {

                        _instance = new ResultSetCache_SearchListing();
                        _instance.On_CacheStartup();
                    }
                }
                return _instance;
            }
        }
        public int ItemsPerPage {
            get { return _cache.ItemsPerPage; }
            set { _cache.ItemsPerPage = value; }
        }

        #endregion (Properties)
    }
}


