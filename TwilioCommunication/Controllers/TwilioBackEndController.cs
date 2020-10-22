using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Twilio.Jwt;
using Twilio.Jwt.Client;
using Twilio.TwiML;
using Twilio.Types;

namespace Voice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TwilioBackEndController : ControllerBase
    {
        public readonly string AccountSid = "AC98412f8c26b4111d7ef5285223996d89";
        public readonly string AuthToken = "bdd4ef7699fc6d853b319439d8ef3a26";
        public readonly string AppSid = "AP18bf72b4ad2baa77978480553ed9a7b1";
        public readonly string PhoneNumber = "+12095957845";

        [HttpGet]
        public IActionResult Status()
        {
            return Ok("API is up and running");
        }

        [HttpGet("token")]
        public async Task<IActionResult> GetToken()
        {
            var scopes = new HashSet<IScope>
            {
                new OutgoingClientScope(AppSid),
                new IncomingClientScope("tester")
            };

            var capability = new ClientCapability(AccountSid, AuthToken, scopes: scopes);
            return await Task.FromResult(Content(capability.ToJwt(), "application/jwt"));
        }

        [HttpPost("voice")]
        public async Task<IActionResult> PostVoiceRequest([FromForm] string phone)
        {
            var destination = !phone.StartsWith('+') ? $"+{phone}" : phone;

            var response = new VoiceResponse();
            var dial = new Twilio.TwiML.Voice.Dial
            {
                CallerId = PhoneNumber
            };
            dial.Number(new PhoneNumber(destination));

            response.Append(dial);

            return await Task.FromResult(Content(response.ToString(), "application/xml"));
        }
    }
}
