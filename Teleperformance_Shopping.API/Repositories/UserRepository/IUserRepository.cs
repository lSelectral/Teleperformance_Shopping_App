using Teleperformance_Shopping.API.Models;
using Teleperformance_Shopping.API.Repositories.BaseRepository;

namespace Teleperformance_Shopping.API.Repositories.UserRepository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetUserIdFromMail(string userEmail, string password);
    }
}
