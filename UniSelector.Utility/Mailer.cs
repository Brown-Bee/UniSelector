using System.Net;
using System.Net.Mail;
using UniSelector.Models;

namespace UniSelector.Utility;

public class Mailer : IMailer
{
    public Task SendEmailAsync(EmailPayload emailData) {
        
        var client = new SmtpClient("smtp.gmail.com.", 587) {   
            EnableSsl = true,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential("Yemeniq0@gmail.com", "wvws gsyv owmi peow")
        };
 
        var message = new MailMessage(
            from: "Yemeniq0@gmail.com",
            to: emailData.Email,
            subject: emailData.Subject,
            body: emailData.Message
        )
        {
            IsBodyHtml = true  // Set this to true to send HTML emails
        };

        return client.SendMailAsync(message);
    }
}