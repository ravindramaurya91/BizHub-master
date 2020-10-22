using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Text;
using Twilio.Jwt.AccessToken;
using Microsoft.Extensions.Configuration;

using Base;

namespace TwilioGateway {

    public class TokenGenerator : ITokenGenerator {

        #region Fields
        private IConfiguration _configuration;
        #endregion (Fields)

        public TokenGenerator(IConfiguration config) {
            _configuration = config;
        }
        public string Generate(string identity) {
            var config = Context.Get<IConfiguration>();
            var section = config.GetSection("TwilioSetup");
            var ServiceSID = section.GetValue<string>("ChatServiceSID");
            var AccountSID = section.GetValue<string>("AccountSID");
            var ApiKey = section.GetValue<string>("ApiKey");
            var ApiSecret = section.GetValue<string>("ApiSecret");

            var grants = new HashSet<IGrant>
            {
                new ChatGrant {ServiceSid = ServiceSID}
            };

            var token = new Token(
                AccountSID,
                ApiKey,
                ApiSecret,
                identity,
                grants: grants);

            return token.ToJwt();
        }
    }
}
