using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using TravelGuide.Models;
using TravelGuide.Models.Articles;

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
