using System.Data.Entity;
using TravelGuide.Models;

namespace TravelGuide.Data
{
    public interface ITravelGuideContext
    {
        IDbSet<Comment> Comments { get; }

        IDbSet<Article> Articles { get; }
        
        void SaveChanges();
    }
}
