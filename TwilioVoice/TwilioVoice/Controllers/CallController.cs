using TwilioVoice.Domain.Twilio;
using Twilio.TwiML;
using Twilio.TwiML.Voice;
using Microsoft.Extensions.Configuration;
using Twilio.AspNet.Core;
using Microsoft.AspNetCore.Mvc;

namespace TwilioVoice.Controllers
{
    public class CallController : TwilioController
    {
        #region Fields
        private readonly IConfiguration _configuration;
        #endregion (Fields)
        //public CallController() : this(new Credentials()) {}

        #region Constructor
        public CallController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        #endregion


        #region Methods
        // POST Call/Connect
        [HttpPost]
        public TwiMLResult Connect(string phoneNumber)
        {
            var response = new VoiceResponse();

            var dial = new Dial(callerId: _configuration.GetSection("TwilioPhoneNumber").Value);
            if (phoneNumber != null)
            {
                dial.Number(phoneNumber);
            }
            else
            {
                dial.Client("support_agent");
            }
            response.Append(dial);

            return TwiML(response);
        }
        #endregion
    }
}
