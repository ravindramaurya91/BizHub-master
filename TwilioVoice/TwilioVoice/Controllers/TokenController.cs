using Microsoft.AspNetCore.Mvc;
using System;
using TwilioVoice.Domain.Twilio;

namespace TwilioVoice.Controllers
{
    public class TokenController : Controller
    {
        #region Fields
        private readonly Capability _capability;
        #endregion (Fields)

        #region Constructor
        public TokenController(Capability capability)
        {
            _capability = capability;
        }
        #endregion

        #region Methods
        // GET: Token/Generate
        public JsonResult Generate(string page)
        {
            var token = _capability.Generate(InferRole(page));
            return Json(new {token});
        }

        private static string InferRole(string page)
        {
            return page.Equals("/Dashboard", StringComparison.InvariantCultureIgnoreCase)
                ? "support_agent" : "customer";
        }
        #endregion
    }
}
