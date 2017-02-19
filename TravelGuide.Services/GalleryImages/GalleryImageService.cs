using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        protected IGalleryImageFactory imageFactory;
        protected IGalleryLikeFactory likeFactory;
        protected IGalleryCommentFactory commentFactory;

        public GalleryImageService(ITravelGuideContext context, IGalleryImageFactory imageFactory,
            IGalleryLikeFactory likeFactory, IGalleryCommentFactory commentFactory)
        {
            this.context = context;
            this.imageFactory = imageFactory;
            this.likeFactory = likeFactory;
            this.commentFactory = commentFactory;
        }

        public void AddComment(string username, string content, Guid imageId)
        {
            var userId = Guid.Parse(this.context.Users.FirstOrDefault(x => x.UserName == username).Id);
            var comment = this.commentFactory.CreateGalleryComment(userId, content, imageId);
            var image = this.GetGalleryImageById(imageId);
            image.Comments.Add(comment);
            this.context.SaveChanges();
        }

        public void ToggleLike(string username, Guid imageId)
        {
            var userId = Guid.Parse(this.context.Users.FirstOrDefault(x => x.UserName == username).Id);
            var like = this.likeFactory.CreateGalleryLike(userId, imageId);
            var image = this.GetGalleryImageById(imageId);

            GalleryLike dbLike = null;
            foreach (var item in image.Likes)
            {
                if (item.UserId == userId)
                {
                    dbLike = item;
                    break;
                }
            }

            if (dbLike != null)
            {
                this.context.GalleryLikes.Remove(dbLike);
            }
            else
            {
                image.Likes.Add(like);
            }
            
            this.context.SaveChanges();
        }

        public IEnumerable<GalleryImage> GetAllGalleryImages()
        {
            return this.context.GalleryImages.ToList();
        }

        public IEnumerable<GalleryImage> GetAllNotDeletedGalleryImagesOrderedByDate()
        {
            return this.context
                .GalleryImages
                .Include(im => im.Likes)
                .Include(im => im.Comments)
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

            var image = this.GetAllNotDeletedGalleryImagesOrderedByDate().FirstOrDefault(x => x.Id == id);
            return image;
        }
    }
}
