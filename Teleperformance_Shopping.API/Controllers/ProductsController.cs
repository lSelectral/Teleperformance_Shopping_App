using AutoMapper;
using Microsoft.Extensions.Options;
using Teleperformance_Shopping.API.DTOs;
using Teleperformance_Shopping.API.Models;
using Teleperformance_Shopping.API.Repositories.BaseRepository;
using Teleperformance_Shopping.API.ViewModels;

namespace Teleperformance_Shopping.API.Controllers
{
    public class ProductsController :
        CustomControllerBase<Product, ProductViewModel,
            ProductDto, ProductInsertModel, ProductUpdateModel>
    {
        public ProductsController(IMapper mapper, IBaseRepository<Product> repository, IOptions<TokenData> options) : base(mapper, repository, options)
        {
        }
    }
}