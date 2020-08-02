using RiSAT.Eshop.Application.Common.Interfaces;
using RiSAT.Eshop.Application.Notifications.Models;
using System.Threading.Tasks;

namespace RiSAT.Eshop.Infrastructure
{
    public class NotificationService : INotificationService
    {
        public Task SendAsync(MessageDto message)
        {
            return Task.CompletedTask;
        }
    }
}
