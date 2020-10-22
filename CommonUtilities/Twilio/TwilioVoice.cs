using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Twilio.Jwt;
using Twilio.Jwt.Client;
using Twilio.Rest.Verify.V2.Service;

namespace CommonUtil {
    public class TwilioVoice {

        #region Fields
        private string _tokenUrl = "https://twiliocommunication.conveyor.cloud/api/twiliobackend/token";
        protected IJSRuntime _jsRuntime { get; set; }

        public readonly string AccountSid = "AC98412f8c26b4111d7ef5285223996d89";
        public readonly string AuthToken = "bdd4ef7699fc6d853b319439d8ef3a26";
        public readonly string AppSid = "AP18bf72b4ad2baa77978480553ed9a7b1";
        public readonly string PhoneNumber = "+12095957845";

        #endregion (Fields)

        public TwilioVoice(IJSRuntime toJsRunTime) {
            _jsRuntime = toJsRunTime;
            var token = GetToken().Result;
            Initialize(token).GetAwaiter();
        }
        public async Task Initialize(string tsToken) {
            await _jsRuntime.InvokeVoidAsync("Twilio.Device.setup", tsToken);
        }
        public async Task InitiatePhoneCall(string tsPhoneNumber) {
            await _jsRuntime.InvokeVoidAsync("Twilio.Device.connect", new IM { phone = tsPhoneNumber });
        }
        public async Task EndPhoneCall() {
            await _jsRuntime.InvokeVoidAsync("Twilio.Device.disconnectAll");
        }

        private async Task<string> GetClientToken() {
            string sReturn = "Unsuccessful Connection to Twilio.";
            try {
                // Role Values can be "support_agent" or "customer"
                string sRole = "support_agent";
                string sToken = TokenGenerator.GenerateTwilioToken(sRole);
                return sToken;
                var uri = new Uri(_tokenUrl);
                IHttpClientFactory oHttpClientFactory = CommonUtil.ContainerAccess.Get<IHttpClientFactory>();
                HttpClient oClient = oHttpClientFactory.CreateClient();
                var response = await oClient.GetAsync(uri);
                response.EnsureSuccessStatusCode();
                sReturn = await response.Content.ReadAsStringAsync();
            } catch(Exception ex){
                throw ex;
            }
            return sReturn;
        }

        //Generate Token
        public async Task<string> GetToken()
        {
            var scopes = new HashSet<IScope>
            {
                new OutgoingClientScope(AppSid),
                new IncomingClientScope("UserName")
            };
            var capability = new ClientCapability(AccountSid, AuthToken, scopes: scopes);
            return await Task.FromResult(capability.ToJwt());
        }

        #region Properties

        #endregion (Properties)

    }

    public class IM {
        public string phone { get; set; }
    }
}
