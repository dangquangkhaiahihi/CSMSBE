using CSMSBE.Infrastructure.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace CSMSBE.Infrastructure.Implements;

public class NotificationHub : Hub<INotificationHubClient>
{
    public async Task SendNotification(string message)
    {
        await Clients.All.SendNotification(message);
    }
}