using System;
using TravelGuide.Models;
using TravelGuide.Models.Gallery;

namespace TravelGuide.Services.Factories
{
    public interface IGalleryImageFactory
    {
        GalleryImage CreateGalleryImage(string title, string imageUrl, Guid userId, User user);
    }
}
