using System;
using System.Collections.Generic;
using net5_catalog.Entities;

namespace net5_catalog.Repositories
{
    public interface IItemsRepository
    {
        Item GetItem(Guid id);
        IEnumerable<Item> GetItems();
        void CreateItem(Item item);
        void UpdateItem(Item item);
         void DeleteItem(Guid id);
    }
}