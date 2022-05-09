using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Teleperformance_Shopping.API.DTOs;
using Teleperformance_Shopping.API.Models;
using Teleperformance_Shopping.API.Repositories.BaseRepository;
using Teleperformance_Shopping.API.Repositories.ShoppingListRepository;
using Teleperformance_Shopping.API.Services.Commands;
using Teleperformance_Shopping.API.Services.Queries;
using Teleperformance_Shopping.API.ViewModels;

namespace Teleperformance_Shopping.API.Controllers
{
    public class ShoppingListsController :
        CustomControllerBase<
        ShoppingList,
        ShoppingListViewModel,
        ShoppingListDto,
        ShoppingListInsertModel,
        ShoppingListUpdateModel
        >
    {
        private readonly IShoppingListRepository _shoppingListRepository;

        public ShoppingListsController(IMapper mapper, IBaseRepository<ShoppingList> repository, IOptions<TokenData> options, IShoppingListRepository shoppingListRepository) : base(mapper, repository, options)
        {
            _shoppingListRepository = shoppingListRepository;
        }

        [Authorize(Policy = "user")]
        public override Task<IActionResult> Add(ShoppingListInsertModel request)
        {
            return base.Add(request);
        }
        [Authorize(Policy = "user")]
        public override Task<IActionResult> Update(ShoppingListUpdateModel request)
        {
            return base.Update(request);
        }

        [Authorize(Policy = "user")]
        public override Task<IActionResult> Delete([FromQuery] int id)
        {
            return base.Delete(id);
        }

        [Authorize(Policy = "user")]
        [HttpGet("users/{userId}")]
        public async Task<IActionResult> GetShoppingListsByUserId(int userId)
        {
            var query = new GetShoppingListsByUserIdQuery(_mapper, _shoppingListRepository, userId);
            var response = await query.Handle();
            return CreateActionResult(response);
        }

    }
}