using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using bax.api.Services;
using Microsoft.AspNetCore.Mvc;

namespace bax.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiteMapController : ControllerBase
    {
        private readonly SiteMapService _siteMapService;

        public SiteMapController(SiteMapService siteMapService)
        {
            _siteMapService = siteMapService;
        }


        [HttpGet]
        public IActionResult GetSiteMap(bool newsOwnDate=true)
        {
            return Content(this._siteMapService.GenSiteMap(newsOwnDate).ToString(), "application/xml", UTF8Encoding.UTF8);
        }




    }
}