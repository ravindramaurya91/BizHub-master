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

namespace BizHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageStatusController : TwilioController
    {
        #region Variables
        private ITwilioSMSRepository _twilioSMSRepository;
        #endregion

        #region Constructor
        public MessageStatusController(ITwilioSMSRepository twilioSMSRepository)
        {
            _twilioSMSRepository = twilioSMSRepository;
        }
        #endregion

        #region "Methods"
        [HttpPost]
        public void Index()
        {
            // Receive SMS Status (queued, sent, delivered) through webhook
            SMSMessage_Model smsmodel = new SMSMessage_Model();
            smsmodel.MessageSid = Request.Form["SmsSid"];
            smsmodel.Status = Request.Form["MessageStatus"];
            _twilioSMSRepository.UpdateSMS(smsmodel);
        }
        #endregion
    }
}
