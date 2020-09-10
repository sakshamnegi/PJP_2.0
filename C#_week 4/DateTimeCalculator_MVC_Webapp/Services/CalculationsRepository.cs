using System.Collections.Generic;
using DateTimeCalculator_MVC_Webapp.Data;
using DateTimeCalculator_MVC_Webapp.Models;

namespace DateTimeCalculator_MVC_Webapp.Services
{
    public class CalculationsRepository : IRepository
    {
        private CalculationsDbContext _CalculationsDbContext; 

        public CalculationsRepository(CalculationsDbContext CalculationsDbContext)
        {
            _CalculationsDbContext = CalculationsDbContext;
        }


        public IEnumerable<OperationModel> GetCalculations()
        {
            return _CalculationsDbContext.Calculations;
        }
        public void AddCalculation(OperationModel calculation)
        {
            _CalculationsDbContext.Calculations.Add(calculation);
            _CalculationsDbContext.SaveChanges(true);
        }

    }
}