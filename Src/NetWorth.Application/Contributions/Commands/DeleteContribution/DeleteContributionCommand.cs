using MediatR;

namespace NetWorth.Application.Contributions.Commands.DeleteContribution
{
    public class DeleteContributionCommand : IRequest
    {
        public long Id { get; set; }
    }
}