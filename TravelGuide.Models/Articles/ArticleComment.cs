using System;
using TravelGuide.Models.Abstractions;

namespace TravelGuide.Models.Articles
{
    public class ArticleComment : Comment
    {
        public Guid ArticleId { get; set; }

        public virtual Article Article { get; set; }
    }
}
