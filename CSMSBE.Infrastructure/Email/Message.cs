using Microsoft.AspNetCore.Http;
using MimeKit;

namespace CSMSBE.Infrastructure.Email
{

    public class EmailAddress
    {
        public string Address { get; set; }

        public string DisplayName { get; set; }
    }

    public class Message
    {
        public List<MailboxAddress> Tos { get; set; }

        public string Subject { get; set; }

        public string Content { get; set; }

        public IFormFileCollection Attachments { get; set; }

        public Message(IEnumerable<EmailAddress> tos, string subject, string content, IFormFileCollection attachments)
        {
            Tos = new List<MailboxAddress>();

            Tos.AddRange(tos.Select(x => new MailboxAddress(x.DisplayName, x.Address)));
            Subject = subject;
            Content = content;
            Attachments = attachments;
        }
    }
}
