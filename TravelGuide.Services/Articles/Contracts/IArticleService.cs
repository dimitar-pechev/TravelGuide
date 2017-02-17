using System;
using System.Collections.Generic;
using TravelGuide.Models.Articles;

namespace TravelGuide.Services.Contracts
{
    public interface IArticleService
    {
        IEnumerable<Article> GetAllArticles();

        Article GetArticleById(Guid id);

        void CreateArticle(string username, string title, string city, string country, string content, string imageUrl);

        void EditArticle(Article article);

        void DeleteArticle(Article article);
    }
}
