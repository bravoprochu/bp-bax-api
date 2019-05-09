using bax.api.Interfaces;
using bax.api.maszynyNowe.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace bax.api.Services
{
    public class BaxDataFactoryService
    {
        const string BAX_NEWS_FILENAME = "baxNews.json";
        const string MASZYNY_NOWE_FILENAME = "maszynyNoweList.json";

        private IHostingEnvironment _env { get; set; }

        public BaxDataFactoryService(IHostingEnvironment env)
        {
            this._env = env;
        }

        public List<BaxNews> GetNewsList()
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
            return res;
        }


        public List<MaszynyNoweList> getMaszynyNoweList()
        {
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
