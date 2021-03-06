﻿using System;
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
        protected readonly ITravelGuideContext context;
        protected readonly IStoreItemFactory factory;

        public StoreService(ITravelGuideContext context, IStoreItemFactory factory)
        {
            if (context == null)
            {
                throw new ArgumentNullException();
            }

            if (factory == null)
            {
                throw new ArgumentNullException();
            }

            this.context = context;
            this.factory = factory;
        }

        public bool AddNewItem(string itemName, string description, string destFor, string imageUrl, string brand, string price)
        {
            if (string.IsNullOrEmpty(itemName))
            {
                throw new ArgumentNullException();
            }

            if (string.IsNullOrEmpty(description))
            {
                throw new ArgumentNullException();
            }

            if (string.IsNullOrEmpty(destFor))
            {
                throw new ArgumentNullException();
            }

            if (string.IsNullOrEmpty(imageUrl))
            {
                throw new ArgumentNullException();
            }

            if (string.IsNullOrEmpty(brand))
            {
                throw new ArgumentNullException();
            }

            if (string.IsNullOrEmpty(price))
            {
                throw new ArgumentNullException();
            }

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
            if (option != "true" && option != "false")
            {
                throw new ArgumentException();
            }

            var status = bool.Parse(option);
            var item = this.context.StoreItems.Find(itemId);

            if (item == null)
            {
                throw new InvalidOperationException();
            }

            item.InStock = status;

            this.context.SaveChanges();
        }

        public void DeleteItem(Guid itemId)
        {
            var item = this.context.StoreItems.Find(itemId);

            if (item == null)
            {
                throw new InvalidOperationException();
            }

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

            if (storeItem == null)
            {
                throw new InvalidOperationException();
            }

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
                return this.context.StoreItems.Where(x => !x.IsDeleted).ToList();
            }

            var keywordToLower = keyword.ToLower();
            var items = this.context.StoreItems
                .Where(x => x.Brand.ToLower().Contains(keywordToLower) ||
                x.Description.ToLower().Contains(keywordToLower) ||
                x.DestinationFor.ToLower().Contains(keywordToLower) ||
                x.ItemName.ToLower().Contains(keywordToLower))
                .Where(x => !x.IsDeleted)
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
