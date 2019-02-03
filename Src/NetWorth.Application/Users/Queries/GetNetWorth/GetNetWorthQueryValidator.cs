using FluentValidation;

namespace NetWorth.Application.Users.Queries.GetNetWorth
{
    public class GetNetWorthQueryValidator : AbstractValidator<GetNetWorthQuery>
    {
        public GetNetWorthQueryValidator()
        {
            RuleFor(v => v.Id).GreaterThan(0).NotEmpty();

            RuleFor(v => v.FutureDate).NotEmpty();
        }
    }
}