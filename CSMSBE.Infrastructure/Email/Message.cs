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
        public List<MailboxAddress> DisplaynameAddressTos { get; set; }
        public List<string> AddressTos { get; set; }

        public string Subject { get; set; }

        public string Content { get; set; }

        public IFormFileCollection Attachments { get; set; }

        public Message(IEnumerable<EmailAddress> displayNameAddressTos, string subject, string content, IFormFileCollection attachments)
        {
            DisplaynameAddressTos = new List<MailboxAddress>();

            DisplaynameAddressTos.AddRange(displayNameAddressTos.Select(x => new MailboxAddress(x.DisplayName, x.Address)));
            Subject = subject;
            Content = content;
            Attachments = attachments;
        }

        public Message(List<EmailAddress> addressTos, string subject, string content, IFormFileCollection attachments)
        {
            AddressTos = new List<string>();

            AddressTos.AddRange(addressTos.Select(x => x.Address));
            Subject = subject;
            Content = content;
            Attachments = attachments;
        }
    }
}
