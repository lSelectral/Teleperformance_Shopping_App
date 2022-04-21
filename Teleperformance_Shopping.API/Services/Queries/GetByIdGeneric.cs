using AutoMapper;
using Teleperformance_Shopping.API.DTOs;
using Teleperformance_Shopping.API.Repositories.BaseRepository;

namespace Teleperformance_Shopping.API.Services.Queries
{
    public class GetByIdGeneric<TEntity, TViewModel> where TEntity : class where TViewModel : class
    {
        private readonly IBaseRepository<TEntity> _repository;
        private readonly IMapper _mapper;
        private int _id;

        public GetByIdGeneric(IBaseRepository<TEntity> repository, IMapper mapper, int id)
        {
            _repository = repository;
            _mapper = mapper;
            _id = id;
        }
        public async Task<ResponseDto<TViewModel>> Handle()
        {
            var response = await _repository.GetById(_id);
            return ResponseDto<TViewModel>.Success(_mapper.Map<TViewModel>(response), 200);
        }
    }
}
