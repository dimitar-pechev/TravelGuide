using System;
using TravelGuide.Data;
using TravelGuide.Models.Store;
using TravelGuide.Services.Factories;
using TravelGuide.Services.Requests.Contracts;
using TravelGuide.Services.Users.Contracts;

namespace TravelGuide.Services.Requests
{
    public class RequestService : IRequestService
    {
        private readonly ITravelGuideContext context;
        private readonly IUserService userService;
        private readonly IRequestFactory factory;

        public RequestService(ITravelGuideContext context, IUserService userService, IRequestFactory factory)
        {
            this.context = context;
            this.userService = userService;
            this.factory = factory;
        }

        public void MakeRequest(StoreItem item, string username, string firstName, string lastName, string phone, string address)
        {
            var user = this.userService.GetByUsername(username);
            var request = this.factory.CreateRequest(item.Id, item, Guid.Parse(user.Id), user, firstName, lastName, phone, address);

            this.context.Requests.Add(request);
            this.context.SaveChanges();
        }
    }
}
