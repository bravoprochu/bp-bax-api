using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using bax.api.maszynyNowe.Interfaces;
using System.Threading;

namespace bax.api.maszynyNowe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaszynyNoweController : ControllerBase
    {
        const string MASZYNY_NOWE_FILENAME = "maszynyNoweList.json";
        public IHostingEnvironment _env { get; set; }

        public MaszynyNoweController(IHostingEnvironment env)
        {
            _env = env;
        }




        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var maszynyList = this.getFullData();

            // Thread.Sleep(2500);

            return Ok(maszynyList);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(string id)
        {
            var maszynyList = this.getFullData();
            var found = maszynyList.Find(w => w.id.ToLower() == id.ToLower());

            if (found != null)
            {
                return Ok(found);
            }
            else {
                return NotFound("asdfasdF");
            }
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


        private List<MaszynyNoweList> getFullData() {

            var res = new List<MaszynyNoweList>();
            WebClient wc = new WebClient();
            Uri _uri = new Uri($"{_env.WebRootPath}/data/{MASZYNY_NOWE_FILENAME}");

            try
            {
                var json = wc.DownloadString(_uri);
                res = JsonConvert.DeserializeObject<List<MaszynyNoweList>>(json);
            }
            catch (Exception e)
            {
                throw e;
            }
            return res.OrderByDescending(o => o.nazwaModelu).ToList();
        }
    }
}
