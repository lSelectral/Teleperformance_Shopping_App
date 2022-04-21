using AutoMapper;
using Teleperformance_Shopping.API.DTOs;
using Teleperformance_Shopping.API.Repositories.BaseRepository;
using Teleperformance_Shopping.API.Repositories.ProductRepository;

namespace Teleperformance_Shopping.API.Services.Queries
{
    public class GetAllGeneric<TEntity, TViewModel> where TEntity : class where TViewModel : class
    {
        private readonly IBaseRepository<TEntity> _repository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetAllGeneric(IBaseRepository<TEntity> repository, IMapper mapper, IProductRepository productRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<ResponseDto<IReadOnlyList<TViewModel>>> Handle()
        {
            var response = await _repository.GetAll();
            return ResponseDto<IReadOnlyList<TViewModel>>.Success(_mapper.Map<IReadOnlyList<TViewModel>>(response), 200);
        }
    }
}