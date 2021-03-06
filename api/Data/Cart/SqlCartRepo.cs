using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportSystemAPI.Model;
using Microsoft.EntityFrameworkCore;
using SportSystemAPI.Context;

namespace SportSystemAPI.Data.Cart
{
    public class SqlCartRepo : ICartRepo
    {
        public SqlCartRepo(SportSystemContext context)
        {
            _context = context;
        }
        private readonly SportSystemContext _context;

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CartModel>> GetCartListAsync()
        {
            var cartList = _context.Carts.ToList();

            return await Task.FromResult(cartList);
        }
        public async Task<IEnumerable<CartModel>> GetCartListByIdAsync(int id)
        {
            var cart = _context.Carts.Where(x => x.UserId == id).ToList();

            return await Task.FromResult(cart);
        }


        public async Task CreateCartAsync(CartModel cartModel)
        {
            CartModel cart = await _context.Carts.FirstOrDefaultAsync(x => x.ItemId == cartModel.ItemId && x.UserId == cartModel.UserId);
            if (cart is null)
            {
                await _context.Carts.AddAsync(cartModel);
            }
            else
            {
                cart.Quantity += cartModel.Quantity;
            }
        }

        public async Task UpdateCartAsync(CartModel cartModel)
        {
            await Task.CompletedTask;
        }

        public async Task DeleteCartAsync(int id)
        {
            CartModel cart = await _context.Carts.FirstOrDefaultAsync(x => x.Id == id);
            if (cart is null)
            {
                throw new ArgumentException(nameof(cart));
            }
            await Task.FromResult(_context.Carts.Remove(cart));

        }

    }
}