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
        public IActionResult GetResults(string ResultType, string FilterType)
        {
            List<OutputModel> results;

            // if(ResultType.Equals("Session"))
            // {
            //     results=  _session.Get("calculations") as List<OutputModel>;

            // }

            
            if(FilterType.Equals("All"))
            {
                results = _calculationsRepository.GetCalculations().ToList();
            }
            else
            {
                results = _calculationsRepository.GetCalculations().Where(o => o.Operation == _filterMap[FilterType]).ToList();
            }
            ViewBag.results = results;
            ViewBag.showingResults = true;
            return View("~/Views/Result/Index.cshtml");
            // TempData["results"] = results;
            // return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
