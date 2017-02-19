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

        void ToggleLike(string username, Guid imageId);

        void AddComment(string username, string content, Guid imageId);
    }
}
