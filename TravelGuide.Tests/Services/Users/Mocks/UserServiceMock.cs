using TravelGuide.Data;
using TravelGuide.Services.Users;

namespace TravelGuide.Tests.Services.Users.Mocks
{
    public class UserServiceMock : UserService
    {
        public UserServiceMock(ITravelGuideContext context) : base(context)
        {
        }

        public ITravelGuideContext Context
        {
            get
            {
                return base.context;
            }
        }
    }
}
