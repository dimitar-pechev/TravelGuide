using System;

namespace TravelGuide.Models.Gallery
{
    public class GalleryImage
    {
        private GalleryImage()
        {
            this.Id = Guid.NewGuid();
            this.CreatedOn = DateTime.Now;
            this.IsDeleted = false;
        }

        public GalleryImage(string title, string imageUrl, Guid userId, User user)
            : this()
        {
            this.Title = title;
            this.ImageUrl = imageUrl;
            this.UserId = userId;
            this.User = user;
        }

        public Guid Id { get; set; }

        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public Guid UserId { get; set; }

        public virtual User User { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
