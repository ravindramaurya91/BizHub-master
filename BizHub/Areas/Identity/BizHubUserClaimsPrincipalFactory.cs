using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Model;
using Model;

namespace BizHub.Areas.Identity {
    public class BizHubUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<BizHubUser> {
        public BizHubUserClaimsPrincipalFactory(
            UserManager<BizHubUser> userManager,
            IOptions<IdentityOptions> optionsAccessor)
                : base(userManager, optionsAccessor) {
        }

        // STEVEN TODO This is where we create the extended Claims when creating a new User
        public async override Task<ClaimsPrincipal> CreateAsync(BizHubUser user) {
            ClaimsPrincipal oClaimsPrincipal = await base.CreateAsync(user);
            if (!string.IsNullOrWhiteSpace(user.FirstName)) {
                ((ClaimsIdentity)oClaimsPrincipal.Identity).AddClaims(new[] {new Claim("FirstName", user.FirstName)});
            }
            if (!string.IsNullOrWhiteSpace(user.LastName)) {
                ((ClaimsIdentity)oClaimsPrincipal.Identity).AddClaims(new[] { new Claim("LastName", user.LastName)});
            }
            if (!string.IsNullOrWhiteSpace(user.DisplayName)) {
                ((ClaimsIdentity)oClaimsPrincipal.Identity).AddClaims(new[] { new Claim("DisplayName", user.DisplayName)});
            }
            ((ClaimsIdentity)oClaimsPrincipal.Identity).AddClaims(new[] { new Claim("EntityOid", user.EntityOid.ToString()) });
            ((ClaimsIdentity)oClaimsPrincipal.Identity).AddClaims(new[] { new Claim("EntityOid_Master", user.EntityOid_Master.ToString())});
            ((ClaimsIdentity)oClaimsPrincipal.Identity).AddClaims(new[] { new Claim("EntityOid_Region", user.EntityOid_Region.ToString())});
            ((ClaimsIdentity)oClaimsPrincipal.Identity).AddClaims(new[] { new Claim("EntityOid_Office", user.EntityOid_Office.ToString())});
            ((ClaimsIdentity)oClaimsPrincipal.Identity).AddClaims(new[] { new Claim("lkpStateOid", user.lkpStateOid.ToString())});
            return oClaimsPrincipal;
        }
    }
}