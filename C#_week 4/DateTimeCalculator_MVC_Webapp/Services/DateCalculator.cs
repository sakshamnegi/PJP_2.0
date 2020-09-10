using System;
using System.Collections.Generic;
using DateTimeCalculator_MVC_Webapp.Models;

namespace DateTimeCalculator_MVC_Webapp.Services
{
    public class DateCalculator : IDateCalculator
    {
        public string Calculate(InputModel input)
        {
            string result = null;
            switch (input.Operation)
            {
                case DateOperation.ADD:
                    result = AddToDate(input);
                    break;
                case DateOperation.SUBTRACT:
                    result = SubtractFromDate(input);
                    break;
                case DateOperation.DAY_OF_WEEK:
                    result = DayOfTheWeek(input);
                    break;
                case DateOperation.WEEK_OF_YEAR:
                    result = WeekOfTheYear(input);
                    break;
                default:
                    result = "Error : No/Invalid operation specified.";
                    break;
            }
            return result;
        }
        
        public string AddToDate(InputModel ip)
        {   
            DateTime date = ip.Date.AddDays(ip.ParamDays + ip.ParamWeeks * 7)
                                       .AddMonths(ip.ParamMonths)
                                       .AddYears(ip.ParamYears);
            return date.ToString("dd/MM/yyyy");
        }

        public string SubtractFromDate(InputModel ip)
        {
            DateTime date = ip.Date.AddDays(-ip.ParamDays - ip.ParamWeeks * 7)
                                       .AddMonths(-ip.ParamMonths)
                                       .AddYears(-ip.ParamYears);
            return date.ToString("dd/MM/yyyy");
        }

        public string DayOfTheWeek(InputModel ip)
        {
            return ip.Date.DayOfWeek.ToString();
        }


        public string WeekOfTheYear(InputModel ip)
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