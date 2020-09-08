using System.Collections.Generic;
using DateTimeCalculator.Models;

namespace DateTimeCalculator.Services
{
    public interface IDateCalculator 
    {
        List<OutputEntity> Calculate(List<InputEntity> inputList);

        string AddToDate(InputEntity ip);

        string SubtractFromDate(InputEntity ip);

        string DayOfTheWeek(InputEntity ip);

        string WeekOfTheYear(InputEntity ip);
    }
}