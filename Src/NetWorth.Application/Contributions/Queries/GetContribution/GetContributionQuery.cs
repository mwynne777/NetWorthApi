using MediatR;

namespace NetWorth.Application.Contributions.Queries.GetContribution
{
    public class GetContributionQuery : IRequest<ContributionViewModel>
    {
        public long Id { get; set; }
    }
}