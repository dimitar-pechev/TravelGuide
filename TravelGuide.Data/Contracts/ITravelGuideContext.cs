using System.Data.Entity;
using TravelGuide.Models.Articles;

namespace TravelGuide.Data
{
    public interface ITravelGuideContext
    {
        IDbSet<ArticleComment> Comments { get; }

        IDbSet<Article> Articles { get; }
        
        void SaveChanges();
    }
}
