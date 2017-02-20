using System;
using TravelGuide.Models;
using TravelGuide.Models.Requests;
using TravelGuide.Models.Store;

namespace TravelGuide.Services.Factories
{
    public interface IRequestFactory
    {
        Request CreateRequest(Guid itemId, StoreItem item, Guid userId, User user,
            string firstName, string lastName, string phone, string address);
    }
}
