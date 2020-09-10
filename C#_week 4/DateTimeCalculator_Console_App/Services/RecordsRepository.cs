using System.Collections.Generic;
using DateTimeCalculator.Data;
using DateTimeCalculator.Models;

namespace DateTimeCalculator.Services
{
    public class RecordsRepository : IRepository
    {
        private RecordsDbContext _recordsDbContext; 

        public RecordsRepository(RecordsDbContext recordsDbContext)
        {
            _recordsDbContext = recordsDbContext;
        }


        public IEnumerable<OutputEntity> GetRecords()
        {
            return _recordsDbContext.Records;
        }
        public void AddRecord(OutputEntity record)
        {
            _recordsDbContext.Records.Add(record);
            _recordsDbContext.SaveChanges(true);
        }

    }
}