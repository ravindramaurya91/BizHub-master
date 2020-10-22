using System;
using System.Text;
using System.Collections.Generic;
using System.Web.Http.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Twilio.Jwt;
using Twilio.Jwt.Client;


namespace CommonUtil {
    public class TokenGenerator {

        #region Fields
        private readonly IConfiguration _configuration;
        #endregion (Fields)


        #region Constructor
        public TokenGenerator() {
            
        }
        #endregion (Constructor)

        #region Methods
        //public JsonResult Generate(string page) {
        //    var token = _capability.Generate(InferRole(page));
        //    return Json(new { token });
        //}

        //private static string InferRole(string page) {
        //    return page.Equals("/Dashboard", StringComparison.InvariantCultureIgnoreCase)
        //        ? "support_agent" : "customer";
        //}

        //Generate Token
        public static string GenerateTwilioToken(string role) {
            // Role is passed in:  Values can be "support_agent" or "customer"
            IConfiguration oConfiguration = ContainerAccess.Get<IConfiguration>();

            var scopes = new HashSet<IScope>
            {
                new IncomingClientScope(role),
                new OutgoingClientScope(oConfiguration.GetSection("TwiMLApplicationSid").Value)
            };

            var capability = new ClientCapability(oConfiguration.GetSection("TwilioAccountSid").Value,
                                                  oConfiguration.GetSection("TwilioAuthToken").Value,
                                                  scopes: scopes);
            var oReturn = capability.ToJwt();
            //var s = Microsoft.AspNetCore.Mvc.Json(new { oReturn });
            return oReturn;
        }
        #endregion

    }
}
