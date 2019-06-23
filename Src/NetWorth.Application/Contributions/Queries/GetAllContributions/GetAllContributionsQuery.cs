using MediatR;

namespace NetWorth.Application.Contributions.Queries.GetAllContributions
{
    public class GetAllContributionsQuery : IRequest<ContributionsListViewModel>
    {
    }
}