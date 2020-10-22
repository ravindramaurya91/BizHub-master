using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
using CommonUtil;

namespace ServiceHub.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class Queue : ControllerBase {

        [HttpPost("PublishToQueue")]
        public ActionResult<string> PublishToQueue([FromBody] QueableMessage Message) {
            string sReturn = "Message Received";
            try {
                MessageHandler.Instance.Enqueue(Message);
            } catch (Exception ex) {
            //      throw ex;
            }
            return sReturn;
        }

    }
}
