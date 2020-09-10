using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DateTimeCalculator.Models
{
    public class OutputEntity
    {
        public int Id { get; set; }

        public string Timestamp { get; set; }
        public DateTime Date { get; set; }
        public string TimeParams { get; set; }

        [Column(TypeName = "varchar(25)")]
        public DateOperation Operation { get; set; }

        public string Result { get; set; }

        public OutputEntity(string timestamp, DateTime date, string timeParams, DateOperation operation, string result)
        {
            this.Timestamp = timestamp;
            this.Date = date;
            this.TimeParams = timeParams;
            this.Operation = operation;
            this.Result = result;
            
        }
    }
}