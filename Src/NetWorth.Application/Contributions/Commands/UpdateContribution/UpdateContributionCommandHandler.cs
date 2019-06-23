using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NetWorth.Application.Exceptions;
using NetWorth.Domain.Entities;
using NetWorth.Persistence;

namespace NetWorth.Application.Contributions.Commands.UpdateContribution
{
    public class UpdateContributionCommandHandler : IRequestHandler<UpdateContributionCommand, Unit>
    {
        private readonly NetWorthContext _context;

        public UpdateContributionCommandHandler(NetWorthContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateContributionCommand request, CancellationToken cancellationToken)
        {
            Contribution entity = await _context.Contributions.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Contribution), request.Id);
            }

            entity.Id = request.Id;
            entity.Name = request.Name;
            entity.Amount = request.Amount;
            entity.FactorID = request.FactorID;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}