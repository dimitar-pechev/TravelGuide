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

        public bool AddNewItem(string itemName, string description, string destFor, string imageUrl, string brand, string price)
        {
            double parsedPrice;
            var isParsable = double.TryParse(price, out parsedPrice);

            if (!isParsable)
            {
                return false;
            }

            var item = this.factory.CreateStoreItem(itemName, description, destFor, imageUrl, brand, parsedPrice);
            this.context.StoreItems.Add(item);
            this.context.SaveChanges();
            return true;
        }

        public void ChangeStatus(Guid itemId, string option)
        {
            if (itemId == null)
            {
                throw new ArgumentNullException("Passed store item cannot be null!");
            }

            if (option != "true" && option != "false")
            {
                throw new ArgumentException();
            }

            var status = bool.Parse(option);
            var item = this.context.StoreItems.Find(itemId);
            item.InStock = status;

            this.context.SaveChanges();
        }

        public void DeleteItem(Guid itemId)
        {
            if (itemId == null)
            {
                throw new ArgumentNullException("Passed store item cannot be null!");
            }

            var item = this.context.StoreItems.Find(itemId);

            item.IsDeleted = true;
            this.context.SaveChanges();
        }

        public bool EditItem(StoreItem item, string itemName, string description, string destFor, string imageUrl, string brand, string price)
        {
            double parsedPrice;
            var isParsable = double.TryParse(price, out parsedPrice);

            if (!isParsable)
            {
                return false;
            }

            var storeItem = this.context.StoreItems.Find(item.Id);

            storeItem.ItemName = itemName;
            storeItem.Description = description;
            storeItem.DestinationFor = destFor;
            storeItem.ImageUrl = imageUrl;
            storeItem.Brand = brand;
            storeItem.Price = parsedPrice;

            this.context.SaveChanges();
            return true;
        }

        public IEnumerable<StoreItem> GetAllNotDeletedStoreItemsOrderedByDate()
        {
            var items = this.context.StoreItems
                .Where(x => !x.IsDeleted)
                .OrderByDescending(x => x.CreatedOn)
                .ToList();

            return items;
        }

        public IEnumerable<StoreItem> GetByDestination(string targetDestination)
        {
            var items = this.context.StoreItems
                .Where(x => x.DestinationFor.ToLower().Contains(targetDestination.ToLower()))
                .ToList();

            return items;
        }

        public IEnumerable<StoreItem> GetItemsByKeyword(string keyword)
        {
            if (string.IsNullOrEmpty(keyword) || string.IsNullOrEmpty(keyword.Trim()))
            {
                return this.context.StoreItems.ToList();
            }

            var keywordToLower = keyword.ToLower();
            var items = this.context.StoreItems
                .Where(x => x.Brand.ToLower().Contains(keywordToLower) ||
                x.Description.ToLower().Contains(keywordToLower) ||
                x.DestinationFor.ToLower().Contains(keywordToLower) ||
                x.ItemName.ToLower().Contains(keywordToLower))
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
