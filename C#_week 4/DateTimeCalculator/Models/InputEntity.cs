using System;

namespace DateTimeCalculator.Models
{
    public class InputEntity
    {
        public DateTime Date { get; set; }
        public string TimeParams { get; set; }

        public DateOperation Operation { get; set; }

        public InputEntity(DateTime date, string timeParams, DateOperation operation)
        {
            this.Date = date;
            this.TimeParams = timeParams;
            this.Operation = operation;
        }

    }
    
}