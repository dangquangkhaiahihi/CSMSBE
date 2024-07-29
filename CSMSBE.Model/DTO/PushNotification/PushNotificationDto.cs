namespace CSMSBE.Services.PushNotification;

public class PushNotificationDto
{
    public string Title { get; set; }
    public string Body { get; set; }
    public string Token { get; set; }
    public DateTime SentDate { get; set; }
    public bool IsRead { get; set; }
}