namespace CSMSBE.Infrastructure.Interfaces;

public interface INotificationHubClient
{
    Task ReceiveMessage(string title, string body);
}