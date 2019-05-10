using System;
using System.Xml.Serialization;

namespace bax.api.Models
{
    public class SiteMapUrl
    {
        [XmlAttribute]
        public string Loc { get; set; }
        private string _lastmod;


        public string Lastmod
        {
            get
            {

                DateTime dateValue;

                if (DateTime.TryParse(_lastmod, out dateValue))
                {
                    return dateValue.ToShortDateString();
                }
                else
                {
                    return null;
                }
            }
            set { _lastmod = value; }
        }
        [XmlAttribute]
        public string Changefreq { get; set; }
        [XmlAttribute]
        public double Priority { get; set; }
    }
}