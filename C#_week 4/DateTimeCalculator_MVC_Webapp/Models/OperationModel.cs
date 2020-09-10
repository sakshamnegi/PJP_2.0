using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DateTimeCalculator_MVC_Webapp.Models
{
    public class OperationModel
    {
        public int Id { get; set; }

        public string Timestamp { get; set; }
        public DateTime Date { get; set; }
        
        public int ParamDays { get; set; }
        public int ParamWeeks { get; set; }
        public int ParamMonths { get; set; }
        public int ParamYears { get; set; }

        [Column(TypeName = "varchar(25)")]
        public DateOperation Operation { get; set; }

        public string Result { get; set; }

        public OperationModel(string timestamp, DateTime date, int paramDays, int paramWeeks, int paramMonths, int paramYears, DateOperation operation, string result)
        {
            this.Timestamp = timestamp;
            this.Date = date;
            this.ParamDays = paramDays;
            this.ParamWeeks = paramWeeks;
            this.ParamMonths = paramMonths;
            this.ParamYears = paramYears;
            this.Operation = operation;
            this.Result = result;
            
        }
    }
}