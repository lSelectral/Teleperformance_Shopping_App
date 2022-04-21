using AutoMapper;
using Teleperformance_Shopping.API.DBOperations.Queries.Bases.GetAll;
using Teleperformance_Shopping.API.DTOs;
using Teleperformance_Shopping.API.Repositories.ShoppingListRepository;
using Teleperformance_Shopping.API.ViewModels;

namespace Teleperformance_Shopping.API.DBOperations.Queries.ShoppingList.ShoppingListGetAll
{
    public class ShoppingListGetAllQueryHandler : GetAllQueryHandler<ShoppingListViewModel>
    {
        private readonly IShoppingListRepository _shoppingListRepository;
        public ShoppingListGetAllQueryHandler(IMapper mapper, IShoppingListRepository shoppingListRepository) : base(mapper)
        {
            _shoppingListRepository = shoppingListRepository;
        }
        public override async Task<ResponseDto<IReadOnlyList<ShoppingListViewModel>>> Handle(GetAllQuery<ShoppingListViewModel> request, CancellationToken cancellationToken)
        {
            _baseEntities = await _shoppingListRepository.GetAll();
            return await base.Handle(request, cancellationToken);
        }
    }
}
