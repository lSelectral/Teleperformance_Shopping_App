﻿using Teleperformance_Shopping.API.Core;
using Teleperformance_Shopping.API.Models;
using Teleperformance_Shopping.API.Repositories.BaseRepository;

namespace Teleperformance_Shopping.API.Repositories.ShoppingListRepository
{
    public class ShoppingListRepository : BaseRepository<ShoppingList>, IShoppingListRepository
    {
        public ShoppingListRepository(ShoppingDbContext context) : base(context)
        {
        }
    }
}