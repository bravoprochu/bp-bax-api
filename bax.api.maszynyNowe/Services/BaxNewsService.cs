using bax.api.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bax.api.Services
{
    public class BaxNewsService
    {
        private readonly BaxDataFactoryService _baxDataFactory;

        public BaxNewsService(BaxDataFactoryService baxDataFactoryService)
        {
            _baxDataFactory = baxDataFactoryService;
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

            var foundedNews = this.GetById(id);

            if (foundedNews == null) { return null; }





            var res = new BaxNewsPayload();
            var newsList = this.GetList();
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
