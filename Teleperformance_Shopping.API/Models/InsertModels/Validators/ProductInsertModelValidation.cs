using FluentValidation;

namespace Teleperformance_Shopping.API.Models
{
    public class ProductInsertModelValidation : AbstractValidator<ProductInsertModel>
    {
        public ProductInsertModelValidation()
        {
            RuleFor(x => x.Name).MinimumLength(2);
            RuleFor(x => x.Description).MinimumLength(8);
            RuleFor(x => x.Price).GreaterThan(0);
            RuleFor(x => x.CategoryId).GreaterThan(0);
            RuleFor(x => x.Color).MinimumLength(3);
        }
    }
}
