using Microsoft.EntityFrameworkCore;
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

        public async Task<User> GetUserIdFromMail(string userEmail, string password)
        {
            var user = _context.Users.Where(x => x.Email == userEmail && x.Password == password);
            if (user == null)
                throw new ArgumentException("With given values, user couldn't be found");
            return await _context.Users.Where(x => x.Email == userEmail && x.Password == password).FirstAsync();
        }
    }
}