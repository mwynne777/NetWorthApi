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
            NWFactor entity;
            if(request.IsAsset)
                entity = await _context.Assets.FindAsync(request.Id);
            else
                entity = await _context.Liabilities.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(NWFactor), request.Id);
            }

            if(request.IsAsset)
                _context.Assets.Remove((Asset)entity);
            else
                _context.Liabilities.Remove((Liability)entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}