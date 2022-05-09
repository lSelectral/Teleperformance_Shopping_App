using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        [Authorize(Roles = "admin")]
        public override Task<IActionResult> Add(ProductInsertModel request)
        {
            return base.Add(request);
        }
        [Authorize(Roles = "admin")]
        public override Task<IActionResult> Update(ProductUpdateModel request)
        {
            return base.Update(request);
        }
        [Authorize(Roles = "admin")]
        public override Task<IActionResult> Delete([FromQuery] int id)
        {
            return base.Delete(id);
        }
    }
}