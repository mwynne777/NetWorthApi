using NetWorth.Application.Interfaces;
using NetWorth.Application.Notifications.Models;
using System.Threading.Tasks;

namespace NetWorth.Infrastructure
{
    public class NotificationService : INotificationService
    {
        public Task SendAsync(Message message)
        {
            return Task.CompletedTask;
        }
    }
}
