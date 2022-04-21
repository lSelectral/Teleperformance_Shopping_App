using Microsoft.EntityFrameworkCore;
using Teleperformance_Shopping.API.Models;

namespace Teleperformance_Shopping.API.Core
{
    public class ShoppingDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingList> ShoppingLists { get; set; }
        public DbSet<Category> Categories { get; set; }

        public ShoppingDbContext(DbContextOptions<ShoppingDbContext> options) : base(options) { }
    }
}
