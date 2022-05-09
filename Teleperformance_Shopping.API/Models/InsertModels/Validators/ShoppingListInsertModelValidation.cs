using FluentValidation;

namespace Teleperformance_Shopping.API.Models
{
    public class ShoppingListInsertModelValidation : AbstractValidator<ShoppingListInsertModel>
    {
        public ShoppingListInsertModelValidation()
        {
            RuleFor(x => x.Name).MinimumLength(2);
            RuleFor(x => x.UserId).GreaterThan(0);
        }
    }
}
