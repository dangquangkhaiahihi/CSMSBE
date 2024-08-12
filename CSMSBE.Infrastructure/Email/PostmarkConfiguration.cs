namespace CSMSBE.Infrastructure.Email
{
    public class PostmarkConfiguration
    {
        public string? ServerToken { get; set; }

        public string? SenderSignature { get; set; }

        public string? SenderEmail { get; set; }
    }
}
