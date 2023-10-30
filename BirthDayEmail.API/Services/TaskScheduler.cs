using BirthDayEmail.API.Interfaces;
using Hangfire;
using System.Linq.Expressions;

namespace BirthDayEmail.API.Services
{
    public class TaskScheduler : ITaskScheduler
    {
        public void ScheduleTask(Expression<Func<Task>> methodCall, string cronExpression)
        {
            RecurringJob.AddOrUpdate("employeeBirthayId", methodCall, cronExpression);
        }
    }
}
