using BirthDayEmail.API.Entities;

namespace BirthDayEmail.API.Interfaces
{
    public interface IEmployeeBirthDayRepository
    {
        Task<List<Employee>> GetBirthdaysToday();
        Task<List<Employee>> GetBirthdaysNextWeek();
    }
}
