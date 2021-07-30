using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace UEW_Quality_Assurance.App_Start.Messaging
{
    public interface IMailService
    {
        Task SendEmailAsync(
            string fromDisplayName,
            string fromEmailAddress,
            string toName,
            string toEmailAddress,
            string subject,
            string message,
            params Attachment[] attachments

         );
    }
}
