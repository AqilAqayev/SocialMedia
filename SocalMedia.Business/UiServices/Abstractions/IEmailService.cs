namespace SocalMedia.Business.UiServices.Abstractions;

public interface IEmailService
{
    void SendEmail(string toEmail, string subject, string emailBody);
}
