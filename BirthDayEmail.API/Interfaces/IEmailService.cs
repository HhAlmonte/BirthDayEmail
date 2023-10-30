using BirthDayEmail.API.Models;

namespace BillWare.Application.Contracts.Service
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(Email email);
    }
}
