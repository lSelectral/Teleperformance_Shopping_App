using AutoMapper;
using Teleperformance_Shopping.API.DTOs;
using Teleperformance_Shopping.API.Models;
using Teleperformance_Shopping.API.Repositories.BaseRepository;
using Teleperformance_Shopping.API.Repositories.ProductRepository;
using Teleperformance_Shopping.API.Services.Commands.InsertModels;
using Teleperformance_Shopping.API.Services.Commands.UpdateModels;
using Teleperformance_Shopping.API.ViewModels;

namespace Teleperformance_Shopping.API.Controllers
{
    public class CategoriesController :
        CustomControllerBase<Category, CategoryViewModel,
        CategoryDto, CategoryInsertModel, CategoryUpdateModel>
    {
        public CategoriesController(IMapper mapper, IBaseRepository<Category> repository, IProductRepository productRepository)
            : base(mapper, repository, productRepository)
        {
        }
    }
}
