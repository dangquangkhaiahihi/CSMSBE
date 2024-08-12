using CSMSBE.Infrastructure.Email;
using CSMSBE.Services.Interfaces;

namespace CSMSBE.Services.Implements
{
    public class EmailService : IEmailService
    {
        private readonly IEmailSenderFactory _emailSenderFactory;

        public EmailService(IEmailSenderFactory emailSenderFactory)
        {
            _emailSenderFactory = emailSenderFactory;
        }
    }
}
