namespace Teleperformance_Shopping.API.Repositories.BaseRepository
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAll();
        Task<T> GetById(int id);
        Task<IReadOnlyList<T>> GetBySearch(string keyword);
        Task<IReadOnlyList<T>> GetByPage(int page, int pageSize);
        Task Save(T entity);
        Task Update(T entity);
        Task Delete(int id);
    }
}
