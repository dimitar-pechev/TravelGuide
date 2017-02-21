using TravelGuide.Data;
using TravelGuide.Services.Articles;
using TravelGuide.Services.Factories;

namespace TravelGuide.Tests.Services.Articles.Mock
{
    public class ExtendedArticleService : ArticleService
    {
        public ExtendedArticleService(ITravelGuideContext context, IArticleFactory articleFactory, IArticleCommentFactory commentFactory)
            : base(context, articleFactory, commentFactory)
        {
        }

        public ITravelGuideContext Context
        {
            get
            {
                return base.context;
            }
        }

        public IArticleFactory ArticleFactory
        {
            get
            {
                return base.articleFactory;
            }
        }

        public IArticleCommentFactory CommentFactory
        {
            get
            {
                return base.commentFactory;
            }
        }
    }
}
