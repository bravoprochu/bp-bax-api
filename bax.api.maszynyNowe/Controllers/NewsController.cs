using bax.api.Models;
using bax.api.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace bax.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {

        private readonly NewsService _baxNewsService;

        public NewsController(DataFactoryService dataFactoryService, NewsService baxNewsService)
        {
            this._baxNewsService = baxNewsService;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            Thread.Sleep(500);
            var res = this._baxNewsService.GetMiniInfoList();

            return Ok(res);
            // return Ok(news.OrderByDescending(o => o.creationDate));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var found = this._baxNewsService.GetNewsPayload(id);

            if (found != null)
            {
                return Ok(found);
            }
            else
            {
                return NotFound("asdfasdF");
            }
        }





    }
}
