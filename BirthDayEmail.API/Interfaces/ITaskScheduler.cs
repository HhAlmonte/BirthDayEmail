using System.Linq.Expressions;

namespace BirthDayEmail.API.Interfaces
{
    public interface ITaskScheduler
    {
        void ScheduleTask(Expression<Func<Task>> methodCall, string cronExpression);
    }
}
