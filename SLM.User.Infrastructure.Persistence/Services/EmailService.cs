using SLM.User.Infrastructure.Persistence.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SLM.User.Infrastructure.Persistence.Services
{
    public class EmailService : IEmailService
    {
        public bool SendEmail(EmailViewModel email)
        {
            try
            {
                using (var mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress(email.SenderEmail);
                    mailMessage.To.Add(email.RecieptentEmaails);
                    if (!string.IsNullOrEmpty(email.RecieptentCCemails))
                    {
                        mailMessage.CC.Add(email.RecieptentCCemails);
                    }
                    if (!string.IsNullOrEmpty(email.RecieptentBCCemails))
                    {
                        mailMessage.Bcc.Add(email.RecieptentBCCemails);
                    }
                    mailMessage.Subject = email.EmailSubject;
                    mailMessage.Body = email.EmailBody;

                    // Adding attachments
                    if (email.AttachmentList != null && email.AttachmentList.Count > 0)
                    {
                        foreach (var attachmentPath in email.AttachmentList)
                        {
                            mailMessage.Attachments.Add(new Attachment(attachmentPath));
                        }
                    }

                    using (var smtpClient = new SmtpClient("smtp.gmail.com"))
                    {
                        smtpClient.Port = 587; // Gmail SMTP port
                        smtpClient.Credentials = new NetworkCredential("Devkranth@gmail.com", "AdminPas$$word1");
                        smtpClient.EnableSsl = true;
                        smtpClient.Send(mailMessage);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                return false;
            }
        }

        public bool SendEmail(string fromEmail, string toEmail, string subject, string body)
        {
            try
            {
                var email = new EmailViewModel
                {
                    SenderEmail = fromEmail,
                    RecieptentEmaails = toEmail,
                    EmailSubject = subject,
                    EmailBody = body
                };

                return SendEmail(email);
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                return false;
            }
        }
    }

    public interface IEmailService
    {
        bool SendEmail(EmailViewModel email);

        bool SendEmail(string fromemail,string toemail, string subject, string body);
    }
}
