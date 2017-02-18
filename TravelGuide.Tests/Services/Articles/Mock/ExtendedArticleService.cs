using TravelGuide.Data;
using TravelGuide.Services.Articles;
using TravelGuide.Services.Factories;

namespace TravelGuide.Tests.Services.Articles.Mock
{
    public class ExtendedArticleService : ArticleService
    {
        public ExtendedArticleService(ITravelGuideContext context, IArticleFactory articleFactory)
            : base(context, articleFactory)
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
    }
}
