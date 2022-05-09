using FluentValidation;

namespace Teleperformance_Shopping.API.Models
{
    public class CategoryUpdateModelValidation : AbstractValidator<CategoryUpdateModel>
    {
        public CategoryUpdateModelValidation()
        {
            RuleFor(c => c.Name).NotEmpty().MinimumLength(2);
        }
    }
}
