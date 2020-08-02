using RiSAT.Eshop.Application.Notifications.Models;
using System.Threading.Tasks;

namespace RiSAT.Eshop.Application.Common.Interfaces
{
    public interface INotificationService
    {
        Task SendAsync(MessageDto message);
    }
}
