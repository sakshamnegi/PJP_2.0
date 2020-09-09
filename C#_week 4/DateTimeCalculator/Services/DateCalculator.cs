using System;
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
            DateTime date = ip.Date.AddDays(ip.Params[0] + ip.Params[1] * 7)
                                       .AddMonths(ip.Params[2])
                                       .AddYears(ip.Params[3]);
            return date.ToString("dd/MM/yyyy");
        }

        public string SubtractFromDate(InputEntity ip)
        {
             DateTime date = ip.Date.AddDays(-1*ip.Params[0] - ip.Params[1] * 7)
                                       .AddMonths(-ip.Params[2])
                                       .AddYears(-ip.Params[3]);
            return date.ToString("dd/MM/yyyy");
        }

        public string DayOfTheWeek(InputEntity ip)
        {
            return ip.Date.DayOfWeek.ToString();
        }


        public string WeekOfTheYear(InputEntity ip)
        {
            DateTime tempDate = new DateTime(ip.Date.Year,1,1);
            for (int i = 0; i < 7; i++) {
                if ((int) tempDate.AddDays(-i).DayOfWeek == 1) {
                    tempDate = tempDate.AddDays(-i);
                    break;
                }
            }
            TimeSpan timeSpan = ip.Date.Subtract(tempDate);
            int daysSince = timeSpan.Days;
            if (daysSince < 0) {
                return "53";
            }
            if (daysSince == 0) {
                return "1";
            }

            double res = Math.Ceiling(daysSince / 7.0);
            return ((int) res).ToString();

            
        }
    }

}