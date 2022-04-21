using AutoMapper;
using Teleperformance_Shopping.API.DTOs;
using Teleperformance_Shopping.API.Repositories.ProductRepository;
using Teleperformance_Shopping.API.Services.Commands.InsertModels;

namespace Teleperformance_Shopping.API.Services.Commands
{
    public class InsertProduct
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ProductInsertModel _model;
        public InsertProduct(IProductRepository productRepository, ProductInsertModel model, IMapper mapper)
        {
            _productRepository = productRepository;
            _model = model;
            this._mapper = mapper;
        }

        public async Task<ResponseDto<NoContent>> Handle()
        {
            await _productRepository.SaveProduct(_model);
            return ResponseDto<NoContent>.Success(204);
        }
    }
}