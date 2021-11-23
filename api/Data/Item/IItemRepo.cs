using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportSystemAPI.Model;

namespace SportSystemAPI.Data.Item
{
    public interface IItemRepo
    {
        bool SaveChanges();
        Task<IEnumerable<ItemModel>> GetItemListAsync();
        Task<ItemModel> GetItemByIdAsync(int id);
        Task CreateItemAsync(ItemModel itemModel);
    }
}