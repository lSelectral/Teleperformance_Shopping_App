using Microsoft.EntityFrameworkCore;
using Teleperformance_Shopping.API.Core;
using Teleperformance_Shopping.API.Models;
using Teleperformance_Shopping.API.Repositories.BaseRepository;
using Teleperformance_Shopping.API.Services.Commands.InsertModels;

namespace Teleperformance_Shopping.API.Repositories.ProductRepository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ShoppingDbContext context) : base(context)
        {
        }

        public async Task SaveProduct(ProductInsertModel model)
        {
            Product product = new Product()
            {
                Name = model.Name,
                Price = model.Price,
                Color = model.Color,
                Description = model.Description,
                Category = _context.Categories.Where(x => x.Id == model.CategoryId).First(),
            };
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public override async Task<IReadOnlyList<Product>> GetAll()
        {
            var products = await _context.Products.Include(p => p.Category).ToListAsync();
            return products;
            //var foods = await _context.Food.Include(f => f.Ingredients).ToListAsync();
            //return foods;
        }
    }
}