using System;
using System.Collections.Generic;
using System.Linq;
using TravelGuide.Data;
using TravelGuide.Models.Requests;
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

        public IEnumerable<Request> GetAllRequests()
        {
            var requests = this.context.Requests.ToList();
            return requests;
        }

        public void ChangeStatus(string id)
        {
            var parsedId = Guid.Parse(id);
            var request = this.context.Requests.Find(parsedId);
            request.Status = "Confirmed!";
            this.context.SaveChanges();
        }
    }
}
