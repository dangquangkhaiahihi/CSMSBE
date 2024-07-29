using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;

namespace CSMSBE.Infrastructure.Email
{
    public class EmailSmtp : IEmailSenderFactory
    {
        private readonly EmailConfiguration _smtpConfiguration;
        private readonly ILogger<EmailConfiguration> _logger;

        public EmailSmtp(IOptions<EmailConfiguration> smtpConfiguration, ILogger<EmailConfiguration> logger)
        {
            _smtpConfiguration = smtpConfiguration.Value;
            _logger = logger;
        }

        public bool IsValid => !string.IsNullOrEmpty(_smtpConfiguration.MailServer);

        public void SendEmail(Message message)
        {
            var mail = CreateEmailMessage(message);

            Send(mail);
        }

        public async Task SendEmailAsync(Message message)
        {
            var mail = CreateEmailMessage(message);

            await SendAsync(mail);
        }

        private MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_smtpConfiguration.SenderName, _smtpConfiguration.Sender));
            emailMessage.To.AddRange(message.Tos);
            emailMessage.Subject = message.Subject;

            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = string.Format("<h2 style='color:red;'>{0}</h2>", message.Content),
            };

            if (message.Attachments != null)
            {
                byte[] fileBytes;
                foreach (var attachment in message.Attachments)
                {
                    using var ms = new MemoryStream();
                    attachment.CopyTo(ms);
                    fileBytes = ms.ToArray();

                    bodyBuilder.Attachments.Add(attachment.FileName, fileBytes, ContentType.Parse(attachment.ContentType));
                }
            }

            emailMessage.Body = bodyBuilder.ToMessageBody();
            return emailMessage;
        }

        private void Send(MimeMessage message)
        {
            using var client = new SmtpClient();

            try
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                client.Connect(_smtpConfiguration.MailServer, _smtpConfiguration.MailPort, SecureSocketOptions.None);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Send(message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"SMTP send error: {ex}");
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
        }

        private async Task SendAsync(MimeMessage message)
        {
            using var client = new SmtpClient();

            try
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                await client.ConnectAsync(_smtpConfiguration.MailServer, _smtpConfiguration.MailPort, SecureSocketOptions.None);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                await client.SendAsync(message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"SMTP send error: {ex}");
            }
            finally
            {
                await client.DisconnectAsync(true);
                client.Dispose();
            }
        }
    }
}
