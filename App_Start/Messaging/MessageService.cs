
using MimeKit;
using System.Threading.Tasks;
using MailKit.Net.Smtp;

namespace UEW_Quality_Assurance.App_Start.Messaging
{
    public class MessageService : IMailService
    {
        public async Task SendEmailAsync(string fromDisplayName, string fromEmailAddress, string toName, string toEmailAddress, string subject, 
            string message, params Attachment[] attachments)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress(fromDisplayName, fromEmailAddress));
            email.To.Add(new MailboxAddress(toName, toEmailAddress));
            email.Subject = subject;

            var body = new BodyBuilder
            {
                HtmlBody = message
            };
            foreach (var attachment in attachments)
            {
                using (var stream = await attachment.ContentToStreamAsync())
                {
                    body.Attachments.Add(attachment.FileName, stream);
                }
            }

            using (var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (sender, Certifcate, CertChainType, errors) => true;
                client.AuthenticationMechanisms.Remove("XOAUTH2");

                await client.ConnectAsync("smtp.host", 587, false).ConfigureAwait(false);
                await client.AuthenticateAsync("username", "password").ConfigureAwait(false);

                await client.SendAsync(email).ConfigureAwait(false); 
            }

        }
    }
}
