using System.Collections.Generic;
using DateTimeCalculator_MVC_Webapp.Models;

namespace DateTimeCalculator_MVC_Webapp.Services
{
    public interface IDateCalculator 
    {
        string Calculate(InputModel ip);

        string AddToDate(InputModel ip);

        string SubtractFromDate(InputModel ip);

        string DayOfTheWeek(InputModel ip);

        string WeekOfTheYear(InputModel ip);
    }
}