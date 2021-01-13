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
        const string SERVER_URL = "https://www.bax-maszyny.pl";
        const string DATE_FORMAT = "yyyy-MM-dd";
        private readonly NewsService _newsService;
        private MaszynyNoweService _maszynyNoweService;

        public SiteMapService(NewsService newsService, MaszynyNoweService maszynyNoweService)
        {
            _newsService = newsService;
            _maszynyNoweService = maszynyNoweService;

        }


        public StringBuilder GenSiteMap(bool isNewsOwnDate)
        {
            return TextXMLSiteMap(isNewsOwnDate);
        }


        


        private void AddMaszynyNoweRoutes(List<SiteMapUrl> siteMapList)
        {
            var maszynyNoweList = this._maszynyNoweService.GetMaszynyNoweList();

            foreach (var maszynyNowe in maszynyNoweList)
            {
                var _siteMapUrl = new SiteMapUrl
                {
                    Changefreq = "weekly",
                    Loc = maszynyNowe.Id,
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
                    Loc = news.Id,
                };

                siteMapList.Add(_siteMapUrl);
            }
        }

        private string _todayFormatted { get {
            return DateTime.Today.ToString(DATE_FORMAT);
            }}

        private StreamWriter Serialize(List<SiteMapUrl> siteMapUrls)
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<SiteMapUrl>));
            MemoryStream ms = new MemoryStream();
            StreamWriter sw = new StreamWriter("dupa.xml");
            ser.Serialize(sw, siteMapUrls);
            ms.Close();

            sw.Close();



            return sw;


        }

        private StringBuilder TextSiteMap(List<SiteMapUrl> siteMapUrl)
        {
            var res = new StringBuilder();


            //oferta
            res.AppendLine($"{SERVER_URL}/offer/arjes");
            res.AppendLine($"{SERVER_URL}/offer/guidetti");
            res.AppendLine($"{SERVER_URL}/offer/sennebogen");
            res.AppendLine($"{SERVER_URL}/offer/yanmar");
            res.AppendLine($"{SERVER_URL}/offer/czesci");
            res.AppendLine($"{SERVER_URL}/offer/serwis");


            // kontakt i pierdoly

            res.AppendLine($"{SERVER_URL}/contact");
            res.AppendLine($"{SERVER_URL}/kontakt");


            //special
            res.AppendLine($"{SERVER_URL}/info/bax-bauma2019-sennebogen-voucher");


            //maszyny nowe
            var maszynyNoweList = this._maszynyNoweService.GetMaszynyNoweList();
            var maszynyNoweRoute = $"{SERVER_URL}/offer/maszynyNowe";
            res.AppendLine(maszynyNoweRoute);
            foreach (var maszyna in maszynyNoweList)
            {
                res.AppendLine($"{maszynyNoweRoute}/{maszyna.Id}");
            }


            // news list..
            var newsList = this._newsService.GetList();
            var newsRoute = $"{SERVER_URL}/news";
            res.AppendLine(newsRoute);
            foreach (var news in newsList)
            {
                res.AppendLine($"{newsRoute}/{news.Id}");
            }


            return res;
        }

        private StringBuilder TextXMLSiteMap(bool isNewsOwnDate)
        {
            const string _OFERTA_STATIC_DATE = "2020-02-28";
            const string _FIRST_TIME_DATE = "2018-08-01";
            const string _MASZYNY_NOWE_DETAIL_DATE = "2020-02-28";
            

            var res = new StringBuilder();
            res.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            res.AppendLine("<urlset xmlns=\"http://www.sitemaps.org/schemas/sitemap/0.9\"");
            res.AppendLine("xmlns:image= \"http://www.google.com/schemas/sitemap-image/1.1\"");
            res.AppendLine("xmlns:news= \"http://www.google.com/schemas/sitemap-news/0.9\">");


            // news list..
            var newsList = this._newsService.GetList();
            var newsRoute = $"{SERVER_URL}/news";
            res.AppendLine(GenXmlUrlElement(newsRoute, _FIRST_TIME_DATE));
            foreach (var news in newsList)
            {
                var imgUrl = $"{SERVER_URL}/{news.ImgUrl.Replace("./", "")}";
                var _title = $"{news.Title.title} {news.Title.shortTitle} {news.Title.subtitle}";
                _title = _title.Trim();
                //news prep

                
                //default url

                string _newsDate = isNewsOwnDate ? news.CreationDate.ToString(DATE_FORMAT) : _todayFormatted;

                res.AppendLine(GenXmlUrlElement($"{newsRoute}/{news.Id}", imgUrl, _newsDate , _title));
            }

            // kontakt i pierdoly

            // res.AppendLine(GenXmlUrlElement($"{SERVER_URL}/contact"));
            res.AppendLine(GenXmlUrlElement($"{SERVER_URL}/kontakt", _FIRST_TIME_DATE));

            //oferta 
            res.AppendLine(GenXmlUrlElement($"{SERVER_URL}/offer/arjes", _OFERTA_STATIC_DATE));
            res.AppendLine(GenXmlUrlElement($"{SERVER_URL}/offer/guidetti", _OFERTA_STATIC_DATE));
            res.AppendLine(GenXmlUrlElement($"{SERVER_URL}/offer/sennebogen", _OFERTA_STATIC_DATE));
            res.AppendLine(GenXmlUrlElement($"{SERVER_URL}/offer/yanmar", _OFERTA_STATIC_DATE));
            res.AppendLine(GenXmlUrlElement($"{SERVER_URL}/offer/czesci", _OFERTA_STATIC_DATE));
            res.AppendLine(GenXmlUrlElement($"{SERVER_URL}/offer/serwis", _OFERTA_STATIC_DATE));


            //special
            res.AppendLine(GenXmlUrlElement($"{SERVER_URL}/info/bax-eRobocze-Sosnowiec-2019", "2019-08-01"));
            string[] info1BaumaSenneImg = new string[2];
            info1BaumaSenneImg[0] = $"{SERVER_URL}/assets/info/bax_bauma_2019_sennebogen.png";
            info1BaumaSenneImg[1] = $"{SERVER_URL}/assets/info/SENNEBOGEN_green_heart_of_bauma.png";
            res.AppendLine(GenXmlUrlElement($"{SERVER_URL}/info/bax-bauma2019-sennebogen-voucher", info1BaumaSenneImg, "2019-08-01"));
            


            //maszyny nowe
            var maszynyNoweList = this._maszynyNoweService.GetMaszynyNoweList();
            var maszynyNoweRoute = $"{SERVER_URL}/offer/maszynyNowe";
            res.AppendLine(GenXmlUrlElement(maszynyNoweRoute, _MASZYNY_NOWE_DETAIL_DATE));
            foreach (var maszyna in maszynyNoweList)
            {
                var imgUrl = $"{SERVER_URL}/assets/oferta/modele/{maszyna.Marka.ToLower()}/{maszyna.mediaCardImg}";
                var _title = $"{maszyna.Marka} {maszyna.NazwaModelu}";
                res.AppendLine(GenXmlUrlElement($"{maszynyNoweRoute}/{maszyna.Id}", imgUrl, _MASZYNY_NOWE_DETAIL_DATE, _title));
            }      
            
            
            res.AppendLine("</urlset>");
            return res;

        }

        private string GenXmlUrlNewsElement(string url, string imgUrl, string imgTitle, BaxNews news)
        {
            var res = new StringBuilder();
            var _date = $"{news.CreationDate.ToString(DATE_FORMAT)}T{news.CreationDate.ToString("HH:mm:ss")}";
            // _date = news.creationDate.ToUniversalTime().ToString();
            _date = news.CreationDate.ToString(DATE_FORMAT);

            res.AppendLine("<url>");
            res.AppendLine($"<lastmod>{_todayFormatted}</lastmod>");
            res.AppendLine($"<loc>{url}</loc>");
            if (!string.IsNullOrWhiteSpace(imgUrl))
            {
                GenXmlUrlElementImage(res, imgUrl, imgTitle);
            }
            res.AppendLine($"<news:news>");
                res.AppendLine($"<news:publication>");
                    res.AppendLine($"<news:name>{imgTitle}</news:name>");
                    res.AppendLine($"<news:language>pl</news:language>");
                res.AppendLine($"</news:publication>");
                res.AppendLine($"<news:publication_date>{_date}</news:publication_date>");
                res.AppendLine($"<news:keywords>bax maszyny, dealer yanmar, dealer sennebogen</news:keywords>");
                res.AppendLine($"<news:title>{imgTitle}</news:title>");
            res.AppendLine($"</news:news>");


            res.AppendLine("</url>");

            return res.ToString();
        }


        private string GenXmlUrlElement(string url, string lastmod)
        {

            var res = new StringBuilder();
            res.AppendLine("<url>");
            res.AppendLine($"<lastmod>{lastmod}</lastmod>");
            res.AppendLine($"<loc>{url}</loc>");
            res.AppendLine($"<lastmod>{lastmod}</lastmod>");
            res.AppendLine("</url>");
            return res.ToString();
        }

        private string GenXmlUrlElement(string url, string imgUrl, string lastmod, string imgTitle = "")
        {
            var res = new StringBuilder();

            res.AppendLine("<url>");
            res.AppendLine($"<lastmod>{lastmod}</lastmod>");
            res.AppendLine($"<loc>{url}</loc>");
            if (!string.IsNullOrWhiteSpace(imgUrl)) {
                GenXmlUrlElementImage(res, imgUrl, imgTitle);
            }
            res.AppendLine("</url>");

            return res.ToString();
        }

        private string GenXmlUrlElement(string url, string[] imgUrlList, string lastmod, string imgTitle = "")
        {
            var res = new StringBuilder();

            res.AppendLine("<url>");
            res.AppendLine($"<lastmod>{lastmod}</lastmod>");
            res.AppendLine($"<loc>{url}</loc>");
            if (imgUrlList != null && imgUrlList.Length > 0)
            {
                foreach (var imgUrl in imgUrlList)
                {
                    GenXmlUrlElementImage(res, imgUrl);
                }
            }
            res.AppendLine("</url>");

            

            return res.ToString();
        }

        private void GenXmlUrlElementImage(StringBuilder res, string imgUrl, string imgTitle = "")
        {
            res.AppendLine("<image:image>");
            res.AppendLine($"<image:loc>{imgUrl}</image:loc>");
            if (!string.IsNullOrWhiteSpace(imgTitle)) {
                res.AppendLine($"<image:title>{imgTitle}</image:title>");
            }
            res.AppendLine("</image:image>");
        }

    }
        
}
