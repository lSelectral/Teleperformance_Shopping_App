using Microsoft.EntityFrameworkCore;
using Teleperformance_Shopping.API.Core;
using Teleperformance_Shopping.API.Models;
using Teleperformance_Shopping.API.Repositories.BaseRepository;

namespace Teleperformance_Shopping.API.Repositories.ShoppingListProductRepository
{
    public class ShoppingListProductRepository : BaseRepository<ShoppingListProduct>, IShoppingListProductRepository
    {
        public ShoppingListProductRepository(ShoppingDbContext context) : base(context)
        {
        }

        public async Task AddProductToShoppingListCustom(ShoppingListProduct model)
        {
            var checkIfShoppinglistAlreadyHasProduct = await _context.ShoppingLists
                .Where(sl => sl.Id == model.ShoppingListId)
                .Select(x => x.Products
                .Where(p => p.Id == model.ProductId)).FirstAsync();

            if (checkIfShoppinglistAlreadyHasProduct != null)
            {
                _context.ShoppingListProducts.Add(model);
                await _context.SaveChangesAsync();
            }
            else
            {
                //_context.Entry(entity).State = EntityState.Modified;

                _context.SaveChanges();
            }
        }

        public async Task UpdateCartStatusOfProduct(int shoppingListProductId)
        {
            var product = _context.ShoppingListProducts.Where(x => x.Id == shoppingListProductId).Single();
            _context.ShoppingListProducts.Attach(product);
            product.IsAddedToCart = !product.IsAddedToCart;
            _context.Entry(product).Property(x => x.IsAddedToCart).IsModified = true;
            await _context.SaveChangesAsync();
        }
    }
}
