using System;
using TravelGuide.Models.Gallery;

namespace TravelGuide.Services.Factories
{
    public interface IGalleryLikeFactory
    {
        GalleryLike CreateGalleryLike(Guid userId, Guid imageId);
    }
}
