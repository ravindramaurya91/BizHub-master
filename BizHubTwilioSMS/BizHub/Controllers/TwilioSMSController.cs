using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Model;
using Model.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BizHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TwilioSMSController : ControllerBase
    {
        #region Fields
        private ITwilioSMSRepository _twilioSMSRepository;
        #endregion (Fields)

        #region Constructor
        public TwilioSMSController(ITwilioSMSRepository twilioSMSRepository)
        {
            _twilioSMSRepository = twilioSMSRepository;
        }
        #endregion

        #region Public Methods
        // GET: api/<TwilioSMSController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "TwilioSMS", "TwilioChat" };
        }

        // GET api/<TwilioSMSController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "TwilioSMS" + id;
        }

        // POST api/<TwilioSMSController>
        // Send SMS
        [HttpPost]
        public void Post([FromBody] SMSMessage_Model objsms)
        {
            _twilioSMSRepository.TwilioSMSCreate(objsms);
        }


        // PUT api/<TwilioSMSController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TwilioSMSController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        #endregion

        #region Private Methods

        #endregion

    }
}