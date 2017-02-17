using System;
using System.Collections.Generic;

namespace TravelGuide.Models.Articles
{
    public class Article
    {
        public Article()
        {
            this.Id = Guid.NewGuid();
            this.CreatedOn = DateTime.Now;
            this.Comments = new HashSet<ArticleComment>();
            this.Likes = new HashSet<ArticleLike>();
            this.IsDeleted = false;
        }

        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public virtual User User { get; set; }

        public string Title { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Content { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string ImageUrl { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<ArticleLike> Likes { get; set; }

        public virtual ICollection<ArticleComment> Comments { get; set; }
    }
}
