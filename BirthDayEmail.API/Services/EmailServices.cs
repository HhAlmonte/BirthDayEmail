using BillWare.Application.Contracts.Service;
using BirthDayEmail.API.Models;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace BillWare.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task<bool> SendEmailAsync(Email email)
        {
            try
            {
                using (var smtpClient = new SmtpClient(_emailSettings.SmtpServer))
                {
                    smtpClient.Port = _emailSettings.SmtpPort;
                    smtpClient.Credentials = new NetworkCredential(_emailSettings.SmtpUserName, _emailSettings.SmtpPassword);
                    smtpClient.EnableSsl = true;

                    var message = new MailMessage
                    {
                        From = new MailAddress(_emailSettings.SmtpUserName),
                        Subject = email.Subject,
                        Body = email.Body,
                        IsBodyHtml = email.IsBodyHtml,
                    };

                    message.To.Add(email.To);

                    await smtpClient.SendMailAsync(message);

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al enviar el correo electrónico: {ex.Message}");
            }
        }
    }
}
