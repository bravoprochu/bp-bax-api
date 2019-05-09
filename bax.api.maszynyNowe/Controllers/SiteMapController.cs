using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace bax.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiteMapController : ControllerBase
    {


        [HttpGet]
        public async Task<IActionResult> GetSiteMap()
        {

            var res = new SiteMapUrl();


            return Ok();
        }



        private List<SiteMapUrl> GenRoutes()
        {
            var res = new List<SiteMapUrl>();
                

            return res;
        }
    }
}