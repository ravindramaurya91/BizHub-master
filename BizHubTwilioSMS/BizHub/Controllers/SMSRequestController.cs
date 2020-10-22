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
    public class SMSRequestController : TwilioController
    {
        #region Fields
        private ITwilioSMSRepository _twilioSMSRepository;
        #endregion (Fields)

        #region Constructor
        public SMSRequestController(ITwilioSMSRepository twilioSMSRepository)
        {
            _twilioSMSRepository = twilioSMSRepository;
        }
        #endregion



        #region "Methods"

        [HttpPost]
        public void Post([FromBody] SMSMessageResponse_Model objSMSMessageResponse_Model)
        {

            _twilioSMSRepository.TwilioSMSReceive(objSMSMessageResponse_Model);
        }
        #endregion
    }
}