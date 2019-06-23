using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NetWorth.Application.Exceptions;
using NetWorth.Domain.Entities;
using NetWorth.Persistence;

namespace NetWorth.Application.Factors.Commands.UpdateFactor
{
    public class UpdateFactorCommandHandler : IRequestHandler<UpdateFactorCommand, Unit>
    {
        private readonly NetWorthContext _context;

        public UpdateFactorCommandHandler(NetWorthContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateFactorCommand request, CancellationToken cancellationToken)
        {
            NWFactor entity = await _context.Factors.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(NWFactor), request.Id);
            }

            entity.Id = request.Id;
            entity.Name = request.Name;
            entity.CurrentValue = request.CurrentValue;
            entity.HasInterest = request.HasInterest;
            entity.InterestRate = request.InterestRate;
            entity.Type = request.Type;
            entity.UserID = request.UserID;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}