using FluentValidation;

namespace Teleperformance_Shopping.API.Models
{
    public class UserInsertModelValidation : AbstractValidator<UserInsertModel>
    {
        public UserInsertModelValidation()
        {
            RuleFor(x => x.Email).MinimumLength(10);
            RuleFor(x => x.FirstName).MinimumLength(2);
            RuleFor(x => x.LastName).MinimumLength(2);
            RuleFor(x => x.Password).MinimumLength(8);
        }
    }
}
