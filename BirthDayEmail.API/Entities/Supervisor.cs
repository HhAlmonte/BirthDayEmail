namespace BirthDayEmail.API.Entities
{
    public class Supervisor
    {
        public int Id { get; set; }

        public int? EmployeeId { get; set; }
        public virtual Employee? Employee { get; set; }
    }
}
