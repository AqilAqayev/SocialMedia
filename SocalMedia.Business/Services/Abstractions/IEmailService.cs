namespace SocalMedia.Business.Services.Abstractions;

public interface IEmailService
{
    void SendEmail(string toEmail, string subject, string emailBody);
}
