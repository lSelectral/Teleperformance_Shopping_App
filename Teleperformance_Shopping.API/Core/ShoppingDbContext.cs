using Microsoft.EntityFrameworkCore;
using Teleperformance_Shopping.API.Models;

namespace Teleperformance_Shopping.API.Core
{
    public class ShoppingDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingList> ShoppingLists { get; set; }
        public DbSet<ShoppingListProduct> ShoppingListProducts { get; set; }
        public DbSet<Category> Categories { get; set; }

        public ShoppingDbContext(DbContextOptions<ShoppingDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
             * UNIQUE DECLEAREATION
             */
            modelBuilder.Entity<User>(u => u.HasIndex(x => x.Email).IsUnique());
            modelBuilder.Entity<Category>(u => u.HasIndex(x => x.Name).IsUnique());
            modelBuilder.Entity<Product>(u => u.HasIndex(x => x.Name).IsUnique());

            /*
             * DEFAULT VALUES
             */
            modelBuilder.Entity<User>(u => u.Property(x => x.IsAdmin).HasDefaultValue(false));
            modelBuilder.Entity<ShoppingList>(u => u.Property(x => x.IsEditable).HasDefaultValue(true));

            /*
             * REQUIRED PROPERTIES
             */
            modelBuilder.Entity<Category>(u => u.Property(x => x.Name).IsRequired());

            modelBuilder.Entity<Product>(u => u.Property(x => x.Name).IsRequired());
            modelBuilder.Entity<Product>(u => u.Property(x => x.Price).IsRequired());
            modelBuilder.Entity<Product>(u => u.Property(x => x.CategoryId).IsRequired());
            modelBuilder.Entity<Product>(u => u.Property(x => x.Color).IsRequired());
            modelBuilder.Entity<Product>(u => u.Property(x => x.Description).IsRequired());

            modelBuilder.Entity<ShoppingList>(u => u.Property(x => x.Name).IsRequired());
            modelBuilder.Entity<ShoppingList>(u => u.Property(x => x.UserId).IsRequired());

            modelBuilder.Entity<ShoppingListProduct>(u => u.Property(x => x.ProductId).IsRequired());
            modelBuilder.Entity<ShoppingListProduct>(u => u.Property(x => x.ShoppingListId).IsRequired());
            modelBuilder.Entity<ShoppingListProduct>(u => u.Property(x => x.Amount).IsRequired());

            modelBuilder.Entity<User>(u => u.Property(x => x.FirstName).IsRequired());
            modelBuilder.Entity<User>(u => u.Property(x => x.LastName).IsRequired());
            modelBuilder.Entity<User>(u => u.Property(x => x.Email).IsRequired());
            modelBuilder.Entity<User>(u => u.Property(x => x.Password).IsRequired());
        }
    }
}