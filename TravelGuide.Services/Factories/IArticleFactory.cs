using System;
using TravelGuide.Models;
using TravelGuide.Models.Articles;

namespace TravelGuide.Services.Factories
{
    public interface IArticleFactory
    {
        Article CreateArticle(User user, Guid userId, string title, string city, string country, string content, string imageUrl);
    }
}
