using FluentValidation;

namespace NetWorth.Application.Contributions.Commands.CreateContribution
{
    public class CreateContributionCommandValidator : AbstractValidator<CreateContributionCommand>
    {
        public CreateContributionCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).NotEmpty();
            RuleFor(x => x.Name).MaximumLength(20).NotEmpty();
            RuleFor(x => x.Amount).NotEmpty();
            RuleFor(x => x.FactorID).NotEmpty();
        }
    }
}