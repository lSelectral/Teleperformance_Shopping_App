using AutoMapper;
using Teleperformance_Shopping.API.DTOs;
using Teleperformance_Shopping.API.Repositories.ShoppingListRepository;
using Teleperformance_Shopping.API.ViewModels;

namespace Teleperformance_Shopping.API.Services.Queries
{
    public class GetShoppingListsByUserIdQuery
    {
        private readonly IShoppingListRepository _shoppingListRepository;
        private readonly IMapper _mapper;
        private int _userId;

        public GetShoppingListsByUserIdQuery(IMapper mapper, IShoppingListRepository shoppingListRepository, int userId)
        {
            _mapper = mapper;
            _shoppingListRepository = shoppingListRepository;
            _userId = userId;
        }

        public async Task<ResponseDto<IReadOnlyList<ShoppingListViewModel>>> Handle()
        {
            var response = await _shoppingListRepository.GetShoppingsByUserId(_userId);
            return ResponseDto<IReadOnlyList<ShoppingListViewModel>>
                .Success(_mapper.Map<IReadOnlyList<ShoppingListViewModel>>(response), 200);
        }
    }
}
