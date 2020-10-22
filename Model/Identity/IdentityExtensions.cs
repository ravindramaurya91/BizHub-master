using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Security.Principal;

namespace Model {
    public static class IdentityExtensions {

        #region Extended Identity Properties
        public static string FirstName(this IIdentity identity) {
            var claim = ((ClaimsIdentity)identity).FindFirst("FirstName");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }

        public static string LastName(this IIdentity identity) {
            var claim = ((ClaimsIdentity)identity).FindFirst("LastName");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }
        public static string DisplayName(this IIdentity identity) {
            var claim = ((ClaimsIdentity)identity).FindFirst("DisplayName");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }

        public static string Zip(this IIdentity identity) {
            var claim = ((ClaimsIdentity)identity).FindFirst("Zip");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }

        public static string Email(this IIdentity identity) {
            var claim = ((ClaimsIdentity)identity).FindFirst("Email");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }

        public static string EntityOid(this IIdentity identity) {
            var claim = ((ClaimsIdentity)identity).FindFirst("EntityOid");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }
        public static string EntityOid_Master(this IIdentity identity) {
            var claim = ((ClaimsIdentity)identity).FindFirst("EntityOid_Master");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }
        public static string Country(this IIdentity identity) {
            var claim = ((ClaimsIdentity)identity).FindFirst(ClaimTypes.Country);
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }
        public static string lkpStateOid(this IIdentity identity) {
            var claim = ((ClaimsIdentity)identity).FindFirst("lkpStateOid");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }
        public static string Avatar(this IIdentity identity) {
            var claim = ((ClaimsIdentity)identity).FindFirst("Avatar");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }

        // STEVEN TODO This is where we add a method to search the claims by Name and return the associated value
        // We do not have a method for EntityOid_Region of Office since we are trying to keep them oput of the MS scheme

        #endregion (Extended Identity Properties)
    }
}
