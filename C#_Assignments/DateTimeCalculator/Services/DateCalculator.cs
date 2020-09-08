using System.Collections.Generic;
using DateTimeCalculator.Models;

namespace DateTimeCalculator.Services
{
    public class DateCalculator : IDateCalculator
    {
        public List<OutputEntity> Calculate(List<InputEntity> inputList)
        {
            List<OutputEntity> list = new List<OutputEntity>();
            foreach(var ip in inputList)
            {
                OutputEntity op = new OutputEntity(ip.Date, ip.Params, ip.Operation, null);
                switch (ip.Operation)
                {
                    case DateOperation.ADD:
                        op.Result = AddToDate(ip);
                        break;
                    case DateOperation.SUBTRACT:
                        op.Result = SubtractFromDate(ip);
                        break;
                    case DateOperation.DAY_OF_WEEK:
                        op.Result = DayOfTheWeek(ip);
                        break;
                    case DateOperation.WEEK_OF_YEAR:
                        op.Result = WeekOfTheYear(ip);
                        break;
                    default:
                        op.Result = "No/Invalid operation specified.";
                        break;
                }
                list.Add(op);
            }

            return list;
        }
        public string AddToDate(InputEntity ip)
        {
            return "Added";
        }


        public string DayOfTheWeek(InputEntity ip)
        {
            return "Day of the week";
        }

        public string SubtractFromDate(InputEntity ip)
        {
            return "Subtracted";
        }

        public string WeekOfTheYear(InputEntity ip)
        {
            return "Week of the year";
        }
    }

}