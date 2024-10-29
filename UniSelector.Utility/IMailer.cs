using UniSelector.Models;

namespace UniSelector.Utility;

public interface IMailer
{
    Task SendEmailAsync(EmailPayload emailPayload);
}