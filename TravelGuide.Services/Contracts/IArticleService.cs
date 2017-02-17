using System;
using System.Collections.Generic;
using TravelGuide.Models.Articles;

namespace TravelGuide.Services.Contracts
{
    public interface IArticleService
    {
        IEnumerable<Article> GetAllArticles();

        Article GetArticleById(Guid Id);

        void CreateArticle(Article article);

        void EditArticle(Article article);

        void DeleteArticle(Article article);
    }
}
