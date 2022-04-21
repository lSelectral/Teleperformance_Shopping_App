using AutoMapper;
using Teleperformance_Shopping.API.DBOperations.Queries.Bases.GetById;
using Teleperformance_Shopping.API.DTOs;
using Teleperformance_Shopping.API.Repositories.CategoryRepository;
using Teleperformance_Shopping.API.ViewModels;

namespace Teleperformance_Shopping.API.DBOperations.Queries.Category.CategoryGetById
{
    public class CategoryGetByIdHandler : GetByIdQueryHandler<CategoryViewModel>
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryGetByIdHandler(IMapper mapper, ICategoryRepository categoryRepository) : base(mapper)
        {
            _categoryRepository = categoryRepository;
        }
        public override async Task<ResponseDto<CategoryViewModel>> Handle(GetByIdQuery<CategoryViewModel> request, CancellationToken cancellationToken)
        {
            _baseEntity = await _categoryRepository.GetById(request.Id);
            return await base.Handle(request, cancellationToken);
        }
    }
}
