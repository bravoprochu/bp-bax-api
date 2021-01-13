using bax.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bax.api.Services
{
    public class GalleryService
    {
        private readonly DataFactoryService _baxDataFactoryService;

        public GalleryService(DataFactoryService dataFactoryService)
        {
            this._baxDataFactoryService = dataFactoryService;
        }


        public List<ImageGallery> GetImageGallery() {
            return this._baxDataFactoryService.GetGalleries();
        }



        public ImageGallery GetGalleryById(string id) {
            var _galleries = this.GetImageGallery();

            return _galleries.Find(f => f.Id == id);
        }


    }
}
