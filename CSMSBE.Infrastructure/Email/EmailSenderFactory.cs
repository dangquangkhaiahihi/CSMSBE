using Microsoft.Extensions.Configuration;
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
        private readonly ILogger<SmtpConfiguration> _smtpLogger;
        private readonly ILogger<PostmarkConfiguration> _postmarkLogger;
        public EmailSenderFactory(
            IConfiguration configuration,
            IOptions<SmtpConfiguration> smtpConfiguration,
            IOptions<PostmarkConfiguration> postmarkConfiguration,
            ILogger<SmtpConfiguration> smtpLogger,
            ILogger<PostmarkConfiguration> postmarkLogger)
        {
            _senderInstance = null;
            _smtpLogger = smtpLogger;
            _postmarkLogger = postmarkLogger;

            var doUseSmtp = bool.Parse(configuration["UseSmtp"]);

            if (doUseSmtp)
            {
                var smtp = new EmailSmtp(smtpConfiguration, _smtpLogger);

                if (smtp.IsValid)
                {
                    _senderInstance = smtp;
                }
                else
                {
                    _smtpLogger.LogError("SMTP email provider selected but no valid SMTP settings configured.");
                }
            }
            else
            {
                var postmark = new EmailPostmark(postmarkConfiguration, _postmarkLogger);

                if (postmark.IsValid)
                {
                    _senderInstance = postmark;
                }
                else
                {
                    _postmarkLogger.LogError("Postmark email provider selected but no valid server token settings configured.");
                }
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
