using BirthDayEmail.API.Entities;
using System.Text;

namespace BirthDayEmail.API.Helper
{
    public class MailMessageHtmlHelper
    {
        public static string BuildHtmlBody(List<Employee> employees)
        {
            var html = new StringBuilder();

            html.Append("<h1>Birthdays next week</h1>");

            html.Append("<table style='border: 1px solid black; border-collapse: collapse;'>");
            html.Append("<thead>");
            html.Append("<tr>");
            html.Append("<th style='border: 1px solid black; padding: 5px;'>Name</th>");
            html.Append("<th style='border: 1px solid black; padding: 5px;'>BirthDay</th>");
            html.Append("</tr>");
            html.Append("</thead>");
            html.Append("<tbody>");

            foreach (var employee in employees)
            {
                html.Append("<tr>");
                html.Append($"<td style='border: 1px solid black; padding: 5px;'>{employee.Name}</td>");
                html.Append($"<td style='border: 1px solid black; padding: 5px;'>{employee.BirthDay.ToShortDateString()}</td>");
                html.Append("</tr>");
            }

            html.Append("</tbody>");
            html.Append("</table>");

            return html.ToString();
        }
    }
}
