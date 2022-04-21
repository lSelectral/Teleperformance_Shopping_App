using Teleperformance_Shopping.API.DTOs;
using Teleperformance_Shopping.API.Repositories.BaseRepository;

namespace Teleperformance_Shopping.API.Services.Commands
{
    public class DeleteGeneric<TEntity> where TEntity : class
    {
        private readonly IBaseRepository<TEntity> _repository;
        private readonly int _id;

        public DeleteGeneric(IBaseRepository<TEntity> repository, int id)
        {
            _repository = repository;
            _id = id;
        }
        public async Task<ResponseDto<NoContent>> Handle()
        {
            await _repository.Delete(_id);
            return ResponseDto<NoContent>.Success(204);
        }
    }
}
