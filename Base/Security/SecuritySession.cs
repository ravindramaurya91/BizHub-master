using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Base.Security
{
    public class SecuritySession
    {

        private IHttpContextAccessor httpContextAccessor;
        private object cachedUserData; // cached is scoped to the request

        public SecuritySession(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public static T GetSessionData<T>()
        {
            var session = Context.Get<SecuritySession>();
            return session.GetCachedUserData<T>();
        }

        protected virtual T GetCachedUserData<T>()
        {

            if (cachedUserData == null)
            {
                var user = httpContextAccessor.HttpContext.User;
                if (user == null) return default(T);

                var claims = user.Claims;
                if (claims == null) return default(T);

                Claim userDataClaim = null;

                foreach (var claim in claims)
                {
                    if (claim.Type.Equals(LoginService.USER_DATA_JSON_KEY))
                    {
                        userDataClaim = claim;
                    }
                }

                cachedUserData = JsonConvert.DeserializeObject<T>(userDataClaim.Value);
            }

            return (T) cachedUserData;
        }

    }
}
