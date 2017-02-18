using System;
using System.Collections.Generic;

namespace TravelGuide.Models.Articles.Contracts
{
    public interface IArticle
    {
        Guid Id { get; set; }

        Guid UserId { get; set; }

        User User { get; set; }

        string Title { get; set; }

        DateTime CreatedOn { get; set; }

        string Content { get; set; }

        string Country { get; set; }

        string City { get; set; }

        string ImageUrl { get; set; }

        bool IsDeleted { get; set; }

        ICollection<ArticleLike> Likes { get; set; }

        ICollection<ArticleComment> Comments { get; set; }
    }
}
