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
    public class ShoppingListProductsController :
        CustomControllerBase<
        ShoppingListProduct,
        ShoppingListProductViewModel,
        ShoppingListProductDto,
        ShoppingListProductInsertModel,
        ShoppingListProductUpdateModel
        >
    {
        public ShoppingListProductsController(IMapper mapper, IBaseRepository<ShoppingListProduct> repository, IOptions<TokenData> options) : base(mapper, repository, options)
        {
        }

        [Authorize(Policy = "user")]
        public override Task<IActionResult> Add(ShoppingListProductInsertModel request)
        {
            return base.Add(request);
        }

        [Authorize(Policy = "user")]
        public override Task<IActionResult> Update(ShoppingListProductUpdateModel request)
        {
            return base.Update(request);
        }

        [Authorize(Policy = "user")]
        public override Task<IActionResult> Delete([FromQuery] int id)
        {
            return base.Delete(id);
        }
    }
}