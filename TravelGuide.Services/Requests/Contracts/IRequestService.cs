﻿using System.Collections.Generic;
using TravelGuide.Models.Requests;
using TravelGuide.Models.Store;

namespace TravelGuide.Services.Requests.Contracts
{
    public interface IRequestService
    {
        void MakeRequest(StoreItem item, string username, string firstName, string lastName, string phone, string address);

        IEnumerable<Request> GetAllRequests();
    }
}
