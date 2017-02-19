using System;
using System.Collections.Generic;
using TravelGuide.Models.Gallery;

namespace TravelGuide.Services.GalleryImages.Contracts
{
    public interface IGalleryImageService
    {
        IEnumerable<GalleryImage> GetAllGalleryImages();

        IEnumerable<GalleryImage> GetAllNotDeletedGalleryImagesOrderedByDate();

        GalleryImage GetGalleryImageById(Guid id);
    }
}
