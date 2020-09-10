using System;

namespace DateTimeCalculator_MVC_Webapp.Models
{
    public class InputModel
    {
        public DateTime Date { get; set; }
        public int ParamDays { get; set; }
        public int ParamWeeks { get; set; }
        public int ParamMonths { get; set; }
        public int ParamYears { get; set; }
        public DateOperation Operation { get; set; }


        public InputModel()
        {
            
        }
        public InputModel( DateTime date, int paramDays, int paramWeeks, int paramMonths, int paramYears, DateOperation operation)
        {
            this.Date = date;
            this.ParamDays = paramDays;
            this.ParamWeeks = paramWeeks;
            this.ParamMonths = paramMonths;
            this.ParamYears = paramYears;
            this.Operation = operation;
            
        }
    }
}