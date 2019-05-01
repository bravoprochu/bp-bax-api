using bax.api.Interfaces;
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
        private string BAX_NEWS_FILENAME = "baxNews.json";
        private IHostingEnvironment _env { get; set; }

        public NewsController(IHostingEnvironment env)
        {
            this._env = env;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var news = this.GetFullNews();

            // Thread.Sleep(2500);

            return Ok(news.Select(s=>s.miniInfo).ToList());
            // return Ok(news.OrderByDescending(o => o.creationDate));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var news = this.GetFullNews();
            var found = news.Find(w => w.id.ToLower() == id.ToLower());

            if (found != null)
            {
                return Ok(this.GetNewsPayload(news, found));
            }
            else
            {
                return NotFound("asdfasdF");
            }
        }



        private List<BaxNews> GetFullNews()
        {
            var res = new List<BaxNews>();
            WebClient wc = new WebClient();
            Uri _uri = new Uri($"{_env.WebRootPath}/data/{BAX_NEWS_FILENAME}");

            try
            {
                var json = wc.DownloadString(_uri);
                res = JsonConvert.DeserializeObject<List<BaxNews>>(json);
            }
            catch (Exception e)
            {
                throw e;
            }
            return res.OrderByDescending(o => o.creationDate).ToList();
        }

        private BaxNewsPayload GetNewsPayload(List<BaxNews> newsList, BaxNews news)
        {
            var res = new BaxNewsPayload();
            res.News = news;
            var idx = newsList.IndexOf(news);

            if (idx < newsList.Count-1)
            {
                res.NextId = newsList.ElementAt(idx + 1).id;
            }
            if (idx > 0)
            {
                res.PrevId = newsList.ElementAt(idx - 1).id;
            }




            return res;
        }

    }
}
