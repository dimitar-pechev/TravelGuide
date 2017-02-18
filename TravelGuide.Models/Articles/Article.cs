using System;
using System.Collections.Generic;
using TravelGuide.Models.Articles.Contracts;

namespace TravelGuide.Models.Articles
{
    public class Article : IArticle
    {
        protected Article()
        {
            this.Id = Guid.NewGuid();
            this.CreatedOn = DateTime.Now;
            this.Comments = new HashSet<ArticleComment>();
            this.Likes = new HashSet<ArticleLike>();
            this.IsDeleted = false;
        }

        public Article(User user, Guid userId, string title, string city, string country, string content, string imageUrl) 
            : this()
        {
            this.User = user;
            this.UserId = userId;
            this.Title = title;
            this.City = city;
            this.Country = country;
            this.Content = content;
            this.ImageUrl = imageUrl;
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
