using FluentValidation;
namespace Teleperformance_Shopping.API.Models
{
    public class ShoppingListProductUpdateModelValidation : AbstractValidator<ShoppingListProductUpdateModel>
    {
        public ShoppingListProductUpdateModelValidation()
        {
            RuleFor(x => x.ProductId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.ShoppingListId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Amount).NotEmpty().GreaterThan(0);
        }
    }
}
