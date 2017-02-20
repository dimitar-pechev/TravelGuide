using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelGuide.Models.Store;
using TravelGuide.Services.Store.Contracts;

namespace TravelGuide.Services.Store
{
    public class CartService : ICartService
    {
        private const string CookieName = "store-items";
        private readonly IStoreService service;

        public CartService(IStoreService service)
        {
            this.service = service;
        }

        public IEnumerable<StoreItem> extractItemsFromCookie(HttpCookie cookie)
        {
            var items = new List<StoreItem>();
            if (cookie == null || cookie.Name != CookieName)
            {
                return items;
            }

            var ids = cookie.Value.Split(',').ToArray();

            foreach (var id in ids)
            {
                var parsedId = Guid.Parse(id);
                var item = this.service.GetStoreItemById(parsedId);
                items.Add(item);
            }

            return items;
        }

        public HttpCookie WriteCookie(HttpCookie cookie, string itemId)
        {
            if (cookie == null || cookie.Name != CookieName)
            {
                cookie = new HttpCookie(CookieName, itemId);
            }
            else
            {
                var temp = cookie.Value;
                cookie.Value = $"{temp},{itemId}";
            }

            cookie.Expires = DateTime.Now.AddDays(7);
            return cookie;
        }

        public HttpCookie DeleteItemFromCookie(HttpCookie cookie, string itemId)
        {
            if (cookie == null || cookie.Name != CookieName)
            {
                throw new ArgumentNullException("Passed cookie cannot be null!");
            }

            var ids = cookie.Value.Split(',').ToList();
            ids.Remove(itemId);
            var cookieContent = string.Join(",", ids);

            cookie.Value = cookieContent;
            return cookie;
        }
    }
}
