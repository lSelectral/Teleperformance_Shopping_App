using AutoMapper;
using Teleperformance_Shopping.API.DTOs;
using Teleperformance_Shopping.API.Repositories.BaseRepository;

namespace Teleperformance_Shopping.API.Services.Queries
{
    public class GetBySearchGeneric<TEntity, TViewModel> where TEntity : class where TViewModel : class
    {
        private readonly IBaseRepository<TEntity> _repository;
        private readonly IMapper _mapper;
        private readonly string _keyword;
        public GetBySearchGeneric(IBaseRepository<TEntity> repository, IMapper mapper, string keyword)
        {
            _repository = repository;
            _mapper = mapper;
            _keyword = keyword;
        }

        public async Task<ResponseDto<IReadOnlyList<TViewModel>>> Handle()
        {
            var response = await _repository.GetBySearch(_keyword);
            return ResponseDto<IReadOnlyList<TViewModel>>.Success(_mapper.Map<IReadOnlyList<TViewModel>>(response), 200);
        }
    }
}