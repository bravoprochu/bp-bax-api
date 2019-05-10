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
        public HttpResponseMessage GetSiteMap()
        {

            //var stream = new MemoryStream();
            var stream = this._siteMapService.GenSiteMap();
            //// processing the stream.

            var result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(stream.ToArray())
            };
            result.Content.Headers.ContentDisposition =
                new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                {
                    FileName = "CertificationCard.pdf"
                };
            result.Content.Headers.ContentType =
                new MediaTypeHeaderValue("application/octet-stream");

            return result;

            //var res = this._siteMapService.GenSiteMap();

            //return File(res.GetBuffer(), );

        }




    }
}