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
    public class ShoppingListsController :
        CustomControllerBase<
        ShoppingList,
        ShoppingListViewModel,
        ShoppingListDto,
        ShoppingListInsertModel,
        ShoppingListUpdateModel
        >
    {
        public ShoppingListsController(IMapper mapper, IBaseRepository<ShoppingList> repository, IProductRepository productRepository)
            : base(mapper, repository, productRepository)
        {
        }
    }
}