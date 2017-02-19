using System;
using System.Collections.Generic;
using TravelGuide.Models.Store;

namespace TravelGuide.Services.Store.Contracts
{
    public interface IStoreService
    {
        IEnumerable<StoreItem> GetAllNotDeletedStoreItemsOrderedByDate();

        StoreItem GetStoreItemById(Guid id);        
        
        void DeleteItem(StoreItem item);

        void AddNewItem(string itemName, string description, string destFor, string imageUrl, string brand, double price);

        void ChangeStatus(StoreItem item);
    }
}
