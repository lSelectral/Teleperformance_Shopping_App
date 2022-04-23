﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Teleperformance_Shopping.API.DTOs;
using Teleperformance_Shopping.API.Models;
using Teleperformance_Shopping.API.Repositories.BaseRepository;
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
        public ShoppingListsController(IMapper mapper, IBaseRepository<ShoppingList> repository, IOptions<TokenData> options) : base(mapper, repository, options)
        {
        }

        [Authorize(Roles = "User")]
        public override Task<IActionResult> Add(ShoppingListInsertModel request)
        {
            return base.Add(request);
        }

        [Authorize(Roles = "User")]
        public override Task<IActionResult> Delete([FromQuery] int request)
        {
            return base.Delete(request);
        }
    }
}