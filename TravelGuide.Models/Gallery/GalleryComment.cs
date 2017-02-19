using System;
using TravelGuide.Models.Abstractions;

namespace TravelGuide.Models.Gallery
{
    public class GalleryComment : Comment
    {
        public GalleryComment() : base()
        {
        }

        public GalleryComment(Guid userId, string content, Guid imageId)
            : base()
        {
            this.UserId = userId;
            this.Content = content;
            this.GalleryImageId = imageId;
        }

        public Guid GalleryImageId { get; set; }

        public virtual GalleryImage GalleryImage { get; set; }
    }
}
