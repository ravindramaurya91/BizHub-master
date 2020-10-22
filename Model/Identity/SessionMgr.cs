using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Threading.Tasks;
using System.Net.Http;

using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

using CommonUtil;
using System.ComponentModel;

namespace Model {
    public class SessionMgr {

        #region EventHandlers
        public event EventHandler OnMessageQueued;
        #endregion (EventHandlers)

        #region Fields
        private static volatile SessionMgr _session = null;
        private BizHubUser _user = null;
        private MessageHubClient _messageHubClient = null;
        private List<Int64> _favoritedListingOids = new List<long>();
        private IHttpContextAccessor _httpContextAccessor;
        private IConfiguration _configuration = null;
        private bool _serviceHubIsOn = false;
        #endregion (Fields)

        #region Constructor
        public SessionMgr() {
        }

        public SessionMgr(IHttpContextAccessor httpContextAccessor, IConfiguration toConfig) {
            _session = this;
            _user = new BizHubUser();

            if( toConfig != null) {
                _configuration = toConfig;
                _serviceHubIsOn = _configuration.GetValue<string>("RunTimeParameters:ServiceHub").ToUpper().Equals("ON");
            }

            if (_httpContextAccessor != null) {
                _user.DisplayName = _httpContextAccessor.HttpContext.User.Identity.DisplayName();
                _user.FirstName = _httpContextAccessor.HttpContext.User.Identity.FirstName();
                _user.EntityOid = Convert.ToInt64(_httpContextAccessor.HttpContext.User.Identity.EntityOid());
                _user.EntityOid_Master = Convert.ToInt64(_httpContextAccessor.HttpContext.User.Identity.EntityOid_Master());
                _user.LastName = _httpContextAccessor.HttpContext.User.Identity.LastName();
                _user.Zip = _httpContextAccessor.HttpContext.User.Identity.Zip();
                _user.Email = _httpContextAccessor.HttpContext.User.Identity.Email();
            }

            LoadUserData();
        }

        #endregion (Constructor)

        #region Methods
        private void LoadUserData() {
            if ((User != null) && (User.EntityOid != null) && (User.EntityOid > 0)){
                Entity oEntity = SQL.GetEntityByOid(User.EntityOid);
                if(oEntity != null) {
                    User.EntityOid_Master = oEntity.EntityOid_Master;


                    if (oEntity.EntityOid_Office != null) {
                        User.EntityOid_Office = (long)oEntity.EntityOid_Office;
                    }


                }
                UpdateFavoritedListings();
            }
        }
        
        private void LoadMessageHubClient() {
            _messageHubClient = new MessageHubClient();
        }

        public async void UpdateFavoritedListings() {
            if (_user == null) {
                _favoritedListingOids.Clear();
            } else {
                string sSql = @"SELECT map.ListingOid , MAP.*
                    FROM Entity2ListingMap_Stat map
	                INNER JOIN Listing ON Listing.Oid = map.ListingOid
	                WHERE map.EntityOid = @0 AND map.IsFavorite = 1 AND Listing.IsActive = 1 ";
                _favoritedListingOids = Base.Database.GetInstance().Fetch<Int64>(sSql, _user.EntityOid);
            }
        }

        #region Queue
        public async Task PostToServiceHub(QueableMessage oMsg) {
            // QueableMessage oMsg = (QueableMessage)_queue.Dequeue();
            if (_configuration == null) {
                _configuration = ContainerAccess.Get<IConfiguration>();
                _serviceHubIsOn = _configuration.GetValue<string>("RunTimeParameters:ServiceHub").ToUpper().Equals("ON");
            }

            if (oMsg != null && _serviceHubIsOn) {
                SendToServiceHub(oMsg);
            }
        }

        private static void SendToServiceHub(QueableMessage toMsg) {
            BackgroundWorker oWorker = new BackgroundWorker();
            oWorker.DoWork += ServiceHubThread_DoWork;
            oWorker.RunWorkerAsync(toMsg);
        }

        private static void ServiceHubThread_DoWork(object sender, DoWorkEventArgs e) {
            try {
                QueableMessage oMsg = (QueableMessage)e.Argument;
                string json = oMsg.ToJson();
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                IHttpClientFactory oHttpClientFactory = CommonUtil.ContainerAccess.Get<IHttpClientFactory>();

                HttpClient oServiceHubClient = oHttpClientFactory.CreateClient("ServiceHub");

                HttpResponseMessage oResponse = oServiceHubClient.PostAsync("queue/PublishToQueue", httpContent).Result;
                oResponse.EnsureSuccessStatusCode();
                string oResponseBody = oResponse.Content.ReadAsStringAsync().Result;
                Debug.WriteLine(oResponseBody);
                oServiceHubClient.Dispose();
                e.Result = "OK";
            } catch (Exception ex) {
                throw new Exception("An error has occured when trying to send the Search request to the ServiceHub Queue.");
            }
        }
        #endregion (Events)

        #endregion (Methods)

        #region Properties
        public static SessionMgr Instance {
            get {
                if (_session == null) {
                    _session = new SessionMgr();
                    _session.User = new BizHubUser();
                }
                return _session;
            }
        }
        public BizHubUser User {
            get {
                return _user;
            }
            set { 
                if(_user != value)
                _user = value;
                LoadUserData();
            }
        }

        private MessageHubClient MessageHubClient {
            get {
                if (_messageHubClient == null) {
                    LoadMessageHubClient();
                }
                return _messageHubClient;
            }
        }
         
        public bool ServiceHubIsOn { get => _serviceHubIsOn; }
        public List<Int64> FavoritedListingOids { get => _favoritedListingOids; }
        #endregion (Properties)

    }

    
}

