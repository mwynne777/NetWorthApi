using MediatR;
using NetWorth.Application.Interfaces;
using NetWorth.Application.Notifications.Models;
using System.Threading;
using System.Threading.Tasks;

namespace NetWorth.Application.Users.Commands.CreateUser
{
    public class UserCreated : INotification
    {
        public long Id { get; set; }

        public class UserCreatedHandler : INotificationHandler<UserCreated>
        {
            private readonly INotificationService _notification;

            public UserCreatedHandler(INotificationService notification)
            {
                _notification = notification;
            }

            public async Task Handle(UserCreated notification, CancellationToken cancellationToken)
            {
                await _notification.SendAsync(new Message());
            }
        }
    }
}