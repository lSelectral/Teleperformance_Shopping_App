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
    public class UsersController : CustomControllerBase<User, UserViewModel, UserDto, UserInsertModel, UserUpdateModel>
    {
        public UsersController(IMapper mapper, IBaseRepository<User> repository, IProductRepository productRepository)
            : base(mapper, repository, productRepository)
        {
        }
    }
}
