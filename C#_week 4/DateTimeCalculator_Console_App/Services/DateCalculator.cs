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
                OutputEntity op = new OutputEntity(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), ip.Date, ip.TimeParams, ip.Operation,null);
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
                        op.Result = "Error : No/Invalid operation specified.";
                        break;
                }
                list.Add(op);
            }

            return list;
        }
        public string AddToDate(InputEntity ip)
        {   
            string[] paramStr = ip.TimeParams.Split(" ");
            int[] parameters = new int[4];
            for(int i=0; i<4; i++)
            {
                if(int.TryParse(paramStr[i], out parameters[i]))
                {

                }
                else
                {
                    return "Error : Parameters in invalid format.";
                }
            }
            
            DateTime date = ip.Date.AddDays(parameters[0] + parameters[1] * 7)
                                       .AddMonths(parameters[2])
                                       .AddYears(parameters[3]);
            return date.ToString("dd/MM/yyyy");
        }

        public string SubtractFromDate(InputEntity ip)
        {
            string[] paramStr = ip.TimeParams.Split(" ");
            int[] parameters = new int[4];
            for(int i=0; i<4; i++)
            {
                if(int.TryParse(paramStr[i], out parameters[i]))
                {

                }
                else
                {
                    return "Error : Parameters in invalid format.";
                }
            }
             DateTime date = ip.Date.AddDays(-1*parameters[0] - parameters[1] * 7)
                                       .AddMonths(-parameters[2])
                                       .AddYears(-parameters[3]);
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