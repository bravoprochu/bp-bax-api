using bax.api.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace bax.api.Services
{
    public class SiteMapService
    {
        private readonly NewsService _newsService;
        private MaszynyNoweService _maszynyNoweService;

        public SiteMapService(NewsService newsService, MaszynyNoweService maszynyNoweService)
        {
            _newsService = newsService;
            _maszynyNoweService = maszynyNoweService;

        }


        public MemoryStream GenSiteMap()
        {
            var res = new List<SiteMapUrl>();
            this.AddMaszynyNoweRoutes(res);
            this.AddNewsRoutes(res);




            return this.Serialize(res);
        }





        private void AddMaszynyNoweRoutes(List<SiteMapUrl> siteMapList)
        {
            var maszynyNoweList = this._maszynyNoweService.GetMaszynyNoweList();

            foreach (var maszynyNowe in maszynyNoweList)
            {
                var _siteMapUrl = new SiteMapUrl
                {
                    Changefreq = "weekly",
                    Loc = maszynyNowe.id,
                };

                siteMapList.Add(_siteMapUrl);
            }
        }

        private void AddNewsRoutes(List<SiteMapUrl> siteMapList)
        {
            var newsList = this._newsService.GetList();

            foreach (var news in newsList)
            {
                var _siteMapUrl = new SiteMapUrl
                {
                    Changefreq = "weekly",
                    Loc = news.id,
                };

                siteMapList.Add(_siteMapUrl);
            }
        }

        private MemoryStream Serialize(List<SiteMapUrl> siteMapUrls)
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<SiteMapUrl>));
            MemoryStream ms = new MemoryStream();
            ser.Serialize(ms, siteMapUrls);
            ms.Close();

            

            return ms;


        }



    }
}
