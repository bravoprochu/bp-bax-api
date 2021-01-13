using System.Collections.Generic;

namespace bax.api.Models
{
    public class ImageGallery
    {
        public string GalleryName { get; set; }
        public string GalleryDescription { get; set; }
        public string GalleryPathUrl { get; set; }
        public string Id { get; set; }
        public List<ImageGalleryItem> ImageGalleryItemList { get; set; }
        public string InfoBgColor { get; set; }
        public List<string> Tags { get; set; }
    }
}