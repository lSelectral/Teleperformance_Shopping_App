using Teleperformance_Shopping.API.DTOs;
using Teleperformance_Shopping.API.Repositories.UserRepository;

namespace Teleperformance_Shopping.API.Services.Queries
{
    public class GetUserIdFromEmailQuery
    {
        private readonly IUserRepository _userRepository;
        private string _email;
        private string _password;

        public GetUserIdFromEmailQuery(IUserRepository userRepository, string email, string password)
        {
            _userRepository = userRepository;
            _email = email;
            _password = password;
        }

        public async Task<ResponseDto<int>> Handle()
        {
            var response = await _userRepository.GetUserIdFromMail(_email, _password);
            return ResponseDto<int>.Success(response.Id, 200);
        }
    }
}
