using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServiceHub.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class APIControllerReadWrite : ControllerBase {
        // GET: api/<APIControllerReadWrite>
        [HttpGet]
        public IEnumerable<string> Get() {
            return new string[] { "value1", "value2" };
        }

        // GET api/<APIControllerReadWrite>/5
        [HttpGet("{id}")]
        public string Get(int id) {
            return "value";
        }

        // POST api/<APIControllerReadWrite>
        [HttpPost]
        public void Post([FromBody] string value) {
        }

        // PUT api/<APIControllerReadWrite>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) {
        }

        // DELETE api/<APIControllerReadWrite>/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
        }
    }
}
