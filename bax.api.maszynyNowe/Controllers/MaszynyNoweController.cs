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
using bax.api.Services;

namespace bax.api.maszynyNowe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaszynyNoweController : ControllerBase
    {
        private readonly BaxDataFactoryService _dataFactoryService;

        public MaszynyNoweController(BaxDataFactoryService dataFactoryService)
        {
            _dataFactoryService = dataFactoryService;
        }




        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            // var maszynyList = this.getFullData();

            var maszynyList = this._dataFactoryService.getMaszynyNoweList();

            // Thread.Sleep(2500);

            return Ok(maszynyList);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(string id)
        {
            var maszynyList = this._dataFactoryService.getMaszynyNoweList();
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
    }
}
