using System;
using System.Collections.Generic;
using System.Linq;
using TravelGuide.Data;
using TravelGuide.Models.Articles;
using TravelGuide.Services.Contracts;
using TravelGuide.Services.Factories;

namespace TravelGuide.Services.Articles
{
    public class ArticleService : IArticleService
    {
        private readonly ITravelGuideContext context;
        private readonly IArticleFactory articleFactory;

        public ArticleService(ITravelGuideContext context, IArticleFactory articleFactory)
        {
            if (context == null)
            {
                throw new ArgumentNullException("Passed DdContext cannot be null!");
            }

            if (articleFactory == null)
            {
                throw new ArgumentNullException("Passed factory cannot be null!");
            }

            this.context = context;
            this.articleFactory = articleFactory;
        }

        public void CreateArticle(string username, string title, string city, string country, string content, string imageUrl)
        {
            if (string.IsNullOrEmpty(username.Trim()))
            {
                throw new ArgumentNullException("Username cannot be null!");
            }
            if (string.IsNullOrEmpty(title.Trim()) || title.Length < 2 || title.Length > 30)
            {
                throw new ArgumentNullException("Title cannot be null, shorter than 2 symbols or greater than 30!");
            }
            if (string.IsNullOrEmpty(city.Trim()) || city.Length < 2 || city.Length > 30)
            {
                throw new ArgumentNullException("City name cannot be null, shorter than 2 symbols or greater than 30!");
            }
            if (string.IsNullOrEmpty(country.Trim()) || country.Length < 2 || country.Length > 30)
            {
                throw new ArgumentNullException("Country name cannot be null, shorter than 2 symbols or greater than 30!");
            }
            if (string.IsNullOrEmpty(content.Trim()) || content.Length < 50 || content.Length > 5000)
            {
                throw new ArgumentNullException("Content cannot be null, shorter than 50 symbols or greater than 5000!");
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

            var article = this.articleFactory.CreateArticle(user, Guid.Parse(user.Id), title, city, country, content, imageUrl);

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
