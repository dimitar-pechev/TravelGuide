using System.Data.Entity;
using TravelGuide.Models;

namespace TravelGuide.Data
{
    public class TravelGuideContext : DbContext, ITravelGuideContext
    {
        public TravelGuideContext()
            : base("TravelGuideDb")
        {
        }

        public IDbSet<Article> Articles { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}
