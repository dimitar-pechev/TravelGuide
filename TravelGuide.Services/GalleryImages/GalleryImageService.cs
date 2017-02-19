using System;
using System.Collections.Generic;
using System.Linq;
using TravelGuide.Data;
using TravelGuide.Models.Gallery;
using TravelGuide.Services.Factories;
using TravelGuide.Services.GalleryImages.Contracts;

namespace TravelGuide.Services.GalleryImages
{
    public class GalleryImageService : IGalleryImageService
    {
        protected ITravelGuideContext context;
        protected IGalleryImageFactory factory;

        public GalleryImageService(ITravelGuideContext context, IGalleryImageFactory factory)
        {
            this.context = context;
            this.factory = factory;
        }

        public IEnumerable<GalleryImage> GetAllGalleryImages()
        {
            return this.context.GalleryImages.ToList();
        }

        public IEnumerable<GalleryImage> GetAllNotDeletedGalleryImagesOrderedByDate()
        {
            return this.context
                .GalleryImages
                .Where(x => !x.IsDeleted)
                .OrderByDescending(x => x.CreatedOn)
                .ToList();
        }

        public GalleryImage GetGalleryImageById(Guid id)
        {
            if (id == null)
            {
                throw new InvalidOperationException("Passed guid cannot be null!");
            }

            var image = this.context.GalleryImages.Find(id);
            return image;
        }
    }
}
