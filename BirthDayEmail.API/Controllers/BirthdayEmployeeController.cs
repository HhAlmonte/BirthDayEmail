using BirthDayEmail.API.Features.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BirthDayEmail.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirthdayEmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BirthdayEmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> SendEmailBirthDayTodayEmployees()
        {
            await _mediator.Send(new SendEmailBirthDayTodayEmployeesCommand());
            return Ok();
        }
    }
}
