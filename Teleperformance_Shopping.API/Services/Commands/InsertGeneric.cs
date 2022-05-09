using AutoMapper;
using Teleperformance_Shopping.API.DTOs;
using Teleperformance_Shopping.API.Repositories.BaseRepository;

namespace Teleperformance_Shopping.API.Services.Commands
{
    public class InsertGeneric<TEntity, TInsertModel> where TEntity : class where TInsertModel : class
    {
        private readonly IBaseRepository<TEntity> _repository;
        private readonly IMapper _mapper;
        private readonly TInsertModel _model;
        public InsertGeneric(IBaseRepository<TEntity> repository, IMapper mapper, TInsertModel model)
        {
            _repository = repository;
            _mapper = mapper;
            _model = model;
        }
        public async Task<ResponseDto<int>> Handle()
        {
            var id = await _repository.Save(_mapper.Map<TEntity>(_model));

            return ResponseDto<int>.Success(id, 201);
        }
    }
}