using CSMSBE.Services.PushNotification;

namespace CSMSBE.Services.Interfaces;

public interface IPushNotificationService
{
    Task AddNotification(PushNotificationCreateDto pushNotificationCreate);
    Task<IEnumerable<PushNotificationDto>> GetNotificationsByUserId(string userId, bool trackchanges);
    Task<PushNotificationDto> GetNotificationById(int id, bool trackchanges);
    Task MarkAsRead(int id);
}