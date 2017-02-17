using System;
using System.Collections.Generic;
using TravelGuide.Models.Articles;

namespace TravelGuide.Services.Contracts
{
    public interface ICommentService
    {
        IEnumerable<ArticleComment> GetAllComments();

        ArticleComment GetCommentById(Guid id);

        void CreateComment(ArticleComment comment);

        void EditComment(ArticleComment comment);

        void DeleteComment(ArticleComment comment);
    }
}
