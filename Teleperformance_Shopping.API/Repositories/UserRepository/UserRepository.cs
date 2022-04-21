using Teleperformance_Shopping.API.Core;
using Teleperformance_Shopping.API.Models;
using Teleperformance_Shopping.API.Repositories.BaseRepository;

namespace Teleperformance_Shopping.API.Repositories.UserRepository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ShoppingDbContext context) : base(context)
        {
        }
    }
}
