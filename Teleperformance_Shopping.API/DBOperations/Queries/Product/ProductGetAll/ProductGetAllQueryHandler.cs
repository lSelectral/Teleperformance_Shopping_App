using AutoMapper;
using Teleperformance_Shopping.API.DBOperations.Queries.Bases.GetAll;
using Teleperformance_Shopping.API.DTOs;
using Teleperformance_Shopping.API.Repositories.ProductRepository;
using Teleperformance_Shopping.API.ViewModels;

namespace Teleperformance_Shopping.API.DBOperations.Queries.Product.ProductGetAll
{
    public class ProductGetAllQueryHandler : GetAllQueryHandler<ProductViewModel>
    {
        private readonly IProductRepository _productRepository;
        public ProductGetAllQueryHandler(IMapper mapper, IProductRepository productRepository) : base(mapper)
        {
            _productRepository = productRepository;
        }

        public override async Task<ResponseDto<IReadOnlyList<ProductViewModel>>> Handle(GetAllQuery<ProductViewModel> request, CancellationToken cancellationToken)
        {
            _baseEntities = await _productRepository.GetAll();
            return await base.Handle(request, cancellationToken);
        }
    }
}