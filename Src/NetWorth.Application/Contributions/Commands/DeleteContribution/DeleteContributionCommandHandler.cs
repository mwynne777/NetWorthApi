using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NetWorth.Application.Exceptions;
using NetWorth.Domain.Entities;
using NetWorth.Persistence;

namespace NetWorth.Application.Contributions.Commands.DeleteContribution
{
    public class DeleteContributionCommandHandler : IRequestHandler<DeleteContributionCommand>
    {
        private readonly NetWorthContext _context;

        public DeleteContributionCommandHandler(NetWorthContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteContributionCommand request, CancellationToken cancellationToken)
        {
            Contribution entity = await _context.Contributions.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Contribution), request.Id);
            }

            _context.Contributions.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}