using System.Collections.Generic;
using Twilio.Jwt;
using Twilio.Jwt.Client;
using Microsoft.Extensions.Configuration;

namespace TwilioVoice.Domain.Twilio
{
    public class Capability
    {
        #region Variables
        private readonly IConfiguration _configuration;
        #endregion

        #region Constructor
        public Capability(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        #endregion

        #region Methods
        //Generate Token
        public string Generate(string role)
        {
            var scopes = new HashSet<IScope>
            {
                new IncomingClientScope(role),
                new OutgoingClientScope(_configuration.GetSection("TwiMLApplicationSid").Value)
            };
            var capability = new ClientCapability(_configuration.GetSection("TwilioAccountSid").Value,
                                                  _configuration.GetSection("TwilioAuthToken").Value,
                                                  scopes: scopes);

            return capability.ToJwt();
        }
        #endregion
    }
}