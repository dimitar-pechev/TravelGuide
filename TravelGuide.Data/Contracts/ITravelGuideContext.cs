using System.Data.Entity;
using TravelGuide.Models;
using TravelGuide.Models.Articles;

namespace TravelGuide.Data
{
    public interface ITravelGuideContext
    {
        IDbSet<ArticleComment> Comments { get; }

        IDbSet<Article> Articles { get; }

        IDbSet<User> Users { get; }

        void SaveChanges();
    }
}
