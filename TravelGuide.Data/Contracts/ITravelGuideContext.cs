using System.Data.Entity;
using TravelGuide.Models;
using TravelGuide.Models.Articles;
using TravelGuide.Models.Gallery;

namespace TravelGuide.Data
{
    public interface ITravelGuideContext
    {
        IDbSet<ArticleComment> Comments { get; }

        IDbSet<Article> Articles { get; }

        IDbSet<GalleryImage> GalleryImages { get; set; }

        IDbSet<User> Users { get; }

        void SaveChanges();
    }
}
