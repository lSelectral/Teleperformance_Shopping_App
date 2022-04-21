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
    public class ProductsController :
        CustomControllerBase<Product, ProductViewModel,
            ProductDto, ProductInsertModel, ProductUpdateModel>
    {
        private readonly IProductRepository _productRepository;
        public ProductsController(IMapper mapper, IBaseRepository<Product> repository, IProductRepository productRepository)
            : base(mapper, repository, productRepository)
        {
            _productRepository = productRepository;
        }

        //public async override Task<IActionResult> Add(ProductInsertModel request)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var insertCommand = new InsertProduct(_productRepository, request, _mapper);
        //        var response = await insertCommand.Handle();
        //        return CreateActionResult(response);
        //    }
        //    return CreateActionResult(ResponseDto<NoContent>.Fail("Inputs are not valid", 404));
        //}
    }
}