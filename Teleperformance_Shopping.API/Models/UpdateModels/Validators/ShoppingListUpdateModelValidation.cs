using FluentValidation;

namespace Teleperformance_Shopping.API.Models
{
    public class ShoppingListUpdateModelValidation : AbstractValidator<ShoppingListUpdateModel>
    {
        public ShoppingListUpdateModelValidation()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
            RuleFor(x => x.UserId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Name).NotEmpty().MinimumLength(2);
        }
    }
}
