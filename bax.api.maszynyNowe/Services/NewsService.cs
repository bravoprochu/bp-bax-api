using bax.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bax.api.Services
{
    public class NewsService
    {
        private readonly DataFactoryService _baxDataFactory;
        private readonly GalleryService _galleryService;

        public NewsService(DataFactoryService dataFactoryService, GalleryService galleryService)
        {
            _baxDataFactory = dataFactoryService;
            _galleryService = galleryService;
        }


        public BaxNews GetById(string id)
        {
            return this.GetList().Find(f => f.Id.ToLower() == id.ToLower());

        }


        public List<BaxNews> GetList()
        {
            var res = this._baxDataFactory.GetNewsList().OrderByDescending(o => o.CreationDate).ToList();
            var _imageGallery = this._galleryService.GetImageGallery();
            foreach (var news in res)
            {
                news.ImageGallery = _imageGallery.Find(f => f.Id == news.Id);
            }

            return res;
        }

       


        public List<BaxNewsMiniInfo> GetMiniInfoList()
        {
            var res = this.GetList();
            return res.Select(s => s.MiniInfo).ToList();
        }

        public BaxNewsPayload GetNewsPayload(string id)
        {
            var res = new BaxNewsPayload();
            var newsList = this.GetList();
            var foundedNews = newsList.Find(f => f.Id.ToLower() == id.ToLower());
            if (foundedNews == null) { return null; }
            res.News = foundedNews;
            var idx = newsList.IndexOf(foundedNews);

            if (idx < newsList.Count - 1)
            {
                res.NextId = newsList.ElementAt(idx + 1).Id;
            }
            if (idx > 0)
            {
                res.PrevId = newsList.ElementAt(idx - 1).Id;
            }
            return res;
        }

    }
}
