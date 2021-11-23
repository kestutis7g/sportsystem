using Microsoft.EntityFrameworkCore;
using SportSystemAPI.Model;

namespace SportSystemAPI.Context
{
    public class SportSystemContext : DbContext
    {
        public SportSystemContext(DbContextOptions<SportSystemContext> opt) : base(opt)
        {

        }

        public DbSet<ItemModel> Items { get; set; }
    }
}