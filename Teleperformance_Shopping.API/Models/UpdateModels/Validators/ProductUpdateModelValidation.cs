using FluentValidation;

namespace Teleperformance_Shopping.API.Models
{
    public class ProductUpdateModelValidation : AbstractValidator<ProductUpdateModel>
    {
        public ProductUpdateModelValidation()
        {
            RuleFor(p => p.Name).NotEmpty().MinimumLength(2);
            RuleFor(p => p.Description).NotEmpty().MinimumLength(2);
            RuleFor(p => p.Price).NotEmpty().GreaterThan(0);
            RuleFor(p => p.Id).NotEmpty().GreaterThan(0);
            RuleFor(p => p.CategoryId).GreaterThan(0);
            RuleFor(p => p.Color).NotEmpty().MinimumLength(2);
        }
    }
}
