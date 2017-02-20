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
        protected readonly ITravelGuideContext context;
        protected readonly IArticleFactory articleFactory;
        protected readonly IArticleCommentFactory commentFactory;

        public ArticleService(ITravelGuideContext context, IArticleFactory articleFactory, IArticleCommentFactory commentFactory)
        {
            if (context == null)
            {
                throw new ArgumentNullException("Passed DdContext cannot be null!");
            }

            if (articleFactory == null)
            {
                throw new ArgumentNullException("Passed factory cannot be null!");
            }

            if (commentFactory == null)
            {
                throw new ArgumentNullException("Passed factory cannot be null!");
            }

            this.context = context;
            this.articleFactory = articleFactory;
            this.commentFactory = commentFactory;
        }

        public void CreateArticle(string username, string title, string city, string country, string contentMain,
            string contentMustSee, string contentBudgetTips, string contentAccomodation,
            string primaryImageUrl, string secondImageUrl, string thirdImageUrl, string coverImageUrl)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(username.Trim()))
            {
                throw new ArgumentNullException("Username cannot be null!");
            }
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(title.Trim()) || title.Length < 2 || title.Length > 30)
            {
                throw new ArgumentException("Title cannot be null, shorter than 2 symbols or greater than 30!");
            }
            if (string.IsNullOrEmpty(city) || string.IsNullOrEmpty(city.Trim()) || city.Length < 2 || city.Length > 30)
            {
                throw new ArgumentException("City name cannot be null, shorter than 2 symbols or greater than 30!");
            }
            if (string.IsNullOrEmpty(country) || string.IsNullOrEmpty(country.Trim()) || country.Length < 2 || country.Length > 30)
            {
                throw new ArgumentException("Country name cannot be null, shorter than 2 symbols or greater than 30!");
            }
            if (string.IsNullOrEmpty(contentMain) || string.IsNullOrEmpty(contentMain.Trim()) || contentMain.Length < 50 || contentMain.Length > 5000)
            {
                throw new ArgumentException("Content cannot be null, shorter than 50 symbols or greater than 5000!");
            }
            if (string.IsNullOrEmpty(primaryImageUrl) || string.IsNullOrEmpty(primaryImageUrl.Trim()))
            {
                throw new ArgumentNullException("ImageUrl cannot be null!");
            }

            var user = this.context.Users.FirstOrDefault(x => x.UserName == username);
            if (user == null)
            {
                throw new InvalidOperationException("Only logged in users can create articles!");
            }

            var article = this.articleFactory.CreateArticle(user, Guid.Parse(user.Id), title, city, country, contentMain,
                contentMustSee, contentBudgetTips, contentAccomodation, primaryImageUrl, secondImageUrl, thirdImageUrl, coverImageUrl);

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

        public IEnumerable<Article> GetAllNotDeletedArticlesOrderedByDate()
        {
            return this.context
                .Articles
                .Where(x => !x.IsDeleted)
                .OrderByDescending(x => x.CreatedOn)
                .ToList();
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

        public void AddComment(string username, string content, Guid articleId)
        {
            var user = this.context.Users.FirstOrDefault(x => x.UserName == username);
            var parsedId = Guid.Parse(user.Id);

            var comment = this.commentFactory.CreateArticleComment(parsedId, user, content, articleId);
            var article = this.context.Articles.Find(articleId);
            article.Comments.Add(comment);

            this.context.SaveChanges();
        }

        public IEnumerable<Article> GetArticlesByKeyword(string keyword)
        {
            if (string.IsNullOrEmpty(keyword) || string.IsNullOrEmpty(keyword.Trim()))
            {
                return this.context.Articles.ToList();
            }

            var keywordToLower = keyword.ToLower();
            var articles = this.context.Articles
                .Where(x => x.City.ToLower().Contains(keywordToLower) ||
                x.Country.ToLower().Contains(keywordToLower) ||
                x.Title.ToLower().Contains(keywordToLower))
                .ToList();

            return articles;
        }
    }
}
