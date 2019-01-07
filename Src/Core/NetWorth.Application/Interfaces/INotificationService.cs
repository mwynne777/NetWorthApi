using NetWorth.Application.Notifications.Models;
using System.Threading.Tasks;

namespace NetWorth.Application.Interfaces
{
    public interface INotificationService
    {
        Task SendAsync(Message message);
    }
}