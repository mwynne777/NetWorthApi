using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NetWorth.Application.Interfaces;
using NetWorth.Domain.Entities;
using NetWorth.Persistence;

namespace NetWorth.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public class Handler : IRequestHandler<CreateUserCommand, Unit>
        {
            private readonly NetWorthContext _context;
            private readonly INotificationService _notificationService;
            private readonly IMediator _mediator;

            public Handler(
                NetWorthContext context,
                INotificationService notificationService,
                IMediator mediator)
            {
                _context = context;
                _notificationService = notificationService;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                var entity = new User
                {
                    Id = request.Id,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    UserName = request.UserName,
                    Password = request.Password,
                };

                _context.Users.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                await _mediator.Publish(new UserCreated { Id = entity.Id });

                return Unit.Value;
            }
        }
    }
}