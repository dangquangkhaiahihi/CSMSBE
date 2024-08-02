using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PostmarkDotNet;
using PostmarkDotNet.Model;

namespace CSMSBE.Infrastructure.Email
{
    public class EmailPostmark : IEmailSenderFactory
    {
        private readonly PostmarkConfiguration _postmarkConfiguration;
        private readonly ILogger<PostmarkConfiguration> _logger;

        public EmailPostmark(IOptions<PostmarkConfiguration> postmarkConfiguration, ILogger<PostmarkConfiguration> logger)
        {
            _postmarkConfiguration = postmarkConfiguration.Value;
            _logger = logger;
        }

        public bool IsValid => !string.IsNullOrEmpty(_postmarkConfiguration.ServerToken) &&
                                !string.IsNullOrEmpty(_postmarkConfiguration.SenderEmail);

        public void SendEmail(Message message)
        {
            throw new NotImplementedException();
        }

        public async Task SendEmailAsync(Message message)
        {
            var addressTos = string.Join(",", message.AddressTos);

            var postmarkMessage = new PostmarkMessage()
            {
                To = addressTos,
                From = _postmarkConfiguration.SenderEmail,
                TrackOpens = true,
                Subject = message.Subject,
                HtmlBody = message.Content,
                Headers = new HeaderCollection
                {
                  new MailHeader("X-CUSTOM-HEADER", "Header content"),
                },
            };

            if (message.Attachments != null)
            {
                foreach (var attachment in message.Attachments)
                {
                    using var ms = new MemoryStream();
                    await attachment.CopyToAsync(ms);
                    postmarkMessage.AddAttachment(ms.ToArray(), attachment.FileName, attachment.ContentType);
                }
            }

            var client = new PostmarkClient(_postmarkConfiguration.ServerToken);
            var sendResult = await client.SendMessageAsync(postmarkMessage);

            if (sendResult.Status == PostmarkStatus.Success)
            {
                _logger.LogInformation($"Email sent successfully to {addressTos}.");
            }
            else
            {
                _logger.LogWarning($"Failed to send email to {addressTos}. Error: {sendResult.Message}");
            }
        }
    }
}
