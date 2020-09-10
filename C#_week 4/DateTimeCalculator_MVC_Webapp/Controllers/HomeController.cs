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
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IRepository _calculationsRepository;
        private IDateCalculator _dateCalculator;
        // private ISession _session;

        //DI
        public HomeController(ILogger<HomeController> logger, IRepository calculationsRepository, IDateCalculator dateCalculator )
        {
            _logger = logger;
            _calculationsRepository = calculationsRepository;
            _dateCalculator = dateCalculator;
            // _session = session;
        }
 
        public IActionResult Index()
        {
            if(TempData["result"]!=null)
            {
                ViewBag.result = TempData["result"].ToString();
            }
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Calculate(InputModel model)
        {
            OutputModel output = new OutputModel(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
                                                    model.Date,
                                                    model.ParamDays,
                                                    model.ParamWeeks,
                                                    model.ParamMonths,
                                                    model.ParamYears,
                                                    model.Operation);
            output.Result = _dateCalculator.Calculate(model);
            _calculationsRepository.AddCalculation(output);
            TempData["result"] = output.Result;
            return RedirectToAction("Index");
        }
    }
}
