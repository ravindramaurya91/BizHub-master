using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Twilio.AspNet.Common;
using Twilio.AspNet.Core;
using Twilio.TwiML;

using Model;
using Model.Interfaces;
using Microsoft.AspNetCore.Http;

namespace ServiceHub.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class TwilioAccessController : TwilioController {

        #region Fields
        private ITwilioSMSRepository _twilioSMSRepository;
        #endregion (Fields)

        #region Constructor
        public TwilioAccessController(ITwilioSMSRepository twilioSMSRepository) {
            _twilioSMSRepository = twilioSMSRepository;
        }
        #endregion

        #region Methods
        [HttpPost]
        public void Index() {
            // Receive Incoming SMS through Webhook
            var requestBody = Request.Form["Body"];
            var requestfrom = Request.Form["From"];
        }

        #region SMS
        // Question: What is the purpose of this Get?
        [HttpGet]
        public IEnumerable<string> Get() {
            return new string[] { "TwilioSMS", "TwilioChat" };
        }

        // Question: What is the purpose of this Get?
        // GET api/<TwilioSMSController>/5
        [HttpGet("{id}")]
        public string Get(int id) {
            return "TwilioSMS" + id;
        }

        // Question: What is the purpose of this Post?
        // POST api/<TwilioSMSController>
        // Send SMS
        [HttpPost("SMSPostMessage")]
        public void SMSPostMessage([FromBody] SMSMessage toMessage) {
            _twilioSMSRepository.TwilioSMSCreate(toMessage);
        }

        #endregion (SMS)

        [HttpPost("SMSMessageRecievedCallBack")]
        public void SMSMessageRecievedCallBack([FromBody] HttpRequest toRequest) {
            var requestBody = toRequest.Form["Body"];
            var requestfrom = toRequest.Form["From"];
        }

        [HttpPost("SMSStatusResponse")]
        public void SMSStatusResponse([FromBody] HttpRequest toRequest) {
            // Receive SMS Status (queued, sent, delivered) through webhook
            SMSMessage smsmodel = new SMSMessage();
            smsmodel.MessageSid = toRequest.Form["SmsSid"];
            smsmodel.Status = toRequest.Form["MessageStatus"];
            _twilioSMSRepository.UpdateSMS(smsmodel);
        }

        #endregion (Methods)
    }
}
