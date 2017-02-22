using TravelGuide.Data;
using TravelGuide.Services.Factories;
using TravelGuide.Services.Requests;
using TravelGuide.Services.Users.Contracts;

namespace TravelGuide.Tests.Services.Requests.Mocks
{
    public class RequestServiceMock : RequestService
    {
        public RequestServiceMock(ITravelGuideContext context, IUserService userService, IRequestFactory factory)
            : base(context, userService, factory)
        {
        }

        public ITravelGuideContext Context
        {
            get
            {
                return base.context;
            }
        }

        public IUserService UserService
        {
            get
            {
                return base.userService;
            }
        }

        public IRequestFactory Factory
        {
            get
            {
                return base.factory;
            }
        }
    }
}
