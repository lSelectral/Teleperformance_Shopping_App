using AutoMapper;
using Teleperformance_Shopping.API.DBOperations.Queries.Bases.GetAll;
using Teleperformance_Shopping.API.DTOs;
using Teleperformance_Shopping.API.Repositories.CategoryRepository;
using Teleperformance_Shopping.API.ViewModels;

namespace Teleperformance_Shopping.API.DBOperations.Queries.Category.CategoryGetAll
{
    public class CategoryGetAllQueryHandler : GetAllQueryHandler<CategoryViewModel>
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryGetAllQueryHandler(IMapper mapper, ICategoryRepository categoryRepository) : base(mapper)
        {
            _categoryRepository = categoryRepository;
        }

        public override async Task<ResponseDto<IReadOnlyList<CategoryViewModel>>> Handle(GetAllQuery<CategoryViewModel> request, CancellationToken cancellationToken)
        {
            _baseEntities = await _categoryRepository.GetAll();
            return await base.Handle(request, cancellationToken);
        }
    }
}