using TravelGuide.Data;
using TravelGuide.Services.Factories;
using TravelGuide.Services.GalleryImages;

namespace TravelGuide.Tests.Services.GalleryImages.Mocks
{
    public class ExtendedGalleryImageService : GalleryImageService
    {
        public ExtendedGalleryImageService(ITravelGuideContext context, IGalleryImageFactory imageFactory,
            IGalleryLikeFactory likeFactory, IGalleryCommentFactory commentFactory) 
            : base(context, imageFactory, likeFactory, commentFactory)
        {
        }

        public ITravelGuideContext Context
        {
            get
            {
                return base.context;
            }
        }

        public IGalleryImageFactory ImageFactory
        {
            get
            {
                return base.imageFactory;
            }
        }

        public IGalleryLikeFactory LikeFactory
        {
            get
            {
                return base.likeFactory;
            }
        }

        public IGalleryCommentFactory CommentFactory
        {
            get
            {
                return base.commentFactory;
            }
        }
    }
}
