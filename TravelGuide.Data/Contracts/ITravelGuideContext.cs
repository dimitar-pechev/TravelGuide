using System.Data.Entity;
using TravelGuide.Models;
using TravelGuide.Models.Articles;
using TravelGuide.Models.Gallery;
using TravelGuide.Models.Requests;
using TravelGuide.Models.Store;

namespace TravelGuide.Data
{
    public interface ITravelGuideContext
    {
        IDbSet<ArticleComment> Comments { get; }

        IDbSet<Article> Articles { get; }

        IDbSet<GalleryImage> GalleryImages { get; set; }

        IDbSet<GalleryComment> GalleryComments { get; set; }

        IDbSet<GalleryLike> GalleryLikes { get; set; }

        IDbSet<StoreItem> StoreItems { get; set; }

        IDbSet<Request> Requests { get; set; }

        IDbSet<User> Users { get; }

        void SaveChanges();
    }
}
