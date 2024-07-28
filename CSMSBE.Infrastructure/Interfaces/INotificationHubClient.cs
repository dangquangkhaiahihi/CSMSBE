namespace CSMSBE.Infrastructure.Interfaces;

public interface INotificationHubClient
{
    Task SendNotification(string message);
}