using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Teleperformance_Shopping.API.DTOs;
using Teleperformance_Shopping.API.Models;
using Teleperformance_Shopping.API.Repositories.BaseRepository;
using Teleperformance_Shopping.API.Services.AuthenticationServices;
using Teleperformance_Shopping.API.ViewModels;

namespace Teleperformance_Shopping.API.Controllers
{
    public class UsersController : CustomControllerBase<User, UserViewModel, UserDto, UserInsertModel, UserUpdateModel>
    {
        public UsersController(IMapper mapper, IBaseRepository<User> repository, IOptions<TokenData> options) : base(mapper, repository, options)
        {
        }

        [AllowAnonymous]
        [HttpPost("auth")]
        public async Task<IActionResult> Login(UserAuthorizationObjectDto user)
        {
            string token = GetJWTSecurityTokenService.GetJWTSecurityTokenSerialized(user, _tokenData);
            //await HttpContext.SignInAsync(GetJWTSecurityTokenService.GetClaimsPrincipal(user), 
            //    new AuthenticationProperties() { AllowRefresh = true, IsPersistent = true});
            return CreateActionResult(ResponseDto<string>.Success(token, 201));
        }

        // Register user
        [AllowAnonymous]
        public override Task<IActionResult> Add(UserInsertModel request)
        {
            return base.Add(request);
        }
    }
}