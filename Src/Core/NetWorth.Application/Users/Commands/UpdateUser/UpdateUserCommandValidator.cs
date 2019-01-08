using FluentValidation;
using FluentValidation.Validators;

namespace NetWorth.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).NotEmpty();
            RuleFor(x => x.FirstName).MaximumLength(20).NotEmpty();
            RuleFor(x => x.LastName).MaximumLength(20).NotEmpty();
            RuleFor(x => x.UserName).MaximumLength(20).NotEmpty();
            RuleFor(x => x.Password).MaximumLength(20).NotEmpty();
        }
    }
}