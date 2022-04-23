using FluentValidation;

namespace Teleperformance_Shopping.API.Models
{
    public class CategoryInsertModelValidation : AbstractValidator<CategoryInsertModel>
    {
        public CategoryInsertModelValidation()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().MinimumLength(2);
        }
    }
}
