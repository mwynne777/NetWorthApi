using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NetWorth.Application.Exceptions;
using NetWorth.Domain.Entities;
using NetWorth.Persistence;

namespace NetWorth.Application.Users.Commands.UpdateUser
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly NetWorthContext _context;

        public UpdateCustomerCommandHandler(NetWorthContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Users
                .SingleAsync(c => c.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }

            entity.Id = request.Id;
            entity.FirstName = request.FirstName;
            entity.LastName = request.LastName;
            entity.UserName = request.UserName;
            entity.Password = request.Password;

            _context.Users.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}