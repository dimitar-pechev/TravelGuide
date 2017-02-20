﻿using System.Collections.Generic;
using System.Web;
using TravelGuide.Models.Store;

namespace TravelGuide.Services.Store.Contracts
{
    public interface ICartService
    {
        HttpCookie WriteCookie(HttpCookie cookie, string username, string itemId);
        
        IEnumerable<StoreItem> extractItemsFromCookie(HttpCookie cookie);

        HttpCookie DeleteItemFromCookie(HttpCookie cookie, string itemId);

        HttpCookie GetClearedCookie(string username);
    }
}
