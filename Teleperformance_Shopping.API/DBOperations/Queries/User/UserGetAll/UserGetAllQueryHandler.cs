using AutoMapper;
using Teleperformance_Shopping.API.DBOperations.Queries.Bases.GetAll;
using Teleperformance_Shopping.API.DTOs;
using Teleperformance_Shopping.API.Repositories.UserRepository;
using Teleperformance_Shopping.API.ViewModels;

namespace Teleperformance_Shopping.API.DBOperations.Queries.User.UserGetAll
{
    public class UserGetAllQueryHandler : GetAllQueryHandler<UserViewModel>
    {
        private readonly IUserRepository _userRepository;
        public UserGetAllQueryHandler(IMapper mapper, IUserRepository userRepository) : base(mapper)
        {
            _userRepository = userRepository;
        }
        public override async Task<ResponseDto<IReadOnlyList<UserViewModel>>> Handle(GetAllQuery<UserViewModel> request, CancellationToken cancellationToken)
        {
            _baseEntities = await _userRepository.GetAll();
            return await base.Handle(request, cancellationToken);
        }
    }
}
