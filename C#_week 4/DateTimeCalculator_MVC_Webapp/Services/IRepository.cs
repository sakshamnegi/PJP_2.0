using System.Collections.Generic;
using DateTimeCalculator_MVC_Webapp.Models;

namespace DateTimeCalculator_MVC_Webapp.Services
{
    public interface IRepository
    {
        IEnumerable<OperationModel> GetCalculations();

        void AddCalculation(OperationModel record);
    }
}