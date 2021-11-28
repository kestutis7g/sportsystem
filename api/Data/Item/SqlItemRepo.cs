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

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public async Task<IEnumerable<ItemModel>> GetItemListAsync()
        {
            var itemList = _context.Items.ToList();

            return itemList;
        }
        public async Task<ItemModel> GetItemByIdAsync(int id)
        {
            var item = _context.Items.FirstOrDefault(x => x.Id == id);

            return item;
        }

        public async Task CreateItemAsync(ItemModel itemModel)
        {
            _context.Items.Add(itemModel);
        }

        public async Task UpdateItemAsync(ItemModel itemModel)
        {
            //nothing to see here
        }
    }
}