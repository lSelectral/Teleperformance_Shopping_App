using AutoMapper;
using Teleperformance_Shopping.API.DTOs;
using Teleperformance_Shopping.API.Repositories.BaseRepository;

namespace Teleperformance_Shopping.API.Services.Commands
{
    public class UpdateGeneric<TEntity, TUpdateModel> where TEntity : class where TUpdateModel : class
    {
        private readonly IBaseRepository<TEntity> _repository;
        private readonly TUpdateModel _model;
        private readonly IMapper _mapper;

        public UpdateGeneric(IBaseRepository<TEntity> repository, IMapper mapper, TUpdateModel model)
        {
            _repository = repository;
            _model = model;
            _mapper = mapper;
        }
        public async Task<ResponseDto<NoContent>> Handle()
        {
            await _repository.Update(_mapper.Map<TEntity>(_model));
            return ResponseDto<NoContent>.Success(204);
        }
    }
}