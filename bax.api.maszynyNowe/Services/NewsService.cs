using bax.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bax.api.Services
{
    public class NewsService
    {
        private readonly dataFactoryService _baxDataFactory;

        public NewsService(dataFactoryService dataFactoryService)
        {
            _baxDataFactory = dataFactoryService;
        }


        public BaxNews GetById(string id)
        {
            return this.GetList().Find(f => f.id.ToLower() == id.ToLower());

        }


        public List<BaxNews> GetList()
        {
            var res = this._baxDataFactory.GetNewsList().OrderByDescending(o => o.creationDate).ToList();
            return res;
        }

       


        public List<BaxNewsMiniInfo> GetMiniInfoList()
        {
            var res = this.GetList();
            return res.Select(s => s.miniInfo).ToList();
        }

        public BaxNewsPayload GetNewsPayload(string id)
        {
            var res = new BaxNewsPayload();
            var newsList = this.GetList();
            var foundedNews = newsList.Find(f => f.id.ToLower() == id.ToLower());
            if (foundedNews == null) { return null; }
            res.News = foundedNews;
            var idx = newsList.IndexOf(foundedNews);

            if (idx < newsList.Count - 1)
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
