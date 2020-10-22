using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using Model;

namespace BizHub.Areas.Identity {
    public class BizHubUserManager : UserManager<BizHubUser> {
        public BizHubUserManager(IUserStore<BizHubUser> store, IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<BizHubUser> passwordHasher, IEnumerable<IUserValidator<BizHubUser>> userValidators,
            IEnumerable<IPasswordValidator<BizHubUser>> passwordValidators, ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<BizHubUser>> logger) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger) {

        }

        public override async Task<IdentityResult> CreateAsync(BizHubUser toUser) {

            if (toUser.UserName.Contains("If there are unacceptable User details we can check them here")) {
                return IdentityResult.Failed(new IdentityError { Description = "User names must contain the string 'allowed'" });
            }
            Entity oNewEntity = Entity.CreateDefaultEntity();

            oNewEntity.EntityOid_Master = Constants.BIZHUB_SYSTEM_ENTITY_OID;
            oNewEntity.Email = toUser.Email;
            oNewEntity.FirstName = toUser.FirstName;
            oNewEntity.LastName = toUser.LastName;
            oNewEntity.DisplayName = oNewEntity.FirstName + " " + oNewEntity.LastName;
            oNewEntity.CreatedBy = oNewEntity.Email;

            oNewEntity.Save();

            oNewEntity.EntityOid_Master = oNewEntity.Oid;
            oNewEntity.EntityOid_Region = oNewEntity.Oid;
            oNewEntity.EntityOid_Office = oNewEntity.Oid;

            oNewEntity.Save();

            //Complete user identity extended data assignmemnt

            toUser.EntityOid = oNewEntity.Oid;
            toUser.EntityOid_Master = oNewEntity.EntityOid_Master;
            // TODO : toUser.EntityOid_Region = oNewEntity.EntityOid_Region;
            // TODO : toUser.EntityOid_Office = oNewEntity.EntityOid_Office;
            toUser.DisplayName = oNewEntity.DisplayName;
            toUser.lkpStateOid = (oNewEntity.lkpStateOid !=null) ? (Int64)oNewEntity.lkpStateOid: 0 ;

            // Added Custom Claims for extended data in BizHubUserClaimsPrincipalFactory.CreateAsync()
            //AddClaim(new Claim("EntityOid", this.EntityOid.ToString()));
            //.AddClaim(new Claim("EntityOid_Master", this.EntityOid_Master.ToString()));
            //.AddClaim(new Claim("lkpStateOid", this.lkpStateOid.ToString()));

            return await base.CreateAsync(toUser);
        }

        public static T GetLoggedInUserId<T>(ClaimsPrincipal principal) {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            var loggedInUserId = principal.FindFirstValue(ClaimTypes.NameIdentifier);

            if (typeof(T) == typeof(string)) {
                return (T)Convert.ChangeType(loggedInUserId, typeof(T));
            } else if (typeof(T) == typeof(int) || typeof(T) == typeof(long)) {
                return loggedInUserId != null ? (T)Convert.ChangeType(loggedInUserId, typeof(T)) : (T)Convert.ChangeType(0, typeof(T));
            } else {
                throw new Exception("Invalid type provided");
            }
        }

        public static string GetLoggedInUserName(ClaimsPrincipal principal) {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            return principal.FindFirstValue(ClaimTypes.Name);
        }

        public static string GetLoggedInUserEmail(ClaimsPrincipal principal) {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            return principal.FindFirstValue(ClaimTypes.Email);
        }
        //public static string GetLoggedInUserEntityOid(ClaimsPrincipal principal) {
        //    if (principal == null)
        //        throw new ArgumentNullException(nameof(principal));

        //    return principal.FindFirstValue(ClaimTypes.EntityOid);
        //}
    }

}

