using FluentValidation;

namespace Teleperformance_Shopping.API.Models
{
    public class ShoppingListProductInsertModelValidation : AbstractValidator<ShoppingListProductInsertModel>
    {
        public ShoppingListProductInsertModelValidation()
        {
            RuleFor(x => x.ProductId).GreaterThan(0);
            RuleFor(x => x.ShoppingListId).GreaterThan(0);
            RuleFor(x => x.Amount).GreaterThan(0);
        }
    }
}
