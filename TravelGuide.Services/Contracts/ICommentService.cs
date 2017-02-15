using System;
using System.Collections.Generic;
using TravelGuide.Models;

namespace TravelGuide.Services.Contracts
{
    public interface ICommentService
    {
        IEnumerable<Comment> GetAllComments();

        Comment GetCommentById(Guid Id);

        void CreateComment(Comment comment);

        void EditComment(Comment comment);

        void DeleteComment(Comment comment);
    }
}
