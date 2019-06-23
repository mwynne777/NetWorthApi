using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NetWorth.Domain.Entities;
using NetWorth.Persistence;

namespace NetWorth.Application.Contributions.Commands.CreateContribution
{
    public class CreateContributionCommandHandler : IRequestHandler<CreateContributionCommand, long>
    {
        private readonly NetWorthContext _context;

        public CreateContributionCommandHandler(NetWorthContext context)
        {
            _context = context;
        }

        public async Task<long> Handle(CreateContributionCommand request, CancellationToken cancellationToken)
        {
            Contribution entity = new Contribution
            {
                Id = request.Id,
                Name = request.Name,
                Amount = request.Amount,
                FactorID = request.FactorID
            };
            _context.Contributions.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}