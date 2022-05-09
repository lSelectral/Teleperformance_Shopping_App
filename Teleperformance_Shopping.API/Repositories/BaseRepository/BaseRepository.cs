using Microsoft.EntityFrameworkCore;
using Teleperformance_Shopping.API.Core;
using Teleperformance_Shopping.API.Models;

namespace Teleperformance_Shopping.API.Repositories.BaseRepository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly ShoppingDbContext _context;

        public BaseRepository(ShoppingDbContext context)
        {
            _context = context;
        }
        public virtual async Task<IReadOnlyList<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> GetBySearch(string keyword)
        {
            return await _context.Set<T>().Where(x => x.Name.Contains(keyword)).ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetByPage(int page, int pageSize)
        {
            return await _context.Set<T>().Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public virtual async Task<int> Save(T entity)
        {
            var q = _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public virtual async Task Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public virtual async Task Delete(int id)
        {
            var deleted = _context.Set<T>().Where(x => x.Id == id);
            if (deleted.Count() == 0)
                throw new ArgumentOutOfRangeException("404", $"Element with ID {id} isn't exist");
            _context.Set<T>().Remove(deleted.First());
            await _context.SaveChangesAsync();
        }
    }
}
