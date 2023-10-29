using System.ComponentModel.DataAnnotations;

namespace BirthDayEmail.API.Entities
{
    public class Department
    {
        public int Id { get; set; }
        [MaxLength(80)] public string Name { get; set; } = string.Empty;
        [MaxLength(100)] public string Description { get; set; } = string.Empty;
        public int SupervisorId { get; set; }
        public Supervisor? Supervisor { get; set; }
    }
}
