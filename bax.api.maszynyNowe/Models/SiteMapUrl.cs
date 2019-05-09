using System;

namespace bax.api.Controllers
{
    public class SiteMapUrl
    {
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
        public string Chanefreq { get; set; }
        public double Priority { get; set; }
    }
}