using CSMS.Entity.IdentityAccess;

namespace CSMS.Entity.Notification;

public class PushNotification
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public string Token { get; set; }
    public string AppUserId { get; set; }
    public User AppUser { get; set; }
    public DateTime SentDate { get; set; }
    public bool IsRead { get; set; }
}