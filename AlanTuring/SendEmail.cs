using System;
using System.Net;
using System.Net.Mail;

namespace AlanTuring
{
    public class SendEmail
    {
        public static void SendRegistrationEmail(string recipient)
        {
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = true,
                Credentials = new NetworkCredential("example@gmail.com", "password")
            };

            MailMessage message = new MailMessage();
            message.To.Add(recipient);
            message.From = new MailAddress("example@gmail.com");
            message.Subject = "Welcome to Alan Turing School";
            message.Body = "This email confirms that your registered in Alan Turing School. We will send you interview invitation email.";
            client.Send(message);
        }
    }
}
