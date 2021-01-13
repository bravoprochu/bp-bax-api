using bax.api.Models;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace bax.api.Services
{
    public class DataFactoryService
    {
        const string BAX_NEWS_FILENAME = "baxNews.json";
        const string MASZYNY_NOWE_FILENAME = "maszynyNoweList.json";
        const string GALLERIES_FILENAME = "galleries.json";

        private IHostingEnvironment _env { get; set; }

        public DataFactoryService(IHostingEnvironment env)
        {
            this._env = env;
        }

        public List<ImageGallery> GetGalleries()
        {
            var res = new List<ImageGallery>();
            WebClient wc = new WebClient();
            Uri _uri = new Uri($"{_env.WebRootPath}/data/{GALLERIES_FILENAME}");

            try
            {
                var json = wc.DownloadString(_uri);
                res = JsonConvert.DeserializeObject<List<ImageGallery>>(json);
            }
            catch (Exception e)
            {
                throw e;
            }
            return res;
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

        public List<MaszynyNowe> GetMaszynyNoweList()   
        {
            var res = new List<MaszynyNowe>();
            WebClient wc = new WebClient();
            Uri _uri = new Uri($"{_env.WebRootPath}/data/{MASZYNY_NOWE_FILENAME}");

            try
            {
                var json = wc.DownloadString(_uri);
                res = JsonConvert.DeserializeObject<List<MaszynyNowe>>(json);
            }
            catch (Exception e)
            {
                throw e;
            }
            return res;
        }
    }
}
