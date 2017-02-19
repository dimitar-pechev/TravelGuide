using System;
using TravelGuide.Models;
using TravelGuide.Models.Gallery;

namespace TravelGuide.Services.Factories
{
    public interface IGalleryCommentFactory
    {
        GalleryComment CreateGalleryComment(Guid userId, User user, string content, Guid imageId);
    }
}
