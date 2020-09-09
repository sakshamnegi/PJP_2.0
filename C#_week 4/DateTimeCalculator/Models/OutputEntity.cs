using System;

namespace DateTimeCalculator.Models
{
    public class OutputEntity
    {
        public DateTime Date { get; set; }
        public int[] Params { get; set; }

        public DateOperation Operation { get; set; }

        public string Result { get; set; }

        public OutputEntity(DateTime date, int[] param, DateOperation operation, string result)
        {
            this.Date = date;
            this.Params = param;
            this.Operation = operation;
            this.Result = result;
            
        }
    }
}