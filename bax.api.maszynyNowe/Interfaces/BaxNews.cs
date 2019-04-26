using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bax.api.Interfaces
{
    public class BaxNews
    {
        public DateTime creationDate { get; set; }
        public string id { get; set; }
        public BaxNewsTitle title { get; set; }
        public string imgUrl { get; set; }
        public string youtubeUrl { get; set; }
        public string youtubeEmbedUrl { get; set; }
        public string text { get; set; }
        public BaxNewsMiniInfo miniInfo{ get; set; }
    }
}
