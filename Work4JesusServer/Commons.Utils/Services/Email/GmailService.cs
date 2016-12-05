using System;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Commons.Utils.Services.Email
{
    public class GmailService : IEmailService
    {
        private readonly EmailConfig _config;

        public GmailService(EmailConfig config)
        {
            _config = config;
        }

        public void Send(EmailParam param)
        {
            var client = new SmtpClient
            {
                Port = 587,
                Host = "smtp.gmail.com",
                EnableSsl = true,
                Timeout = 10000,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_config.Email, _config.Password)
            };

            var mm = new MailMessage(_config.Email, param.ToEmail, param.Subject, param.Message)
            {
                BodyEncoding = Encoding.UTF8,
                DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
            };
            try
            {
                client.Send(mm);
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
            }
            finally
            {
                client.Dispose();
            }
        }
    }
}