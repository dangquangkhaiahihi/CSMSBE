using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CSMSBE.Infrastructure.Email
{
    public interface IEmailSenderFactory
    {
        void SendEmail(Message message);

        Task SendEmailAsync(Message message);
    }

    public class EmailSenderFactory : IEmailSenderFactory
    {
        private readonly IEmailSenderFactory _senderInstance;
        private readonly ILogger<EmailConfiguration> _logger;

        public EmailSenderFactory(IOptions<EmailConfiguration> smtpConfiguration, ILogger<EmailConfiguration> logger)
        {
            _senderInstance = null;
            _logger = logger;

            var smtp = new EmailSmtp(smtpConfiguration, logger);

            if (smtp.IsValid)
            {
                _senderInstance = smtp;
            }
            // TODO: Add flag to switch to 3rd-party email service provider e.g., SendGrid, Postmark, etc. here
            else
            {
                _logger.LogError("SMTP email provider selected but no valid SMTP settings configured.");
            }
        }

        public void SendEmail(Message message)
        {
            _senderInstance?.SendEmail(message);
        }

        public async Task SendEmailAsync(Message message)
        {
            if (_senderInstance != null)
            {
                await _senderInstance.SendEmailAsync(message);
            }
        }
    }
}
