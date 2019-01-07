using FluentValidation;

namespace NetWorth.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).NotEmpty();
            RuleFor(x => x.FirstName).MaximumLength(20).NotEmpty();
            RuleFor(x => x.LastName).MaximumLength(20).NotEmpty();
            RuleFor(x => x.UserName).MaximumLength(40).NotEmpty();
            RuleFor(x => x.Password).MaximumLength(30).NotEmpty();
        }
    }
}