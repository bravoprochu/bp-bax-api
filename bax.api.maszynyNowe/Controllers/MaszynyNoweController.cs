using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using bax.api.Models;
using System.Threading;
using bax.api.Services;

namespace bax.api.maszynyNowe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaszynyNoweController : ControllerBase
    {
        private readonly MaszynyNoweService _maszynyNoweService;

        public MaszynyNoweController(MaszynyNoweService maszynyNoweService)
        {
            _maszynyNoweService = maszynyNoweService;
        }




        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var maszynyList = this._maszynyNoweService.GetMaszynyNoweList();
            return Ok(maszynyList);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(string id)
        {
            var found = this._maszynyNoweService.GetMaszynyNoweById(id);

            if (found != null)
            {
                return Ok(found);
            }
            else {
                return NotFound("asdfasdF");
            }
        }

    }
}
