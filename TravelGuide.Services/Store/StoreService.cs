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
