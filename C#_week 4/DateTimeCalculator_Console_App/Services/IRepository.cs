using System.Collections.Generic;
using DateTimeCalculator.Models;

namespace DateTimeCalculator.Services
{
    public interface IRepository
    {
        IEnumerable<OutputEntity> GetRecords();

        void AddRecord(OutputEntity record);
    }
}