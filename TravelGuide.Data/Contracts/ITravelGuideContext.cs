using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using TravelGuide.Models;

namespace TravelGuide.Data
{
    public interface ITravelGuideContext
    {
        IDbSet<Comment> Comments { get; }

        IDbSet<Article> Articles { get; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        void SaveChanges();
    }
}
