using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportSystemAPI.Model;
using Microsoft.EntityFrameworkCore;
using SportSystemAPI.Context;

namespace SportSystemAPI.Data.Item
{
    public class SqlItemRepo : IItemRepo
    {
        public SqlItemRepo(SportSystemContext context)
        {
            _context = context;
        }
        private readonly SportSystemContext _context;

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ItemModel>> GetItemListAsync()
        {
            var itemList = _context.Items.ToList();

            return await Task.FromResult(itemList);
        }
        public async Task<ItemModel> GetItemByIdAsync(int id)
        {
            ItemModel item = await _context.Items.FirstOrDefaultAsync(x => x.Id == id);

            return item;
        }

        public async Task<ItemModel> GetItemByNameAsync(string name)
        {
            ItemModel item = await _context.Items.FirstOrDefaultAsync(x => x.Name == name);

            return item;
        }

        public async Task<List<ItemModel>> GetItemListByUserIdAsync(int userId)
        {
            List<ItemModel> itemList = new List<ItemModel>();
            var itemListByUser = _context.Carts.Where(x => x.UserId == userId).ToList();
            foreach (var item in itemListByUser)
            {
                var temp = await GetItemByIdAsync(item.ItemId);
                temp.Quantity = item.Quantity;
                temp.Id = item.Id;
                itemList.Add(temp);
            }
            //var itemList = await _context.Items.Where(x => x.Id.Contains(itemListByUser));

            return await Task.FromResult(itemList);
        }

        public async Task CreateItemAsync(ItemModel itemModel)
        {
            await _context.Items.AddAsync(itemModel);
        }

        public async Task UpdateItemAsync(ItemModel itemModel)
        {
            await Task.CompletedTask;
        }

        public async Task DeleteItemAsync(ItemModel item)
        {
            if (item is null)
            {
                throw new ArgumentException(nameof(item));
            }
            await Task.FromResult(_context.Items.Remove(item));

        }

    }
}