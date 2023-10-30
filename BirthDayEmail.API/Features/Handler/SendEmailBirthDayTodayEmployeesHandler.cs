using BillWare.Application.Contracts.Service;
using BirthDayEmail.API.Features.Command;
using BirthDayEmail.API.Helper;
using BirthDayEmail.API.Interfaces;
using BirthDayEmail.API.Models;
using MediatR;

namespace BirthDayEmail.API.Features.Handler
{
    public class SendEmailBirthDayTodayEmployeesHandler : IRequestHandler<SendEmailBirthDayTodayEmployeesCommand>
    {
        private readonly IEmployeeBirthDayRepository _employeeBirthDayRepository;
        private readonly ITaskScheduler _taskScheduler;
        private readonly IEmailService _emailService;

        public SendEmailBirthDayTodayEmployeesHandler(
                       IEmployeeBirthDayRepository employeeBirthDayRepository,
                       ITaskScheduler taskScheduler,
                       IEmailService emailService)
        {
            _employeeBirthDayRepository = employeeBirthDayRepository;
            _taskScheduler = taskScheduler;
            _emailService = emailService;
        }

        public async Task Handle(SendEmailBirthDayTodayEmployeesCommand request, CancellationToken cancellationToken)
        {
            _taskScheduler.ScheduleTask(() => ExecuteTask(), "0 8 * * *"); // cada día a las 7 am
            await Task.CompletedTask;
        }

        public async Task ExecuteTask()
        {
            var employeesBirthdayToday = await _employeeBirthDayRepository.GetBirthdaysToday();

            if (employeesBirthdayToday.Any())
            {
                var email = new Email
                {
                    To = "infobillwaresystem@gmail.com", // aquí va el correo electrónico de la empresa
                    Subject = "Happy Birthdays",
                    IsBodyHtml = true,
                    Body = MailMessageHtmlHelper.BuildHtmlBody(employeesBirthdayToday)
                };

                await _emailService.SendEmailAsync(email);
            }
        }
    }
}