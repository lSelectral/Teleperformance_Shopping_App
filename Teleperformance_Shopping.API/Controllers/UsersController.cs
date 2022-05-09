using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Teleperformance_Shopping.API.DTOs;
using Teleperformance_Shopping.API.Models;
using Teleperformance_Shopping.API.Repositories.BaseRepository;
using Teleperformance_Shopping.API.Repositories.UserRepository;
using Teleperformance_Shopping.API.Services.AuthenticationServices;
using Teleperformance_Shopping.API.Services.Queries;
using Teleperformance_Shopping.API.ViewModels;

namespace Teleperformance_Shopping.API.Controllers
{
    public class UsersController : CustomControllerBase<User, UserViewModel, UserDto, UserInsertModel, UserUpdateModel>
    {
        private readonly IUserRepository _userRepository;
        public UsersController(IMapper mapper, IBaseRepository<User> repository, IOptions<TokenData> options, IUserRepository userRepository) : base(mapper, repository, options)
        {
            _userRepository = userRepository;
        }

        [AllowAnonymous]
        [HttpPost("auth")]
        public async Task<IActionResult> Login(UserAuthorizationObjectDto user)
        {
            var getUserIdQuery = new GetUserIdFromEmailQuery(_userRepository, user.Email, user.Password);
            var id = await getUserIdQuery.Handle();
            string token = GetJWTSecurityTokenService.GetJWTSecurityTokenSerialized(user, _tokenData);
            return CreateActionResult(ResponseDto<UserIdTokenViewModel>.Success(new UserIdTokenViewModel()
            {
                Token = token,
                UserId = id.Data
            }, 201));
        }

        // Register user
        [AllowAnonymous]
        public override Task<IActionResult> Add(UserInsertModel request)
        {
            return base.Add(request);
        }

        [Authorize(Policy = "user")]
        public override Task<IActionResult> Update(UserUpdateModel request)
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