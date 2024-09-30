using Microsoft.AspNetCore.Identity.UI.Services;

namespace UniSelector.Utility
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // The logic to send email
            return Task.CompletedTask;
        }
    }
}
