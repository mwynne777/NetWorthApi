using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NetWorth.Application.Exceptions;
using NetWorth.Domain.Entities;
using NetWorth.Persistence;

namespace NetWorth.Application.Factors.Commands.DeleteFactor
{
    public class DeleteFactorCommandHandler : IRequestHandler<DeleteFactorCommand>
    {
        private readonly NetWorthContext _context;

        public DeleteFactorCommandHandler(NetWorthContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteFactorCommand request, CancellationToken cancellationToken)
        {
            NWFactor entity = await _context.Factors.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(NWFactor), request.Id);
            }

            _context.Factors.Remove((Liability)entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}