using BirthDayEmail.API.Entities;
using BirthDayEmail.API.Interfaces;
using BirthDayEmail.API.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BirthDayEmail.API.Repositories
{
    public class EmployeeBirthDayRepository : IEmployeeBirthDayRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeBirthDayRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetBirthdaysNextWeek()
        {
            var currentDate = DateTime.Now;
            var nextWeekDate = currentDate.AddDays(7);

            var employeesBirthdayNextWeek = await _context
                .Employees
                .Where(x => x.BirthDay >= currentDate && x.BirthDay < nextWeekDate)
                .ToListAsync();

            return employeesBirthdayNextWeek;
        }

        public async Task<List<Employee>> GetBirthdaysToday()
        {
            var currentDate = DateTime.Now;

            var employeesBirthdayToday = await _context
                .Employees
                .Where(x => x.BirthDay.Day == currentDate.Day && x.BirthDay.Month == currentDate.Month)
                .ToListAsync();

            return employeesBirthdayToday;
        }
    }
}
