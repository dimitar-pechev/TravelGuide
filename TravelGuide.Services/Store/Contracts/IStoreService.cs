﻿using System;
using System.Collections.Generic;
using TravelGuide.Models.Store;

namespace TravelGuide.Services.Store.Contracts
{
    public interface IStoreService
    {
        IEnumerable<StoreItem> GetAllNotDeletedStoreItemsOrderedByDate();

        IEnumerable<StoreItem> GetItemsByKeyword(string keyword);

        StoreItem GetStoreItemById(Guid id);        
        
        void DeleteItem(StoreItem item);

        bool AddNewItem(string itemName, string description, string destFor, string imageUrl, string brand, string price);

        void ChangeStatus(StoreItem item);

        IEnumerable<StoreItem> GetByDestination(string targetDestination);
    }
}
