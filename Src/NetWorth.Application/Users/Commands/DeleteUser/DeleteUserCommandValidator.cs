using FluentValidation;

namespace NetWorth.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(v => v.Id).GreaterThan(0).NotEmpty();
        }
    }
}