using System.ComponentModel.DataAnnotations;

namespace BirthDayEmail.API.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        [MaxLength(80)] public string Name { get; set; } = string.Empty;
        [MaxLength(100)] public string LastName { get; set; } = string.Empty;
        public int IdDepartment { get; set; }
        public virtual Department? Department { get; set; }
        public DateTime BirthDay { get; set; }

        public string Email { get; set; } = string.Empty;
    }
}
