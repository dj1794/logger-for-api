using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using log4net.Repository.Hierarchy;
using log4net.Core;
using log4net.Repository;
using Microsoft.Extensions.Logging;
using log4net;

namespace LoggerTestApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
       
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var logger = LogManager.GetLogger(typeof(Program));
            var j = "b";
            try
            {
                Convert.ToInt32(j);
            }
            catch (Exception e)
            {
                logger.Error("Logger is working!!! " + e.Message);
            }
            
            return new string[] { j, "Test" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
            Convert.ToInt32(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
