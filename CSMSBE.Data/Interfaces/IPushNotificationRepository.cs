using CSMS.Entity.Notification;

namespace CSMS.Data.Interfaces;

public interface IPushNotificationRepository
{
    Task AddNotificationAsync(PushNotification pushNotification);
    Task<IEnumerable<PushNotification>> GetNotificationsByUserIdAsync(string appUserId, bool trackchanges);
    Task<PushNotification?> GetNotificationByIdAsync(Guid id, bool trackchanges);
    Task MarkAsReadAsync(Guid id);
}