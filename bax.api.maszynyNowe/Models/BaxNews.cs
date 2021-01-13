using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bax.api.Models
{
    public class BaxNews
    {
        public DateTime CreationDate { get; set; }
        public string Id { get; set; }
        public ImageGallery ImageGallery { get; set; }
        public string ImgUrl { get; set; }
        public BaxNewsMiniInfo MiniInfo { get; set; }
        public BaxNewsTitle Title { get; set; }
        public string Text { get; set; }
        public string YoutubeUrl { get; set; }
        public string YoutubeEmbedUrl { get; set; }
    }
}
