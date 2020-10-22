using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace Model {
    public class BizHubUser : IdentityUser, IFSUser {
        #region Fields
        private readonly IHttpContextAccessor _httpContextAccessor;
        private Int64 _entityOid = -1;
        private Int64 _entityOid_Master = -1;
        private Int64 _entityOid_Region = -1;
        private Int64 _entityOid_Office = -1;
        private string _displayName = "";
        private string _firstName = "";
        private string _lastName = "";
        private string _zip = "";
        private string _country = "United States";
        private Int64 _lkpStateOid = -1;
        #endregion (Fields)

        // This constructor breaks with the following message:
        /* InvalidOperationException: No suitable constructor found for entity type 'BizHubUser'. 
         * The following constructors had parameters that could not be bound to properties of the entity type: 
         * cannot bind 'httpContextAccessor' in 'BizHubUser(IHttpContextAccessor httpContextAccessor)'.  */

        public BizHubUser(IHttpContextAccessor httpContextAccessor, SessionMgr toSessionManager) {
            _httpContextAccessor = httpContextAccessor;
            if (_httpContextAccessor.HttpContext.User.Claims.Count() > 0) {
                DisplayName = _httpContextAccessor.HttpContext.User.Identity.DisplayName();
                FirstName = _httpContextAccessor.HttpContext.User.Identity.FirstName();
                EntityOid = Convert.ToInt64(_httpContextAccessor.HttpContext.User.Identity.EntityOid());
                EntityOid_Master = Convert.ToInt64(_httpContextAccessor.HttpContext.User.Identity.EntityOid_Master());
                LastName = _httpContextAccessor.HttpContext.User.Identity.LastName();
                lkpStateOid = Convert.ToInt64(_httpContextAccessor.HttpContext.User.Identity.lkpStateOid());
                Zip = _httpContextAccessor.HttpContext.User.Identity.Zip();
                Email = _httpContextAccessor.HttpContext.User.Identity.Email();
                Avatar = _httpContextAccessor.HttpContext.User.Identity.Avatar();
                toSessionManager.User = this;
            }
        }

        public BizHubUser() {
            _httpContextAccessor = CommonUtil.ContainerAccess.Get<IHttpContextAccessor>();

            if ((_httpContextAccessor != null) &&
                (_httpContextAccessor.HttpContext != null) &&
                (_httpContextAccessor.HttpContext.User.Claims.Count() > 0)) {
                DisplayName = _httpContextAccessor.HttpContext.User.Identity.DisplayName();
                FirstName = _httpContextAccessor.HttpContext.User.Identity.FirstName();
                EntityOid = Convert.ToInt64(_httpContextAccessor.HttpContext.User.Identity.EntityOid());
                EntityOid_Master = Convert.ToInt64(_httpContextAccessor.HttpContext.User.Identity.EntityOid_Master());
                LastName = _httpContextAccessor.HttpContext.User.Identity.LastName();
                lkpStateOid = Convert.ToInt64(_httpContextAccessor.HttpContext.User.Identity.lkpStateOid());
                Zip = _httpContextAccessor.HttpContext.User.Identity.Zip();
                Email = _httpContextAccessor.HttpContext.User.Identity.Email();
                Avatar = _httpContextAccessor.HttpContext.User.Identity.Avatar();
            } else {
                EntityOid = 8;
                EntityOid_Master = 1;
                DisplayName = "Test User";
                Email = "t@test";
                Zip = "95356";
                lkpStateOid = 32221;
                Avatar = Constants.DEFAULT_UNKNOWN_INDIVIDUAL_AVATAR;
            }
            SessionMgr.Instance.User = this;
        }

        //public static Int64 GetEntityOid(IIdentity identity) {
        //    Int64 iReturn = -1;
        //    var claim = ((ClaimsIdentity)identity).FindFirst("EntityOid");
        //    // Test for null to avoid issues during local testing
        //    string sClaimValue = (claim != null) ? claim.Value : string.Empty;
        //    if (!String.IsNullOrEmpty(sClaimValue)) {
        //        iReturn = Convert.ToInt64(sClaimValue);
        //    }
        //    return iReturn;
        //}

        //public static Int64 GetEntityOid_Master(IIdentity identity) {
        //    Int64 iReturn = -1;
        //    var claim = ((ClaimsIdentity)identity).FindFirst("EntityOid_Master");
        //    // Test for null to avoid issues during local testing
        //    string sClaimValue = (claim != null) ? claim.Value : string.Empty;
        //    if (!String.IsNullOrEmpty(sClaimValue)) {
        //        iReturn = Convert.ToInt64(sClaimValue);
        //    }
        //    return iReturn;
        //}

        //public static string GetDisplayName(IIdentity identity) {
        //    var claim = ((ClaimsIdentity)identity).FindFirst("DisplayName");
        //    // Test for null to avoid issues during local testing
        //    return (claim != null) ? claim.Value : string.Empty;
        //}
        //public static string GetZip(IIdentity identity) {
        //    var claim = ((ClaimsIdentity)identity).FindFirst("Zip");
        //    // Test for null to avoid issues during local testing
        //    return (claim != null) ? claim.Value : string.Empty;
        //}

        public void LoadAvatar() {
            Entity oEntity = SQL.GetEntityByOid(this.EntityOid, false);
            if (oEntity != null) {
                Avatar = oEntity.Avatar;
            }
        }

        #region Properties
        public Int64 EntityOid { get => _entityOid; set => _entityOid = value; }
        public Int64 EntityOid_Master { get => _entityOid_Master; set => _entityOid_Master = value; }
        public Int64 EntityOid_Region { get => _entityOid_Region; set => _entityOid_Region = value;}
        public Int64 EntityOid_Office { get => _entityOid_Office; set => _entityOid_Office = value;}
        // Properties marked with the [PersonalData] attribute are automatically included in the download when a User 
        // requests to download their personal data and automatically deleted when they request to delete the same.
        [PersonalData] public string DisplayName { get => _displayName; set => _displayName = value; }
        [PersonalData] public string FirstName { get => _firstName; set => _firstName = value; }
        [PersonalData] public string LastName { get => _lastName; set => _lastName = value; }
        [PersonalData]
        public string Zip {
            get {
                if (string.IsNullOrEmpty(_zip)) {
                    if ((_httpContextAccessor != null) &&
                       (_httpContextAccessor.HttpContext != null) &&
                       (_httpContextAccessor.HttpContext.User.Claims.Count() > 0)) {
                          _zip = _httpContextAccessor.HttpContext.User.Identity.Zip();
                    }
                }
                return _zip;
            }
            set { _zip = value; }
        }
        [PersonalData] public string Country { get => _country; set => _country = value; }
        [PersonalData] public Int64 lkpStateOid { get => _lkpStateOid; set => _lkpStateOid = value; }
        [PersonalData] public string Avatar { get; set; }
        #endregion (Properties)
    }
}
