using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NetWorth.Domain.Entities;
using NetWorth.Persistence;

namespace NetWorth.Application.Factors.Commands.CreateFactor
{
    public class CreateFactorCommandHandler : IRequestHandler<CreateFactorCommand, long>
    {
        private readonly NetWorthContext _context;

        public CreateFactorCommandHandler(NetWorthContext context)
        {
            _context = context;
        }

        public async Task<long> Handle(CreateFactorCommand request, CancellationToken cancellationToken)
        {
            NWFactor entity;
            if(request.IsAsset)
            {
                entity = new Asset
                {
                    Id = request.Id,
                    Name = request.Name,
                    CurrentValue = request.CurrentValue,
                    HasInterest = request.HasInterest,
                    InterestRate = request.InterestRate,
                    Type = request.Type,
                    UserID = request.UserID
                };
                _context.Factors.Add((Asset)entity);
            }
            else
            {
                entity = new Liability
                {
                    Id = request.Id,
                    Name = request.Name,
                    CurrentValue = request.CurrentValue,
                    HasInterest = request.HasInterest,
                    InterestRate = request.InterestRate,
                    Type = request.Type,
                    UserID = request.UserID
                };
                _context.Factors.Add((Liability)entity);
            }

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}