using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DateTimeCalculator_MVC_Webapp.Models;
using DateTimeCalculator_MVC_Webapp.Services;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace DateTimeCalculator_MVC_Webapp.Controllers
{
    public class ResultController : Controller
    {
        private readonly Dictionary<string,DateOperation> _filterMap = new Dictionary<string, DateOperation>{
                {"Add" , DateOperation.ADD},
                {"Subtract", DateOperation.SUBTRACT},
                {"Day", DateOperation.DAY_OF_WEEK},
                {"WeekNumber", DateOperation.WEEK_OF_YEAR}
        }; 
        private readonly ILogger<ResultController> _logger;
        private IRepository _calculationsRepository;

        // private ISession _session;

        public ResultController(ILogger<ResultController> logger, IRepository calculationsRepository)
        {
            _logger = logger;
            _calculationsRepository = calculationsRepository;
            // _session = session;

        }

        public IActionResult Index()
        {
            // if(TempData["results"] != null){
            //     ViewBag.results = TempData["results"] as IEnumerable<OutputModel>;
            //     ViewBag.showingResults = true;
            // }
            return View();
        }
        public IActionResult GetResults(string resultType, string filterType)
        {
            IEnumerable<OutputModel> results = GetResultList(resultType, filterType);
            ViewBag.results = results;
            ViewBag.showingResults = true;
            return View("~/Views/Result/Index.cshtml");
            // TempData["results"] = results;
            // return RedirectToAction("Index");
        }


        [HttpPost]
        public FileResult Download(string resultType, string filterType)
        {
            IEnumerable<OutputModel> results = GetResultList(resultType, filterType);
            

            // the Column Names.
            
            //results.Insert(0, new string[] { "Date", "ParamDays", "ParamWeeks", "ParamMonths", "ParamYears", "Operation", "Result" });

            StringBuilder sb = new StringBuilder();
            sb.AppendLine( string.Join(", ", "Timestamp", "Input_Date", "ParamDays", "ParamWeeks", "ParamMonths",
                                       "ParamYears", "Operation", "Result"));
            
            foreach(var result in results)
            {
                sb.AppendLine(string.Join(", ", result.Timestamp, result.Date.ToString("dd/MM/yyyy"), result.ParamDays,
                                          result.ParamWeeks, result.ParamMonths, result.ParamYears,
                                          result.Operation.ToString(), result.Result));
            }
            
            return File(Encoding.UTF8.GetBytes(sb.ToString()), "text/csv", "DateTimeCalculator_"+ resultType + DateTime.Now.ToString("dd/MM/yyyy hh:MM:ss") +".csv");
        }

        private IEnumerable<OutputModel> GetResultList(string resultType, string filterType)
        {
            IEnumerable<OutputModel> results;
            IEnumerable<PersistenceModel> dbResults = _calculationsRepository.GetCalculations();
            if (resultType.Equals("Session"))
            {
                string sessionID = HttpContext.Session.Id;
                _logger.LogInformation("Result SessionID " + sessionID); ;
                dbResults = dbResults.Where(o => o.SessionID.Equals(sessionID));
            }

            if (!filterType.Equals("All"))
            {
                dbResults = dbResults.Where(o => o.Operation == _filterMap[filterType]);
            }

            results = dbResults.Select(p => new OutputModel() { Timestamp=p.Timestamp, Date = p.Date, ParamDays = p.ParamDays, ParamWeeks = p.ParamWeeks, ParamMonths = p.ParamMonths, ParamYears = p.ParamYears, Operation = p.Operation, Result = p.Result });

            return results;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        
    }
}
