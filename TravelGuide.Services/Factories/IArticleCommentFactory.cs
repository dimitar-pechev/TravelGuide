using System;
using TravelGuide.Models;
using TravelGuide.Models.Articles;

namespace TravelGuide.Services.Factories
{
    public interface IArticleCommentFactory
    {
        ArticleComment CreateArticleComment(Guid userId, User user, string content, Guid articleId);
    }
}
