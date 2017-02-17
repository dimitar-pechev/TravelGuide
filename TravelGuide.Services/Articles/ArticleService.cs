using System;
using System.Collections.Generic;
using System.Linq;
using TravelGuide.Data;
using TravelGuide.Models.Articles;
using TravelGuide.Services.Contracts;

namespace TravelGuide.Services.Articles
{
    public class ArticleService : IArticleService
    {
        private readonly ITravelGuideContext context;

        public ArticleService(ITravelGuideContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("Passed DdContext cannot be null!");
            }

            this.context = context;
        }

        public void CreateArticle(string username, string title, string city, string country, string content, string imageUrl)
        {
            if (string.IsNullOrEmpty(username.Trim()))
            {
                throw new ArgumentNullException("Username cannot be null!");
            }
            if (string.IsNullOrEmpty(title.Trim()))
            {
                throw new ArgumentNullException("Title cannot be null!");
            }
            if (string.IsNullOrEmpty(city.Trim()))
            {
                throw new ArgumentNullException("City name cannot be null!");
            }
            if (string.IsNullOrEmpty(country.Trim()))
            {
                throw new ArgumentNullException("Country name cannot be null!");
            }
            if (string.IsNullOrEmpty(content.Trim()))
            {
                throw new ArgumentNullException("Content cannot be null!");
            }
            if (string.IsNullOrEmpty(imageUrl.Trim()))
            {
                throw new ArgumentNullException("ImageUrl cannot be null!");
            }

            var user = this.context.Users.FirstOrDefault(x => x.UserName == username);
            if (user == null)
            {
                throw new InvalidOperationException("Only logged in users can create articles!");
            }

            var article = new Article()
            {
                Title = title,
                Country = country,
                City = city,
                Content = content,
                User = user,
                UserId = Guid.Parse(user.Id),
                ImageUrl = imageUrl
            };

            this.context.Articles.Add(article);
            this.context.SaveChanges();
        }

        public void DeleteArticle(Article article)
        {
            if (article == null)
            {
                throw new InvalidOperationException("The passed article is null!");
            }

            var dbArticle = this.context.Articles.Find(article.Id);

            if (dbArticle == null)
            {
                throw new InvalidOperationException("The passed article is not present in the database!");
            }

            dbArticle.IsDeleted = true;
            this.context.SaveChanges();
        }

        public void EditArticle(Article article)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Article> GetAllArticles()
        {
            return this.context.Articles.ToList();
        }

        public Article GetArticleById(Guid id)
        {
            if (id == null)
            {
                throw new InvalidOperationException("Passed guid cannot be null!");
            }

            var article = this.context.Articles.Find(id);
            return article;
        }
    }
}
