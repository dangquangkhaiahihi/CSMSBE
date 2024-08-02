﻿namespace CSMSBE.Infrastructure.Email
{
    public class SmtpConfiguration
    {
        public string? MailServer { get; set; }

        public int MailPort { get; set; }

        public string? SenderName { get; set; }

        public string? Sender { get; set; }

        public string? Username { get; set; }

        public string? Password { get; set; }
    }
}
