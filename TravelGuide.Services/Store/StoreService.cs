using System;
using System.Collections.Generic;
using System.Linq;
using TravelGuide.Data;
using TravelGuide.Models.Store;
using TravelGuide.Services.Factories;
using TravelGuide.Services.Store.Contracts;

namespace TravelGuide.Services.Store
{
    public class StoreService : IStoreService
    {
        private readonly ITravelGuideContext context;
        private readonly IStoreItemFactory factory;

        public StoreService(ITravelGuideContext context, IStoreItemFactory factory)
        {
            this.context = context;
            this.factory = factory;
        }

        public void AddNewItem(string itemName, string description, string destFor, string imageUrl, string brand, double price)
        {
            var item = this.factory.CreateStoreItem(itemName, description, destFor, imageUrl, brand, price);
            this.context.StoreItems.Add(item);
            this.context.SaveChanges();
        }

        public void ChangeStatus(StoreItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Passed store item cannot be null!");
            }

            if (item.InStock)
            {
                item.InStock = false;
            }
            else
            {
                item.InStock = true;
            }

            this.context.SaveChanges();
        }

        public void DeleteItem(StoreItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Passed store item cannot be null!");
            }

            item.IsDeleted = true;
            this.context.SaveChanges();
        }

        public IEnumerable<StoreItem> GetAllNotDeletedStoreItemsOrderedByDate()
        {
            var items = this.context.StoreItems
                .Where(x => !x.IsDeleted)
                .OrderByDescending(x => x.CreatedOn)
                .ToList();

            return items;
        }

        public StoreItem GetStoreItemById(Guid id)
        {
            var item = this.context.StoreItems.Find(id);
            return item;
        }
    }
}
