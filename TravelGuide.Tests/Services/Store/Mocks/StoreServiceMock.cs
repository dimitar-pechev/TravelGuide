using TravelGuide.Data;
using TravelGuide.Services.Factories;
using TravelGuide.Services.Store;

namespace TravelGuide.Tests.Services.Store.Mocks
{
    public class StoreServiceMock : StoreService
    {
        public StoreServiceMock(ITravelGuideContext context, IStoreItemFactory factory)
            : base(context, factory)
        {
        }

        public ITravelGuideContext Context
        {
            get
            {
                return base.context;
            }
        }

        public IStoreItemFactory Factory
        {
            get
            {
                return base.factory;
            }
        }
    }
}
