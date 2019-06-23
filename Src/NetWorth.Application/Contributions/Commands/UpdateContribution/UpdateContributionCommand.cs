using MediatR;
using NetWorth.Domain.Entities;

namespace NetWorth.Application.Contributions.Commands.UpdateContribution
{
    public class UpdateContributionCommand : IRequest
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public double Amount { get; set; }

        public long FactorID { get; set; }
    }
}