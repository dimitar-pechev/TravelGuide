using System;
using TravelGuide.Models.Gallery;

namespace TravelGuide.Services.Factories
{
    public interface IGalleryCommentFactory
    {
        GalleryComment CreateGalleryComment(Guid userId, string content, Guid imageId);
    }
}
