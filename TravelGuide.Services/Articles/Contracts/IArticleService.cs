using System;
using System.Collections.Generic;
using TravelGuide.Models.Articles;

namespace TravelGuide.Services.Contracts
{
    public interface IArticleService
    {
        IEnumerable<Article> GetAllArticles();

        IEnumerable<Article> GetAllNotDeletedArticlesOrderedByDate();

        IEnumerable<Article> GetArticlesByKeyword(string keyword);

        Article GetArticleById(Guid id);

        void CreateArticle(string username, string title, string city, string country, string contentMain,
            string contentMustSee, string contentBudgetTips, string contentAccomodation,
            string primaryImageUrl, string secondImageUrl, string thirdImageUrl, string coverImageUrl);

        void EditArticle(Article article);

        void DeleteArticle(Article article);

        void AddComment(string username, string content, Guid articleId);
    }
}
