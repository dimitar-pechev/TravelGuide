using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using TravelGuide.Models;
using TravelGuide.Models.Articles;
using TravelGuide.Models.Gallery;
using TravelGuide.Models.Store;

namespace TravelGuide.Data
{
    public class TravelGuideContext : IdentityDbContext<User>, ITravelGuideContext
    {
        public TravelGuideContext()
            : base("TravelGuideDb")
        {
        }
        
        public IDbSet<Article> Articles { get; set; }

        public IDbSet<ArticleComment> Comments { get; set; }

        public IDbSet<GalleryImage> GalleryImages { get; set; }

        public IDbSet<GalleryComment> GalleryComments { get; set; }

        public IDbSet<GalleryLike> GalleryLikes { get; set; }

        public IDbSet<StoreItem> StoreItems { get; set; }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }
        
        public static TravelGuideContext Create()
        {
            return new TravelGuideContext();
        }
    }
}
