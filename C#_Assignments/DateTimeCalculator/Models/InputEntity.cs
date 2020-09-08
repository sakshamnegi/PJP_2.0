using System;

namespace DateTimeCalculator.Models
{
    public class InputEntity
    {
        public DateTime Date { get; set; }
        public int[] Params { get; set; }

        public DateOperation Operation { get; set; }

        public InputEntity(DateTime date, int[] param, DateOperation operation)
        {
            this.Date = date;
            this.Params = param;
            this.Operation = operation;
        }

    }
    
}