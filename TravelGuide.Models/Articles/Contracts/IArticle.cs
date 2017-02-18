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

        string ContentMain { get; set; }

        string ContentMustSee { get; set; }

        string ContentBudgetTips { get; set; }

        string ContentAccomodation { get; set; }

        string Country { get; set; }

        string City { get; set; }

        string PrimaryImageUrl { get; set; }

        string SecondImageUrl { get; set; }

        string ThirdImageUrl { get; set; }

        string CoverImageUrl { get; set; }

        bool IsDeleted { get; set; }

        ICollection<ArticleLike> Likes { get; set; }

        ICollection<ArticleComment> Comments { get; set; }
    }
}
