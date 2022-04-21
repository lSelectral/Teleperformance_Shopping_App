using Teleperformance_Shopping.API.Models;
using Teleperformance_Shopping.API.Repositories.BaseRepository;
using Teleperformance_Shopping.API.Services.Commands.InsertModels;

namespace Teleperformance_Shopping.API.Repositories.ProductRepository
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task SaveProduct(ProductInsertModel model);
    }
}
