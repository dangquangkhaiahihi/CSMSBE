using System.Reactive;
using CSMS.Data.Extensions;
using CSMSBE.Services.PushNotification;

namespace CSMSBE.Services.Interfaces;

public interface IPushNotificationService
{
    Task<Result<IEnumerable<PushNotificationDto>>> GetListNotificationsByUserId(string userId);
    Task<Result<PushNotificationDto>> GetNotificationById(Guid id);
    Task<Result<string>> MarkAsRead(Guid id);
}